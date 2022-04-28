using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonStreamInfo
    {
        /// <summary>
        /// If the stream automatically starts
        /// </summary>
        [DisplayName("Autostart?")]
        [IncludedInVisualization(VisualizationModes.Single)]
        [JsonProperty("autostart")]
        public bool autostart { get; set; } = false;

        /// <summary>
        /// Broadcast Group ID
        /// </summary>
        [DisplayName("Broadcast Group ID")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("broadcastgroup_id")]
        public string broadcastgroup_id { get; set; }

        // TODO
        [JsonProperty("channel")]
        public long channel { get; set; } = 1;

        // TODO
        [JsonProperty("cmd")]
        public string cmd { get; set; } = "create-stream";

        // TODO
        [JsonProperty("devices")]
        public List<JsonBroadcastDevice> devices { get; set; } = new List<JsonBroadcastDevice>();

        /// <summary>
        /// Encrypted stream's initialization vector
        /// </summary>
        [DisplayName("Stream IV")]
        [JsonProperty("iv")]
        public string iv { get; set; }

        /// <summary>
        /// Encrypted stream's key
        /// </summary>
        [DisplayName("Stream Key")]
        [JsonProperty("key")]
        public string key { get; set; }

        /// <summary>
        /// Media file ID being used
        /// </summary>
        [DisplayName("Media File ID")]
        [JsonProperty("mediafile_id")]
        public string mediafile_id { get; set; }

        [JsonProperty("quality")]
        public long quality { get; set; } = 4;

        /// <summary>
        /// Sample rate of audio
        /// </summary>
        [DisplayName("Sample Rate")]
        [IncludedInVisualization]
        [JsonProperty("rate")]
        public long rate { get; set; } = 48000;

        /// <summary>
        /// Filename of running audio
        /// </summary>
        [DisplayName("Filename")]
        [IncludedInVisualization]
        [JsonProperty("sample_filename")]
        public string sample_filename { get; set; }

        // TODO
        [JsonProperty("type")]
        public string type { get; set; } = "media";

        /// <summary>
        /// Source URL of running stream
        /// </summary>
        [DisplayName("URL")]
        [IncludedInVisualization]
        [JsonProperty("url")]
        public string url { get; set; }
    }
}
