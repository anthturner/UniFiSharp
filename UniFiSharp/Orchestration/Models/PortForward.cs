using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Models
{
    public class PortForward
    {
        public string PortForwardId => Json._id;
        public string Source => Json.src;
        public string Destination => Json.fwd;
        public int FromPort => Json.fwd_port;
        public string Proto => Json.proto;
        public int DestinationPort => Json.dst_port;
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
