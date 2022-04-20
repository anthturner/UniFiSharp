using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GcmSharp.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using UniFiSharp.Json;

namespace UniFiSharp
{
    internal class DefaultUniFiRestClient : RestClient, IUniFiRestClient
    {
        private string _username, _password, _code, _csrf_token;
        private Uri _baseUrl;
        private bool _useModernApi;

        internal DefaultUniFiRestClient(Uri baseUrl, string username, string password, string code,
            bool ignoreSslValidation, bool useModernApi) :
            this(baseUrl, username, password, ignoreSslValidation, useModernApi)
        {
            _code = code;
        }

        #nullable enable
        internal DefaultUniFiRestClient(Uri baseUrl, string username, string password, bool ignoreSslValidation,
            bool useModernApi, Encoding? encoding = null, int timeout = 1000) : base(new RestClientOptions()
            {                
                BaseUrl = baseUrl,                
                RemoteCertificateValidationCallback = ignoreSslValidation ? (sender, certificate, chain, sslPolicyErrors) => true : default(System.Net.Security.RemoteCertificateValidationCallback?),                
                CookieContainer = new System.Net.CookieContainer(),
                // Bodge to work around the fact uploads don't return the normal metadata if unauthorized (migrated to RestClientOptions)
                FollowRedirects = true,
                Encoding = encoding != null ? encoding : Encoding.UTF8,
                Timeout = timeout,
                ThrowOnAnyError = true
            })
        {
            _username = username;
            _password = password;
            _useModernApi = useModernApi;
            _baseUrl = baseUrl;

            this.UseNewtonsoftJson();
        }
        #nullable disable

        public async Task UniFiGet(string url)
        {
            await UniFiRequest(Method.Get, url);
        }

        public async Task<T> UniFiGet<T>(string url) where T : new()
        {
            return await UniFiRequest<T>(Method.Get, url);
        }

        public async Task<IList<T>> UniFiGetMany<T>(string url) where T : new()
        {
            return await UniFiRequestMany<T>(Method.Get, url);
        }

        public async Task UniFiPost(string url, object jsonBody)
        {
            await UniFiRequest(Method.Post, url, jsonBody);
        }

        public async Task<T> UniFiPost<T>(string url, object jsonBody) where T : new()
        {
            return await UniFiRequest<T>(Method.Post, url, jsonBody);
        }

        public async Task<IList<T>> UniFiPostMany<T>(string url, object jsonBody) where T : new()
        {
            return await UniFiRequestMany<T>(Method.Post, url, jsonBody);
        }

        public async Task UniFiPut(string url, object jsonBody)
        {
            await UniFiRequest(Method.Put, url, jsonBody);
        }

        public async Task<T> UniFiPut<T>(string url, object jsonBody) where T : new()
        {
            return await UniFiRequest<T>(Method.Put, url, jsonBody);
        }

        public async Task<IList<T>> UniFiPutMany<T>(string url, object jsonBody) where T : new()
        {
            return await UniFiRequestMany<T>(Method.Put, url, jsonBody);
        }

        public async Task UniFiDelete(string url)
        {
            await UniFiRequest(Method.Delete, url);
        }

        public async Task UnifiFileUpload(string url, string name, string fileName, string contentType, byte[] data)
        {
            await UnifiMultipartFormRequest(url, name, fileName, contentType, data);
        }

        private async Task UniFiRequest(Method method, string url, object jsonBody = null)
        {
            var request = new RestRequest(url, method);
            if ((method == Method.Post || method == Method.Put) && jsonBody != null)
                request.AddJsonBody(jsonBody);
            await ExecuteRequest<object>(request);
        }

        private async Task<T> UniFiRequest<T>(Method method, string url, object jsonBody = null) where T : new()
        {
            var request = new RestRequest(url, method);
            if ((method == Method.Post || method == Method.Put) && jsonBody != null)
                request.AddJsonBody(jsonBody);

            var envelope = await ExecuteRequest<T>(request);
            if (envelope.Data != null && envelope.Data.Length > 0)
            {
                return envelope.Data[0];
            }

            if (envelope.Metadata.ResultCode.Equals("error", StringComparison.OrdinalIgnoreCase))
            {
                throw new UniFiApiException($"UniFi API returned an error: {envelope.Metadata.Message}");
            }

            return default;
        }

        private async Task<IList<T>> UniFiRequestMany<T>(Method method, string url, object jsonBody = null)
            where T : new()
        {
            var request = new RestRequest(url, method);
            if ((method == Method.Post || method == Method.Put) && jsonBody != null)
                request.AddJsonBody(jsonBody);
            var envelope = await ExecuteRequest<T>(request);
            return (envelope.Data == null) ? new List<T>() : new List<T>(envelope.Data);
        }

        public async Task<JsonLoginResult> Authenticate()
        {
            if (_useModernApi)
            {
                var request = new RestRequest("api/auth/login", Method.Post);
                request.AddJsonBody(new
                {
                    username = _username,
                    password = _password,
                    token = _code,
                    rememberMe = false
                });

                var response = await this.ExecuteAsync<JsonLoginResult>(request);
                _csrf_token = response.Headers.Where(x => x.Name == "X-CSRF-Token").FirstOrDefault().Value.ToString();
                return response.Data;
            }
            else
            {
                await UniFiPost("api/login", new
                {
                    username = _username,
                    password = _password,
                    remember = false,
                    strict = true
                });
                return new JsonLoginResult();
            }
        }

        private async Task<JsonMessageEnvelope<T>> ExecuteRequest<T>(RestRequest request,
            bool attemptReauthentication = true) where T : new()
        {
            if (_useModernApi)
                request.Resource = "proxy/network/" + request.Resource;

            request.AddHeader("Referrer", _baseUrl.ToString());

            if (CookieContainer.GetCookies(_baseUrl).Count > 0)
            {
                var csrf_token = CookieContainer.GetCookies(_baseUrl)["csrf_token"]?.Value;

                if (csrf_token != null)
                {
                    request.AddHeader("X-Csrf-Token", csrf_token);
                }

                if (_useModernApi)
                {
                    if(_csrf_token != null)
                    {
                        request.AddHeader("X-CSRF-Token", _csrf_token);
                    }
                }
            }
            

            var response = await this.ExecuteAsync<JsonMessageEnvelope<T>>(request);
            var envelope = response.Data;

            if (envelope == null && !response.IsSuccessful)
                throw response.ErrorException;

            if (!envelope.IsSuccessfulResponse &&
                envelope.Metadata.Message == "api.err.LoginRequired" &&
                attemptReauthentication)
            {
                await Authenticate();
                return await ExecuteRequest<T>(request, false);
            }

            return response.Data;
        }

        /// <summary>
        ///     Upload a file to the UniFi controller. The only known use of this at the moment is for uploading .ogg files for the
        ///     AP-AC-EDU APs
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="data"></param>
        /// <param name="attemptReauthentication"></param>
        /// <returns></returns>
        private async Task UnifiMultipartFormRequest(string url, string name, string fileName, string contentType,
            byte[] data, bool attemptReauthentication = true)
        {
            // Note the UniFi controller will return 404 when uploading a file - however the file *is* successfully uploaded. 

            var request = new RestRequest(url, Method.Post)
            {
                AlwaysMultipartFormData = true
            };

            request.AddHeader("Referrer", _baseUrl.ToString());

            if (CookieContainer.GetCookies(_baseUrl).Count > 0)
            {
                var csrf_token = CookieContainer.GetCookies(_baseUrl)["csrf_token"]?.Value;

                if (csrf_token != null)
                {
                    request.AddHeader("X-Csrf-Token", csrf_token);
                }
            }

            request.AddParameter("name", name, ParameterType.RequestBody);
            request.AddFile(name, fileName, contentType);
            
            var response = await ExecuteAsync(request);

            // Bodge to authenticate if needed (if we're being redirected back to the login page, then we need to attempt to authenticate)
            if (response.StatusCode == HttpStatusCode.Redirect)
            {
                var redirectLocation = response.Headers.ToList().Find(x => x.Name == "Location").Value.ToString();

                if (redirectLocation.Contains("/manage/account/login?redirect"))
                {
                    await Authenticate();
                    await UnifiMultipartFormRequest(url, name, fileName, contentType, data, false);
                }
            }
        }
    }
}