using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonStreamStatus
    {
        /// <summary>
        /// Stream ID
        /// </summary>
        [DisplayName("Stream ID")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("streamId")]
        public string streamId { get; set; }

        /// <summary>
        /// If the stream is ready for activity
        /// </summary>
        [DisplayName("Ready?")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("ready")]
        public bool ready { get; set; }

        /// <summary>
        /// If a stream is running
        /// </summary>
        [DisplayName("Streaming?")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
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
        [Complexity(Complexities.Average)]
        [JsonProperty("sample_filename")]
        public string sample_filename { get; set; }

        /// <summary>
        /// Media file ID being used
        /// </summary>
        [DisplayName("Media File ID")]
        [JsonProperty("mediafile_id")]
        public string mediafile_id { get; set; }
    }
}