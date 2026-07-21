using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp
{
    internal interface IUniFiSessionRestClient
    {
        Task Logout();
    }

    internal class DefaultUniFiRestClient : RestClient, IUniFiRestClient, IUniFiSessionRestClient
    {
        private const string CSRF_HEADER = "X-CSRF-Token";
        private readonly string _username, _password, _code;
        private string _csrf_token;
        private readonly Uri _baseUrl;
        private readonly bool _useModernApi;

        internal DefaultUniFiRestClient(Uri baseUrl, string username, string password, string code,
            bool ignoreSslValidation, bool useModernApi) :
            this(baseUrl, username, password, ignoreSslValidation, useModernApi)
        {
            _code = code;
        }

#nullable enable
        internal DefaultUniFiRestClient(Uri baseUrl, string username, string password, bool ignoreSslValidation,
            bool useModernApi, Encoding? encoding = null, int timeout = 5000) : base(new RestClientOptions()
            {
                BaseUrl = baseUrl,
                RemoteCertificateValidationCallback = ignoreSslValidation ? (sender, certificate, chain, sslPolicyErrors) => true : default(System.Net.Security.RemoteCertificateValidationCallback?),
                CookieContainer = new System.Net.CookieContainer(),
                // Bodge to work around the fact uploads don't return the normal metadata if unauthorized (migrated to RestClientOptions)
                FollowRedirects = true,
                Encoding = encoding ?? Encoding.UTF8,
                Timeout = TimeSpan.FromMilliseconds(timeout),
                ThrowOnAnyError = true
            }, configureSerialization: serializerConfig => serializerConfig.UseNewtonsoftJson())
        {
            _username = username;
            _password = password;
            _useModernApi = useModernApi;
            _baseUrl = baseUrl;

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

                await ApplyRequestHeaders(request);

                var response = await this.ExecuteAsync<JsonLoginResult>(request);
                CaptureCsrfToken(response);
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
            if (_useModernApi && !request.Resource.StartsWith("proxy/network"))
                request.Resource = "proxy/network/" + request.Resource;

            await ApplyRequestHeaders(request);

            try
            {
                var response = await this.ExecuteAsync<JsonMessageEnvelope<T>>(request);
                var envelope = response.Data;

                CaptureCsrfToken(response);

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
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unauthorized") && attemptReauthentication)
                {
                    await Authenticate();
                    return await ExecuteRequest<T>(request, false);
                }
                throw;
            }
        }

        public async Task Logout()
        {
            if (!_useModernApi)
            {
                await UniFiPost("api/logout", new { });
                return;
            }

            // UniFi OS authentication endpoints live at the console root, not below
            // /proxy/network like Network application endpoints.
            var request = new RestRequest("api/auth/logout", Method.Post);
            await ApplyRequestHeaders(request);
            await this.ExecuteAsync(request);
        }

        /// <summary>
        /// Captures a CSRF token when a controller provides one. Older UniFi OS releases use
        /// cookie-only sessions and do not return this header, so its absence is intentionally
        /// accepted and must not make authentication or subsequent requests fail.
        /// </summary>
        private void CaptureCsrfToken(RestResponse response)
        {
            var csrfHeader = response.Headers?
                .FirstOrDefault(x => string.Equals(x.Name, CSRF_HEADER, StringComparison.OrdinalIgnoreCase));
            var csrfToken = csrfHeader?.Value?.ToString();
            if (!string.IsNullOrWhiteSpace(csrfToken))
                _csrf_token = csrfToken;
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
        /// <returns></returns>
        private async Task UnifiMultipartFormRequest(string url, string name, string fileName, string contentType,
            byte[] data)
        {
            // Note the UniFi controller will return 404 when uploading a file - however the file *is* successfully uploaded. 

            var request = new RestRequest(url, Method.Post)
            {
                AlwaysMultipartFormData = true
            };

            await ApplyRequestHeaders(request);

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
                    await UnifiMultipartFormRequest(url, name, fileName, contentType, data);
                }
            }
        }

        private async Task ApplyRequestHeaders(RestRequest request)
        {
            request.AddHeader("Referrer", _baseUrl.ToString());

            // Some intermediate UniFi OS versions supplied the token as a cookie rather than
            // (or in addition to) the login response header.
            var cookies = Options.CookieContainer.GetCookies(_baseUrl);
            var cookieToken = cookies["csrf_token"]?.Value;
            if (!string.IsNullOrWhiteSpace(cookieToken))
                _csrf_token = cookieToken;

            if (string.IsNullOrWhiteSpace(_csrf_token))
            {
                // A few releases expose the token only on the console root after login. This
                // probe is best-effort: a controller that returns no token continues with its
                // authenticated cookies, preserving legacy-modern behavior.
                var baseUrl = new RestRequest("/", Method.Get);
                var baseUrlResponse = await this.ExecuteAsync(baseUrl);
                CaptureCsrfToken(baseUrlResponse);
            }

            if (!string.IsNullOrWhiteSpace(_csrf_token))
                request.AddHeader(CSRF_HEADER, _csrf_token);
        }
    }
}
