using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp
{
    /// <summary>
    /// Encapsulates the functionality to manage a network powered by Ubiquiti UniFi networking devices
    /// </summary>
    public partial class UniFiApi : IDisposable
    {
        private IUniFiRestClient RestClient { get; set; }

        /// <summary>
        /// UniFi Site name (normally 'default')
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// Main API interface for controlling Ubiquiti UniFi devices via a controller
        /// </summary>
        /// <param name="baseUrl">URL to the controller</param>
        /// <param name="username">Controller username</param>
        /// <param name="password">Controller password</param>
        /// <param name="site">Site name (or <c>default</c>)</param>
        /// <param name="ignoreSslValidation">Ignore self signed certificate errors</param>
        /// <param name="useModernApi">Use the 2020-era UniFi API</param>
        public UniFiApi(Uri baseUrl, string username, string password, string site = "default", bool ignoreSslValidation = false, bool useModernApi = true)
        {
            Site = site;
            RestClient = new DefaultUniFiRestClient(baseUrl, username, password, ignoreSslValidation, useModernApi);
        }

        /// <summary>
        /// Main API interface for controlling Ubiquiti UniFi devices via a controller
        /// </summary>
        /// <param name="baseUrl">URL to the controller</param>
        /// <param name="username">Controller username</param>
        /// <param name="password">Controller password</param>
        /// <param name="code">2FA Code</param>
        /// <param name="site">Site name (or <c>default</c>)</param>
        /// <param name="ignoreSslValidation">Ignore self signed certificate errors</param>
        /// <param name="useModernApi">Use the 2020-era UniFi API</param>
        public UniFiApi(Uri baseUrl, string username, string password, string code, string site = "default", bool ignoreSslValidation = false, bool useModernApi = true)
        {
            Site = site;
            RestClient = new DefaultUniFiRestClient(baseUrl, username, password, code, ignoreSslValidation, useModernApi);
        }

        /// <summary>
        /// Main API interface for controlling Ubiquiti UniFi devices via a controller
        /// </summary>
        /// <param name="baseUrl">URL to the controller</param>
        /// <param name="username">Controller username</param>
        /// <param name="password">Controller password</param>
        /// <param name="encoding">Defines the encoding of API calls</param>
        /// <param name="site">Site name (or <c>default</c>)</param>
        /// <param name="ignoreSslValidation">Ignore self signed certificate errors</param>
        /// <param name="useModernApi">Use the 2020-era UniFi API</param>
        public UniFiApi(Uri baseUrl, string username, string password, Encoding encoding, string site = "default", bool ignoreSslValidation = false, bool useModernApi = true)
        {
            Site = site;
            RestClient = new DefaultUniFiRestClient(baseUrl, username, password, ignoreSslValidation, useModernApi, encoding);
        }

        /// <summary>
        /// Main API interface for controlling Ubiquiti UniFi devices via a controller
        /// </summary>
        /// <param name="baseUrl">URL to the controller</param>
        /// <param name="username">Controller username</param>
        /// <param name="password">Controller password</param>
        /// <param name="site">Site name (or <c>default</c>)</param>
        /// <param name="ignoreSslValidation">Ignore self signed certificate errors</param>
        /// <param name="useModernApi">Use the 2020-era UniFi API</param>
        /// <param name="timeout">HTTP Timeout</param>
        public UniFiApi(Uri baseUrl, string username, string password, string site = "default", bool ignoreSslValidation = false, bool useModernApi = true, int timeout = 1000)
        {
            Site = site;
            RestClient = new DefaultUniFiRestClient(baseUrl, username, password, ignoreSslValidation, useModernApi, null, timeout);
        }

        /// <summary>
        /// Main API interface for controlling Ubiquiti UniFi devices via a controller
        /// </summary>
        /// <param name="restClient">UniFi REST client implementation to use for data services</param>
        /// <param name="site">Site name (or <c>default</c>)</param>
        public UniFiApi(IUniFiRestClient restClient, string site = "default")
        {
            Site = site;
            RestClient = restClient;
        }
        

        /// <summary>
        /// Retrieve a list of sites managed by this controller
        /// </summary>
        /// <returns>A list of JSON objects describing sites managed by this controller</returns>
        public async Task<IList<JsonSite>> ControllerSiteList()
        {
            return await RestClient.UniFiGetMany<JsonSite>("api/self/sites");
        }

        /// <summary>
        /// Force the wrapper to authenticate with the controller
        /// </summary>
        /// <returns></returns>
        public async Task<JsonLoginResult> Authenticate()
        {
            return await RestClient.Authenticate();
        }

        /// <summary>
        /// End the active session
        /// </summary>
        /// <returns></returns>
        public async Task Logout()
        {
            await RestClient.UniFiPost("api/logout", new { });
        }

        public void Dispose() { }
    }
}
