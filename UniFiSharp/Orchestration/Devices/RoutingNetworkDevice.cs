using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Collections;
using UniFiSharp.Protocol;
using static UniFiSharp.Protocol.NetworkDevice;

namespace UniFiSharp.Orchestration.Devices
{
    public class RoutingNetworkDevice : IUniFiNetworkDevice
    {
        /// <summary>
        /// Physical ports on the device
        /// </summary>
        public IList<PortTable> Ports => State.port_table;

        /// <summary>
        /// Port forwarding entries
        /// </summary>
        public PortForwardCollection PortForwards { get; private set; }

        public RoutingNetworkDevice(UniFiApi api, string macAddress) : base(api, macAddress)
        {
            PortForwards = new PortForwardCollection(api);
        }

        public RoutingNetworkDevice(UniFiApi api, NetworkDevice deviceData) : base(api, deviceData)
        {
            PortForwards = new PortForwardCollection(api);
        }

        /// <summary>
        /// Refresh router state and port forwards
        /// </summary>
        /// <returns></returns>
        public async override Task Refresh()
        {
            await PortForwards.Refresh();
            await base.Refresh();
        }
    }
}