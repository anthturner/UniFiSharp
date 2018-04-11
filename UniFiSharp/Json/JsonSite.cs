using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonSite
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("desc")]
        public string desc { get; set; }

        [JsonProperty("num_ap")]
        public int num_ap { get; set; }

        [JsonProperty("num_sta")]
        public int num_sta { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }
    }
}
