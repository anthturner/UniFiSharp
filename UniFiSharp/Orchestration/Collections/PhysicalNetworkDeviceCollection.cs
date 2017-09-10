using System;
using System.Collections.Generic;
using System.Linq;
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

            // todo: show unadopted devices in tree

            foreach (var device in this)
                device.Converge(this);

            if (this.Any(d => d is RoutingNetworkDevice && d.State.adopted))
                Root = this.FirstOrDefault(d => d is RoutingNetworkDevice && d.State.adopted);
            else
            {
                var parentlessDevices = this.Select(d => !HasParentDevice(d)).ToList();
                Root = new NonUniFiDevice();
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