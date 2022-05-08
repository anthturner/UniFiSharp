using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonHotspotVoucher
    {
        // TODO
        [JsonProperty("admin_name")]
        public string adminName { get; set; }

        // TODO
        [JsonProperty("code")]
        public string code { get; set; }

        /// <summary>
        /// Date/time when the voucher was created (in seconds since epoch)
        /// </summary>
        [DisplayName("Voucher Creation Time")]
        [Complexity(Complexities.Average)]
        [JsonProperty("create_time")]
        public long createTime { get; set; }

        /// <summary>
        /// Duration of time in seconds that the voucher is valid
        /// </summary>
        [DisplayName("Valid Duration")]
        [Complexity(Complexities.Average)]
        [JsonProperty("duration")]
        public long duration { get; set; }

        /// <summary>
        /// Date/time when the voucher expires (in seconds since epoch)
        /// </summary>
        [DisplayName("Voucher Expiry Time")]
        [Complexity(Complexities.Average)]
        [JsonProperty("end_time")]
        public long endTime { get; set; }

        // TODO
        [JsonProperty("for_hotspot")]
        public bool forHotspot { get; set; }

        /// <summary>
        /// Voucher ID
        /// </summary>
        [DisplayName("Voucher ID")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("_id")]
        public string id { get; set; }

        /// <summary>
        /// User-defined note associated with voucher
        /// </summary>
        [DisplayName("Voucher Note")]
        [Complexity(Complexities.Average)]
        [JsonProperty("note")]
        public string note { get; set; }

        // TODO
        [JsonProperty("qos_overwrite")]
        public bool qosOverwrite { get; set; }

        /// <summary>
        /// Maximum downstream rate permitted by QoS rules for the voucher
        /// </summary>
        [DisplayName("Max Downstream (bytes)")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("qos_rate_max_down")]
        public long qosRateMaxDown { get; set; }

        /// <summary>
        /// Maximum upstream rate permitted by QoS rules for the voucher
        /// </summary>
        [DisplayName("Max Downstream (bytes)")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("qos_rate_max_up")]
        public long qosRateMaxUp { get; set; }

        /// <summary>
        /// Usage quota for the voucher
        /// </summary>
        [DisplayName("Usage Quota (bytes)")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("qos_usage_quota")]
        public long qosUsageQuota { get; set; }

        /// <summary>
        /// Maximum number of bytes which can be used by the voucher
        /// </summary>
        [DisplayName("Byte Quota (bytes)")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("quota")]
        public long quota { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the client
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        public string siteId { get; set; }

        // TODO
        [JsonProperty("start_time")]
        public long startTime { get; set; }

        // TODO
        [JsonProperty("status")]
        public string status { get; set; }

        // TODO
        [JsonProperty("status_expires")]
        public long statusExpires { get; set; }

        /// <summary>
        /// Date/time when the voucher was used (in seconds since epoch)
        /// </summary>
        [DisplayName("Date Used")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("used")]
        public long used { get; set; }
    }
}
