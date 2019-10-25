using System.Collections.Generic;

namespace UniFiSharp.Json
{
    public class JsonStreamInfo
    {
        public bool autostart { get; set; } = false;
        public string broadcastgroup_id { get; set; }
        public long channel { get; set; } = 1;
        public string cmd { get; set; } = "create-stream";
        public List<JsonBroadcastDevice> devices { get; set; } = new List<JsonBroadcastDevice>();
        public string iv { get; set; }
        public string key { get; set; }
        public string mediafile_id { get; set; }
        public long quality { get; set; } = 4;
        public long rate { get; set; } = 48000;
        public string sample_filename { get; set; }
        public string type { get; set; } = "media";
        public string url { get; set; }
    }
}
