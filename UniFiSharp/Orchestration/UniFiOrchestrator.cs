using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Collections;
using UniFiSharp.Orchestration.Devices;

namespace UniFiSharp.Orchestration
{
    public class UniFiOrchestrator : IDisposable
    {
        /// <summary>
        /// Collection of connected infrastructure devices (routers, switches, APs)
        /// </summary>
        public InfrastructureNetworkedDeviceCollection InfrastructureDevices { get; private set; }

        /// <summary>
        /// Collection of connected client devices
        /// </summary>
        public ClientNetworkedDeviceCollection Clients { get; private set; }

        /// <summary>
        /// Collection of WLAN groups for managing WiFi configurations
        /// </summary>
        public WlanGroupCollection WlanGroups { get; private set; }

        /// <summary>
        /// Collection of user groups for managing QoS settings on user classes
        /// </summary>
        public UserGroupCollection UserGroups { get; private set; }

        /// <summary>
        /// Collection of port forwarding rules for a UniFi Security Gateway (router)
        /// </summary>
        public PortForwardCollection PortForwards { get; private set; }

        /// <summary>
        /// Inferred 'root' node of the network topology
        /// </summary>
        public INetworkedDevice TopologicalRoot { get; private set; }

        private UniFiApi API { get; set; }

        /// <summary>
        /// Wrapper around the UniFi API that provides an object tree view of the UniFi managed network
        /// </summary>
        /// <param name="api">UniFi API</param>
        public UniFiOrchestrator(UniFiApi api)
        {
            API = api;

            Clients = new ClientNetworkedDeviceCollection(API);
            InfrastructureDevices = new InfrastructureNetworkedDeviceCollection(API);
            WlanGroups = new WlanGroupCollection(API);
            UserGroups = new UserGroupCollection(API);
            PortForwards = new PortForwardCollection(API);
        }

        /// <summary>
        /// Update the state of the wrapper to reflect the current network configuration and state
        /// </summary>
        /// <returns></returns>
        public async Task Refresh()
        {
            await Task.WhenAll(
                Clients.Refresh(),
                InfrastructureDevices.Refresh(),
                WlanGroups.Refresh(),
                UserGroups.Refresh(),
                PortForwards.Refresh()
            );

            InferConvergedTopology();
        }

        /// <summary>
        /// Create a list of objects reflecting the path taken through the network to get from the edge to a given device
        /// </summary>
        /// <param name="device">Device to generate a route path to</param>
        /// <returns>Collection of Tuples where the first element is the device and the second element is the port number</returns>
        public IList<Tuple<INetworkedDevice, int>> GeneratePathTo(INetworkedDevice device)
        {
            var list = new List<Tuple<INetworkedDevice, int>>();
            var thisDevice = device;
            while (thisDevice != null)
            {
                var parent = GetParentPortOf(thisDevice);
                if (parent == null)
                    break;
                list.Add(Tuple.Create((INetworkedDevice)parent.Item1, parent.Item2));
                thisDevice = parent.Item1;
            }
            return list;
        }

        /// <summary>
        /// Retrieve the immediate network-topological parent of a given device
        /// </summary>
        /// <param name="device">Device to locate the parent of</param>
        /// <returns>Device parent or <c>NULL</c> if there is no corresponding uplink</returns>
        public IInfrastructureNetworkedDevice GetParentOf(INetworkedDevice device)
        {
            string parentMac = "";

            if (device is IClientNetworkedDevice)
            {
                if (device is WirelessClientNetworkedDevice)
                    parentMac = ((WirelessClientNetworkedDevice)device).ap_mac;
                else if (device is WiredClientNetworkedDevice)
                    parentMac = ((WiredClientNetworkedDevice)device).sw_mac;
            }
            else if (device is IInfrastructureNetworkedDevice)
            {
                if (((IInfrastructureNetworkedDevice)device).uplink != null)
                    parentMac = ((IInfrastructureNetworkedDevice)device).uplink.uplink_mac;
            }

            if (string.IsNullOrEmpty(parentMac))
                return null;

            return InfrastructureDevices.GetByMac(parentMac);
        }

        /// <summary>
        /// Retrieve the immediate network-toplogical parent and the attached switch port of a given device
        /// </summary>
        /// <param name="device">Device to locate the parent and switch port of</param>
        /// <returns>Tuple where the first item is the parent device and the second item is the switch port</returns>
        public Tuple<IInfrastructureNetworkedDevice, int> GetParentPortOf(INetworkedDevice device)
        {
            string parentMac = "";
            int viaPort = 0;
            if (device is IClientNetworkedDevice)
            {
                if (device is WirelessClientNetworkedDevice)
                    parentMac = ((WirelessClientNetworkedDevice)device).ap_mac;
                else if (device is WiredClientNetworkedDevice)
                {
                    parentMac = ((WiredClientNetworkedDevice)device).sw_mac;
                    viaPort = ((WiredClientNetworkedDevice)device).sw_port;
                }
            }
            else if (device is IInfrastructureNetworkedDevice)
            {
                if (((IInfrastructureNetworkedDevice)device).uplink != null)
                {
                    parentMac = ((IInfrastructureNetworkedDevice)device).uplink.uplink_mac;
                    viaPort = ((IInfrastructureNetworkedDevice)device).uplink.uplink_remote_port.GetValueOrDefault(0);
                }
            }

            if (string.IsNullOrEmpty(parentMac))
                return null;

            return Tuple.Create(InfrastructureDevices.GetByMac(parentMac), viaPort);
        }

        private void InferConvergedTopology()
        {
            foreach (var device in InfrastructureDevices)
            {
                device.Clients.Clear();
                device.InfrastructureDevices.Clear();
            }

            foreach (var childDevice in InfrastructureDevices)
            {
                var parentDevice = GetParentOf(childDevice);
                if (parentDevice != null)
                    parentDevice.InfrastructureDevices.Add(childDevice);
            }

            foreach (var childClient in Clients)
            {
                var parentDevice = GetParentOf(childClient);
                if (parentDevice != null)
                    parentDevice.Clients.Add(childClient);
            }

            var rootCandidates = InfrastructureDevices.Where(d => 
                (d.Uplink == null || string.IsNullOrEmpty(d.Uplink.UplinkMac)) &&
                d.StateEnum != IInfrastructureNetworkedDevice.NetworkDeviceState.Disconnected).ToList();
            if (rootCandidates.Count == 1)
                TopologicalRoot = rootCandidates[0];
            else
            {
                var nonManagedDevice = new UnknownInfrastructureNetworkedDevice();
                nonManagedDevice.InfrastructureDevices = rootCandidates;
                TopologicalRoot = nonManagedDevice;
            }
        }

        public void Dispose() { }
    }
}
