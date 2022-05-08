using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonHotspotOperator
    {
        /// <summary>
        /// Hotspot Operator ID
        /// </summary>
        [DisplayName("Operator ID")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("_id")]
        public string id { get; set; }

        /// <summary>
        /// Hotspot Operator Name
        /// </summary>
        [DisplayName("Operator Name")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// User-defined note associated with hotspot operator
        /// </summary>
        [DisplayName("Operator Note")]
        [Complexity(Complexities.Average)]
        [JsonProperty("note")]
        public string note { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the operator
        /// </summary>
        [DisplayName("Site ID")]
        [Complexity(Complexities.Average)]
        [JsonProperty("site_id")]
        public string siteId { get; set; }

        // TODO
        [JsonProperty("x_password")]
        public string xPassword { get; set; }
    }
}
