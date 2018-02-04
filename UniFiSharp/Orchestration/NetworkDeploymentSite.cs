using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Collections;
using UniFiSharp.Orchestration.Devices;

namespace UniFiSharp.Orchestration
{
    public class NetworkDeploymentSite
    {
        /// <summary>
        /// UniFi API hooked by this site
        /// </summary>
        public UniFiApi API { get; private set; }

        /// <summary>
        /// Collection of clients on the network
        /// </summary>
        public ClientDeviceCollection Clients { get; private set; }

        /// <summary>
        /// Collection of UniFi network devices on the network
        /// </summary>
        public PhysicalNetworkDeviceCollection Devices { get; private set; }

        /// <summary>
        /// Collection of port forwarding entries
        /// </summary>
        public PortForwardCollection PortForwards { get; private set; }

        /// <summary>
        /// Collection of wireless network SSIDs
        /// </summary>
        public WirelessNetworkCollection WirelessNetworks { get; private set; }

        /// <summary>
        /// Collection of WLAN groups
        /// </summary>
        public WlanGroupCollection WirelessNetworkGroups { get; private set; }

        /// <summary>
        /// Collection of user groups
        /// </summary>
        public UserGroupCollection UserGroups { get; private set; }

        /// <summary>
        /// Physical root of network (closest to edge)
        /// </summary>
        public INetworkDevice Root => Devices.Root;

        public NetworkDeploymentSite(UniFiApi api)
        {
            API = api;

            Clients = new ClientDeviceCollection(api);
            Devices = new PhysicalNetworkDeviceCollection(api);
            PortForwards = new PortForwardCollection(api);
            WirelessNetworks = new WirelessNetworkCollection(api);
            WirelessNetworkGroups = new WlanGroupCollection(api);
            UserGroups = new UserGroupCollection(api);
        }

        /// <summary>
        /// Refresh network state
        /// </summary>
        /// <returns></returns>
        public async Task Refresh()
        {
            if (!API.IsAuthenticated)
                await API.Authenticate();

            await Task.WhenAll(new Task[]
            {
                Clients.Refresh(),
                Devices.Refresh(),
                PortForwards.Refresh(),
                WirelessNetworks.Refresh(),
                WirelessNetworkGroups.Refresh(),
                UserGroups.Refresh()
            });

            Devices.ConvergeTree(Clients);
        }

        /// <summary>
        /// Turn site LED on or off
        /// </summary>
        /// <param name="enabled"><c>TRUE</c> if site LED is enabled, otherwise <c>FALSE</c></param>
        /// <returns></returns>
        public async Task SetSiteLed(bool enabled)
        {
            await API.SiteLedToggle(enabled);
        }
    }
}