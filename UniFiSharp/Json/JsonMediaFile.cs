namespace UniFiSharp.Json
{
    public class JsonMediaFile
    {
        public string _id { get; set; }
        public string site_id { get; set; }
        public string filename { get; set; }
        public int filesize { get; set; }
        public string content_type { get; set; }
        public int last_modified { get; set; }
        public string md5 { get; set; }
        public string name { get; set; }
        public int length { get; set; }
        public string url { get; set; }
    }
}
