using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonPortForward
    {
        /// <summary>
        /// Port Forward ID
        /// </summary>
        [DisplayName("Port Forward ID")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// User-defined name of the port forward
        /// </summary>
        [DisplayName("Name")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Source IP address
        /// </summary>
        [DisplayName("Source IP")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("src")]
        public string src { get; set; }

        /// <summary>
        /// Port which the router listens on
        /// </summary>
        [DisplayName("Router Port")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("dst_port")]
        public int dst_port { get; set; }

        /// <summary>
        /// Port which the traffic is forwarded to on the destination
        /// </summary>
        [DisplayName("Destination Port")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("fwd_port")]
        public int fwd_port { get; set; }

        /// <summary>
        /// Destination IP for the traffic
        /// </summary>
        [DisplayName("Destination IP")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("fwd")]
        public string fwd { get; set; }

        /// <summary>
        /// Protocol the port forward applies to
        /// </summary>
        [DisplayName("Protocol")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("proto")]
        public string proto { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the port forward
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        public string site_id { get; set; }
    }
}
