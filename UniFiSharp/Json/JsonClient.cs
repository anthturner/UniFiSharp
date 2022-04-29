using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonClient : IJsonObject
    {
        /// <summary>
        /// Client ID
        /// </summary>
        [DisplayName("Client ID")]
        [IncludedInVisualization]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// If the client is a guest via a wireless access point
        /// </summary>
        [DisplayName("Guest by AP?")]
        [JsonProperty("_is_guest_by_uap")]
        public bool _is_guest_by_uap { get; set; }

        /// <summary>
        /// If the client is a guest via a gateway/router
        /// </summary>
        [DisplayName("Guest by Gateway?")]
        [JsonProperty("_is_guest_by_ugw")]
        public bool _is_guest_by_ugw { get; set; }

        /// <summary>
        /// If the client is a guest via a switch
        /// </summary>
        [DisplayName("Guest by Switch?")]
        [JsonProperty("_is_guest_by_usw")]
        public bool _is_guest_by_usw { get; set; }

        /// <summary>
        /// Number of seconds since last seen by the AP
        /// </summary>
        [DisplayName("Last Seen by AP (sec)")]
        [JsonProperty("_last_seen_by_uap")]
        public long _last_seen_by_uap { get; set; }

        /// <summary>
        /// Number of seconds since last seen by the gateway/router
        /// </summary>
        [DisplayName("Last Seen by Gateway (sec)")]
        [JsonProperty("_last_seen_by_ugw")]
        public long _last_seen_by_ugw { get; set; }

        /// <summary>
        /// Number of seconds since last seen by a switch
        /// </summary>
        [DisplayName("Last Seen by Switch (sec)")]
        [JsonProperty("_last_seen_by_usw")]
        public long _last_seen_by_usw { get; set; }

        /// <summary>
        /// Number of seconds of client uptime according to the AP
        /// </summary>
        [DisplayName("Uptime by AP (sec)")]
        [JsonProperty("_uptime_by_uap")]
        public long _uptime_by_uap { get; set; }

        /// <summary>
        /// Number of seconds of client uptime according to the gateway/router
        /// </summary>
        [DisplayName("Uptime by Gateway (sec)")]
        [JsonProperty("_uptime_by_ugw")]
        public long _uptime_by_ugw { get; set; }

        /// <summary>
        /// Number of seconds of client uptime according to the switch
        /// </summary>
        [DisplayName("Uptime by Switch (sec)")]
        [JsonProperty("_uptime_by_usw")]
        public long _uptime_by_usw { get; set; }

        /// <summary>
        /// MAC Address of the AP the client is connected to
        /// </summary>
        [DisplayName("AP Mac Address")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("ap_mac")]
        public string ap_mac { get; set; }

        /// <summary>
        /// Date/time when the client was associated (in seconds since epoch)
        /// </summary>
        [DisplayName("Date/Time of Association (sec)")]
        [IncludedInVisualization(VisualizationModes.Single)]
        [JsonProperty("assoc_time")]
        public long assoc_time { get; set; }

        /// <summary>
        /// If the client has been authorized by 802.1X 
        /// </summary>
        [DisplayName("802.1X Authorized?")]
        [IncludedInVisualization(VisualizationModes.Single)]
        [JsonProperty("authorized")]
        public bool authorized { get; set; }

        /// <summary>
        /// BSSID which the client is connected to; a BSSID is typically an AP's MAC address
        /// </summary>
        [DisplayName("BSSID")]
        [IncludedInVisualization(VisualizationModes.Single)]
        [JsonProperty("bssid")]
        public string bssid { get; set; }

        // TODO
        [JsonProperty("bytes-r")]
        public long bytes_r { get; set; }

        /// <summary>
        /// CCQ (Client Connection Quality) measurement; this is deprecated in newer UniFi firmware
        /// </summary>
        [DisplayName("CCQ")]
        [JsonProperty("ccq")]
        public long ccq { get; set; }

        /// <summary>
        /// Wireless channel which the client is using
        /// </summary>
        [DisplayName("Channel")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("channel")]
        public int channel { get; set; }

        /// <summary>
        /// ESSID which the client is connected to; an ESSID is frequently the same as the SSID
        /// </summary>
        [DisplayName("ESSID")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("essid")]
        public string essid { get; set; }

        /// <summary>
        /// Date/time when the client was first seen on the network (in seconds since epoch)
        /// </summary>
        [DisplayName("First Seen")]
        [JsonProperty("first_seen")]
        public long first_seen { get; set; }

        /// <summary>
        /// MAC Address of the gateway the client uses to access the internet
        /// </summary>
        [DisplayName("Gateway MAC Address")]
        [IncludedInVisualization]
        [JsonProperty("gw_mac")]
        public string gw_mac { get; set; }

        /// <summary>
        /// Hostname of the client
        /// </summary>
        [DisplayName("Hostname")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("hostname")]
        public string hostname { get; set; }

        /// <summary>
        /// Amount of time in seconds that the client has not sent traffic
        /// </summary>
        [DisplayName("Idle Time (sec)")]
        [IncludedInVisualization]
        [JsonProperty("idletime")]
        public long idletime { get; set; }

        /// <summary>
        /// IP Address of the client
        /// </summary>
        [DisplayName("IP Address")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("ip")]
        public string ip { get; set; }

        /// <summary>
        /// If the client is a guest on the network
        /// </summary>
        [DisplayName("Is Guest?")]
        [IncludedInVisualization]
        [JsonProperty("is_guest")]
        public bool is_guest { get; set; }

        /// <summary>
        /// If the client is connected via a wired connection
        /// </summary>
        [DisplayName("Is Wired?")]
        [IncludedInVisualization]
        [JsonProperty("is_wired")]
        public bool is_wired { get; set; }

        /// <summary>
        /// Date/time when the client was last seen on the network (in seconds since epoch)
        /// </summary>
        [DisplayName("Last Seen Time")]
        [JsonProperty("last_seen")]
        public long last_seen { get; set; }

        /// <summary>
        /// Date/time when the client was last associated (in seconds since epoch)
        /// </summary>
        [DisplayName("Latest Association Time")]
        [JsonProperty("latest_assoc_time")]
        public long latest_assoc_time { get; set; }

        /// <summary>
        /// MAC address of the client's network interface
        /// </summary>
        [DisplayName("Client MAC Address")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        /// <summary>
        /// Network name where the client is attached
        /// </summary>
        [DisplayName("Network")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("network")]
        public string network { get; set; }

        /// <summary>
        /// Network ID where the client is attached
        /// </summary>
        [DisplayName("Network ID")]
        [JsonProperty("network_id")]
        public string network_id { get; set; }

        // TODO: Verify measurement below
        /// <summary>
        /// Amount of interference (noise) in the wireless signal in dBm (0-100); closer to 0 is better
        /// </summary>
        [DisplayName("Noise")]
        [JsonProperty("noise")]
        public int noise { get; set; }

        // TODO
        [DisplayName("Noted?")]
        [JsonProperty("noted")]
        public bool noted { get; set; }

        /// <summary>
        /// OUI (Organizationally Unique Identifier) identifying the vendor/manufacturer of the client network interface
        /// </summary>
        [DisplayName("OUI")]
        [JsonProperty("oui")]
        public string oui { get; set; }

        /// <summary>
        /// If the client's network interface is in power-save mode
        /// </summary>
        [DisplayName("Power-Save?")]
        [JsonProperty("powersave_enabled")]
        public bool powersave_enabled { get; set; }

        /// <summary>
        /// If a quality-of-service policy is applied to this client
        /// </summary>
        [DisplayName("QOS Applied?")]
        [JsonProperty("qos_policy_applied")]
        public bool qos_policy_applied { get; set; }

        /// <summary>
        /// Type of radio being used to connect the client to the access point
        /// </summary>
        [DisplayName("Radio Type")]
        [JsonProperty("radio")]
        public string radio { get; set; }

        /// <summary>
        /// Protocol of radio being used to connect the client to the access point
        /// </summary>
        [DisplayName("Radio Protocol")]
        [JsonProperty("radio_proto")]
        public string radio_proto { get; set; }

        /// <summary>
        /// RSSI (Received Signal Strength Indicator) in dBm (0-100), according to the client device; closer to 0 is stronger
        /// </summary>
        [DisplayName("RSSI")]
        [JsonProperty("rssi")]
        public int rssi { get; set; }

        /// <summary>
        /// Total number of bytes received by this client
        /// </summary>
        [DisplayName("Total RX Bytes")]
        [IncludedInVisualization]
        [JsonProperty("rx_bytes")]
        public long rx_bytes { get; set; }

        // TODO: Verify this
        /// <summary>
        /// Current receive rate in bytes
        /// </summary>
        [DisplayName("RX Rate")]
        [IncludedInVisualization]
        [JsonProperty("rx_bytes-r")]
        public long rx_bytes_r { get; set; }

        /// <summary>
        /// Total number of packets received by this client
        /// </summary>
        [DisplayName("Total RX Packets")]
        [JsonProperty("rx_packets")]
        public long rx_packets { get; set; }

        /// <summary>
        /// Negotiated receive rate betwen the client and the network device it is connected to
        /// </summary>
        [DisplayName("Negotiated RX Rate")]
        [JsonProperty("rx_rate")]
        public long rx_rate { get; set; }

        /// <summary>
        /// Wireless signal strength in dBm (0 to -100); closer to 0 is stronger
        /// </summary>
        [DisplayName("WiFi Signal Strength")]
        [JsonProperty("signal")]
        public int signal { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the client
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        public string site_id { get; set; }

        // TODO
        [JsonProperty("sw_depth")]
        public int sw_depth { get; set; }

        /// <summary>
        /// MAC address of switch where this client is connected
        /// </summary>
        [DisplayName("Switch MAC Address")]
        [JsonProperty("sw_mac")]
        public string sw_mac { get; set; }

        /// <summary>
        /// Switch port where this client is connected
        /// </summary>
        [DisplayName("Switch Port")]
        [JsonProperty("sw_port")]
        public int sw_port { get; set; }

        /// <summary>
        /// Total number of bytes sent by this client
        /// </summary>
        [DisplayName("Total TX Bytes")]
        [IncludedInVisualization(VisualizationModes.Single)]
        [JsonProperty("tx_bytes")]
        public long tx_bytes { get; set; }

        // TODO: Verify this
        /// <summary>
        /// Current transmit rate in bytes
        /// </summary>
        [DisplayName("TX Rate")]
        [IncludedInVisualization(VisualizationModes.Single)]
        [JsonProperty("tx_bytes-r")]
        public long tx_bytes_r { get; set; }

        /// <summary>
        /// Total number of packets sent by this client
        /// </summary>
        [DisplayName("Total TX Packets")]
        [JsonProperty("tx_packets")]
        public long tx_packets { get; set; }

        /// <summary>
        /// Transmit power from AP to client
        /// </summary>
        [DisplayName("Transmit Power")]
        [JsonProperty("tx_power")]
        public long tx_power { get; set; }

        /// <summary>
        /// Negotiated transmit rate betwen the client and the network device it is connected to
        /// </summary>
        [DisplayName("Negotiated TX Rate")]
        [JsonProperty("tx_rate")]
        public long tx_rate { get; set; }

        /// <summary>
        /// Uptime of client
        /// </summary>
        [DisplayName("Uptime")]
        [JsonProperty("uptime")]
        public long uptime { get; set; }

        /// <summary>
        /// User ID associated with client, if authentication was performed
        /// </summary>
        [DisplayName("Client User ID")]
        [JsonProperty("user_id")]
        public string user_id { get; set; }

        /// <summary>
        /// User Group ID associated with client, if authentication was performed
        /// </summary>
        [DisplayName("Client User Group ID")]
        [JsonProperty("usergroup_id")]
        public string usergroup_id { get; set; }

        // TODO
        [JsonProperty("dpi_stats")]
        public IList<object> dpi_stats { get; set; }

        // TODO: Verify below
        /// <summary>
        /// Date/time when the client's DPI data was last updated (in seconds since epoch)
        /// </summary>
        [DisplayName("DPI Updated Time")]
        [JsonProperty("dpi_stats_last_updated")]
        public long? dpi_stats_last_updated { get; set; }

        /// <summary>
        /// If the client is actively being blocked from accessing the network
        /// </summary>
        [DisplayName("Blocked?")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("blocked")]
        public bool? blocked { get; set; }

        /// <summary>
        /// The IP address enforced for this client from the router
        /// </summary>
        [DisplayName("Fixed IP Address")]
        [IncludedInVisualization]
        [JsonProperty("fixed_ip")]
        public string fixed_ip { get; set; }

        /// <summary>
        /// User-defined name of the client
        /// </summary>
        [DisplayName("Name")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// If the router enforces a fixed IP address for this client
        /// </summary>
        [DisplayName("Fixed IP?")]
        [IncludedInVisualization(VisualizationModes.Single)]
        [JsonProperty("use_fixedip")]
        public bool? use_fixedip { get; set; }

        // TODO
        [JsonProperty("dev_cat")]
        public long? dev_cat { get; set; }

        // TODO
        [JsonProperty("dev_family")]
        public long? dev_family { get; set; }

        // TODO
        [JsonProperty("dev_id")]
        public long? dev_id { get; set; }

        // TODO
        [JsonProperty("dev_vendor")]
        public long? dev_vendor { get; set; }

        // TODO
        [JsonProperty("os_class")]
        public long? os_class { get; set; }

        // TODO
        [JsonProperty("os_name")]
        public long? os_name { get; set; }
    }
}
