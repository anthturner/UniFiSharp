using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace UniFiSharp
{
    /// <summary>
    /// Represents a RESTful client that provides data services to the UniFiApi class
    /// </summary>
    public interface IUniFiRestClient
    {
        /// <summary>
        /// Execute an HTTP GET operation on a given URL
        /// </summary>
        /// <param name="url">URL to operate on</param>
        /// <returns></returns>
        Task UniFiGet(string url);
        
        /// <summary>
        /// Execute an HTTP GET operation on a given URL and return one result
        /// </summary>
        /// <typeparam name="T">Type of JSON response object</typeparam>
        /// <param name="url">URL to operate on</param>
        /// <returns>JSON response object of the given type</returns>
        Task<T> UniFiGet<T>(string url) where T : new();

        /// <summary>
        /// Execute an HTTP GET operation on a given URL and return a collection of results
        /// </summary>
        /// <typeparam name="T">Type of JSON response objects</typeparam>
        /// <param name="url">URL to operate on</param>
        /// <returns>List of JSON response objects of the given type</returns>
        Task<IList<T>> UniFiGetMany<T>(string url) where T : new();

        /// <summary>
        /// Execute an HTTP POST operation on a given URL
        /// </summary>
        /// <param name="url">URL to operate on</param>
        /// <param name="jsonBody">JSON object to POST</param>
        /// <returns></returns>
        Task UniFiPost(string url, object jsonBody);

        /// <summary>
        /// Execute an HTTP POST operation on a given URL and return one result
        /// </summary>
        /// <typeparam name="T">Type of JSON response object</typeparam>
        /// <param name="url">URL to operate on</param>
        /// <param name="jsonBody">JSON object to POST</param>
        /// <returns>JSON response object of the given type</returns>
        Task<T> UniFiPost<T>(string url, object jsonBody) where T : new();

        /// <summary>
        /// Execute an HTTP POST operation on a given URL and return a collection of results
        /// </summary>
        /// <typeparam name="T">Type of JSON response objects</typeparam>
        /// <param name="url">URL to operate on</param>
        /// <param name="jsonBody">JSON object to POST</param>
        /// <returns>List of JSON response objects of the given type</returns>
        Task<IList<T>> UniFiPostMany<T>(string url, object jsonBody) where T : new();

        /// <summary>
        /// Execute an HTTP PUT operation on a given URL
        /// </summary>
        /// <param name="url">URL to operate on</param>
        /// <param name="jsonBody">JSON object to PUT</param>
        /// <returns></returns>
        Task UniFiPut(string url, object jsonBody);

        /// <summary>
        /// Execute an HTTP PUT operation on a given URL and return one result
        /// </summary>
        /// <typeparam name="T">Type of JSON response object</typeparam>
        /// <param name="url">URL to operate on</param>
        /// <param name="jsonBody">JSON object to PUT</param>
        /// <returns>JSON response object of the given type</returns>
        Task<T> UniFiPut<T>(string url, object jsonBody) where T : new();

        /// <summary>
        /// Execute an HTTP PUT operation on a given URL and return a collection of results
        /// </summary>
        /// <typeparam name="T">Type of JSON response objects</typeparam>
        /// <param name="url">URL to operate on</param>
        /// <param name="jsonBody">JSON object to PUT</param>
        /// <returns>List of JSON response objects of the given type</returns>
        Task<IList<T>> UniFiPutMany<T>(string url, object jsonBody) where T : new();

        /// <summary>
        /// Execute an HTTP DELETE operation on a given URL
        /// </summary>
        /// <param name="url">URL to operate on</param>
        /// <returns></returns>
        Task UniFiDelete(string url);

        Task UnifiFileUpload(string url, string name, string fileName, string contentType, byte[] data);

        /// <summary>
        /// Authenticate to the UniFi controller
        /// </summary>
        /// <returns></returns>
        Task Authenticate();
    }
}
