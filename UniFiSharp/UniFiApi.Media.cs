using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp
{
    public partial class UniFiApi
    {
        // Partial class for managing media files on the UniFi controller. These files can then be streamed to supported devices (e.g. UniFi EDU APs)

        /// <summary>
        /// Retrieves all the media files uploaded to the controller
        /// </summary>
        /// <returns>Collection of JSON objects describing media files stored on this controller</returns>
        public async Task<IEnumerable<JsonMediaFile>> MediaFileList()
        {
            return await RestClient.UniFiGetMany<JsonMediaFile>($"api/s/{Site}/rest/mediafile");
        }

        /// <summary>
        /// Retrieves a specific file uploaded to the controller
        /// </summary>
        /// <returns>Collection of JSON objects describing media files stored on this controller</returns>
        public async Task<JsonMediaFile> MediaFileGet(string fileId)
        {
            return await RestClient.UniFiGet<JsonMediaFile>($"api/s/{Site}/rest/mediafile/{fileId}");
        }

        /// <summary>
        /// Deletes a specific uploaded media file from the controller
        /// </summary>
        /// <returns>Collection of JSON objects describing sample media files stored on this controller</returns>
        public async Task MediaFileDelete(string fileId)
        {
            await RestClient.UniFiDelete($"api/s/{Site}/rest/mediafile/{fileId}");
        }


        /// <summary>
        /// Uploads a media file to the UniFi controller. Note that OGG files are the only known supported file type (recommended quality 4).
        /// Other audio formats will upload but cannot be played by AP-AC-EDU devices
        /// </summary>
        /// <param name="name">Human readable name for the file</param>
        /// <param name="fileData">Byte array containing the file data</param>
        /// <param name="fileName">Optional file name for internal use</param>
        /// <returns></returns>
        public async Task MediaFileCreate(string name, byte[] fileData, string fileName = "", string contentType = "audio/ogg")
        {
            // If no custom filename is specified, then set the filename to the current date/time
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = DateTime.Now.ToString("s") + ".ogg";
            }

            await RestClient.UnifiFileUpload($"/upload/s/{Site}/mediafile", name, fileName, contentType, fileData);
        }

        /// <summary>
        /// Retrieves all the sample media files on the controller
        /// </summary>
        /// <returns>Collection of JSON objects describing sample media files stored on this controller</returns>
        public async Task<IEnumerable<JsonSampleMedia>> SampleFileList()
        {
            return await RestClient.UniFiPostMany<JsonSampleMedia>($"api/s/{Site}/cmd/streammgr/list-samples", new
            {
                cmd = "list-samples"
            });
        }


    }
}
