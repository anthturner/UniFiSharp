using Newtonsoft.Json;
using System.Collections.Generic;

namespace UniFiSharp.Json
{
    public class JsonStreamInfo
    {
        [JsonProperty("autostart")]
        public bool autostart { get; set; } = false;

        [JsonProperty("broadcastgroup_id")]
        public string broadcastgroup_id { get; set; }

        [JsonProperty("channel")]
        public long channel { get; set; } = 1;

        [JsonProperty("cmd")]
        public string cmd { get; set; } = "create-stream";

        [JsonProperty("devices")]
        public List<JsonBroadcastDevice> devices { get; set; } = new List<JsonBroadcastDevice>();

        [JsonProperty("iv")]
        public string iv { get; set; }

        [JsonProperty("key")]
        public string key { get; set; }

        [JsonProperty("mediafile_id")]
        public string mediafile_id { get; set; }

        [JsonProperty("quality")]
        public long quality { get; set; } = 4;

        [JsonProperty("rate")]
        public long rate { get; set; } = 48000;

        [JsonProperty("sample_filename")]
        public string sample_filename { get; set; }

        [JsonProperty("type")]
        public string type { get; set; } = "media";

        [JsonProperty("url")]
        public string url { get; set; }
    }
}
