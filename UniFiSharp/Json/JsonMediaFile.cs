using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// Media file which can be played on broadcast devices
    /// </summary>
    [DisplayName("Media File")]
    public class JsonMediaFile : IJsonObject
    {
        /// <summary>
        /// Media File ID
        /// </summary>
        [DisplayName("Media File ID")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the media file
        /// </summary>
        [DisplayName("Site ID")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("site_id")]
        public string site_id { get; set; }

        /// <summary>
        /// Media file name
        /// </summary>
        [DisplayName("Filename")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("filename")]
        public string filename { get; set; }

        /// <summary>
        /// Size of the file in bytes
        /// </summary>
        [DisplayName("File Size (bytes)")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("filesize")]
        public int filesize { get; set; }

        /// <summary>
        /// Content type of the media file (default audio/ogg)
        /// </summary>
        [DisplayName("Content Type")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("content_type")]
        public string content_type { get; set; }

        /// <summary>
        /// Date/time when the media file was last updated (in seconds since epoch)
        /// </summary>
        [DisplayName("Last Modified")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("last_modified")]
        public long last_modified { get; set; }

        /// <summary>
        /// MD5 hash of file
        /// </summary>
        [DisplayName("MD5")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("md5")]
        public string md5 { get; set; }

        /// <summary>
        /// User-defined name of media file
        /// </summary>
        [DisplayName("Name")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Duration of media file in seconds
        /// </summary>
        [DisplayName("Duration (sec)")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("length")]
        public int length { get; set; }

        /// <summary>
        /// URL to retrieve media file
        /// </summary>
        [DisplayName("URL")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("url")]
        public string url { get; set; }
    }
}
