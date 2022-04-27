using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Models
{
    public class PortForward
    {
        /// <summary>
        /// Port forward record ID
        /// </summary>
        public string PortForwardId => Json._id;

        /// <summary>
        /// Source IP address
        /// </summary>
        public string Source => Json.src;

        /// <summary>
        /// Destination IP address
        /// </summary>
        public string Destination => Json.fwd;

        /// <summary>
        /// Port being listened on externally
        /// </summary>
        public int FromPort => Json.fwd_port;

        /// <summary>
        /// Protocol which the port forward applies to
        /// </summary>
        public string Proto => Json.proto;

        /// <summary>
        /// Port to forward to on the destination
        /// </summary>
        public int DestinationPort => Json.dst_port;

        /// <summary>
        /// User-defined name for the port forward
        /// </summary>
        public string Name => Json.name;

        private JsonPortForward Json { get; set; }
        public PortForward(JsonPortForward json)
        {
            Json = json;
        }

        public static PortForward CreateFromJson(JsonPortForward json)
        {
            return new PortForward(json);
        }
    }
}
