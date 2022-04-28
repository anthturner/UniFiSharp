using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonMediaFile
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("site_id")]
        public string site_id { get; set; }

        [JsonProperty("filename")]
        public string filename { get; set; }

        [JsonProperty("filesize")]
        public int filesize { get; set; }

        [JsonProperty("content_type")]
        public string content_type { get; set; }

        [JsonProperty("last_modified")]
        public int last_modified { get; set; }

        [JsonProperty("md5")]
        public string md5 { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("length")]
        public int length { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }
    }
}
