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

        internal void Converge(PhysicalNetworkDeviceCollection devices, ClientDeviceCollection clients)
        {
            foreach (var device in devices)
            {
                if (device is IUniFiNetworkDevice)
                {
                    if (((IUniFiNetworkDevice)device).State.uplink != null)
                    {
                        var uplinkDevice = devices.GetByMacAddress(((IUniFiNetworkDevice)device).State.uplink.uplink_mac);
                        if (uplinkDevice != null)
                        {
                            if (uplinkDevice is RoutingNetworkDevice)
                            {
                                // find port by netmask instead of port idx
                                var addr = IPAddress.Parse(((IUniFiNetworkDevice)device).State.uplink.ip);
                                foreach (var port in uplinkDevice.State.port_table)
                                    if (port.ip != "0.0.0.0" && addr.IsInSameSubnet(IPAddress.Parse(port.ip), IPAddress.Parse(port.netmask)))
                                        uplinkDevice.Children.Add(port, device);
                            }
                            else
                            {
                                var port = uplinkDevice.State.port_table.FirstOrDefault(p => p.port_idx == ((IUniFiNetworkDevice)device).State.uplink.uplink_remote_port);
                                uplinkDevice.Children.Add(port, device);
                            }
                        }
                    }
                }
            }

            foreach (var client in clients)
            {
                var apUplink = devices.GetByMacAddress(client.State.ap_mac);
                if (apUplink != null && apUplink is AccessPointNetworkDevice)
                {
                    apUplink.Children.Add(null, client);
                    continue;
                }

                var uplinkDevice = devices.GetByMacAddress(client.State.sw_mac);
                if (uplinkDevice != null)
                {
                    if (uplinkDevice is RoutingNetworkDevice)
                    {
                        // find port by netmask instead of port idx
                        var addr = IPAddress.Parse(client.State.ip);
                        foreach (var port in uplinkDevice.State.port_table)
                            if (port.ip != "0.0.0.0" && addr.IsInSameSubnet(IPAddress.Parse(port.ip), IPAddress.Parse(port.netmask)))
                                uplinkDevice.Children.Add(port, client);
                    }
                    else
                    {
                        var port = uplinkDevice.State.port_table.FirstOrDefault(p => p.port_idx == client.State.sw_port);
                        uplinkDevice.Children.Add(port, client);
                    }
                }
            }
        }
    }
}