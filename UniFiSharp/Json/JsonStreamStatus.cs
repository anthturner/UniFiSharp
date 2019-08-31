namespace UniFiSharp.Json
{
    public class JsonStreamStatus
    {
        public string streamId { get; set; }
        public bool ready { get; set; }
        public bool streaming { get; set; }
        public JsonNetworkDevice[] devices { get; set; }
        public string type { get; set; }
        public string sample_filename { get; set; }
        public string mediafile_id { get; set; }
    }
}