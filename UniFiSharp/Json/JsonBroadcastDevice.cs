using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonBroadcastDevice
    {
        [JsonProperty("connected")]
        public bool connected { get; set; }

        [JsonProperty("mac")]
        public string mac { get; set; }

        [JsonProperty("volume")]
        public long volume { get; set; }
    }
}