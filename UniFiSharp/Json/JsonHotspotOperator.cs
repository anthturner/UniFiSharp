using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonHotspotOperator
    {
        [JsonProperty("_id")]
        public string id;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("note")]
        public string note;

        [JsonProperty("site_id")]
        public string siteId;

        [JsonProperty("x_password")]
        public string xPassword;
    }
}
