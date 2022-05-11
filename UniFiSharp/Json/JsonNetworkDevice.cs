using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// UniFi infrastructure device providing network services
    /// </summary>
    public partial class JsonNetworkDevice : IJsonObject
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// Device uptime
        /// </summary>
        [DisplayName("Uptime")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("_uptime")]
        public int _uptime { get; set; }

        /// <summary>
        /// If the controller has adopted the device
        /// </summary>
        [DisplayName("Adopted?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("adopted")]
        public bool adopted { get; set; }

        // TODO
        [JsonProperty("bytes")]
        public object bytes { get; set; }

        /// <summary>
        /// Configuration version
        /// </summary>
        [DisplayName("Configuration Version")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("cfgversion")]
        public string cfgversion { get; set; }

        /// <summary>
        /// Network configuration
        /// </summary>
        [DisplayName("Network Configuration")]
        [JsonProperty("config_network")]
        public JsonConfigNetwork config_network { get; set; }

        /// <summary>
        /// WAN configuration
        /// </summary>
        [DisplayName("WAN Configuration")]
        [JsonProperty("config_network_wan")]
        public JsonConfigNetwork config_network_wan { get; set; }

        // TODO
        [JsonProperty("connect_request_ip")]
        public string connect_request_ip { get; set; }

        // TODO
        [JsonProperty("connect_request_port")]
        public string connect_request_port { get; set; }

        // TODO
        [JsonProperty("considered_lost_at")]
        public int considered_lost_at { get; set; }

        /// <summary>
        /// If the device has been factory-reset to default settings
        /// </summary>
        [DisplayName("Default Settings?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("default")]
        public bool defaultSettings { get; set; }

        /// <summary>
        /// Device ID
        /// </summary>
        [DisplayName("Device ID")]
        [JsonProperty("device_id")]
        public string device_id { get; set; }

        [JsonProperty("ethernet_table")]
        public IList<JsonEthernetTable> ethernet_table { get; set; }

        [JsonProperty("fw_caps")]
        public int fw_caps { get; set; }

        /// <summary>
        /// Number of guest clients
        /// </summary>
        [DisplayName("# Guest Clients")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("guest-num_sta")]
        public int guest_num_sta { get; set; }

        // TODO
        [JsonProperty("guest_token")]
        public string guest_token { get; set; }

        // TODO
        [JsonProperty("has_default_route_distance")]
        public bool has_default_route_distance { get; set; }

        /// <summary>
        /// If DPI (Deep Packet Inspection) is enabled
        /// </summary>
        [DisplayName("DPI Enabled?")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("has_dpi")]
        public bool has_dpi { get; set; }

        // TODO
        [JsonProperty("has_porta")]
        public bool has_porta { get; set; }

        // TODO
        [JsonProperty("has_vti")]
        public bool has_vti { get; set; }

        // TODO
        [JsonProperty("inform_authkey")]
        public string inform_authkey { get; set; }

        // TODO
        [JsonProperty("inform_ip")]
        public string inform_ip { get; set; }

        // TODO
        [JsonProperty("inform_url")]
        public string inform_url { get; set; }

        /// <summary>
        /// Device IP Address
        /// </summary>
        [DisplayName("IP Address")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("ip")]
        public string ip { get; set; }

        // TODO
        [JsonProperty("known_cfgversion")]
        public string known_cfgversion { get; set; }

        /// <summary>
        /// Last time the device was seen
        /// </summary>
        [DisplayName("Last Seen")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("last_seen")]
        public long last_seen { get; set; }

        // TODO
        [JsonProperty("license_state")]
        public string license_state { get; set; }

        /// <summary>
        /// If the device is in "locate" mode (blinking)
        /// </summary>
        [DisplayName("Locating?")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("locating")]
        public bool locating { get; set; }

        /// <summary>
        /// Device MAC Address
        /// </summary>
        [DisplayName("MAC Address")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        // TODO
        [JsonProperty("map_id")]
        public string map_id { get; set; }

        // TODO
        [JsonProperty("mgmt_network_id")]
        public string mgmt_network_id { get; set; }

        /// <summary>
        /// Device model name
        /// </summary>
        [DisplayName("Model")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("model")]
        public string model { get; set; }

        /// <summary>
        /// Device name
        /// </summary>
        [DisplayName("Name")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("name")]
        public string name { get; set; }

        // TODO
        [JsonProperty("network_table")]
        public IList<JsonNetworkTable> network_table { get; set; }

        [JsonProperty("next_heartbeat_at")]
        public int next_heartbeat_at { get; set; }

        /// <summary>
        /// Number of desktop clients connected to this device
        /// </summary>
        [DisplayName("# Desktops")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("num_desktop")]
        public int num_desktop { get; set; }

        /// <summary>
        /// Number of handheld clients connected to this device
        /// </summary>
        [DisplayName("# Handhelds")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("num_handheld")]
        public int num_handheld { get; set; }

        /// <summary>
        /// Number of mobile clients connected to this device
        /// </summary>
        [DisplayName("# Mobile")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("num_mobile")]
        public int num_mobile { get; set; }

        /// <summary>
        /// Number of total clients connected to this device
        /// </summary>
        [DisplayName("# Clients")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("num_sta")]
        public int num_sta { get; set; }

        // TODO
        [JsonProperty("port_table")]
        public IList<JsonPortTable> port_table { get; set; }

        // TODO
        [JsonProperty("radius_caps")]
        public int radius_caps { get; set; }

        /// <summary>
        /// Number of bytes received on device
        /// </summary>
        [DisplayName("RX Bytes")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("rx_bytes")]
        public long rx_bytes { get; set; }
        
        /// <summary>
        /// Device Serial Number
        /// </summary>
        [DisplayName("Serial #")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("serial")]
        public string serial { get; set; }

        /// <summary>
        /// Site ID
        /// </summary>
        [DisplayName("Site ID")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("site_id")]
        public string site_id { get; set; }

        /// <summary>
        /// Status of current speed test
        /// </summary>
        [JsonProperty("speedtest-status")]
        public JsonSpeedtestStatus speedtest_status { get; set; }

        /// <summary>
        /// If the speedtest status has been saved
        /// </summary>
        [JsonProperty("speedtest-status-saved")]
        public bool speedtest_status_saved { get; set; }

        // TODO
        [JsonProperty("state")]
        public int state { get; set; }

        /// <summary>
        /// System stats for device
        /// </summary>
        [DisplayName("System Stats")]
        [JsonProperty("sys_stats")]
        public JsonSysStats sys_stats { get; set; }

        /// <summary>
        /// Total number of bytes sent by this device
        /// </summary>
        [DisplayName("Total TX Bytes")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("tx_bytes")]
        public long tx_bytes { get; set; }

        // TODO
        [JsonProperty("type")]
        public string type { get; set; }

        /// <summary>
        /// Uplink device used by this device
        /// </summary>
        [JsonProperty("uplink")]
        public JsonLink uplink { get; set; }

        /// <summary>
        /// Uptime of device
        /// </summary>
        [DisplayName("Uptime")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("uptime")]
        public int uptime { get; set; }

        [JsonProperty("user-num_sta")]
        public int user_num_sta { get; set; }

        /// <summary>
        /// Version of device
        /// </summary>
        [DisplayName("Version")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("version")]
        public string version { get; set; }

        /// <summary>
        /// Primary (WAN1) link
        /// </summary>
        [DisplayName("WAN1")]
        [JsonProperty("wan1")]
        public JsonLink wan1 { get; set; }

        // TODO
        [JsonProperty("x")]
        public double x { get; set; }

        // TODO
        [JsonProperty("y")]
        public double y { get; set; }

        /// <summary>
        /// Device board revision number
        /// </summary>
        [DisplayName("Board Revision")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("board_rev")]
        public int? board_rev { get; set; }

        // TODO
        [JsonProperty("bytes-d")]
        public int? bytes_d { get; set; }

        // TODO
        [JsonProperty("bytes-r")]
        public long? bytes_r { get; set; }

        /// <summary>
        /// Links to downstream devices
        /// </summary>
        [JsonProperty("downlink_table")]
        public IList<JsonLink> downlink_table { get; set; }

        /// <summary>
        /// If the device has an ETH1
        /// </summary>
        [DisplayName("Has ETH1?")]
        [JsonProperty("has_eth1")]
        public bool? has_eth1 { get; set; }

        /// <summary>
        /// If the device has a speaker
        /// </summary>
        [DisplayName("Has ETH1?")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("has_speaker")]
        public bool? has_speaker { get; set; }

        /// <summary>
        /// Broadcast Device volume level
        /// </summary>
        [DisplayName("Volume")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("volume")]
        public int volume { get; set; }

        /// <summary>
        /// If device is isolated
        /// </summary>
        [DisplayName("Isolated?")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("isolated")]
        public bool? isolated { get; set; }

        // TODO
        [JsonProperty("last_uplink")]
        public JsonLink last_uplink { get; set; }

        /// <summary>
        /// The state of the LED overridden by user settings
        /// </summary>
        [DisplayName("LED Override Mode")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("led_override")]
        public string led_override { get; set; }

        /// <summary>
        /// Channel for the 5GHz radio
        /// </summary>
        [DisplayName("5G Channel")]
        [Group(GROUP_WIRELESS_5G)]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("na-channel")]
        public int? na_channel { get; set; }

        // TODO
        [JsonProperty("na-eirp")]
        public int? na_eirp { get; set; }

        // TODO
        [JsonProperty("na-extchannel")]
        public int? na_extchannel { get; set; }

        /// <summary>
        /// Gain for the 5GHz radio
        /// </summary>
        [DisplayName("5G Gain")]
        [Group(GROUP_WIRELESS_5G)]
        [ShowWith(Levels.Basic)]
        [JsonProperty("na-gain")]
        public int? na_gain { get; set; }

        /// <summary>
        /// Number of guests attached to the 5GHz radio
        /// </summary>
        [DisplayName("5G Guests")]
        [Group(GROUP_WIRELESS_5G)]
        [ShowWith(Levels.Basic)]
        [JsonProperty("na-guest-num_sta")]
        public int? na_guest_num_sta { get; set; }

        /// <summary>
        /// Number of clients attached to the 5GHz radio
        /// </summary>
        [DisplayName("5G Clients")]
        [Group(GROUP_WIRELESS_5G)]
        [ShowWith(Levels.Basic)]
        [JsonProperty("na-num_sta")]
        public int? na_num_sta { get; set; }

        // TODO
        [JsonProperty("na-state")]
        public string na_state { get; set; }

        /// <summary>
        /// Transmit power of the 5GHz radio
        /// </summary>
        [DisplayName("5G TX Power")]
        [Group(GROUP_WIRELESS_5G)]
        [ShowWith(Levels.Basic)]
        [JsonProperty("na-tx_power")]
        public int? na_tx_power { get; set; }

        // TODO
        [JsonProperty("na-user-num_sta")]
        public int? na_user_num_sta { get; set; }

        // TODO
        [JsonProperty("na_ast_be_xmit")]
        public int? na_ast_be_xmit { get; set; }

        // TODO
        [JsonProperty("na_ast_cst")]
        public object na_ast_cst { get; set; }

        // TODO
        [JsonProperty("na_ast_txto")]
        public object na_ast_txto { get; set; }

        // TODO
        [JsonProperty("na_cu_self_rx")]
        public int? na_cu_self_rx { get; set; }

        // TODO
        [JsonProperty("na_cu_self_tx")]
        public int? na_cu_self_tx { get; set; }

        // TODO
        [JsonProperty("na_cu_total")]
        public int? na_cu_total { get; set; }

        // TODO
        [JsonProperty("na_last_interference_at")]
        public int? na_last_interference_at { get; set; }

        /// <summary>
        /// Number of packets sent on 5GHz radio
        /// </summary>
        [DisplayName("TX Packets")]
        [Group(GROUP_WIRELESS_5G)]
        [ShowWith(Levels.Extended)]
        [JsonProperty("na_tx_packets")]
        public int? na_tx_packets { get; set; }

        /// <summary>
        /// Number of retries sent on 5GHz radio
        /// </summary>
        [DisplayName("TX Retries")]
        [Group(GROUP_WIRELESS_5G)]
        [ShowWith(Levels.Extended)]
        [JsonProperty("na_tx_retries")]
        public int? na_tx_retries { get; set; }

        /// <summary>
        /// Channel for the 2.4GHz radio
        /// </summary>
        [DisplayName("2G Channel")]
        [Group(GROUP_WIRELESS_2G)]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("ng-channel")]
        public int? ng_channel { get; set; }

        // TODO
        [JsonProperty("ng-eirp")]
        public int? ng_eirp { get; set; }

        // TODO
        [JsonProperty("ng-extchannel")]
        public int? ng_extchannel { get; set; }

        /// <summary>
        /// Gain for the 2.4GHz radio
        /// </summary>
        [DisplayName("2G Gain")]
        [Group(GROUP_WIRELESS_2G)]
        [ShowWith(Levels.Basic)]
        [JsonProperty("ng-gain")]
        public int? ng_gain { get; set; }

        /// <summary>
        /// Number of guests attached to the 2.4GHz radio
        /// </summary>
        [DisplayName("2G Guests")]
        [Group(GROUP_WIRELESS_2G)]
        [ShowWith(Levels.Basic)]
        [JsonProperty("ng-guest-num_sta")]
        public int? ng_guest_num_sta { get; set; }

        /// <summary>
        /// Number of clients attached to the 2.4GHz radio
        /// </summary>
        [DisplayName("2G Clients")]
        [Group(GROUP_WIRELESS_2G)]
        [ShowWith(Levels.Basic)]
        [JsonProperty("ng-num_sta")]
        public int? ng_num_sta { get; set; }

        // TODO
        [JsonProperty("ng-state")]
        public string ng_state { get; set; }

        /// <summary>
        /// Transmit power of the 2.4GHz radio
        /// </summary>
        [DisplayName("2G TX Power")]
        [Group(GROUP_WIRELESS_2G)]
        [ShowWith(Levels.Basic)]
        [JsonProperty("ng-tx_power")]
        public int? ng_tx_power { get; set; }

        // TODO
        [JsonProperty("ng-user-num_sta")]
        public int? ng_user_num_sta { get; set; }

        // TODO
        [JsonProperty("ng_ast_be_xmit")]
        public int? ng_ast_be_xmit { get; set; }

        // TODO
        [JsonProperty("ng_ast_cst")]
        public object ng_ast_cst { get; set; }

        // TODO
        [JsonProperty("ng_ast_txto")]
        public object ng_ast_txto { get; set; }

        // TODO
        [JsonProperty("ng_cu_self_rx")]
        public int? ng_cu_self_rx { get; set; }

        // TODO
        [JsonProperty("ng_cu_self_tx")]
        public int? ng_cu_self_tx { get; set; }

        // TODO
        [JsonProperty("ng_cu_total")]
        public int? ng_cu_total { get; set; }

        // TODO
        [JsonProperty("ng_last_interference_at")]
        public object ng_last_interference_at { get; set; }

        /// <summary>
        /// Number of packets sent on the 2.4GHz radio
        /// </summary>
        [DisplayName("TX Packets")]
        [Group(GROUP_WIRELESS_2G)]
        [ShowWith(Levels.Extended)]
        [JsonProperty("ng_tx_packets")]
        public int? ng_tx_packets { get; set; }

        /// <summary>
        /// Number of retries sent on the 2.4GHz radio
        /// </summary>
        [DisplayName("TX Retries")]
        [Group(GROUP_WIRELESS_2G)]
        [ShowWith(Levels.Extended)]
        [JsonProperty("ng_tx_retries")]
        public int? ng_tx_retries { get; set; }

        /// <summary>
        /// Details on the 5GHz Radio
        /// </summary>
        [DisplayName("5G Radio Detail")]
        [Group(GROUP_WIRELESS_5G)]
        [JsonProperty("radio_na")]
        public JsonRadioTable radio_na { get; set; }

        /// <summary>
        /// Details on the 2.4GHz Radio
        /// </summary>
        [DisplayName("2G Radio Detail")]
        [Group(GROUP_WIRELESS_2G)]
        [JsonProperty("radio_ng")]
        public JsonRadioTable radio_ng { get; set; }

        /// <summary>
        /// Details on all radios
        /// </summary>
        [DisplayName("All Radio Details")]
        [JsonProperty("radio_table")]
        public IList<JsonRadioTable> radio_table { get; set; }

        // TODO
        [JsonProperty("rx_bytes-d")]
        public long? rx_bytes_d { get; set; }

        /// <summary>
        /// If the device is currently scanning
        /// </summary>
        [DisplayName("Scanning?")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("scanning")]
        public bool? scanning { get; set; }

        /// <summary>
        /// If the device is currently RF spectrum scanning
        /// </summary>
        [DisplayName("RF Scanning?")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("spectrum_scanning")]
        public bool? spectrum_scanning { get; set; }

        // TODO
        [JsonProperty("spectrum_table_time_na")]
        public int? spectrum_table_time_na { get; set; }

        // TODO
        [JsonProperty("spectrum_table_time_ng")]
        public int? spectrum_table_time_ng { get; set; }

        // TODO
        [JsonProperty("ssh_session_table")]
        public IList<object> ssh_session_table { get; set; }

        // TODO
        [JsonProperty("tx_bytes-d")]
        public long? tx_bytes_d { get; set; }

        /// <summary>
        /// Uplinks associated with this device
        /// </summary>
        [DisplayName("Uplinks")]
        [JsonProperty("uplink_table")]
        public IList<object> uplink_table { get; set; }

        /// <summary>
        /// Virtual Access Points configured on this device
        /// </summary>
        [DisplayName("Virtual APs")]
        [JsonProperty("vap_table")]
        public IList<JsonVapTable> vap_table { get; set; }

        // TODO
        [JsonProperty("vwireEnabled")]
        public bool? vwireEnabled { get; set; }

        // TODO
        [JsonProperty("vwire_table")]
        public IList<object> vwire_table { get; set; }

        // TODO
        [JsonProperty("wifi_caps")]
        public int? wifi_caps { get; set; }

        // TODO
        [JsonProperty("wlan_overrides")]
        public object wlan_overrides { get; set; }

        /// <summary>
        /// WLAN Group for the 5GHz radio
        /// </summary>
        [DisplayName("5G WLAN Group")]
        [Group(GROUP_WIRELESS_5G)]
        [ShowWith(Levels.Extended)]
        [JsonProperty("wlangroup_id_na")]
        public string wlangroup_id_na { get; set; }

        /// <summary>
        /// WLAN Group for the 2.4GHz radio
        /// </summary>
        [DisplayName("2G WLAN Group")]
        [Group(GROUP_WIRELESS_2G)]
        [ShowWith(Levels.Extended)]
        [JsonProperty("wlangroup_id_ng")]
        public string wlangroup_id_ng { get; set; }

        /// <summary>
        /// DHCP Server Records
        /// </summary>
        [JsonProperty("dhcp_server_table")]
        public IList<object> dhcp_server_table { get; set; }

        /// <summary>
        /// If 802.1x port control is enabled
        /// </summary>
        [DisplayName("802.1x Port Control?")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("dot1x_portctrl_enabled")]
        public bool? dot1x_portctrl_enabled { get; set; }

        /// <summary>
        /// If flow control is enabled
        /// </summary>
        [DisplayName("Flow Control?")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("flowctrl_enabled")]
        public bool? flowctrl_enabled { get; set; }

        /// <summary>
        /// Device temperature
        /// </summary>
        [DisplayName("Temperature")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("general_temperature")]
        public int? general_temperature { get; set; }

        /// <summary>
        /// If the device has a fan
        /// </summary>
        [DisplayName("Has Fan?")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("has_fan")]
        public bool? has_fan { get; set; }

        /// <summary>
        /// If jumbo frames are enabled the device
        /// </summary>
        [DisplayName("Jumbo Frames?")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("jumboframe_enabled")]
        public bool? jumboframe_enabled { get; set; }

        /// <summary>
        /// If the device is overheating
        /// </summary>
        [DisplayName("Overheating?")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("overheating")]
        public bool? overheating { get; set; }

        /// <summary>
        /// Overrides for ports on this device
        /// </summary>
        [JsonProperty("port_overrides")]
        public IList<JsonPortOverride> port_overrides { get; set; }

        /// <summary>
        /// Priority for Spanning Tree Protocol
        /// </summary>
        [DisplayName("STP Priority")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("stp_priority")]
        public string stp_priority { get; set; }

        /// <summary>
        /// Version of Spanning Tree Protocol
        /// </summary>
        [DisplayName("STP Version")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("stp_version")]
        public string stp_version { get; set; }

        // TODO
        [JsonProperty("uplink_depth")]
        public int? uplink_depth { get; set; }

        // TODO
        public class JsonConfigNetwork : IJsonObject
        {
            // TODO
            [JsonProperty("ip")]
            public string ip { get; set; }

            // TODO
            [JsonProperty("type")]
            public string type { get; set; }
        }

        /// <summary>
        /// Ethernet Port Table
        /// </summary>
        [DisplayName("Ethernet Port Table")]
        public class JsonEthernetTable : IJsonObject
        {
            /// <summary>
            /// MAC Address
            /// </summary>
            [DisplayName("MAC Address")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("mac")]
            public string mac { get; set; }

            /// <summary>
            /// Name
            /// </summary>
            [DisplayName("Name")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("name")]
            public string name { get; set; }
            
            /// <summary>
            /// Port Number
            /// </summary>
            [DisplayName("Port")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("num_port")]
            public int num_port { get; set; }
        }

        /// <summary>
        /// Network information
        /// </summary>
        [DisplayName("Network")]
        public class JsonNetworkTable : IJsonObject
        {
            // TODO
            [JsonProperty("_id")]
            public string _id { get; set; }

            /// <summary>
            /// If the network sends DNS information with DHCP replies
            /// </summary>
            [DisplayName("DHCP Sets DNS?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("dhcpd_dns_enabled")]
            public bool dhcpd_dns_enabled { get; set; }

            /// <summary>
            /// If the network uses DHCP to grant client IPs
            /// </summary>
            [DisplayName("DHCP?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("dhcpd_enabled")]
            public bool dhcpd_enabled { get; set; }

            /// <summary>
            /// Amount of time in seconds a DHCP lease is valid before refresh
            /// </summary>
            [DisplayName("DHCP Lease Time")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("dhcpd_leasetime")]
            public int dhcpd_leasetime { get; set; }

            /// <summary>
            /// Start of DHCP range
            /// </summary>
            [DisplayName("DHCP Range Start")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("dhcpd_start")]
            public string dhcpd_start { get; set; }

            /// <summary>
            /// End of DHCP range
            /// </summary>
            [DisplayName("DHCP Range End")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("dhcpd_stop")]
            public string dhcpd_stop { get; set; }

            /// <summary>
            /// Network domain name
            /// </summary>
            [DisplayName("Domain Name")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("domain_name")]
            public string domain_name { get; set; }

            /// <summary>
            /// If the network is enabled
            /// </summary>
            [DisplayName("Enabled?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("enabled")]
            public bool enabled { get; set; }

            /// <summary>
            /// Network gateway IP
            /// </summary>
            [DisplayName("Gateway IP")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("ip")]
            public string ip { get; set; }

            /// <summary>
            /// Network subnet
            /// </summary>
            [DisplayName("Subnet")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("ip_subnet")]
            public string ip_subnet { get; set; }

            /// <summary>
            /// If the network is a guest network
            /// </summary>
            [DisplayName("Guest Network?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("is_guest")]
            public bool is_guest { get; set; }

            /// <summary>
            /// If the network uses Network Address Translation
            /// </summary>
            [DisplayName("NAT?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("is_nat")]
            public bool is_nat { get; set; }

            /// <summary>
            /// Network MAC address (of gateway?)
            /// </summary>
            [DisplayName("MAC Address")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("mac")]
            public string mac { get; set; }

            /// <summary>
            /// Network name
            /// </summary>
            [DisplayName("Name")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("name")]
            public string name { get; set; }

            // TODO
            [JsonProperty("networkgroup")]
            public string networkgroup { get; set; }

            /// <summary>
            /// Number of total clients connected to this network
            /// </summary>
            [DisplayName("# Clients")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("num_sta")]
            public int num_sta { get; set; }
            
            // TODO
            [JsonProperty("purpose")]
            public string purpose { get; set; }

            /// <summary>
            /// Number of bytes received on network
            /// </summary>
            [DisplayName("RX Bytes")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("rx_bytes")]
            public long rx_bytes { get; set; }

            /// <summary>
            /// Number of packets received on network
            /// </summary>
            [DisplayName("RX Packets")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_packets")]
            public long rx_packets { get; set; }

            /// <summary>
            /// Site ID controlling network
            /// </summary>
            [DisplayName("Site ID")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("site_id")]
            public string site_id { get; set; }

            /// <summary>
            /// Number of bytes sent on network
            /// </summary>
            [DisplayName("TX Bytes")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("tx_bytes")]
            public long tx_bytes { get; set; }

            /// <summary>
            /// Number of packets sent on network
            /// </summary>
            [DisplayName("TX Packets")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_packets")]
            public long tx_packets { get; set; }

            /// <summary>
            /// If the network is up
            /// </summary>
            [DisplayName("Up?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("up")]
            public bool up { get; set; }

            /// <summary>
            /// VLAN ID for this network
            /// </summary>
            [DisplayName("VLAN ID")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("vlan")]
            public int? vlan { get; set; }

            /// <summary>
            /// If a VLAN is enabled on this network
            /// </summary>
            [DisplayName("VLAN?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("vlan_enabled")]
            public bool vlan_enabled { get; set; }

            // TODO
            [JsonProperty("attr_hidden_id")]
            public string attr_hidden_id { get; set; }

            // TODO
            [JsonProperty("attr_no_delete")]
            public bool? attr_no_delete { get; set; }
        }

        /// <summary>
        /// MAC Address Information
        /// </summary>
        [DisplayName("MAC Address Information")]
        public class JsonMacTable : IJsonObject
        {
            /// <summary>
            /// Age of MAC Address on network
            /// </summary>
            [DisplayName("Age")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("age")]
            public int age { get; set; }

            /// <summary>
            /// MAC Address
            /// </summary>
            [DisplayName("MAC Address")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("mac")]
            public string mac { get; set; }

            // TODO
            [JsonProperty("static")]
            public bool IsStatic { get; set; }

            /// <summary>
            /// Uptime of device by MAC
            /// </summary>
            [DisplayName("Uptime")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("uptime")]
            public int uptime { get; set; }

            /// <summary>
            /// VLAN the device is attached to
            /// </summary>
            [DisplayName("VLAN")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("vlan")]
            public int vlan { get; set; }
        }

        /// <summary>
        /// Link Layer Discovery Protocol Configuration
        /// </summary>
        [DisplayName("Link Layer Discovery Protocol Configuration")]
        public class JsonLldpTable : IJsonObject
        {
            /// <summary>
            /// LLDP Chassis ID
            /// </summary>
            [DisplayName("Chassis ID")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("lldp_chassis_id")]
            public string lldp_chassis_id { get; set; }

            /// <summary>
            /// LLDP Chassis ID
            /// </summary>
            [DisplayName("Port ID")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("lldp_port_id")]
            public string lldp_port_id { get; set; }

            /// <summary>
            /// LLDP Chassis ID
            /// </summary>
            [DisplayName("System Name")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("lldp_system_name")]
            public string lldp_system_name { get; set; }
        }
        
        /// <summary>
        /// Port Table Information
        /// </summary>
        [DisplayName("Port Table Information")]
        public class JsonPortTable : IJsonObject
        {
            /// <summary>
            /// DNS Nameservers
            /// </summary>
            [DisplayName("Nameservers")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("dns")]
            public IList<string> dns { get; set; }

            /// <summary>
            /// If the port is enabled
            /// </summary>
            [DisplayName("Enabled?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("enable")]
            public bool enable { get; set; }

            /// <summary>
            /// If the port negotiated a full-duplex link
            /// </summary>
            [DisplayName("Full Duplex?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("full_duplex")]
            public bool full_duplex { get; set; }

            /// <summary>
            /// Gateway IP address
            /// </summary>
            [DisplayName("Gateway")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("gateway")]
            public string gateway { get; set; }

            // TODO
            [JsonProperty("ifname")]
            public string ifname { get; set; }

            /// <summary>
            /// Device IP Address
            /// </summary>
            [DisplayName("IP Address")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("ip")]
            public string ip { get; set; }

            /// <summary>
            /// Device MAC Address
            /// </summary>
            [DisplayName("MAC Address")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("mac")]
            public string mac { get; set; }

            /// <summary>
            /// Port name
            /// </summary>
            [DisplayName("Name")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("name")]
            public string name { get; set; }

            /// <summary>
            /// Subnet mask
            /// </summary>
            [DisplayName("Subnet")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("netmask")]
            public string netmask { get; set; }

            /// <summary>
            /// Number of bytes received on port
            /// </summary>
            [DisplayName("RX Bytes")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("rx_bytes")]
            public object rx_bytes { get; set; }

            /// <summary>
            /// Number of dropped frames received on port
            /// </summary>
            [DisplayName("RX Dropped")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_dropped")]
            public long rx_dropped { get; set; }

            /// <summary>
            /// Number of errors received on port
            /// </summary>
            [DisplayName("RX Errors")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_errors")]
            public long rx_errors { get; set; }

            // TODO
            [JsonProperty("rx_multicast")]
            public long rx_multicast { get; set; }

            /// <summary>
            /// Number of packets received on port
            /// </summary>
            [DisplayName("RX Packets")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_packets")]
            public long rx_packets { get; set; }

            /// <summary>
            /// Negotiated port speed
            /// </summary>
            [DisplayName("Speed")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("speed")]
            public int speed { get; set; }

            /// <summary>
            /// Number of bytes sent on port
            /// </summary>
            [DisplayName("TX Bytes")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("tx_bytes")]
            public object tx_bytes { get; set; }

            /// <summary>
            /// Number of dropped frames sent on port
            /// </summary>
            [DisplayName("TX Dropped")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_dropped")]
            public int tx_dropped { get; set; }

            /// <summary>
            /// Number of errors sent on port
            /// </summary>
            [DisplayName("TX Errors")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_errors")]
            public int tx_errors { get; set; }

            /// <summary>
            /// Number of packets sent on port
            /// </summary>
            [DisplayName("TX Packets")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_packets")]
            public long tx_packets { get; set; }

            /// <summary>
            /// If the port is up
            /// </summary>
            [DisplayName("Up?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("up")]
            public bool up { get; set; }

            /// <summary>
            /// If the port is part of an aggregation
            /// </summary>
            [DisplayName("Aggregated?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("aggregated_by")]
            public bool? aggregated_by { get; set; }

            // TODO
            [JsonProperty("attr_no_edit")]
            public bool? attr_no_edit { get; set; }

            /// <summary>
            /// If the port auto-negotiates speed
            /// </summary>
            [DisplayName("Autonegotiate?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("autoneg")]
            public bool? autoneg { get; set; }

            // TODO
            [JsonProperty("bytes-r")]
            public long? bytes_r { get; set; }

            /// <summary>
            /// If flow control is enabled on data received
            /// </summary>
            [DisplayName("RX Flow Control?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("flowctrl_rx")]
            public bool? flowctrl_rx { get; set; }

            /// <summary>
            /// If flow control is enabled on data sent
            /// </summary>
            [DisplayName("TX Flow Control?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("flowctrl_tx")]
            public bool? flowctrl_tx { get; set; }

            /// <summary>
            /// If the port is an uplink to a parent device
            /// </summary>
            [DisplayName("Uplink?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("is_uplink")]
            public bool? is_uplink { get; set; }

            /// <summary>
            /// If jumbo frames are enabled
            /// </summary>
            [DisplayName("Jumbo Frames?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("jumbo")]
            public bool? jumbo { get; set; }

            // TODO
            [JsonProperty("mac_table")]
            public IList<JsonMacTable> mac_table { get; set; }

            // TODO
            [JsonProperty("masked")]
            public bool? masked { get; set; }

            // TODO
            [JsonProperty("media")]
            public string media { get; set; }

            // TODO
            [JsonProperty("op_mode")]
            public string op_mode { get; set; }

            // TODO
            [JsonProperty("poe_caps")]
            public int? poe_caps { get; set; }

            /// <summary>
            /// Port index
            /// </summary>
            [DisplayName("Port Index")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("port_idx")]
            public int? port_idx { get; set; }

            /// <summary>
            /// If power-over-ethernet is enabled on this port
            /// </summary>
            [DisplayName("POE?")]
            [Group(GROUP_POE)]
            [ShowWith(Levels.Basic)]
            [JsonProperty("port_poe")]
            public bool? port_poe { get; set; }

            // TODO
            [JsonProperty("portconf_id")]
            public string portconf_id { get; set; }

            /// <summary>
            /// Number of broadcast frames received on port
            /// </summary>
            [DisplayName("RX Broadcast")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_broadcast")]
            public int? rx_broadcast { get; set; }

            // TODO
            [JsonProperty("rx_bytes-r")]
            public long? rx_bytes_r { get; set; }

            /// <summary>
            /// Path cost for Spanning Tree Protocol
            /// </summary>
            [DisplayName("STP Path Cost")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stp_pathcost")]
            public int? stp_pathcost { get; set; }

            /// <summary>
            /// Spanning Tree Protocol State
            /// </summary>
            [DisplayName("STP State")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stp_state")]
            public string stp_state { get; set; }

            /// <summary>
            /// Number of broadcast frames transmitted on port
            /// </summary>
            [DisplayName("TX Broadcast")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_broadcast")]
            public int? tx_broadcast { get; set; }

            // TODO

            [JsonProperty("tx_bytes-r")]
            public long? tx_bytes_r { get; set; }

            /// <summary>
            /// Number of multicast frames transmitted on port
            /// </summary>
            [DisplayName("TX Multicast")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_multicast")]
            public int? tx_multicast { get; set; }

            /// <summary>
            /// Mode for 802.1x authentication
            /// </summary>
            [DisplayName("802.1x Mode")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("dot1x_mode")]
            public string dot1x_mode { get; set; }

            /// <summary>
            /// 802.1x authentication status
            /// </summary>
            [DisplayName("802.1x Status")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("dot1x_status")]
            public string dot1x_status { get; set; }
            
            /// <summary>
            /// If the port is in isolation mode?
            /// </summary>
            [DisplayName("Isolation?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("isolation")]
            public bool? isolation { get; set; }

            // TODO
            [JsonProperty("lldp_table")]
            public IList<JsonLldpTable> lldp_table { get; set; }

            /// <summary>
            /// If Storm Control is enabled for broadcast traffic
            /// </summary>
            [DisplayName("Broadcast Storm Control?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_bcast_enabled")]
            public bool? stormctrl_bcast_enabled { get; set; }

            /// <summary>
            /// If Storm Control is enabled for multicast traffic
            /// </summary>
            [DisplayName("Multicast Storm Control?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_mcast_enabled")]
            public bool? stormctrl_mcast_enabled { get; set; }

            /// <summary>
            /// If Storm Control is enabled for unicast traffic
            /// </summary>
            [DisplayName("Unicast Storm Control?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_ucast_enabled")]
            public bool? stormctrl_ucast_enabled { get; set; }

            /// <summary>
            /// Port index of another port mirroring this one
            /// </summary>
            [DisplayName("Mirror Port")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("mirror_port_idx")]
            public string mirror_port_idx { get; set; }

            /// <summary>
            /// Storm Control Broadcast Rate
            /// </summary>
            [DisplayName("Storm Control Broadcast Rate")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_bcast_rate")]
            public int? stormctrl_bcast_rate { get; set; }

            /// <summary>
            /// Storm Control Multicast Rate
            /// </summary>
            [DisplayName("Storm Control Multicast Rate")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_mcast_rate")]
            public int? stormctrl_mcast_rate { get; set; }

            /// <summary>
            /// Storm Control Unicast Rate
            /// </summary>
            [DisplayName("Storm Control Unicast Rate")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_ucast_rate")]
            public int? stormctrl_ucast_rate { get; set; }

            // TODO
            [JsonProperty("poe_class")]
            public string poe_class { get; set; }

            /// <summary>
            /// Power-over-Ethernet Current
            /// </summary>
            [DisplayName("POE Current")]
            [Group(GROUP_POE)]
            [ShowWith(Levels.Extended)]
            [JsonProperty("poe_current")]
            public string poe_current { get; set; }

            /// <summary>
            /// If Power-over-Ethernet is enabled
            /// </summary>
            [DisplayName("POE?")]
            [Group(GROUP_POE)]
            [ShowWith(Levels.Basic)]
            [JsonProperty("poe_enable")]
            public bool? poe_enable { get; set; }

            // TODO
            [JsonProperty("poe_good")]
            public bool? poe_good { get; set; }

            /// <summary>
            /// Power-over-Ethernet Mode
            /// </summary>
            [DisplayName("POE Mode")]
            [Group(GROUP_POE)]
            [ShowWith(Levels.Extended)]
            [JsonProperty("poe_mode")]
            public string poe_mode { get; set; }

            /// <summary>
            /// Power-over-Ethernet Power
            /// </summary>
            [DisplayName("POE Power")]
            [Group(GROUP_POE)]
            [ShowWith(Levels.Extended)]
            [JsonProperty("poe_power")]
            public string poe_power { get; set; }

            /// <summary>
            /// Power-over-Ethernet Voltage
            /// </summary>
            [DisplayName("POE Voltage")]
            [Group(GROUP_POE)]
            [ShowWith(Levels.Extended)]
            [JsonProperty("poe_voltage")]
            public string poe_voltage { get; set; }
        }

        /// <summary>
        /// Speedtest Status
        /// </summary>
        [DisplayName("Speedtest Status")]
        public class JsonSpeedtestStatus : IJsonObject
        {
            /// <summary>
            /// Speedtest-reported latency
            /// </summary>
            [DisplayName("Latency")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("latency")]
            public int latency { get; set; }

            /// <summary>
            /// Date of the test run
            /// </summary>
            [DisplayName("Date")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("rundate")]
            public int rundate { get; set; }

            /// <summary>
            /// Time of the test run
            /// </summary>
            [DisplayName("Time")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("runtime")]
            public int runtime { get; set; }

            // TODO
            [JsonProperty("status_download")]
            public int status_download { get; set; }

            // TODO
            [JsonProperty("status_ping")]
            public int status_ping { get; set; }

            // TODO
            [JsonProperty("status_summary")]
            public int status_summary { get; set; }

            // TODO
            [JsonProperty("status_upload")]
            public int status_upload { get; set; }

            /// <summary>
            /// Download throughput
            /// </summary>
            [DisplayName("Download Throughput")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("xput_download")]
            public double xput_download { get; set; }

            /// <summary>
            /// Upload throughput
            /// </summary>
            [DisplayName("Upload Throughput")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("xput_upload")]
            public double xput_upload { get; set; }
        }

        /// <summary>
        /// System stats
        /// </summary>
        [DisplayName("System Stats")]
        public class JsonSysStats : IJsonObject
        {
            /// <summary>
            /// System load average over the past 1 minute
            /// </summary>
            [DisplayName("Load Avg 1m")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("loadavg_1")]
            public double? loadavg_1 { get; set; }

            /// <summary>
            /// System load average over the past 15 minutes
            /// </summary>
            [DisplayName("Load Avg 15m")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("loadavg_15")]
            public double? loadavg_15 { get; set; }

            /// <summary>
            /// System load average over the past 5 minutes
            /// </summary>
            [DisplayName("Load Avg 5m")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("loadavg_5")]
            public double? loadavg_5 { get; set; }

            /// <summary>
            /// Memory usage for buffers
            /// </summary>
            [DisplayName("Memory Used (Buffers)")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("mem_buffer")]
            public long? mem_buffer { get; set; }

            /// <summary>
            /// Total memory available
            /// </summary>
            [DisplayName("Memory Available")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("mem_total")]
            public long? mem_total { get; set; }

            /// <summary>
            /// Total memory usage
            /// </summary>
            [DisplayName("Memory Used")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("mem_used")]
            public long? mem_used { get; set; }
        }

        /// <summary>
        /// Logical link between two devices
        /// </summary>
        [DisplayName("Link")]
        public class JsonLink : IJsonObject
        {
            // TODO
            [JsonProperty("bytes-r")]
            public long bytes_r { get; set; }

            // TODO
            [JsonProperty("drops")]
            public int drops { get; set; }

            /// <summary>
            /// If the link is enabled
            /// </summary>
            [DisplayName("Enabled?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("enable")]
            public bool enable { get; set; }

            /// <summary>
            /// If the link is a full-duplex connection
            /// </summary>
            [DisplayName("Full-Duplex?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("full_duplex")]
            public bool full_duplex { get; set; }

            /// <summary>
            /// A list of gateways used by the link
            /// </summary>
            [DisplayName("Gateways")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("gateways")]
            public IList<string> gateways { get; set; }

            /// <summary>
            /// IP address at the other end of the link
            /// </summary>
            [DisplayName("IP Address")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("ip")]
            public string ip { get; set; }

            /// <summary>
            /// Latency on the link
            /// </summary>
            [DisplayName("Latency")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("latency")]
            public int latency { get; set; }

            /// <summary>
            /// MAC address at the other end of the link
            /// </summary>
            [DisplayName("MAC Address")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("mac")]
            public string mac { get; set; }

            /// <summary>
            /// Maximum link speed (negotiated)
            /// </summary>
            [DisplayName("Max Speed")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("max_speed")]
            public int max_speed { get; set; }

            /// <summary>
            /// Name of the link
            /// </summary>
            [DisplayName("Name")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("name")]
            public string name { get; set; }

            /// <summary>
            /// DNS nameservers associated with the link
            /// </summary>
            [DisplayName("Nameservers")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("nameservers")]
            public IList<string> nameservers { get; set; }

            /// <summary>
            /// Subnet mask of the link
            /// </summary>
            [DisplayName("Subnet")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("netmask")]
            public string netmask { get; set; }

            /// <summary>
            /// Port number which is connected
            /// </summary>
            [DisplayName("Port Number")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("num_port")]
            public int num_port { get; set; }

            /// <summary>
            /// Number of bytes received on link
            /// </summary>
            [DisplayName("RX Bytes")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("rx_bytes")]
            public object rx_bytes { get; set; }

            // TODO
            [JsonProperty("rx_bytes-r")]
            public long rx_bytes_r { get; set; }

            /// <summary>
            /// Number of dropped frames received on link
            /// </summary>
            [DisplayName("RX Dropped")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_dropped")]
            public long rx_dropped { get; set; }

            /// <summary>
            /// Number of errors received on link
            /// </summary>
            [DisplayName("RX Errors")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_errors")]
            public long rx_errors { get; set; }

            // TODO
            [JsonProperty("rx_multicast")]
            public long rx_multicast { get; set; }

            /// <summary>
            /// Number of packets received on link
            /// </summary>
            [DisplayName("RX Packets")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_packets")]
            public long rx_packets { get; set; }

            /// <summary>
            /// Link speed
            /// </summary>
            [DisplayName("Speed")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("speed")]
            public int speed { get; set; }

            // TODO
            [JsonProperty("speedtest_lastrun")]
            public int speedtest_lastrun { get; set; }

            // TODO
            [JsonProperty("speedtest_ping")]
            public int speedtest_ping { get; set; }

            // TODO
            [JsonProperty("speedtest_status")]
            public string speedtest_status { get; set; }

            /// <summary>
            /// Number of bytes sent on port
            /// </summary>
            [DisplayName("TX Bytes")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("tx_bytes")]
            public object tx_bytes { get; set; }

            // TODO
            [JsonProperty("tx_bytes-r")]
            public long tx_bytes_r { get; set; }

            /// <summary>
            /// Number of dropped frames sent on port
            /// </summary>
            [DisplayName("TX Dropped")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_dropped")]
            public int tx_dropped { get; set; }

            /// <summary>
            /// Number of errors sent on port
            /// </summary>
            [DisplayName("TX Errors")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_errors")]
            public int tx_errors { get; set; }

            /// <summary>
            /// Number of packets sent on port
            /// </summary>
            [DisplayName("TX Packets")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_packets")]
            public long tx_packets { get; set; }

            // TODO
            [JsonProperty("type")]
            public string type { get; set; }

            /// <summary>
            /// If the link is up
            /// </summary>
            [DisplayName("Up?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("up")]
            public bool up { get; set; }

            /// <summary>
            /// Link uptime
            /// </summary>
            [DisplayName("Uptime")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("uptime")]
            public int uptime { get; set; }

            /// <summary>
            /// Download throughput
            /// </summary>
            [DisplayName("Throughput Down")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("xput_down")]
            public double xput_down { get; set; }

            /// <summary>
            /// Upload throughput
            /// </summary>
            [DisplayName("Throughput Up")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("xput_up")]
            public double xput_up { get; set; }

            /// <summary>
            /// Uplink MAC Address
            /// </summary>
            [DisplayName("Uplink MAC")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("uplink_mac")]
            public string uplink_mac { get; set; }

            /// <summary>
            /// Port on uplink device that this device is connected to
            /// </summary>
            [DisplayName("Uplink Remote Port")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("uplink_remote_port")]
            public int? uplink_remote_port { get; set; }

            // TODO
            [JsonProperty("media")]
            public string media { get; set; }

            /// <summary>
            /// Link port index
            /// </summary>
            [DisplayName("Port Index")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("port_idx")]
            public int? port_idx { get; set; }

            /// <summary>
            /// DNS Nameservers used
            /// </summary>
            [DisplayName("Nameservers")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("dns")]
            public IList<string> dns { get; set; }

            /// <summary>
            /// Gateway IP
            /// </summary>
            [DisplayName("Gateway")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("gateway")]
            public string gateway { get; set; }

            // TODO
            [JsonProperty("ifname")]
            public string ifname { get; set; }
        }

        /// <summary>
        /// Information on the wireless radio
        /// </summary>
        [DisplayName("WLAN Radio")]
        public class JsonRadioTable : IJsonObject
        {
            /// <summary>
            /// Radio antenna gain (incl. external)
            /// </summary>
            [DisplayName("Gain")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("antenna_gain")]
            public int antenna_gain { get; set; }

            /// <summary>
            /// Radio antenna gain for builtin antenna
            /// </summary>
            [DisplayName("Builtin Gain")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("builtin_ant_gain")]
            public int builtin_ant_gain { get; set; }

            /// <summary>
            /// If the radio has a builtin antenna
            /// </summary>
            [DisplayName("Builtin Antenna?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("builtin_antenna")]
            public bool builtin_antenna { get; set; }

            /// <summary>
            /// Radio broadcasting channel
            /// </summary>
            [DisplayName("Channel")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("channel")]
            public string channel { get; set; }

            // TODO
            [JsonProperty("ht")]
            public int ht { get; set; }

            /// <summary>
            /// Maximum transmit power to maintain connection to radio
            /// </summary>
            [DisplayName("Max TX Power")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("max_txpower")]
            public int max_txpower { get; set; }

            /// <summary>
            /// If radio implements Minimum RSSI against clients
            /// </summary>
            [DisplayName("Min RSSI?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("min_rssi_enabled")]
            public bool min_rssi_enabled { get; set; }

            /// <summary>
            /// Minimum transmit power to maintain connection to radio
            /// </summary>
            [DisplayName("Min TX Power")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("min_txpower")]
            public int min_txpower { get; set; }

            /// <summary>
            /// Radio name
            /// </summary>
            [DisplayName("Name")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("name")]
            public string name { get; set; }

            // TODO
            [JsonProperty("nss")]
            public int nss { get; set; }

            // TODO
            [JsonProperty("radio")]
            public string radio { get; set; }

            /// <summary>
            /// Transmit power mode
            /// </summary>
            [DisplayName("TX Power Mode")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_power_mode")]
            public string tx_power_mode { get; set; }

            /// <summary>
            /// If the radio has a hard noise floor
            /// </summary>
            [DisplayName("Hard Noise Floor?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("hard_noise_floor_enabled")]
            public bool? hard_noise_floor_enabled { get; set; }

            /// <summary>
            /// If the radio uses DFS (Dynamic Frequency Selection) channels
            /// </summary>
            [DisplayName("DFS?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("has_dfs")]
            public bool? has_dfs { get; set; }

            /// <summary>
            /// If the radio uses FCC DFS (Dynamic Frequency Selection) channels
            /// </summary>
            [DisplayName("FCC DFS?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("has_fccdfs")]
            public bool? has_fccdfs { get; set; }

            /// <summary>
            /// If the radio is a Wireless-AC radio
            /// </summary>
            [DisplayName("AC Radio?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("is_11ac")]
            public bool? is_11ac { get; set; }
        }

        /// <summary>
        /// Information on the Virtual Access Point
        /// </summary>
        [DisplayName("Virtual AP")]
        public class JsonVapTable : IJsonObject
        {
            /// <summary>
            /// MAC Address of the AP
            /// </summary>
            [DisplayName("AP MAC")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("ap_mac")]
            public string ap_mac { get; set; }

            /// <summary>
            /// BSSID for this VAP
            /// </summary>
            [DisplayName("BSSID")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("bssid")]
            public string bssid { get; set; }

            /// <summary>
            /// CCQ (Client Connection Quality) measurement; this is deprecated in newer UniFi firmware
            /// </summary>
            [DisplayName("CCQ")]
            [ShowWith(Levels.All)]
            [JsonProperty("ccq")]
            public int ccq { get; set; }

            /// <summary>
            /// VAP Channel
            /// </summary>
            [DisplayName("Channel")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("channel")]
            public int channel { get; set; }

            /// <summary>
            /// ESSID for this VAP
            /// </summary>
            [DisplayName("ESSID")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("essid")]
            public string essid { get; set; }

            /// <summary>
            /// VAP ID
            /// </summary>
            [DisplayName("ID")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("id")]
            public string id { get; set; }

            /// <summary>
            /// If the VAP is a guest network
            /// </summary>
            [DisplayName("Guest?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("is_guest")]
            public bool is_guest { get; set; }

            /// <summary>
            /// If WEP is enabled on VAP
            /// </summary>
            [DisplayName("WEP?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("is_wep")]
            public bool is_wep { get; set; }

            [JsonProperty("map_id")]
            public string map_id { get; set; }

            /// <summary>
            /// VAP Name
            /// </summary>
            [DisplayName("Name")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("name")]
            public string name { get; set; }

            /// <summary>
            /// Number of total clients connected to this VAP
            /// </summary>
            [DisplayName("# Clients")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("num_sta")]
            public int num_sta { get; set; }

            /// <summary>
            /// Radio being used for this VAP
            /// </summary>
            [DisplayName("Radio")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("radio")]
            public string radio { get; set; }

            /// <summary>
            /// Number of bytes received on VAP
            /// </summary>
            [DisplayName("RX Bytes")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("rx_bytes")]
            public long rx_bytes { get; set; }

            // TODO
            [JsonProperty("rx_crypts")]
            public int rx_crypts { get; set; }

            /// <summary>
            /// Number of dropped frames received on VAP
            /// </summary>
            [DisplayName("RX Dropped")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_dropped")]
            public long rx_dropped { get; set; }

            /// <summary>
            /// Number of errors received on VAP
            /// </summary>
            [DisplayName("RX Errors")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_errors")]
            public long rx_errors { get; set; }

            /// <summary>
            /// Number of fragments received on VAP
            /// </summary>
            [DisplayName("RX Fragments")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_frags")]
            public int rx_frags { get; set; }

            // TODO
            [JsonProperty("rx_nwids")]
            public int rx_nwids { get; set; }

            /// <summary>
            /// Number of packets received on VAP
            /// </summary>
            [DisplayName("RX Packets")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("rx_packets")]
            public int rx_packets { get; set; }

            /// <summary>
            /// Site ID controlling VAP
            /// </summary>
            [DisplayName("Site ID")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("site_id")]
            public string site_id { get; set; }

            /// <summary>
            /// VAP State
            /// </summary>
            [DisplayName("State")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("state")]
            public string state { get; set; }

            // TODO
            [JsonProperty("t")]
            public string t { get; set; }

            /// <summary>
            /// Number of bytes sent on VAP
            /// </summary>
            [DisplayName("TX Bytes")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("tx_bytes")]
            public long tx_bytes { get; set; }

            /// <summary>
            /// Number of dropped frames sent on VAP
            /// </summary>
            [DisplayName("TX Dropped")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_dropped")]
            public int tx_dropped { get; set; }

            /// <summary>
            /// Number of errors sent on VAP
            /// </summary>
            [DisplayName("TX Errors")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_errors")]
            public int tx_errors { get; set; }

            /// <summary>
            /// Number of packets sent on VAP
            /// </summary>
            [DisplayName("TX Packets")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_packets")]
            public long tx_packets { get; set; }

            /// <summary>
            /// Transmit power for this VAP
            /// </summary>
            [DisplayName("Transmit Power")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("tx_power")]
            public int tx_power { get; set; }

            /// <summary>
            /// Number of retries sent on this VAP
            /// </summary>
            [DisplayName("TX Retries")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("tx_retries")]
            public int tx_retries { get; set; }

            /// <summary>
            /// If the VAP is up
            /// </summary>
            [DisplayName("Up?")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("up")]
            public bool up { get; set; }

            // TODO
            [JsonProperty("usage")]
            public string usage { get; set; }

            /// <summary>
            /// WLAN Configuration ID
            /// </summary>
            [DisplayName("WLAN Configuration ID")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("wlanconf_id")]
            public string wlanconf_id { get; set; }

            // TODO
            [JsonProperty("extchannel")]
            public int? extchannel { get; set; }
        }

        /// <summary>
        /// Port override configuration
        /// </summary>
        [DisplayName("Port Override")]
        public class JsonPortOverride : IJsonObject
        {
            /// <summary>
            /// If autonegotiation is enabled
            /// </summary>
            [DisplayName("Autonegotiate?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("autoneg")]
            public bool autoneg { get; set; }

            /// <summary>
            /// If port is isolated
            /// </summary>
            [DisplayName("Isolated?")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("isolation")]
            public bool isolation { get; set; }

            /// <summary>
            /// Port name
            /// </summary>
            [DisplayName("Name")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("name")]
            public string name { get; set; }

            // TODO
            [JsonProperty("op_mode")]
            public string op_mode { get; set; }

            /// <summary>
            /// Port Index
            /// </summary>
            [DisplayName("Port Index")]
            [ShowWith(Levels.Minimal)]
            [JsonProperty("port_idx")]
            public int port_idx { get; set; }

            // TODO
            [JsonProperty("portconf_id")]
            public string portconf_id { get; set; }

            /// <summary>
            /// If Storm Control is enabled for broadcast traffic
            /// </summary>
            [DisplayName("Broadcast Storm Control?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_bcast_enabled")]
            public bool? stormctrl_bcast_enabled { get; set; }

            /// <summary>
            /// If Storm Control is enabled for multicast traffic
            /// </summary>
            [DisplayName("Multicast Storm Control?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_mcast_enabled")]
            public bool? stormctrl_mcast_enabled { get; set; }

            /// <summary>
            /// If Storm Control is enabled for unicast traffic
            /// </summary>
            [DisplayName("Unicast Storm Control?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_ucast_enabled")]
            public bool? stormctrl_ucast_enabled { get; set; }

            /// <summary>
            /// If the port negotiated a full-duplex link
            /// </summary>
            [DisplayName("Full Duplex?")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("full_duplex")]
            public bool? full_duplex { get; set; }

            /// <summary>
            /// Port index of another port mirroring this one
            /// </summary>
            [DisplayName("Mirror Port")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("mirror_port_idx")]
            public string mirror_port_idx { get; set; }

            /// <summary>
            /// Storm Control Broadcast Rate
            /// </summary>
            [DisplayName("Storm Control Broadcast Rate")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_bcast_rate")]
            public int? stormctrl_bcast_rate { get; set; }

            /// <summary>
            /// Storm Control Multicast Rate
            /// </summary>
            [DisplayName("Storm Control Multicast Rate")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_mcast_rate")]
            public int? stormctrl_mcast_rate { get; set; }

            /// <summary>
            /// Storm Control Unicast Rate
            /// </summary>
            [DisplayName("Storm Control Unicast Rate")]
            [ShowWith(Levels.Extended)]
            [JsonProperty("stormctrl_ucast_rate")]
            public int? stormctrl_ucast_rate { get; set; }

            /// <summary>
            /// Power-over-Ethernet Mode
            /// </summary>
            [DisplayName("POE Mode")]
            [ShowWith(Levels.Basic)]
            [JsonProperty("poe_mode")]
            public string poe_mode { get; set; }
        }
    }
}
