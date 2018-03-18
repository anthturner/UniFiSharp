using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonHotspotVoucher
    {
        [JsonProperty("admin_name")]
        public string adminName;

        [JsonProperty("code")]
        public string code;

        [JsonProperty("create_time")]
        public long createTime;

        [JsonProperty("duration")]
        public long duration;

        [JsonProperty("end_time")]
        public long endTime;

        [JsonProperty("for_hotspot")]
        public bool forHotspot;

        [JsonProperty("_id")]
        public string id;

        [JsonProperty("note")]
        public string note;

        [JsonProperty("qos_overwrite")]
        public bool qosOverwrite;

        [JsonProperty("qos_rate_max_down")]
        public long qosRateMaxDown;

        [JsonProperty("qos_rate_max_up")]
        public long qosRateMaxUp;

        [JsonProperty("qos_usage_quota")]
        public long qosUsageQuota;

        [JsonProperty("quota")]
        public long quota;

        [JsonProperty("site_id")]
        public string siteId;

        [JsonProperty("start_time")]
        public long startTime;

        [JsonProperty("status")]
        public string status;

        [JsonProperty("status_expires")]
        public long statusExpires;

        [JsonProperty("used")]
        public long used;
    }
}
