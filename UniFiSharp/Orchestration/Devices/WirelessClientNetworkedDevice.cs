using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    public class WirelessClientNetworkedDevice : IClientNetworkedDevice
    {
        public string AccessPointMac => Json.ap_mac;
        public string Bssid => Json.bssid;
        public int Channel => Json.channel;
        public string Essid => Json.essid;
        public int Noise => Json.noise;
        public string RadioType => Json.radio;
        public string RadioProto => Json.radio_proto;
        public int Rssi => Json.rssi;
        public int Signal => Json.signal;

        public WirelessClientNetworkedDevice(UniFiApi api, JsonClient json) : base(api, json) { }
    }
}
