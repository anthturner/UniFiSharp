using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonRogueAp
    {
        [JsonProperty("age")]
        public long age;

        [JsonProperty("ap_mac")]
        public string apMac;

        [JsonProperty("bssid")]
        public string bssid;

        [JsonProperty("channel")]
        public long channel;

        [JsonProperty("essid")]
        public string essid;

        [JsonProperty("freq")]
        public long freq;

        [JsonProperty("_id")]
        public string id;

        [JsonProperty("is_adhoc")]
        public bool isAdhoc;

        [JsonProperty("is_default")]
        public bool isDefault;

        [JsonProperty("is_isolated")]
        public bool isIsolated;

        [JsonProperty("is_locating")]
        public bool isLocating;

        [JsonProperty("is_ubnt")]
        public bool isUbnt;

        [JsonProperty("is_unifi")]
        public bool isUnifi;

        [JsonProperty("is_vport")]
        public bool isVport;

        [JsonProperty("is_vwire")]
        public bool isVwire;

        [JsonProperty("last_seen")]
        public long lastSeen;

        [JsonProperty("mac")]
        public string mac;

        [JsonProperty("model")]
        public string model;

        [JsonProperty("model_display")]
        public string modelDisplay;

        [JsonProperty("na-channel")]
        public long naChannel;

        [JsonProperty("ng-channel")]
        public long ngChannel;

        [JsonProperty("oui")]
        public string oui;

        [JsonProperty("radio")]
        public string radio;

        [JsonProperty("report_time")]
        public long reportTime;

        [JsonProperty("rssi")]
        public long rssi;

        [JsonProperty("security")]
        public string security;

        [JsonProperty("serialno")]
        public string serialno;

        [JsonProperty("site_id")]
        public string siteId;
    }
}