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
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// User-defined name of the port forward
        /// </summary>
        [DisplayName("Name")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Source IP address
        /// </summary>
        [DisplayName("Source IP")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("src")]
        public string src { get; set; }

        /// <summary>
        /// Port which the router listens on
        /// </summary>
        [DisplayName("Router Port")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("dst_port")]
        public int dst_port { get; set; }

        /// <summary>
        /// Port which the traffic is forwarded to on the destination
        /// </summary>
        [DisplayName("Destination Port")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("fwd_port")]
        public int fwd_port { get; set; }

        /// <summary>
        /// Destination IP for the traffic
        /// </summary>
        [DisplayName("Destination IP")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("fwd")]
        public string fwd { get; set; }

        /// <summary>
        /// Protocol the port forward applies to
        /// </summary>
        [DisplayName("Protocol")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
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
