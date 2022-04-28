using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// Base class for any infrastructure device (router, switch, AP) on the network
    /// </summary>
    public abstract class IInfrastructureNetworkedDevice : JsonNetworkDevice, INetworkedDevice
    {
        public enum NetworkDeviceState
        {
            Adopting,
            AdoptionFailed,
            Disconnected,
            Connected,
            Deleting,
            FirmwareMismatch,
            HeartbeatMissed,
            Isolated,
            PendingApproval,
            Upgrading,
            Unadopted,
            Inaccessible,
            Provisioning,
            RfScanning,
            Unknown
        }

        /// <summary>
        /// Operating state of the device
        /// </summary>
        public NetworkDeviceState StateEnum
        {
            get
            {
                switch (state)
                {
                    case 0:
                        return NetworkDeviceState.Disconnected; // According to the UniFi app, 0 represents restarting although this does not reflect real-world testing where 0 = Disconnected.

                    case 1:
                        return NetworkDeviceState.Connected;

                    case 2:
                        if (defaultSettings) // if we're not on default settings, the controller can't adopt
                            return NetworkDeviceState.PendingApproval;
                        else
                            return NetworkDeviceState.Inaccessible;
                    case 3:
                        return NetworkDeviceState.FirmwareMismatch;
                    case 4:
                        return NetworkDeviceState.Upgrading;
                    case 5:
                        return NetworkDeviceState.Provisioning;
                    case 6:
                        return NetworkDeviceState.HeartbeatMissed;
                    case 7:
                        return NetworkDeviceState.Adopting;
                    case 8:
                        return NetworkDeviceState.Deleting;
                    case 9:
                        return NetworkDeviceState.Disconnected; // According to the UniFi app, 9 represents disconnecting although this does not reflect real-world testing where 0 = Disconnected.
                    case 10:
                        return NetworkDeviceState.AdoptionFailed;
                    case 11:
                        return NetworkDeviceState.Isolated;
                }

                return NetworkDeviceState.Unknown;
            }
        }

        /// <summary>
        /// User-defined name of the device if it exists, otherwise this will return the MAC address
        /// </summary>
        public string NameOrMac => string.IsNullOrEmpty(name) ? mac : name;

        /// <summary>
        /// Load averages for this device for the previous 1, 5, and 15 minutes
        /// </summary>
        public double[] LoadAverage => new double[] {
            sys_stats.loadavg_1.GetValueOrDefault(-1),
            sys_stats.loadavg_5.GetValueOrDefault(-1),
            sys_stats.loadavg_15.GetValueOrDefault(-1),
        };

        /// <summary>
        /// Uptime of the infrastructure device
        /// </summary>
        public TimeSpan Uptime => TimeSpan.FromSeconds(uptime);

        /// <summary>
        /// Amount of RAM the infrastructure device has onboard
        /// </summary>
        public long MemoryTotal => sys_stats.mem_total.GetValueOrDefault(-1);

        /// <summary>
        /// Amount of RAM currently in use on the infrastructure device
        /// </summary>
        public long MemoryUsed => sys_stats.mem_used.GetValueOrDefault(-1);

        /// <summary>
        /// Clients attached to the device
        /// </summary>
        public List<IClientNetworkedDevice> Clients { get; internal set; } = new List<IClientNetworkedDevice>();

        /// <summary>
        /// Other infrastructure devices which are downstream of this device
        /// </summary>
        public List<IInfrastructureNetworkedDevice> InfrastructureDevices { get; internal set; } = new List<IInfrastructureNetworkedDevice>();

        protected UniFiApi API { get; set; }
        internal IInfrastructureNetworkedDevice() { }

        /// <summary>
        /// Activate the "locate" function on the device, which causes its LED to flash for a given number of milliseconds
        /// </summary>
        /// <param name="durationOfLocateMs">Amount of time to flash the locator LED for</param>
        /// <returns></returns>
        public async Task Locate(int durationOfLocateMs = 5000)
        {
            await API.NetworkDeviceLocate(mac, true)
                .ContinueWith(t1 => Task.Delay(durationOfLocateMs))
                .ContinueWith(t2 => API.NetworkDeviceLocate(mac, false));
        }

        /// <summary>
        /// Set the user-defined name of the infrastructure device
        /// </summary>
        /// <param name="newName">User-defined name</param>
        /// <returns></returns>
        public async Task SetName(string newName)
        {
            await API.NetworkDeviceConfigure(device_id, NetworkDeviceConfigurations.Name(newName));
        }

        /// <summary>
        /// Run the adoption process to bring this infrastructure device under the control of the UniFi controller
        /// </summary>
        /// <returns></returns>
        public async Task Adopt()
        {
            await API.NetworkDeviceAdopt(mac);
        }

        /// <summary>
        /// Instruct the UniFi controller to "forget" about this infrastructure device, making it no longer managed
        /// </summary>
        /// <returns></returns>
        public async Task Forget()
        {
            await API.NetworkDeviceForget(mac);
        }

        internal static IInfrastructureNetworkedDevice CreateFromJson(UniFiApi api, JsonNetworkDevice device)
        {
            switch (device.type)
            {
                case "uap":
                    return device.CloneAs<AccessPointInfrastructureNetworkedDevice>(d => d.API = api);
                case "usw":
                    return device.CloneAs<SwitchInfrastructureNetworkedDevice>(d => d.API = api);
                case "ugw":
                    return device.CloneAs<RouterInfrastructureNetworkedDevice>(d => d.API = api);
                default:
                    return device.CloneAs<UnknownInfrastructureNetworkedDevice>(d => d.API = api);
            }
        }
    }
}
