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
    public class HttpClientConnectivityProvider : IConnectivityProvider
    {
        public override event EventHandler AuthenticationRequired;
        private CookieContainer _cookieContainer = new CookieContainer();
        private bool _hasSaneHttpClientValidationCallback = false;

        public HttpClientConnectivityProvider(Uri baseUri, bool sslCertificateValidation = true) : base(baseUri, sslCertificateValidation)
        {
            // TODO: Verify in xplat compile that this check isn't optimized out
            try
            {
                _hasSaneHttpClientValidationCallback = new HttpClientHandler().ServerCertificateCustomValidationCallback != null;
            }
            catch { }
        }

        public override async Task<List<TResponse>> Get<TResponse>(string relativeUri)
        {
            return await ExecuteRequest<TResponse>((client) => client.GetAsync(relativeUri));
        }
        public override async Task Delete(string relativeUri)
        {
            await ExecuteRequest<BlankMessage>((client) => client.DeleteAsync(relativeUri));
        }
        public override async Task<List<TResponse>> Post<TRequest, TResponse>(string relativeUri, TRequest data)
        {
            return await ExecuteRequest<TResponse>((client) => client.PostAsync(relativeUri, CreateHttpContentFrom(data)));
        }
        public override async Task Put<TRequest>(string relativeUri, TRequest data)
        {
            await ExecuteRequest<BlankMessage>((client) => client.PutAsync(relativeUri, CreateHttpContentFrom(data)));
        }

        private static HttpContent CreateHttpContentFrom<TRequest>(TRequest data)
        {
            var postData = new ByteArrayContent(Encoding.UTF8.GetBytes(JObject.FromObject(data).ToString()));
            postData.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "UTF-8" };
            return postData;
        }

        private async Task<List<TResponse>> ExecuteRequest<TResponse>(Func<HttpClient, Task<HttpResponseMessage>> requestFunction, bool attemptReauthentication = true) where TResponse : IMessageBase
        {
            using (var handler = new HttpClientHandler() { CookieContainer = _cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = BaseUri, Timeout = Timeout })
            {
                if (_hasSaneHttpClientValidationCallback)
                {
                    var sslCallback = (SslCertificateValidation ? new HttpClientHandler().ServerCertificateCustomValidationCallback : (message, cert, chain, errors) => { return true; });
                    handler.ServerCertificateCustomValidationCallback = sslCallback;
                }

                try
                {
                    client.DefaultRequestHeaders.Referrer = client.BaseAddress;
                    try { client.DefaultRequestHeaders.Add("X-Csrf-Token", _cookieContainer.GetCookies(client.BaseAddress)["csrf_token"].Value); }
                    catch { }
                    var result = await requestFunction(client);
                    var json = await result.Content.ReadAsStringAsync();

                    List<TResponse> response = new List<TResponse>();
                    try
                    {
                        response = base.DeserializeResponseMessage<TResponse>(json);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        if (attemptReauthentication)
                        {
                            AuthenticationRequired?.Invoke(this, new EventArgs());
                            return await ExecuteRequest<TResponse>(requestFunction, false);
                        }
                    }

                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception("UniFi API Request Error", ex);
                }
            }
        }
    }
}
