using Newtonsoft.Json;

namespace UniFiSharp.Protocol
{
    public class PortForward : IMessageBase
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("src")]
        public string src { get; set; }

        [JsonProperty("dst_port")]
        public int dst_port { get; set; }

        [JsonProperty("fwd_port")]
        public int fwd_port { get; set; }

        [JsonProperty("fwd")]
        public string fwd { get; set; }

        [JsonProperty("proto")]
        public string proto { get; set; }

        [JsonProperty("site_id")]
        public string site_id { get; set; }
    }
}