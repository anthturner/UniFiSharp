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
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("streamId")]
        public string streamId { get; set; }

        /// <summary>
        /// If the stream is ready for activity
        /// </summary>
        [DisplayName("Ready?")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("ready")]
        public bool ready { get; set; }

        /// <summary>
        /// If a stream is running
        /// </summary>
        [DisplayName("Streaming?")]
        [IncludedInVisualization(VisualizationModes.Both)]
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
        [IncludedInVisualization]
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