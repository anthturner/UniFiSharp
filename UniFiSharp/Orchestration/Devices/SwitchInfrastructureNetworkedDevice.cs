using System;
using System.Collections.Generic;
using System.Linq;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    public class SwitchInfrastructureNetworkedDevice : IInfrastructureNetworkedDevice
    {
        public List<Tuple<IInfrastructureNetworkedDevice, int>> InfrastructureDevicesWithPorts =>
            InfrastructureDevices.Select(d =>
                Tuple.Create(d, d.Uplink.UplinkRemotePort.GetValueOrDefault(0))).ToList();

        public List<Tuple<IClientNetworkedDevice, int>> ClientsWithPorts =>
            Clients.Select(c =>
                Tuple.Create(c, ((WiredClientNetworkedDevice)c).SwitchPort)).ToList();

        public List<Tuple<INetworkedDevice, int>> AllWithPorts =>
            InfrastructureDevices.Select(d =>
                Tuple.Create((INetworkedDevice)d, d.Uplink.UplinkRemotePort.GetValueOrDefault(0)))
            .Union(Clients.Select(c =>
                Tuple.Create((INetworkedDevice)c, ((WiredClientNetworkedDevice)c).SwitchPort))).ToList();

        public SwitchInfrastructureNetworkedDevice(UniFiApi api, JsonNetworkDevice json) : base(api, json)
        {
        }
    }
}