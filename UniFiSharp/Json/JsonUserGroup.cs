using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// User group to broadly apply policies to multiple users
    /// </summary>
    [DisplayName("User Group")]
    public class JsonUserGroup
    {
        /// <summary>
        /// User Group ID
        /// </summary>
        [DisplayName("User Group ID")]
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
        /// User Group Name
        /// </summary>
        [DisplayName("User Group Name")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Maximum downstream rate permitted by QoS rules for the guest
        /// </summary>
        [DisplayName("Max Downstream (bytes)")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("qos_rate_max_down")]
        public int qos_rate_max_down { get; set; }

        /// <summary>
        /// Maximum upstream rate permitted by QoS rules for the guest
        /// </summary>
        [DisplayName("Max Upstream (bytes)")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("qos_rate_max_up")]
        public int qos_rate_max_up { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the user group
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        public string site_id { get; set; }
    }
}
