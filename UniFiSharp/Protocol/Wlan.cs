using Newtonsoft.Json;
using System.Collections.Generic;

namespace UniFiSharp.Protocol
{
    public class Wlan : IMessageBase
    {
        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("bc_filter_enabled")]
        public bool bc_filter_enabled { get; set; }

        [JsonProperty("bc_filter_list")]
        public IList<object> bc_filter_list { get; set; }

        [JsonProperty("dtim_mode")]
        public string dtim_mode { get; set; }

        [JsonProperty("dtim_na")]
        public int dtim_na { get; set; }

        [JsonProperty("dtim_ng")]
        public int dtim_ng { get; set; }

        [JsonProperty("enabled")]
        public bool enabled { get; set; }

        [JsonProperty("mac_filter_enabled")]
        public bool mac_filter_enabled { get; set; }

        [JsonProperty("mac_filter_list")]
        public IList<object> mac_filter_list { get; set; }

        [JsonProperty("mac_filter_policy")]
        public string mac_filter_policy { get; set; }

        [JsonProperty("minrate_na_advertising_rates")]
        public bool minrate_na_advertising_rates { get; set; }

        [JsonProperty("minrate_na_beacon_rate_kbps")]
        public int minrate_na_beacon_rate_kbps { get; set; }

        [JsonProperty("minrate_na_data_rate_kbps")]
        public int minrate_na_data_rate_kbps { get; set; }

        [JsonProperty("minrate_na_enabled")]
        public bool minrate_na_enabled { get; set; }

        [JsonProperty("minrate_na_mgmt_rate_kbps")]
        public int minrate_na_mgmt_rate_kbps { get; set; }

        [JsonProperty("minrate_ng_advertising_rates")]
        public bool minrate_ng_advertising_rates { get; set; }

        [JsonProperty("minrate_ng_beacon_rate_kbps")]
        public int minrate_ng_beacon_rate_kbps { get; set; }

        [JsonProperty("minrate_ng_data_rate_kbps")]
        public int minrate_ng_data_rate_kbps { get; set; }

        [JsonProperty("minrate_ng_enabled")]
        public bool minrate_ng_enabled { get; set; }

        [JsonProperty("minrate_ng_mgmt_rate_kbps")]
        public int minrate_ng_mgmt_rate_kbps { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("ratectrl_na_12")]
        public string ratectrl_na_12 { get; set; }

        [JsonProperty("ratectrl_na_18")]
        public string ratectrl_na_18 { get; set; }

        [JsonProperty("ratectrl_na_24")]
        public string ratectrl_na_24 { get; set; }

        [JsonProperty("ratectrl_na_36")]
        public string ratectrl_na_36 { get; set; }

        [JsonProperty("ratectrl_na_48")]
        public string ratectrl_na_48 { get; set; }

        [JsonProperty("ratectrl_na_54")]
        public string ratectrl_na_54 { get; set; }

        [JsonProperty("ratectrl_na_6")]
        public string ratectrl_na_6 { get; set; }

        [JsonProperty("ratectrl_na_9")]
        public string ratectrl_na_9 { get; set; }

        [JsonProperty("ratectrl_na_mode")]
        public string ratectrl_na_mode { get; set; }

        [JsonProperty("ratectrl_ng_12")]
        public string ratectrl_ng_12 { get; set; }

        [JsonProperty("ratectrl_ng_18")]
        public string ratectrl_ng_18 { get; set; }

        [JsonProperty("ratectrl_ng_24")]
        public string ratectrl_ng_24 { get; set; }

        [JsonProperty("ratectrl_ng_36")]
        public string ratectrl_ng_36 { get; set; }

        [JsonProperty("ratectrl_ng_48")]
        public string ratectrl_ng_48 { get; set; }

        [JsonProperty("ratectrl_ng_54")]
        public string ratectrl_ng_54 { get; set; }

        [JsonProperty("ratectrl_ng_6")]
        public string ratectrl_ng_6 { get; set; }

        [JsonProperty("ratectrl_ng_9")]
        public string ratectrl_ng_9 { get; set; }

        [JsonProperty("ratectrl_ng_cck_1")]
        public string ratectrl_ng_cck_1 { get; set; }

        [JsonProperty("ratectrl_ng_cck_11")]
        public string ratectrl_ng_cck_11 { get; set; }

        [JsonProperty("ratectrl_ng_cck_2")]
        public string ratectrl_ng_cck_2 { get; set; }

        [JsonProperty("ratectrl_ng_cck_5_5")]
        public string ratectrl_ng_cck_5_5 { get; set; }

        [JsonProperty("ratectrl_ng_mode")]
        public string ratectrl_ng_mode { get; set; }

        [JsonProperty("schedule")]
        public IList<object> schedule { get; set; }

        [JsonProperty("security")]
        public string security { get; set; }

        [JsonProperty("site_id")]
        public string site_id { get; set; }

        [JsonProperty("usergroup_id")]
        public string usergroup_id { get; set; }

        [JsonProperty("wep_idx")]
        public int wep_idx { get; set; }

        [JsonProperty("wlangroup_id")]
        public string wlangroup_id { get; set; }

        [JsonProperty("wpa_enc")]
        public string wpa_enc { get; set; }

        [JsonProperty("wpa_mode")]
        public string wpa_mode { get; set; }

        [JsonProperty("hide_ssid")]
        public bool? hide_ssid { get; set; }

        [JsonProperty("vlan")]
        public string vlan { get; set; }

        [JsonProperty("vlan_enabled")]
        public bool? vlan_enabled { get; set; }
    }
}