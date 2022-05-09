using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// Port forwarded through router
    /// </summary>
    [DisplayName("Port Forward")]
    public class JsonPortForward
    {
        /// <summary>
        /// Port Forward ID
        /// </summary>
        [DisplayName("Port Forward ID")]
        [Identifier]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// User-defined name of the port forward
        /// </summary>
        [DisplayName("Name")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Source IP address
        /// </summary>
        [DisplayName("Source IP")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("src")]
        public string src { get; set; }

        /// <summary>
        /// Port which the router listens on
        /// </summary>
        [DisplayName("Router Port")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("dst_port")]
        public int dst_port { get; set; }

        /// <summary>
        /// Port which the traffic is forwarded to on the destination
        /// </summary>
        [DisplayName("Destination Port")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("fwd_port")]
        public int fwd_port { get; set; }

        /// <summary>
        /// Destination IP for the traffic
        /// </summary>
        [DisplayName("Destination IP")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("fwd")]
        public string fwd { get; set; }

        /// <summary>
        /// Protocol the port forward applies to
        /// </summary>
        [DisplayName("Protocol")]
        [ShowWith(Levels.Minimal)]
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
