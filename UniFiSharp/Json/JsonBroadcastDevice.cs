using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// Broadcast device (can output audio)
    /// </summary>
    [DisplayName("Broadcast Device")]
    public class JsonBroadcastDevice : IJsonObject
    {
        /// <summary>
        /// If the Broadcast Device is connected
        /// </summary>
        [DisplayName("Connected?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("connected")]
        public bool connected { get; set; }

        /// <summary>
        /// Broadcast Device MAC address
        /// </summary>
        [DisplayName("MAC Address")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        /// <summary>
        /// Broadcast Device volume level
        /// </summary>
        [DisplayName("Volume")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("volume")]
        public long volume { get; set; }
    }
}