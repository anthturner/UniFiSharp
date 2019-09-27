using Newtonsoft.Json;
using System.Collections.Generic;

namespace UniFiSharp.Json
{
    public class JsonClient
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("_is_guest_by_uap")]
        public bool _is_guest_by_uap { get; set; }

        [JsonProperty("_is_guest_by_ugw")]
        public bool _is_guest_by_ugw { get; set; }

        [JsonProperty("_is_guest_by_usw")]
        public bool _is_guest_by_usw { get; set; }

        [JsonProperty("_last_seen_by_uap")]
        public long _last_seen_by_uap { get; set; }

        [JsonProperty("_last_seen_by_ugw")]
        public long _last_seen_by_ugw { get; set; }

        [JsonProperty("_last_seen_by_usw")]
        public long _last_seen_by_usw { get; set; }

        [JsonProperty("_uptime_by_uap")]
        public long _uptime_by_uap { get; set; }

        [JsonProperty("_uptime_by_ugw")]
        public long _uptime_by_ugw { get; set; }

        [JsonProperty("_uptime_by_usw")]
        public long _uptime_by_usw { get; set; }

        [JsonProperty("ap_mac")]
        public string ap_mac { get; set; }

        [JsonProperty("assoc_time")]
        public long assoc_time { get; set; }

        [JsonProperty("authorized")]
        public bool authorized { get; set; }

        [JsonProperty("bssid")]
        public string bssid { get; set; }

        [JsonProperty("bytes-r")]
        public long bytes_r { get; set; }

        [JsonProperty("ccq")]
        public long ccq { get; set; }

        [JsonProperty("channel")]
        public long channel { get; set; }

        [JsonProperty("essid")]
        public string essid { get; set; }

        [JsonProperty("first_seen")]
        public long first_seen { get; set; }

        [JsonProperty("gw_mac")]
        public string gw_mac { get; set; }

        [JsonProperty("hostname")]
        public string hostname { get; set; }

        [JsonProperty("idletime")]
        public long idletime { get; set; }

        [JsonProperty("ip")]
        public string ip { get; set; }

        [JsonProperty("is_guest")]
        public bool is_guest { get; set; }

        [JsonProperty("is_wired")]
        public bool is_wired { get; set; }

        [JsonProperty("last_seen")]
        public long last_seen { get; set; }

        [JsonProperty("latest_assoc_time")]
        public long latest_assoc_time { get; set; }

        [JsonProperty("mac")]
        public string mac { get; set; }

        [JsonProperty("network")]
        public string network { get; set; }

        [JsonProperty("network_id")]
        public string network_id { get; set; }

        [JsonProperty("noise")]
        public long noise { get; set; }

        [JsonProperty("noted")]
        public bool noted { get; set; }

        [JsonProperty("oui")]
        public string oui { get; set; }

        [JsonProperty("powersave_enabled")]
        public bool powersave_enabled { get; set; }

        [JsonProperty("qos_policy_applied")]
        public bool qos_policy_applied { get; set; }

        [JsonProperty("radio")]
        public string radio { get; set; }

        [JsonProperty("radio_proto")]
        public string radio_proto { get; set; }

        [JsonProperty("rssi")]
        public long rssi { get; set; }

        [JsonProperty("rx_bytes")]
        public long rx_bytes { get; set; }

        [JsonProperty("rx_bytes-r")]
        public long rx_bytes_r { get; set; }

        [JsonProperty("rx_packets")]
        public long rx_packets { get; set; }

        [JsonProperty("rx_rate")]
        public long rx_rate { get; set; }

        [JsonProperty("signal")]
        public long signal { get; set; }

        [JsonProperty("site_id")]
        public string site_id { get; set; }

        [JsonProperty("sw_depth")]
        public long sw_depth { get; set; }

        [JsonProperty("sw_mac")]
        public string sw_mac { get; set; }

        [JsonProperty("sw_port")]
        public long sw_port { get; set; }

        [JsonProperty("tx_bytes")]
        public long tx_bytes { get; set; }

        [JsonProperty("tx_bytes-r")]
        public long tx_bytes_r { get; set; }

        [JsonProperty("tx_packets")]
        public long tx_packets { get; set; }

        [JsonProperty("tx_power")]
        public long tx_power { get; set; }

        [JsonProperty("tx_rate")]
        public long tx_rate { get; set; }

        [JsonProperty("uptime")]
        public long uptime { get; set; }

        [JsonProperty("user_id")]
        public string user_id { get; set; }

        [JsonProperty("usergroup_id")]
        public string usergroup_id { get; set; }

        [JsonProperty("dpi_stats")]
        public IList<object> dpi_stats { get; set; }

        [JsonProperty("dpi_stats_last_updated")]
        public long? dpi_stats_last_updated { get; set; }

        [JsonProperty("blocked")]
        public bool? blocked { get; set; }

        [JsonProperty("fixed_ip")]
        public string fixed_ip { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("use_fixedip")]
        public bool? use_fixedip { get; set; }

        [JsonProperty("dev_cat")]
        public long? dev_cat { get; set; }

        [JsonProperty("dev_family")]
        public long? dev_family { get; set; }

        [JsonProperty("dev_id")]
        public long? dev_id { get; set; }

        [JsonProperty("dev_vendor")]
        public long? dev_vendor { get; set; }

        [JsonProperty("os_class")]
        public long? os_class { get; set; }

        [JsonProperty("os_name")]
        public long? os_name { get; set; }
    }
}
