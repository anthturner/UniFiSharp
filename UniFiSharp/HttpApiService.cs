using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UniFiSharp.Protocol;

namespace UniFiSharp
{
    /// <summary>
    /// HTTP Request Wrapper for UniFiApi
    /// </summary>
    public abstract class HttpApiService
    {
        public static bool DEBUG_JSON_TO_STDOUT = false;

        public Uri BaseUri { get; private set; }
        public TimeSpan Timeout { get; set; } = new TimeSpan(0, 1, 0);
        public bool SslCertificateValidation { get; private set; } = true;

        private CookieContainer _cookieContainer = new CookieContainer();

        public abstract Task Authenticate();

        protected HttpApiService(Uri baseUri, bool sslCertificateValidation = true)
        {
            BaseUri = baseUri;
            SslCertificateValidation = sslCertificateValidation;
        }

        protected async Task<List<T>> Get<T>(string relativeUri) where T : IMessageBase
        {
            return await ExecuteRequest<T>((client) => client.GetAsync(relativeUri));
        }

        protected async Task<List<T>> Delete<T>(string relativeUri) where T : IMessageBase
        {
            return await ExecuteRequest<T>((client) => client.DeleteAsync(relativeUri));
        }

        protected async Task<List<T>> Post<T>(string relativeUri, object data) where T : IMessageBase
        {
            var postData = new ByteArrayContent(Encoding.UTF8.GetBytes(JObject.FromObject(data).ToString()));
            postData.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            postData.Headers.ContentType.CharSet = "UTF-8";

            return await ExecuteRequest<T>((client) => client.PostAsync(relativeUri, postData));
        }

        private async Task<List<T>> ExecuteRequest<T>(Func<HttpClient, Task<HttpResponseMessage>> requestFunction) where T : IMessageBase
        {
            var resultJson = await ExecuteRequest(requestFunction);
            if (resultJson == null || string.IsNullOrEmpty(resultJson))
                return new List<T>();

            try
            {
                var result = JsonConvert.DeserializeObject<MessageEnvelope<T>>(resultJson);
                return result.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialization exception:\n{ex.ToString()}");
                throw ex;
            }
        }

        private async Task<string> ExecuteRequest(Func<HttpClient, Task<HttpResponseMessage>> requestFunction, bool attemptReauthentication = true)
        {
            var sslCallback = (SslCertificateValidation ? new HttpClientHandler().ServerCertificateCustomValidationCallback : (message, cert, chain, errors) => { return true; });

            using (var handler = new HttpClientHandler() { CookieContainer = _cookieContainer, ServerCertificateCustomValidationCallback = sslCallback })
            using (var client = new HttpClient(handler) { BaseAddress = BaseUri, Timeout = Timeout })
            {
                try
                {
                    client.DefaultRequestHeaders.Referrer = client.BaseAddress;
                    try { client.DefaultRequestHeaders.Add("X-Csrf-Token", _cookieContainer.GetCookies(client.BaseAddress)["csrf_token"].Value); }
                    catch { }
                    var result = await requestFunction(client);
                    var json = await result.Content.ReadAsStringAsync();

                    if (DEBUG_JSON_TO_STDOUT)
                    {
                        Console.WriteLine(new string('#', 30));
                        Console.WriteLine($"REQUEST:\n{result.RequestMessage.ToString()}");
                        Console.WriteLine(new string('.', 30));
                        Console.WriteLine($"RESPONSE:\n{JsonConvert.SerializeObject((dynamic)JsonConvert.DeserializeObject(json), Formatting.Indented)}");
                        Console.WriteLine(new string('#', 30));
                    }

                    // Deserialize to a message envelope to extract the status message on failure
                    var messageEnvelope = JsonConvert.DeserializeObject<MessageEnvelope>(await result.Content.ReadAsStringAsync());

                    // Short-circuit auth errors and do a single retry
                    if (!messageEnvelope.IsSuccessfulResponse)
                    {
                        if (messageEnvelope.Metadata.Message.Trim() == "api.err.LoginRequired" && attemptReauthentication)
                        {
                            await Authenticate();
                            return await ExecuteRequest(requestFunction, false);
                        }
                        else
                            throw new Exception(messageEnvelope.Metadata.Message);
                    }

                    return json;
                }
                catch (Exception ex)
                {
                    throw new Exception("UniFi API Request Error", ex);
                }
            }
        }
    }
}