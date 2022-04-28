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
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("_id")]
        public string id { get; set; }

        /// <summary>
        /// Hotspot Operator Name
        /// </summary>
        [DisplayName("Operator Name")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// User-defined note associated with hotspot operator
        /// </summary>
        [DisplayName("Operator Note")]
        [IncludedInVisualization(VisualizationModes.Single)]
        [JsonProperty("note")]
        public string note { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the operator
        /// </summary>
        [DisplayName("Site ID")]
        [IncludedInVisualization(VisualizationModes.Single)]
        [JsonProperty("site_id")]
        public string siteId { get; set; }

        // TODO
        [JsonProperty("x_password")]
        public string xPassword { get; set; }
    }
}
