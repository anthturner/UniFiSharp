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
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("connected")]
        public bool connected { get; set; }

        /// <summary>
        /// Broadcast Device MAC address
        /// </summary>
        [DisplayName("MAC Address")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        /// <summary>
        /// Broadcast Device volume level
        /// </summary>
        [DisplayName("Volume")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Average)]
        [JsonProperty("volume")]
        public long volume { get; set; }
    }
}