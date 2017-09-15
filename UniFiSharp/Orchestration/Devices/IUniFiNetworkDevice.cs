using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Collections;
using UniFiSharp.Protocol;

namespace UniFiSharp.Orchestration.Devices
{
    public abstract class IUniFiNetworkDevice : INetworkDevice
    {
        /// <summary>
        /// UniFi Device MAC address
        /// </summary>
        public string MacAddress { get; private set; }

        /// <summary>
        /// Device information as reported by the controller
        /// </summary>
        public NetworkDevice State { get; private set; }
        
        protected IUniFiNetworkDevice(UniFiApi api, string macAddress)
        {
            _api = api;
            MacAddress = macAddress;
        }

        protected IUniFiNetworkDevice(UniFiApi api, NetworkDevice deviceData) : this(api, deviceData.mac)
        {
            State = deviceData;
        }

        /// <summary>
        /// All MAC Addresses associated with this device
        /// </summary>
        public List<string> MacAddresses => State.ethernet_table.Select(e => e.mac).ToList();

        /// <summary>
        /// Refresh device state
        /// </summary>
        /// <returns></returns>
        public async virtual Task Refresh()
        {
            var devices = await _api.ListDevices(MacAddress);
            State = devices.FirstOrDefault();
        }

        /// <summary>
        /// Enable or disable locator LED
        /// </summary>
        /// <param name="ledOn"><c>TRUE</c> if locator LED is on, otherwise <c>FALSE</c></param>
        /// <returns></returns>
        public async Task Locate(bool ledOn)
        {
            await _api.LocateApToggle(MacAddress, ledOn);
        }

        /// <summary>
        /// Upgrade the device to the latest firmware as known by the controller
        /// </summary>
        /// <returns></returns>
        public async Task Upgrade()
        {
            await _api.Upgrade(MacAddress);
        }

        /// <summary>
        /// Adopt device
        /// </summary>
        /// <returns></returns>
        public async Task Adopt()
        {
            if (State.adopted)
                throw new Exception("Device already adopted");

            await _api.Adopt(MacAddress);
        }
    }
}