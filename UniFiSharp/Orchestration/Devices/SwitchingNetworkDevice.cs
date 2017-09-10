using System.Collections.Generic;
using UniFiSharp.Protocol;
using static UniFiSharp.Protocol.NetworkDevice;

namespace UniFiSharp.Orchestration.Devices
{
    public class SwitchingNetworkDevice : IUniFiNetworkDevice
    {
        /// <summary>
        /// Physical ports on the switch
        /// </summary>
        public IList<PortTable> Ports => State.port_table;

        public SwitchingNetworkDevice(UniFiApi api, string macAddress) : base(api, macAddress)
        {
        }

        public SwitchingNetworkDevice(UniFiApi api, NetworkDevice deviceData) : base(api, deviceData)
        {
        }
    }
}