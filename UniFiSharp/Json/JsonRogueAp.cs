using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonRogueAp
    {
        [JsonProperty("age")]
        public long age { get; set; }

        [JsonProperty("ap_mac")]
        public string apMac { get; set; }

        [JsonProperty("bssid")]
        public string bssid { get; set; }

        [JsonProperty("channel")]
        public long channel { get; set; }

        [JsonProperty("essid")]
        public string essid { get; set; }

        [JsonProperty("freq")]
        public long freq { get; set; }

        [JsonProperty("_id")]
        public string id { get; set; }

        [JsonProperty("is_adhoc")]
        public bool isAdhoc { get; set; }

        [JsonProperty("is_default")]
        public bool isDefault { get; set; }

        [JsonProperty("is_isolated")]
        public bool isIsolated { get; set; }

        [JsonProperty("is_locating")]
        public bool isLocating { get; set; }

        [JsonProperty("is_ubnt")]
        public bool isUbnt { get; set; }

        [JsonProperty("is_unifi")]
        public bool isUnifi { get; set; }

        [JsonProperty("is_vport")]
        public bool isVport { get; set; }

        [JsonProperty("is_vwire")]
        public bool isVwire { get; set; }

        [JsonProperty("last_seen")]
        public long lastSeen { get; set; }

        [JsonProperty("mac")]
        public string mac { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }

        [JsonProperty("model_display")]
        public string modelDisplay { get; set; }

        [JsonProperty("na-channel")]
        public long naChannel { get; set; }

        [JsonProperty("ng-channel")]
        public long ngChannel { get; set; }

        [JsonProperty("oui")]
        public string oui { get; set; }

        [JsonProperty("radio")]
        public string radio { get; set; }

        [JsonProperty("report_time")]
        public long reportTime { get; set; }

        [JsonProperty("rssi")]
        public long rssi { get; set; }

        [JsonProperty("security")]
        public string security { get; set; }

        [JsonProperty("serialno")]
        public string serialno { get; set; }

        [JsonProperty("site_id")]
        public string siteId { get; set; }
    }
}