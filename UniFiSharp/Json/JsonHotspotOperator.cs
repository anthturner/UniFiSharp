using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// Wireless Hotspot Operator User
    /// </summary>
    [DisplayName("Hotspot Operator")]
    public class JsonHotspotOperator : IJsonObject
    {
        /// <summary>
        /// Hotspot Operator ID
        /// </summary>
        [DisplayName("Operator ID")]
        [Identifier]
        [JsonProperty("_id")]
        public string id { get; set; }

        /// <summary>
        /// Hotspot Operator Name
        /// </summary>
        [DisplayName("Operator Name")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// User-defined note associated with hotspot operator
        /// </summary>
        [DisplayName("Operator Note")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("note")]
        public string note { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the operator
        /// </summary>
        [DisplayName("Site ID")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("site_id")]
        public string siteId { get; set; }

        // TODO
        [JsonProperty("x_password")]
        public string xPassword { get; set; }
    }
}
