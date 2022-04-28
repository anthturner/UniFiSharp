using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonBroadcastDevice
    {
        /// <summary>
        /// If the Broadcast Device is connected
        /// </summary>
        [DisplayName("Connected?")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("connected")]
        public bool connected { get; set; }

        /// <summary>
        /// Broadcast Device MAC address
        /// </summary>
        [DisplayName("MAC Address")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        /// <summary>
        /// Broadcast Device volume level
        /// </summary>
        [DisplayName("Volume")]
        [IncludedInVisualization]
        [JsonProperty("volume")]
        public long volume { get; set; }
    }
}