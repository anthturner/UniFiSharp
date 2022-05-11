using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// WLAN group to broadly apply policies to multiple WLANs
    /// </summary>
    [DisplayName("WLAN Group")]
    public class JsonWlanGroup
    {
        /// <summary>
        /// WLAN Group ID
        /// </summary>
        [DisplayName("WLAN Group ID")]
        [Identifier]
        [JsonProperty("_id")]
        public string _id { get; set; }

        // TODO
        [JsonProperty("attr_hidden_id")]
        public string attr_hidden_id { get; set; }

        // TODO
        [JsonProperty("attr_no_delete")]
        public bool attr_no_delete { get; set; }

        /// <summary>
        /// WLAN Group Name
        /// </summary>
        [DisplayName("WLAN Group Name")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the WLAN group
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        public string site_id { get; set; }

        /// <summary>
        /// If the WLAN group is hidden
        /// </summary>
        [DisplayName("Hidden?")]
        [JsonProperty("attr_hidden")]
        public bool? attr_hidden { get; set; }

        /// <summary>
        /// If the WLAN group is locked from editing
        /// </summary>
        [DisplayName("Edit-Locked?")]
        [JsonProperty("attr_no_edit")]
        public bool? attr_no_edit { get; set; }

        /// <summary>
        /// PMF (Protected Management Frame) Mode
        /// </summary>
        [DisplayName("PMF Mode")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("pmf_mode")]
        public string pmf_mode { get; set; }

        /// <summary>
        /// Channel used for this WLAN group on the 5GHz radio
        /// </summary>
        [DisplayName("5GHz Channel")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("roam_channel_na")]
        public int? roam_channel_na { get; set; }

        /// <summary>
        /// Channel used for this WLAN group on the 2.4GHz radio
        /// </summary>
        [DisplayName("2.4GHz Channel")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("roam_channel_ng")]
        public int? roam_channel_ng { get; set; }

        /// <summary>
        /// Which radio type to use for this WLAN group
        /// </summary>
        [DisplayName("Radio Type")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("roam_radio")]
        public string roam_radio { get; set; }
    }
}
