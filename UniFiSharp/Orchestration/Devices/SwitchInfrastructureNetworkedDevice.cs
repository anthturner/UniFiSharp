using System;
using System.Collections.Generic;
using System.Linq;

namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// A UniFi-managed wired switch attached to the UniFi network
    /// </summary>
    public class SwitchInfrastructureNetworkedDevice : IInfrastructureNetworkedDevice
    {
        /// <summary>
        /// Gets a list of all child devices which are infrastructure devices (not clients), and what ports they are connected to
        /// </summary>
        public List<Tuple<IInfrastructureNetworkedDevice, int>> InfrastructureDevicesWithPorts =>
            InfrastructureDevices.Select(d =>
                Tuple.Create(d, d.uplink.uplink_remote_port.GetValueOrDefault(0))).ToList();

        /// <summary>
        /// Gets a list of all clients connected to this switch, and what ports they are connected to
        /// </summary>
        public List<Tuple<IClientNetworkedDevice, int>> ClientsWithPorts =>
            Clients.Select(c =>
                Tuple.Create(c, ((WiredClientNetworkedDevice)c).sw_port)).ToList();

        /// <summary>
        /// Gets a list of all infrastructure and client devices connected to this switch, and what ports they are connected to
        /// </summary>
        public List<Tuple<INetworkedDevice, int>> AllWithPorts =>
            InfrastructureDevices.Select(d =>
                Tuple.Create((INetworkedDevice)d, d.uplink.uplink_remote_port.GetValueOrDefault(0)))
            .Union(Clients.Select(c =>
                Tuple.Create((INetworkedDevice)c, ((WiredClientNetworkedDevice)c).sw_port))).ToList();

        internal SwitchInfrastructureNetworkedDevice() { }
    }
}