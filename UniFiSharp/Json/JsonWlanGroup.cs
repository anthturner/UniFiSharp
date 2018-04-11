using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonWlanGroup
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("attr_hidden_id")]
        public string attr_hidden_id { get; set; }

        [JsonProperty("attr_no_delete")]
        public bool attr_no_delete { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("site_id")]
        public string site_id { get; set; }

        [JsonProperty("attr_hidden")]
        public bool? attr_hidden { get; set; }

        [JsonProperty("attr_no_edit")]
        public bool? attr_no_edit { get; set; }

        [JsonProperty("pmf_mode")]
        public string pmf_mode { get; set; }

        [JsonProperty("roam_channel_na")]
        public int? roam_channel_na { get; set; }

        [JsonProperty("roam_channel_ng")]
        public int? roam_channel_ng { get; set; }

        [JsonProperty("roam_radio")]
        public string roam_radio { get; set; }
    }
}
