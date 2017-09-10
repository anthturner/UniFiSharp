using Newtonsoft.Json;

namespace UniFiSharp.Protocol
{
    public class UserGroup : IMessageBase
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("attr_hidden_id")]
        public string attr_hidden_id { get; set; }

        [JsonProperty("attr_no_delete")]
        public bool attr_no_delete { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("qos_rate_max_down")]
        public int qos_rate_max_down { get; set; }

        [JsonProperty("qos_rate_max_up")]
        public int qos_rate_max_up { get; set; }

        [JsonProperty("site_id")]
        public string site_id { get; set; }
    }
}