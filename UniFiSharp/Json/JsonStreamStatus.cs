using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonStreamStatus
    {
        [JsonProperty("streamId")]
        public string streamId { get; set; }

        [JsonProperty("ready")]
        public bool ready { get; set; }

        [JsonProperty("streaming")]
        public bool streaming { get; set; }

        [JsonProperty("devices")]
        public JsonNetworkDevice[] devices { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("sample_filename")]
        public string sample_filename { get; set; }

        [JsonProperty("mediafile_id")]
        public string mediafile_id { get; set; }
    }
}