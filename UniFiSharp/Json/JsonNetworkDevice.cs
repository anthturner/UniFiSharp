using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniFiSharp.Json
{
    public partial class JsonNetworkDevice
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("_uptime")]
        public int _uptime { get; set; }

        [JsonProperty("adopted")]
        public bool adopted { get; set; }

        [JsonProperty("bytes")]
        public object bytes { get; set; }

        [JsonProperty("cfgversion")]
        public string cfgversion { get; set; }

        [JsonProperty("config_network")]
        public JsonConfigNetwork config_network { get; set; }

        [JsonProperty("config_network_wan")]
        public JsonConfigNetwork config_network_wan { get; set; }

        [JsonProperty("connect_request_ip")]
        public string connect_request_ip { get; set; }

        [JsonProperty("connect_request_port")]
        public string connect_request_port { get; set; }

        [JsonProperty("considered_lost_at")]
        public int considered_lost_at { get; set; }

        [JsonProperty("default")]
        public bool defaultSettings { get; set; }

        [JsonProperty("device_id")]
        public string device_id { get; set; }

        [JsonProperty("ethernet_table")]
        public IList<JsonEthernetTable> ethernet_table { get; set; }

        [JsonProperty("fw_caps")]
        public int fw_caps { get; set; }

        [JsonProperty("guest-num_sta")]
        public int guest_num_sta { get; set; }

        [JsonProperty("guest_token")]
        public string guest_token { get; set; }

        [JsonProperty("has_default_route_distance")]
        public bool has_default_route_distance { get; set; }

        [JsonProperty("has_dpi")]
        public bool has_dpi { get; set; }

        [JsonProperty("has_porta")]
        public bool has_porta { get; set; }

        [JsonProperty("has_vti")]
        public bool has_vti { get; set; }

        [JsonProperty("inform_authkey")]
        public string inform_authkey { get; set; }

        [JsonProperty("inform_ip")]
        public string inform_ip { get; set; }

        [JsonProperty("inform_url")]
        public string inform_url { get; set; }

        [JsonProperty("ip")]
        public string ip { get; set; }

        [JsonProperty("known_cfgversion")]
        public string known_cfgversion { get; set; }

        [JsonProperty("last_seen")]
        public int last_seen { get; set; }

        [JsonProperty("license_state")]
        public string license_state { get; set; }

        [JsonProperty("locating")]
        public bool locating { get; set; }

        [JsonProperty("mac")]
        public string mac { get; set; }

        [JsonProperty("map_id")]
        public string map_id { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("network_table")]
        public IList<JsonNetworkTable> network_table { get; set; }

        [JsonProperty("next_heartbeat_at")]
        public int next_heartbeat_at { get; set; }

        [JsonProperty("num_desktop")]
        public int num_desktop { get; set; }

        [JsonProperty("num_handheld")]
        public int num_handheld { get; set; }

        [JsonProperty("num_mobile")]
        public int num_mobile { get; set; }

        [JsonProperty("num_sta")]
        public int num_sta { get; set; }

        [JsonProperty("port_table")]
        public IList<JsonPortTable> port_table { get; set; }

        [JsonProperty("radius_caps")]
        public int radius_caps { get; set; }

        [JsonProperty("rx_bytes")]
        public long rx_bytes { get; set; }

        [JsonProperty("serial")]
        public string serial { get; set; }

        [JsonProperty("site_id")]
        public string site_id { get; set; }

        [JsonProperty("speedtest-status")]
        public JsonSpeedtestStatus speedtest_status { get; set; }

        [JsonProperty("speedtest-status-saved")]
        public bool speedtest_status_saved { get; set; }

        [JsonProperty("state")]
        public int state { get; set; }

        [JsonProperty("sys_stats")]
        public JsonSysStats sys_stats { get; set; }

        [JsonProperty("tx_bytes")]
        public long tx_bytes { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("uplink")]
        public JsonLink uplink { get; set; }

        [JsonProperty("uptime")]
        public int uptime { get; set; }

        [JsonProperty("user-num_sta")]
        public int user_num_sta { get; set; }

        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("wan1")]
        public JsonLink wan1 { get; set; }

        [JsonProperty("x")]
        public double x { get; set; }

        [JsonProperty("y")]
        public double y { get; set; }

        [JsonProperty("board_rev")]
        public int? board_rev { get; set; }

        [JsonProperty("bytes-d")]
        public int? bytes_d { get; set; }

        [JsonProperty("bytes-r")]
        public long? bytes_r { get; set; }

        [JsonProperty("downlink_table")]
        public IList<JsonLink> downlink_table { get; set; }

        [JsonProperty("has_eth1")]
        public bool? has_eth1 { get; set; }

        [JsonProperty("has_speaker")]
        public bool? has_speaker { get; set; }

        [JsonProperty("volume")]
        public int volume { get; set; }

        [JsonProperty("isolated")]
        public bool? isolated { get; set; }

        [JsonProperty("last_uplink")]
        public JsonLink last_uplink { get; set; }

        [JsonProperty("led_override")]
        public string led_override { get; set; }

        [JsonProperty("na-channel")]
        public int? na_channel { get; set; }

        [JsonProperty("na-eirp")]
        public int? na_eirp { get; set; }

        [JsonProperty("na-extchannel")]
        public int? na_extchannel { get; set; }

        [JsonProperty("na-gain")]
        public int? na_gain { get; set; }

        [JsonProperty("na-guest-num_sta")]
        public int? na_guest_num_sta { get; set; }

        [JsonProperty("na-num_sta")]
        public int? na_num_sta { get; set; }

        [JsonProperty("na-state")]
        public string na_state { get; set; }

        [JsonProperty("na-tx_power")]
        public int? na_tx_power { get; set; }

        [JsonProperty("na-user-num_sta")]
        public int? na_user_num_sta { get; set; }

        [JsonProperty("na_ast_be_xmit")]
        public int? na_ast_be_xmit { get; set; }

        [JsonProperty("na_ast_cst")]
        public object na_ast_cst { get; set; }

        [JsonProperty("na_ast_txto")]
        public object na_ast_txto { get; set; }

        [JsonProperty("na_cu_self_rx")]
        public int? na_cu_self_rx { get; set; }

        [JsonProperty("na_cu_self_tx")]
        public int? na_cu_self_tx { get; set; }

        [JsonProperty("na_cu_total")]
        public int? na_cu_total { get; set; }

        [JsonProperty("na_last_interference_at")]
        public int? na_last_interference_at { get; set; }

        [JsonProperty("na_tx_packets")]
        public int? na_tx_packets { get; set; }

        [JsonProperty("na_tx_retries")]
        public int? na_tx_retries { get; set; }

        [JsonProperty("ng-channel")]
        public int? ng_channel { get; set; }

        [JsonProperty("ng-eirp")]
        public int? ng_eirp { get; set; }

        [JsonProperty("ng-extchannel")]
        public int? ng_extchannel { get; set; }

        [JsonProperty("ng-gain")]
        public int? ng_gain { get; set; }

        [JsonProperty("ng-guest-num_sta")]
        public int? ng_guest_num_sta { get; set; }

        [JsonProperty("ng-num_sta")]
        public int? ng_num_sta { get; set; }

        [JsonProperty("ng-state")]
        public string ng_state { get; set; }

        [JsonProperty("ng-tx_power")]
        public int? ng_tx_power { get; set; }

        [JsonProperty("ng-user-num_sta")]
        public int? ng_user_num_sta { get; set; }

        [JsonProperty("ng_ast_be_xmit")]
        public int? ng_ast_be_xmit { get; set; }

        [JsonProperty("ng_ast_cst")]
        public object ng_ast_cst { get; set; }

        [JsonProperty("ng_ast_txto")]
        public object ng_ast_txto { get; set; }

        [JsonProperty("ng_cu_self_rx")]
        public int? ng_cu_self_rx { get; set; }

        [JsonProperty("ng_cu_self_tx")]
        public int? ng_cu_self_tx { get; set; }

        [JsonProperty("ng_cu_total")]
        public int? ng_cu_total { get; set; }

        [JsonProperty("ng_last_interference_at")]
        public object ng_last_interference_at { get; set; }

        [JsonProperty("ng_tx_packets")]
        public int? ng_tx_packets { get; set; }

        [JsonProperty("ng_tx_retries")]
        public int? ng_tx_retries { get; set; }

        [JsonProperty("radio_na")]
        public JsonRadioTable radio_na { get; set; }

        [JsonProperty("radio_ng")]
        public JsonRadioTable radio_ng { get; set; }

        [JsonProperty("radio_table")]
        public IList<JsonRadioTable> radio_table { get; set; }

        [JsonProperty("rx_bytes-d")]
        public long? rx_bytes_d { get; set; }

        [JsonProperty("scanning")]
        public bool? scanning { get; set; }

        [JsonProperty("spectrum_scanning")]
        public bool? spectrum_scanning { get; set; }

        [JsonProperty("spectrum_table_time_na")]
        public int? spectrum_table_time_na { get; set; }

        [JsonProperty("spectrum_table_time_ng")]
        public int? spectrum_table_time_ng { get; set; }

        [JsonProperty("ssh_session_table")]
        public IList<object> ssh_session_table { get; set; }

        [JsonProperty("tx_bytes-d")]
        public long? tx_bytes_d { get; set; }

        [JsonProperty("uplink_table")]
        public IList<object> uplink_table { get; set; }

        [JsonProperty("vap_table")]
        public IList<JsonVapTable> vap_table { get; set; }

        [JsonProperty("vwireEnabled")]
        public bool? vwireEnabled { get; set; }

        [JsonProperty("vwire_table")]
        public IList<object> vwire_table { get; set; }

        [JsonProperty("wifi_caps")]
        public int? wifi_caps { get; set; }

        [JsonProperty("wlan_overrides")]
        public object wlan_overrides { get; set; }

        [JsonProperty("wlangroup_id_na")]
        public string wlangroup_id_na { get; set; }

        [JsonProperty("wlangroup_id_ng")]
        public string wlangroup_id_ng { get; set; }

        [JsonProperty("dhcp_server_table")]
        public IList<object> dhcp_server_table { get; set; }

        [JsonProperty("dot1x_portctrl_enabled")]
        public bool? dot1x_portctrl_enabled { get; set; }

        [JsonProperty("flowctrl_enabled")]
        public bool? flowctrl_enabled { get; set; }

        [JsonProperty("general_temperature")]
        public int? general_temperature { get; set; }

        [JsonProperty("has_fan")]
        public bool? has_fan { get; set; }

        [JsonProperty("jumboframe_enabled")]
        public bool? jumboframe_enabled { get; set; }

        [JsonProperty("overheating")]
        public bool? overheating { get; set; }

        [JsonProperty("port_overrides")]
        public IList<JsonPortOverride> port_overrides { get; set; }

        [JsonProperty("stp_priority")]
        public string stp_priority { get; set; }

        [JsonProperty("stp_version")]
        public string stp_version { get; set; }

        [JsonProperty("uplink_depth")]
        public int? uplink_depth { get; set; }

        public class JsonConfigNetwork
        {
            [JsonProperty("ip")]
            public string ip { get; set; }

            [JsonProperty("type")]
            public string type { get; set; }
        }

        public class JsonEthernetTable
        {
            [JsonProperty("mac")]
            public string mac { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("num_port")]
            public int num_port { get; set; }
        }

        public class JsonNetworkTable
        {
            [JsonProperty("_id")]
            public string _id { get; set; }

            [JsonProperty("dhcpd_dns_enabled")]
            public bool dhcpd_dns_enabled { get; set; }

            [JsonProperty("dhcpd_enabled")]
            public bool dhcpd_enabled { get; set; }

            [JsonProperty("dhcpd_leasetime")]
            public int dhcpd_leasetime { get; set; }

            [JsonProperty("dhcpd_start")]
            public string dhcpd_start { get; set; }

            [JsonProperty("dhcpd_stop")]
            public string dhcpd_stop { get; set; }

            [JsonProperty("domain_name")]
            public string domain_name { get; set; }

            [JsonProperty("enabled")]
            public bool enabled { get; set; }

            [JsonProperty("ip")]
            public string ip { get; set; }

            [JsonProperty("ip_subnet")]
            public string ip_subnet { get; set; }

            [JsonProperty("is_guest")]
            public bool is_guest { get; set; }

            [JsonProperty("is_nat")]
            public bool is_nat { get; set; }

            [JsonProperty("mac")]
            public string mac { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("networkgroup")]
            public string networkgroup { get; set; }

            [JsonProperty("num_sta")]
            public int num_sta { get; set; }

            [JsonProperty("purpose")]
            public string purpose { get; set; }

            [JsonProperty("rx_bytes")]
            public long rx_bytes { get; set; }

            [JsonProperty("rx_packets")]
            public int rx_packets { get; set; }

            [JsonProperty("site_id")]
            public string site_id { get; set; }

            [JsonProperty("tx_bytes")]
            public long tx_bytes { get; set; }

            [JsonProperty("tx_packets")]
            public long tx_packets { get; set; }

            [JsonProperty("up")]
            public bool up { get; set; }

            [JsonProperty("vlan")]
            public int? vlan { get; set; }

            [JsonProperty("vlan_enabled")]
            public bool vlan_enabled { get; set; }

            [JsonProperty("attr_hidden_id")]
            public string attr_hidden_id { get; set; }

            [JsonProperty("attr_no_delete")]
            public bool? attr_no_delete { get; set; }
        }

        public class JsonMacTable
        {
            [JsonProperty("age")]
            public int age { get; set; }

            [JsonProperty("mac")]
            public string mac { get; set; }

            [JsonProperty("static")]
            public bool IsStatic { get; set; }

            [JsonProperty("uptime")]
            public int uptime { get; set; }

            [JsonProperty("vlan")]
            public int vlan { get; set; }
        }

        public class JsonLldpTable
        {
            [JsonProperty("lldp_chassis_id")]
            public string lldp_chassis_id { get; set; }

            [JsonProperty("lldp_port_id")]
            public string lldp_port_id { get; set; }

            [JsonProperty("lldp_system_name")]
            public string lldp_system_name { get; set; }
        }

        public class JsonPortTable
        {
            [JsonProperty("dns")]
            public IList<string> dns { get; set; }

            [JsonProperty("enable")]
            public bool enable { get; set; }

            [JsonProperty("full_duplex")]
            public bool full_duplex { get; set; }

            [JsonProperty("gateway")]
            public string gateway { get; set; }

            [JsonProperty("ifname")]
            public string ifname { get; set; }

            [JsonProperty("ip")]
            public string ip { get; set; }

            [JsonProperty("mac")]
            public string mac { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("netmask")]
            public string netmask { get; set; }

            [JsonProperty("rx_bytes")]
            public object rx_bytes { get; set; }

            [JsonProperty("rx_dropped")]
            public long rx_dropped { get; set; }

            [JsonProperty("rx_errors")]
            public long rx_errors { get; set; }

            [JsonProperty("rx_multicast")]
            public long rx_multicast { get; set; }

            [JsonProperty("rx_packets")]
            public long rx_packets { get; set; }

            [JsonProperty("speed")]
            public int speed { get; set; }

            [JsonProperty("tx_bytes")]
            public object tx_bytes { get; set; }

            [JsonProperty("tx_dropped")]
            public int tx_dropped { get; set; }

            [JsonProperty("tx_errors")]
            public int tx_errors { get; set; }

            [JsonProperty("tx_packets")]
            public long tx_packets { get; set; }

            [JsonProperty("up")]
            public bool up { get; set; }

            [JsonProperty("aggregated_by")]
            public bool? aggregated_by { get; set; }

            [JsonProperty("attr_no_edit")]
            public bool? attr_no_edit { get; set; }

            [JsonProperty("autoneg")]
            public bool? autoneg { get; set; }

            [JsonProperty("bytes-r")]
            public long? bytes_r { get; set; }

            [JsonProperty("flowctrl_rx")]
            public bool? flowctrl_rx { get; set; }

            [JsonProperty("flowctrl_tx")]
            public bool? flowctrl_tx { get; set; }

            [JsonProperty("is_uplink")]
            public bool? is_uplink { get; set; }

            [JsonProperty("jumbo")]
            public bool? jumbo { get; set; }

            [JsonProperty("mac_table")]
            public IList<JsonMacTable> mac_table { get; set; }

            [JsonProperty("masked")]
            public bool? masked { get; set; }

            [JsonProperty("media")]
            public string media { get; set; }

            [JsonProperty("op_mode")]
            public string op_mode { get; set; }

            [JsonProperty("poe_caps")]
            public int? poe_caps { get; set; }

            [JsonProperty("port_idx")]
            public int? port_idx { get; set; }

            [JsonProperty("port_poe")]
            public bool? port_poe { get; set; }

            [JsonProperty("portconf_id")]
            public string portconf_id { get; set; }

            [JsonProperty("rx_broadcast")]
            public int? rx_broadcast { get; set; }

            [JsonProperty("rx_bytes-r")]
            public long? rx_bytes_r { get; set; }

            [JsonProperty("stp_pathcost")]
            public int? stp_pathcost { get; set; }

            [JsonProperty("stp_state")]
            public string stp_state { get; set; }

            [JsonProperty("tx_broadcast")]
            public int? tx_broadcast { get; set; }

            [JsonProperty("tx_bytes-r")]
            public long? tx_bytes_r { get; set; }

            [JsonProperty("tx_multicast")]
            public int? tx_multicast { get; set; }

            [JsonProperty("dot1x_mode")]
            public string dot1x_mode { get; set; }

            [JsonProperty("dot1x_status")]
            public string dot1x_status { get; set; }

            [JsonProperty("isolation")]
            public bool? isolation { get; set; }

            [JsonProperty("lldp_table")]
            public IList<JsonLldpTable> lldp_table { get; set; }

            [JsonProperty("stormctrl_bcast_enabled")]
            public bool? stormctrl_bcast_enabled { get; set; }

            [JsonProperty("stormctrl_mcast_enabled")]
            public bool? stormctrl_mcast_enabled { get; set; }

            [JsonProperty("stormctrl_ucast_enabled")]
            public bool? stormctrl_ucast_enabled { get; set; }

            [JsonProperty("mirror_port_idx")]
            public string mirror_port_idx { get; set; }

            [JsonProperty("stormctrl_bcast_rate")]
            public int? stormctrl_bcast_rate { get; set; }

            [JsonProperty("stormctrl_mcast_rate")]
            public int? stormctrl_mcast_rate { get; set; }

            [JsonProperty("stormctrl_ucast_rate")]
            public int? stormctrl_ucast_rate { get; set; }

            [JsonProperty("poe_class")]
            public string poe_class { get; set; }

            [JsonProperty("poe_current")]
            public string poe_current { get; set; }

            [JsonProperty("poe_enable")]
            public bool? poe_enable { get; set; }

            [JsonProperty("poe_good")]
            public bool? poe_good { get; set; }

            [JsonProperty("poe_mode")]
            public string poe_mode { get; set; }

            [JsonProperty("poe_power")]
            public string poe_power { get; set; }

            [JsonProperty("poe_voltage")]
            public string poe_voltage { get; set; }
        }

        public class JsonSpeedtestStatus
        {
            [JsonProperty("latency")]
            public int latency { get; set; }

            [JsonProperty("rundate")]
            public int rundate { get; set; }

            [JsonProperty("runtime")]
            public int runtime { get; set; }

            [JsonProperty("status_download")]
            public int status_download { get; set; }

            [JsonProperty("status_ping")]
            public int status_ping { get; set; }

            [JsonProperty("status_summary")]
            public int status_summary { get; set; }

            [JsonProperty("status_upload")]
            public int status_upload { get; set; }

            [JsonProperty("xput_download")]
            public double xput_download { get; set; }

            [JsonProperty("xput_upload")]
            public double xput_upload { get; set; }
        }

        public class JsonSysStats
        {
            [JsonProperty("loadavg_1")]
            public double? loadavg_1 { get; set; }

            [JsonProperty("loadavg_15")]
            public double? loadavg_15 { get; set; }

            [JsonProperty("loadavg_5")]
            public double? loadavg_5 { get; set; }

            [JsonProperty("mem_buffer")]
            public int? mem_buffer { get; set; }

            [JsonProperty("mem_total")]
            public int? mem_total { get; set; }

            [JsonProperty("mem_used")]
            public int? mem_used { get; set; }
        }

        public class JsonLink
        {
            [JsonProperty("bytes-r")]
            public long bytes_r { get; set; }

            [JsonProperty("drops")]
            public int drops { get; set; }

            [JsonProperty("enable")]
            public bool enable { get; set; }

            [JsonProperty("full_duplex")]
            public bool full_duplex { get; set; }

            [JsonProperty("gateways")]
            public IList<string> gateways { get; set; }

            [JsonProperty("ip")]
            public string ip { get; set; }

            [JsonProperty("latency")]
            public int latency { get; set; }

            [JsonProperty("mac")]
            public string mac { get; set; }

            [JsonProperty("max_speed")]
            public int max_speed { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("nameservers")]
            public IList<string> nameservers { get; set; }

            [JsonProperty("netmask")]
            public string netmask { get; set; }

            [JsonProperty("num_port")]
            public int num_port { get; set; }

            [JsonProperty("rx_bytes")]
            public object rx_bytes { get; set; }

            [JsonProperty("rx_bytes-r")]
            public long rx_bytes_r { get; set; }

            [JsonProperty("rx_dropped")]
            public long rx_dropped { get; set; }

            [JsonProperty("rx_errors")]
            public long rx_errors { get; set; }

            [JsonProperty("rx_multicast")]
            public long rx_multicast { get; set; }

            [JsonProperty("rx_packets")]
            public long rx_packets { get; set; }

            [JsonProperty("speed")]
            public int speed { get; set; }

            [JsonProperty("speedtest_lastrun")]
            public int speedtest_lastrun { get; set; }

            [JsonProperty("speedtest_ping")]
            public int speedtest_ping { get; set; }

            [JsonProperty("speedtest_status")]
            public string speedtest_status { get; set; }

            [JsonProperty("tx_bytes")]
            public long tx_bytes { get; set; }

            [JsonProperty("tx_bytes-r")]
            public long tx_bytes_r { get; set; }

            [JsonProperty("tx_dropped")]
            public int tx_dropped { get; set; }

            [JsonProperty("tx_errors")]
            public int tx_errors { get; set; }

            [JsonProperty("tx_packets")]
            public long tx_packets { get; set; }

            [JsonProperty("type")]
            public string type { get; set; }

            [JsonProperty("up")]
            public bool up { get; set; }

            [JsonProperty("uptime")]
            public int uptime { get; set; }

            [JsonProperty("xput_down")]
            public double xput_down { get; set; }

            [JsonProperty("xput_up")]
            public double xput_up { get; set; }

            [JsonProperty("uplink_mac")]
            public string uplink_mac { get; set; }

            [JsonProperty("uplink_remote_port")]
            public int? uplink_remote_port { get; set; }

            [JsonProperty("media")]
            public string media { get; set; }

            [JsonProperty("port_idx")]
            public int? port_idx { get; set; }

            [JsonProperty("dns")]
            public IList<string> dns { get; set; }

            [JsonProperty("gateway")]
            public string gateway { get; set; }

            [JsonProperty("ifname")]
            public string ifname { get; set; }
        }

        public class JsonRadioTable
        {
            [JsonProperty("antenna_gain")]
            public int antenna_gain { get; set; }

            [JsonProperty("builtin_ant_gain")]
            public int builtin_ant_gain { get; set; }

            [JsonProperty("builtin_antenna")]
            public bool builtin_antenna { get; set; }

            [JsonProperty("channel")]
            public string channel { get; set; }

            [JsonProperty("ht")]
            public int ht { get; set; }

            [JsonProperty("max_txpower")]
            public int max_txpower { get; set; }

            [JsonProperty("min_rssi_enabled")]
            public bool min_rssi_enabled { get; set; }

            [JsonProperty("min_txpower")]
            public int min_txpower { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("nss")]
            public int nss { get; set; }

            [JsonProperty("radio")]
            public string radio { get; set; }

            [JsonProperty("tx_power_mode")]
            public string tx_power_mode { get; set; }

            [JsonProperty("hard_noise_floor_enabled")]
            public bool? hard_noise_floor_enabled { get; set; }

            [JsonProperty("has_dfs")]
            public bool? has_dfs { get; set; }

            [JsonProperty("has_fccdfs")]
            public bool? has_fccdfs { get; set; }

            [JsonProperty("is_11ac")]
            public bool? is_11ac { get; set; }
        }

        public class JsonVapTable
        {
            [JsonProperty("ap_mac")]
            public string ap_mac { get; set; }

            [JsonProperty("bssid")]
            public string bssid { get; set; }

            [JsonProperty("ccq")]
            public int ccq { get; set; }

            [JsonProperty("channel")]
            public int channel { get; set; }

            [JsonProperty("essid")]
            public string essid { get; set; }

            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("is_guest")]
            public bool is_guest { get; set; }

            [JsonProperty("is_wep")]
            public bool is_wep { get; set; }

            [JsonProperty("map_id")]
            public string map_id { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("num_sta")]
            public int num_sta { get; set; }

            [JsonProperty("radio")]
            public string radio { get; set; }

            [JsonProperty("rx_bytes")]
            public long rx_bytes { get; set; }

            [JsonProperty("rx_crypts")]
            public int rx_crypts { get; set; }

            [JsonProperty("rx_dropped")]
            public long rx_dropped { get; set; }

            [JsonProperty("rx_errors")]
            public long rx_errors { get; set; }

            [JsonProperty("rx_frags")]
            public int rx_frags { get; set; }

            [JsonProperty("rx_nwids")]
            public int rx_nwids { get; set; }

            [JsonProperty("rx_packets")]
            public int rx_packets { get; set; }

            [JsonProperty("site_id")]
            public string site_id { get; set; }

            [JsonProperty("state")]
            public string state { get; set; }

            [JsonProperty("t")]
            public string t { get; set; }

            [JsonProperty("tx_bytes")]
            public long tx_bytes { get; set; }

            [JsonProperty("tx_dropped")]
            public int tx_dropped { get; set; }

            [JsonProperty("tx_errors")]
            public int tx_errors { get; set; }

            [JsonProperty("tx_packets")]
            public long tx_packets { get; set; }

            [JsonProperty("tx_power")]
            public int tx_power { get; set; }

            [JsonProperty("tx_retries")]
            public int tx_retries { get; set; }

            [JsonProperty("up")]
            public bool up { get; set; }

            [JsonProperty("usage")]
            public string usage { get; set; }

            [JsonProperty("wlanconf_id")]
            public string wlanconf_id { get; set; }

            [JsonProperty("extchannel")]
            public int? extchannel { get; set; }
        }

        public class JsonPortOverride
        {
            [JsonProperty("autoneg")]
            public bool autoneg { get; set; }

            [JsonProperty("isolation")]
            public bool isolation { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("op_mode")]
            public string op_mode { get; set; }

            [JsonProperty("port_idx")]
            public int port_idx { get; set; }

            [JsonProperty("portconf_id")]
            public string portconf_id { get; set; }

            [JsonProperty("stormctrl_bcast_enabled")]
            public bool stormctrl_bcast_enabled { get; set; }

            [JsonProperty("stormctrl_mcast_enabled")]
            public bool stormctrl_mcast_enabled { get; set; }

            [JsonProperty("stormctrl_ucast_enabled")]
            public bool stormctrl_ucast_enabled { get; set; }

            [JsonProperty("full_duplex")]
            public bool? full_duplex { get; set; }

            [JsonProperty("mirror_port_idx")]
            public string mirror_port_idx { get; set; }

            [JsonProperty("stormctrl_bcast_rate")]
            public int? stormctrl_bcast_rate { get; set; }

            [JsonProperty("stormctrl_mcast_rate")]
            public int? stormctrl_mcast_rate { get; set; }

            [JsonProperty("stormctrl_ucast_rate")]
            public int? stormctrl_ucast_rate { get; set; }

            [JsonProperty("poe_mode")]
            public string poe_mode { get; set; }
        }
    }
}
