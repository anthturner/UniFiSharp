using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonGuest
    {
        // TODO
        [JsonProperty("package")]
        public string _package { get; set; }

        // TODO
        [JsonProperty("amount")]
        public string amount { get; set; }

        /// <summary>
        /// MAC Address of the access point the guest is connected to
        /// </summary 
        [DisplayName("AP MAC Address")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("ap_mac")]
        public string apMac { get; set; }

        // TODO
        public string authorizedBy { get; set; }

        // TODO: Verify below
        /// <summary>
        /// Number of bytes used by the guest
        /// </summary>
        [DisplayName("Bytes Used")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("bytes")]
        public long bytes { get; set; }

        /// <summary>
        /// Wireless channel which the guest is using
        /// </summary>
        [DisplayName("Channel")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("channel")]
        public long channel { get; set; }

        /// <summary>
        /// The currency type being used to pay for the guest account
        /// </summary>
        [DisplayName("Currency")]
        [JsonProperty("currency")]
        public string currency { get; set; }

        /// <summary>
        /// How long the guest has been connected to the network
        /// </summary>
        [DisplayName("Duration")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("duration")]
        public long duration { get; set; }

        // TODO
        [JsonProperty("end")]
        public long end { get; set; }

        /// <summary>
        /// If the guest account has expired
        /// </summary>
        [DisplayName("Expired?")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("expired")]
        public bool expired { get; set; }

        /// <summary>
        /// Hostname of the client
        /// </summary>
        [DisplayName("Hostname")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("hostname")]
        public string hostname { get; set; }

        /// <summary>
        /// Guest ID
        /// </summary>
        [DisplayName("Guest ID")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Average)]
        [JsonProperty("_id")]
        public string id { get; set; }

        /// <summary>
        /// IP Address of the guest
        /// </summary>
        [DisplayName("IP Address")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("ip")]
        public string ip { get; set; }

        /// <summary>
        /// MAC address of the guest system's network interface
        /// </summary>
        [DisplayName("Guest MAC Address")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        /// <summary>
        /// User-defined name of the guest client
        /// </summary>
        [DisplayName("Guest Name")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Card type used for payment
        /// </summary>
        [DisplayName("Card Type")]
        [Complexity(Complexities.Average)]
        [JsonProperty("payment_cardtype")]
        public string paymentCardtype { get; set; }

        /// <summary>
        /// Payment ID linked to the guest
        /// </summary>
        [DisplayName("Payment ID")]
        [JsonProperty("payment_id")]
        public string paymentId { get; set; }

        /// <summary>
        /// Type of payment used by the guest
        /// </summary>
        [DisplayName("Payment Type")]
        [Complexity(Complexities.Average)]
        [JsonProperty("payment_type")]
        public string paymentType { get; set; }

        // TODO
        [JsonProperty("qos_overwrite")]
        public bool qosOverwrite { get; set; }

        /// <summary>
        /// Maximum downstream rate permitted by QoS rules for the guest
        /// </summary>
        [DisplayName("Max Downstream (bytes)")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("qos_rate_max_down")]
        public long qosRateMaxDown { get; set; }

        /// <summary>
        /// Maximum upstream rate permitted by QoS rules for the guest
        /// </summary>
        [DisplayName("Max Upstream (bytes)")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("qos_rate_max_up")]
        public long qosRateMaxUp { get; set; }

        /// <summary>
        /// Usage quota for the guest
        /// </summary>
        [DisplayName("Usage Quota (bytes)")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("qos_usage_quota")]
        public long qosUsageQuota { get; set; }

        /// <summary>
        /// Type of radio being used to connect the guest to the access point
        /// </summary>
        [DisplayName("Radio Type")]
        [Complexity(Complexities.Average)]
        [JsonProperty("radio")]
        public string radio { get; set; }

        // TODO
        [JsonProperty("roam_count")]
        public long roamCount { get; set; }

        /// <summary>
        /// Total number of bytes received by this guest
        /// </summary>
        [DisplayName("Total RX Bytes")]
        [Complexity(Complexities.Average)]
        [JsonProperty("rx_bytes")]
        public long rxBytes { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the client
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        public string siteId { get; set; }

        // TODO
        [JsonProperty("start")]
        public long start { get; set; }

        /// <summary>
        /// Total number of bytes transmitted by this guest
        /// </summary>
        [DisplayName("Total TX Bytes")]
        [Complexity(Complexities.Average)]
        [JsonProperty("tx_bytes")]
        public long txBytes { get; set; }

        /// <summary>
        /// User ID associated with client, if authentication was performed
        /// </summary>
        [DisplayName("Guest User ID")]
        [JsonProperty("user_id")]
        public string userId { get; set; }

        /// <summary>
        /// Voucher code used to grant guest access
        /// </summary>
        [DisplayName("Voucher Code")]
        [JsonProperty("voucher_code")]
        public string voucherCode { get; set; }

        /// <summary>
        /// Voucher ID used to grant guest access
        /// </summary>
        [DisplayName("Voucher ID")]
        [JsonProperty("voucher_id")]
        public string voucherId { get; set; }
    }
}