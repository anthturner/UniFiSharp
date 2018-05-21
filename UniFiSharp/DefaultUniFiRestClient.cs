using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GcmSharp.Serialization;
using RestSharp;
using UniFiSharp.Json;

namespace UniFiSharp
{
    internal class DefaultUniFiRestClient : RestClient, IUniFiRestClient
    {
        private string _username, _password;

        internal DefaultUniFiRestClient(Uri baseUrl, string username, string password, bool ignoreSslValidation) : base(baseUrl)
        {
            _username = username;
            _password = password;

            CookieContainer = new System.Net.CookieContainer();

            AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            AddHandler("text/json", NewtonsoftJsonSerializer.Default);
            AddHandler("text/x-json", NewtonsoftJsonSerializer.Default);
            AddHandler("text/javascript", NewtonsoftJsonSerializer.Default);
            AddHandler("*+json", NewtonsoftJsonSerializer.Default);

            if (ignoreSslValidation)
            {
                this.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            }
        }

        public async Task UniFiGet(string url)
        {
            await UniFiRequest(Method.GET, url);
        }

        public async Task<T> UniFiGet<T>(string url) where T : new()
        {
            return await UniFiRequest<T>(Method.GET, url);
        }

        public async Task<IList<T>> UniFiGetMany<T>(string url) where T : new()
        {
            return await UniFiRequestMany<T>(Method.GET, url);
        }

        public async Task UniFiPost(string url, object jsonBody)
        {
            await UniFiRequest(Method.POST, url, jsonBody);
        }

        public async Task<T> UniFiPost<T>(string url, object jsonBody) where T : new()
        {
            return await UniFiRequest<T>(Method.POST, url, jsonBody);
        }

        public async Task<IList<T>> UniFiPostMany<T>(string url, object jsonBody) where T : new()
        {
            return await UniFiRequestMany<T>(Method.POST, url, jsonBody);
        }

        public async Task UniFiPut(string url, object jsonBody)
        {
            await UniFiRequest(Method.PUT, url, jsonBody);
        }

        public async Task<T> UniFiPut<T>(string url, object jsonBody) where T : new()
        {
            return await UniFiRequest<T>(Method.PUT, url, jsonBody);
        }

        public async Task<IList<T>> UniFiPutMany<T>(string url, object jsonBody) where T : new()
        {
            return await UniFiRequestMany<T>(Method.PUT, url, jsonBody);
        }

        public async Task UniFiDelete(string url)
        {
            await UniFiRequest(Method.DELETE, url);
        }

        private async Task UniFiRequest(Method method, string url, object jsonBody = null)
        {
            var request = new RestRequest(url, method);
            if ((method == Method.POST || method == Method.PUT) && jsonBody != null)
                request.AddJsonBody(jsonBody);
            await ExecuteRequest<object>(request);
        }

        private async Task<T> UniFiRequest<T>(Method method, string url, object jsonBody = null) where T : new()
        {
            var request = new RestRequest(url, method);
            if ((method == Method.POST || method == Method.PUT) && jsonBody != null)
                request.AddJsonBody(jsonBody);
            var envelope = await ExecuteRequest<T>(request);
            return (envelope.Data == null) ? default(T) : envelope.Data[0];
        }

        private async Task<IList<T>> UniFiRequestMany<T>(Method method, string url, object jsonBody = null) where T : new()
        {
            var request = new RestRequest(url, method);
            if ((method == Method.POST || method == Method.PUT) && jsonBody != null)
                request.AddJsonBody(jsonBody);
            var envelope = await ExecuteRequest<T>(request);
            return (envelope.Data == null) ? new List<T>() : new List<T>(envelope.Data);
        }

        public async Task Authenticate()
        {
            await UniFiPost("api/login", new
            {
                username = _username,
                password = _password,
                remember = false,
                strict = true
            });
        }

        private async Task<JsonMessageEnvelope<T>> ExecuteRequest<T>(IRestRequest request, bool attemptReauthentication = true) where T : new()
        {
            this.AddDefaultHeader("Referrer", BaseUrl.ToString());

            if (this.CookieContainer.GetCookies(this.BaseUrl).Count > 0)
            {
                try { this.AddDefaultHeader("X-Csrf-Token", this.CookieContainer.GetCookies(this.BaseUrl)["csrf_token"].Value); }
                catch { }
            }

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;

            var response = await ExecuteTaskAsync<JsonMessageEnvelope<T>>(request);
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
    }
}
