using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// A client device attached to the network via a wireless connection
    /// </summary>
    public class WirelessClientNetworkedDevice : IClientNetworkedDevice
    {
        /// <summary>
        /// MAC address of access point this client is connected to
        /// </summary>
        public string AccessPointMac => Json.ap_mac;

        /// <summary>
        /// BSSID being used by this client
        /// </summary>
        public string Bssid => Json.bssid;

        /// <summary>
        /// Wifi channel the client is connected on
        /// </summary>
        public int Channel => Json.channel;

        /// <summary>
        /// ESSID being used by this client
        /// </summary>
        public string Essid => Json.essid;

        /// <summary>
        /// Noise level of the connection between the client and AP
        /// This is measured in -dBm, 0 to -100
        /// </summary>
        public int Noise => Json.noise;

        /// <summary>
        /// Radio type being used to connect the client to the AP
        /// </summary>
        public string RadioType => Json.radio;

        /// <summary>
        /// Radio protocol
        /// </summary>
        public string RadioProto => Json.radio_proto;

        /// <summary>
        /// Current Received Signal Strength Indicator (RSSI) between client and AP
        /// </summary>
        public int Rssi => Json.rssi;

        /// <summary>
        /// Current signal strength between client and AP
        /// </summary>
        public int Signal => Json.signal;

        public WirelessClientNetworkedDevice(UniFiApi api, JsonClient json) : base(api, json) { }
    }
}
