using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonGuest
    {
        [JsonProperty("package")]
        public string _package;

        [JsonProperty("amount")]
        public string amount;

        [JsonProperty("ap_mac")]
        public string apMac;

        [JsonProperty("authorized_by")]
        public string authorizedBy;

        [JsonProperty("bytes")]
        public long bytes;

        [JsonProperty("channel")]
        public long channel;

        [JsonProperty("currency")]
        public string currency;

        [JsonProperty("duration")]
        public long duration;

        [JsonProperty("end")]
        public long end;

        [JsonProperty("expired")]
        public bool expired;

        [JsonProperty("hostname")]
        public string hostname;

        [JsonProperty("_id")]
        public string id;

        [JsonProperty("ip")]
        public string ip;

        [JsonProperty("mac")]
        public string mac;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("payment_cardtype")]
        public string paymentCardtype;

        [JsonProperty("payment_id")]
        public string paymentId;

        [JsonProperty("payment_type")]
        public string paymentType;

        [JsonProperty("qos_overwrite")]
        public bool qosOverwrite;

        [JsonProperty("qos_rate_max_down")]
        public long qosRateMaxDown;

        [JsonProperty("qos_rate_max_up")]
        public long qosRateMaxUp;

        [JsonProperty("qos_usage_quota")]
        public long qosUsageQuota;

        [JsonProperty("radio")]
        public string radio;

        [JsonProperty("roam_count")]
        public long roamCount;

        [JsonProperty("rx_bytes")]
        public long rxBytes;

        [JsonProperty("site_id")]
        public string siteId;

        [JsonProperty("start")]
        public long start;

        [JsonProperty("tx_bytes")]
        public long txBytes;

        [JsonProperty("user_id")]
        public string userId;

        [JsonProperty("voucher_code")]
        public string voucherCode;

        [JsonProperty("voucher_id")]
        public string voucherId;
    }
}