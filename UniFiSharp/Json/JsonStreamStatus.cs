using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// Status of streaming media on a Broadcast Device
    /// </summary>
    [DisplayName("Stream Status")]
    public class JsonStreamStatus
    {
        /// <summary>
        /// Stream ID
        /// </summary>
        [DisplayName("Stream ID")]
        [Identifier]
        [JsonProperty("streamId")]
        public string streamId { get; set; }

        /// <summary>
        /// If the stream is ready for activity
        /// </summary>
        [DisplayName("Ready?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("ready")]
        public bool ready { get; set; }

        /// <summary>
        /// If a stream is running
        /// </summary>
        [DisplayName("Streaming?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("streaming")]
        public bool streaming { get; set; }

        // TODO
        [JsonProperty("devices")]
        public JsonNetworkDevice[] devices { get; set; }

        // TODO
        [JsonProperty("type")]
        public string type { get; set; }

        /// <summary>
        /// Filename of running audio
        /// </summary>
        [DisplayName("Filename")]
        [Identifier]
        [ShowWith(Levels.Basic)]
        [JsonProperty("sample_filename")]
        public string sample_filename { get; set; }

        /// <summary>
        /// Media file ID being used
        /// </summary>
        [DisplayName("Media File ID")]
        [Identifier]
        [JsonProperty("mediafile_id")]
        public string mediafile_id { get; set; }
    }
}