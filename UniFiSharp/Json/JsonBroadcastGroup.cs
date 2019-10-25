namespace UniFiSharp.Json
{
    public class JsonBroadcastGroup
    {
        public string _id { get; set; }
        public string site_id { get; set; }
        public string name { get; set; }
        public string[] member_table { get; set; }
        public string attr_hidden_id { get; set; }
        public bool attr_no_delete { get; set; }
        public bool attr_no_edit { get; set; }
    }
}
