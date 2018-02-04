using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Devices;

namespace UniFiSharp.Orchestration.Collections
{
    public class PhysicalNetworkDeviceCollection : RefreshableCollection<IUniFiNetworkDevice>
    {
        private Dictionary<string, Func<UniFiApi, Protocol.NetworkDevice, IUniFiNetworkDevice>> DeviceTypeMap = new Dictionary<string, Func<UniFiApi, Protocol.NetworkDevice, IUniFiNetworkDevice>>()
        {
            { "ugw", (api, device) => new RoutingNetworkDevice(api, device) },
            { "usw", (api, device) => new SwitchingNetworkDevice(api, device) },
            { "uap", (api, device) => new AccessPointNetworkDevice(api, device) },
        };

        public INetworkDevice Root { get; private set; }
        public IReadOnlyCollection<IUniFiNetworkDevice> UnadoptedDevices => this.Where(d => !d.State.adopted).ToList().AsReadOnly();

        public PhysicalNetworkDeviceCollection(UniFiApi api) : base(api)
        {
        }

        public override async Task Refresh()
        {
            var devices = (await API.ListDevices()).Select(device =>
            {
                if (DeviceTypeMap.ContainsKey(device.type))
                    return DeviceTypeMap[device.type](API, device);
                return null;
            }).ToList();
            devices.RemoveAll(d => d == null);

            ClearLocal();
            AddLocal(devices);
        }

        public void ConvergeTree(ClientDeviceCollection clients)
        {
            foreach (var device in this)
            {
                if (device is IUniFiNetworkDevice)
                {
                    if (((IUniFiNetworkDevice)device).State.uplink != null && ((IUniFiNetworkDevice)device).State.uplink.uplink_mac != null)
                    {
                        var uplinkDevice = this.GetByMacAddress(((IUniFiNetworkDevice)device).State.uplink.uplink_mac);
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
                var apUplink = this.GetByMacAddress(client.State.ap_mac);
                if (apUplink != null && apUplink is AccessPointNetworkDevice)
                {
                    apUplink.Children.Add(null, client);
                    continue;
                }

                var uplinkDevice = this.GetByMacAddress(client.State.sw_mac);
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

            if (this.Any(d => d is RoutingNetworkDevice && d.State.adopted))
                Root = this.FirstOrDefault(d => d is RoutingNetworkDevice && d.State.adopted);
            else
            {
                var parentlessDevices = this.Where(d => !HasParentDevice(d)).ToList();
                Root = new NonUniFiDevice();
                foreach (var parentlessDevice in parentlessDevices)
                    Root.Children.Add(null, parentlessDevice);
            }
        }

        public bool HasParentDevice(INetworkDevice device)
        {
            if (device is NonUniFiDevice)
                return false;

            foreach (var searchDevice in this)
                if (searchDevice.Children.HasChild(device))
                    return true;
            return false;
        }

        public IUniFiNetworkDevice GetByMacAddress(string macAddress)
        {
            return this.FirstOrDefault(d => d.MacAddresses.Contains(macAddress));
        }
    }
}