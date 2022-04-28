using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonBroadcastGroup
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("site_id")]
        public string site_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("member_table")]
        public string[] member_table { get; set; }

        [JsonProperty("attr_hidden_id")]
        public string attr_hidden_id { get; set; }

        [JsonProperty("attr_no_delete")]
        public bool attr_no_delete { get; set; }

        [JsonProperty("attr_no_edit")]
        public bool attr_no_edit { get; set; }
    }
}
