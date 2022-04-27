using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// A client device attached to the network via a wired connection
    /// </summary>
    public class WiredClientNetworkedDevice : IClientNetworkedDevice
    {
        /// <summary>
        /// MAC address of switch this client is connected to
        /// </summary>
        public string SwitchMac => Json.sw_mac;

        /// <summary>
        /// Switch port this client is physically attached to
        /// </summary>
        public int SwitchPort => Json.sw_port;

        public int SwitchDepth => Json.sw_depth;

        public WiredClientNetworkedDevice(UniFiApi api, JsonClient json) : base(api, json) { }
    }
}
