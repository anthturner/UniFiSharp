using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonMediaFile
    {
        /// <summary>
        /// Media File ID
        /// </summary>
        [DisplayName("Media File ID")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the media file
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        [Complexity(Complexities.Low)]
        public string site_id { get; set; }

        /// <summary>
        /// Media file name
        /// </summary>
        [DisplayName("Filename")]
        [JsonProperty("filename")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        public string filename { get; set; }

        /// <summary>
        /// Size of the file in bytes
        /// </summary>
        [DisplayName("File Size (bytes)")]
        [JsonProperty("filesize")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        public int filesize { get; set; }

        /// <summary>
        /// Content type of the media file (default audio/ogg)
        /// </summary>
        [DisplayName("Content Type")]
        [JsonProperty("content_type")]
        [Complexity(Complexities.Average)]
        public string content_type { get; set; }

        /// <summary>
        /// Date/time when the media file was last updated (in seconds since epoch)
        /// </summary>
        [DisplayName("Last Modified")]
        [JsonProperty("last_modified")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        public long last_modified { get; set; }

        /// <summary>
        /// MD5 hash of file
        /// </summary>
        [DisplayName("MD5")]
        [JsonProperty("md5")]
        [Complexity(Complexities.Average)]
        public string md5 { get; set; }

        /// <summary>
        /// User-defined name of media file
        /// </summary>
        [DisplayName("Name")]
        [JsonProperty("name")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        public string name { get; set; }

        /// <summary>
        /// Duration of media file in seconds
        /// </summary>
        [DisplayName("Duration (sec)")][IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("length")]
        public int length { get; set; }

        /// <summary>
        /// URL to retrieve media file
        /// </summary>
        [DisplayName("URL")]
        [Complexity(Complexities.Average)]
        [JsonProperty("url")]
        public string url { get; set; }
    }
}
