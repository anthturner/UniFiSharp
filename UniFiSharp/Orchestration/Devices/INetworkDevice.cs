using System.Linq;
using System.Net;
using UniFiSharp.Orchestration.Collections;

namespace UniFiSharp.Orchestration.Devices
{
    public abstract class INetworkDevice
    {
        /// <summary>
        /// Network devices attached to this device
        /// </summary>
        public ChildConnectionCollection Children { get; private set; }

        protected UniFiApi _api;

        public INetworkDevice()
        {
            Children = new ChildConnectionCollection();
        }

        public INetworkDevice(UniFiApi api) : this()
        {
            _api = api;
        }

        internal void Converge(PhysicalNetworkDeviceCollection devices)
        {
            if (this is IUniFiNetworkDevice)
            {
                if (((IUniFiNetworkDevice)this).State.uplink != null)
                {
                    var uplinkDevice = devices.GetByMacAddress(((IUniFiNetworkDevice)this).State.uplink.uplink_mac);
                    if (uplinkDevice != null)
                    {
                        if (uplinkDevice is RoutingNetworkDevice)
                        {
                            // find port by netmask instead of port idx
                            var addr = IPAddress.Parse(((IUniFiNetworkDevice)this).State.uplink.ip);
                            foreach (var port in uplinkDevice.State.port_table)
                                if (port.ip != "0.0.0.0" && addr.IsInSameSubnet(IPAddress.Parse(port.ip), IPAddress.Parse(port.netmask)))
                                    uplinkDevice.Children.Add(port, this);
                        }
                        else
                        {
                            var port = uplinkDevice.State.port_table.FirstOrDefault(p => p.port_idx == ((IUniFiNetworkDevice)this).State.uplink.uplink_remote_port);
                            uplinkDevice.Children.Add(port, this);
                        }
                    }
                }
            }
        }
    }
}