using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonRogueAp
    {
        /// <summary>
        /// Amount of time in seconds which this rogue access point has been detected for
        /// </summary>
        [DisplayName("Age (sec)")]
        [IncludedInVisualization]
        [JsonProperty("age")]
        public long age { get; set; }

        /// <summary>
        /// Rogue access point MAC address
        /// </summary>
        [DisplayName("Rogue AP MAC")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("ap_mac")]
        public string apMac { get; set; }

        /// <summary>
        /// BSSID being broadcast by the rogue access point
        /// </summary>
        [DisplayName("BSSID")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("bssid")]
        public string bssid { get; set; }

        /// <summary>
        /// Channel used by the rogue access point
        /// </summary>
        [DisplayName("Channel")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("channel")]
        public long channel { get; set; }

        /// <summary>
        /// ESSID being broadcast by the rogue access point
        /// </summary>
        [DisplayName("ESSID")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("essid")]
        public string essid { get; set; }

        /// <summary>
        /// Frequency used by the rogue access point
        /// </summary>
        [DisplayName("Frequency")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("freq")]
        public long freq { get; set; }

        /// <summary>
        /// Rogue AP ID
        /// </summary>
        [DisplayName("Rogue AP ID")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("_id")]
        public string id { get; set; }

        /// <summary>
        /// If the rogue access point is running an ad-hoc network
        /// </summary>
        [DisplayName("Adhoc?")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("is_adhoc")]
        public bool isAdhoc { get; set; }

        /// <summary>
        /// If the rogue access point is running default settings (UniFi)
        /// </summary>
        [DisplayName("Default?")]
        [IncludedInVisualization]
        [JsonProperty("is_default")]
        public bool isDefault { get; set; }

        /// <summary>
        /// If the rogue access point is isolated
        /// </summary>
        [DisplayName("Isolated?")]
        [IncludedInVisualization]
        [JsonProperty("is_isolated")]
        public bool isIsolated { get; set; }

        /// <summary>
        /// If the rogue access point is in locating mode
        /// </summary>
        [DisplayName("Locating?")]
        [IncludedInVisualization]
        [JsonProperty("is_locating")]
        public bool isLocating { get; set; }

        /// <summary>
        /// If the rogue access point is a Ubiquiti Networks device
        /// </summary>
        [DisplayName("UBNT?")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("is_ubnt")]
        public bool isUbnt { get; set; }

        /// <summary>
        /// If the rogue access point is a UniFi device
        /// </summary>
        [DisplayName("UniFi?")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("is_unifi")]
        public bool isUnifi { get; set; }

        // TODO
        [JsonProperty("is_vport")]
        public bool isVport { get; set; }

        // TODO
        [JsonProperty("is_vwire")]
        public bool isVwire { get; set; }

        /// <summary>
        /// Date/time when the rogue access point was last seen (in seconds since epoch)
        /// </summary>
        [DisplayName("Last Seen (sec)")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("last_seen")]
        public long lastSeen { get; set; }

        /// <summary>
        /// MAC address of the access point which detected the rogue access point
        /// </summary>
        [DisplayName("AP MAC")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        /// <summary>
        /// Model information of the rogue access point
        /// </summary>
        [DisplayName("Model")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("model")]
        public string model { get; set; }

        // TODO
        [JsonProperty("model_display")]
        public string modelDisplay { get; set; }

        /// <summary>
        /// 5GHz channel used by the rogue access point
        /// </summary>
        [DisplayName("5GHz Channel")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("na-channel")]
        public long naChannel { get; set; }

        /// <summary>
        /// 2.4GHz channel used by the rogue access point
        /// </summary>
        [DisplayName("2.4GHz Channel")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("ng-channel")]
        public long ngChannel { get; set; }

        /// <summary>
        /// OUI (Organizationally Unique Identifier) identifying the vendor/manufacturer of the rogue access point
        /// </summary>
        [DisplayName("OUI")]
        [IncludedInVisualization]
        [JsonProperty("oui")]
        public string oui { get; set; }

        /// <summary>
        /// Type of radio being used by the rogue access point
        /// </summary>
        [DisplayName("Radio Type")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("radio")]
        public string radio { get; set; }

        /// <summary>
        /// Date/time when the rogue access point was first seen (in seconds since epoch)
        /// </summary>
        [DisplayName("First Seen (sec)")]
        [IncludedInVisualization]
        [JsonProperty("report_time")]
        public long reportTime { get; set; }

        /// <summary>
        /// RSSI (Received Signal Strength Indicator) in dBm (0-100), according to the access point detecting the rogue access point; closer to 0 is stronger
        /// </summary>
        [DisplayName("RSSI")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("rssi")]
        public long rssi { get; set; }

        /// <summary>
        /// Security mode being used by the rogue access point
        /// </summary>
        [DisplayName("Security Mode")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("security")]
        public string security { get; set; }

        /// <summary>
        /// Serial number of the rogue access point
        /// </summary>
        [DisplayName("Serial #")]
        [IncludedInVisualization]
        [JsonProperty("serialno")]
        public string serialno { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the access point detecting the rogue access point
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        public string siteId { get; set; }
    }
}