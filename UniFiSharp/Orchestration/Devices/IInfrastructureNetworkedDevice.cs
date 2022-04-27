using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// Base class for any infrastructure device (router, switch, AP) on the network
    /// </summary>
    public abstract class IInfrastructureNetworkedDevice : INetworkedDevice
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
                switch (this.State)
                {
                    case 0:
                        return NetworkDeviceState.Disconnected; // According to the UniFi app, 0 represents restarting although this does not reflect real-world testing where 0 = Disconnected.

                    case 1:
                        return NetworkDeviceState.Connected;

                    case 2:
                        if (this.UsingDefaultSettings) // if we're not on default settings, the controller can't adopt
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
        /// Network device ID
        /// </summary>
        public override string Id => Json._id;

        /// <summary>
        /// Operating state of the device (as a string)
        /// </summary>
        public int State => Json.state;

        /// <summary>
        /// If the infrastructure device has been adopted by the UniFi controller
        /// </summary>
        public bool IsAdopted => Json.adopted;

        /// <summary>
        /// If the infrastructure device is using factory default settings
        /// </summary>
        public bool UsingDefaultSettings => Json.defaultSettings;

        /// <summary>
        /// MAC Address of the infrastructure device
        /// </summary>
        public string MacAddress => Json.mac;

        /// <summary>
        /// IP address of the infrastructure device
        /// </summary>
        public string IpAddress => Json.ip;

        /// <summary>
        /// User-defined name of the device if it exists, otherwise this will return the MAC address
        /// </summary>
        public override string Name => string.IsNullOrEmpty(Json.name) ? Json.mac : Json.name;

        /// <summary>
        /// Infrastructure device model
        /// </summary>
        public string Model => Json.model;

        /// <summary>
        /// Type of infrastructure device
        /// </summary>
        public string Type => Json.type;

        /// <summary>
        /// Serial number of the infrastructure device
        /// </summary>
        public string SerialNumber => Json.serial;

        /// <summary>
        /// Device ID for the infrastructure device
        /// </summary>
        public string DeviceId => Json.device_id;

        /// <summary>
        /// Number of desktop clients attached to the device
        /// </summary>
        public int DesktopClientCount => Json.num_desktop;

        /// <summary>
        /// Number of mobile clients attached to the device
        /// </summary>
        public int MobileClientCount => Json.num_mobile;

        /// <summary>
        /// Number of hand-held clients attached to the device
        /// </summary>
        public int HandheldClientCount => Json.num_handheld;

        /// <summary>
        /// Total number of clients attached to the device
        /// </summary>
        public int ClientCount => Json.num_sta;

        /// <summary>
        /// Device which is upstream of this infrastructure device in the network hierarchy
        /// </summary>
        public DeviceLink Uplink => Json.uplink != null ? new DeviceLink(Json.uplink) : null;

        /// <summary>
        /// Load averages for this device for the previous 1, 5, and 15 minutes
        /// </summary>
        public double[] LoadAverage => new double[] {
            Json.sys_stats.loadavg_1.GetValueOrDefault(-1),
            Json.sys_stats.loadavg_5.GetValueOrDefault(-1),
            Json.sys_stats.loadavg_15.GetValueOrDefault(-1),
        };

        /// <summary>
        /// Uptime of the infrastructure device
        /// </summary>
        public TimeSpan Uptime => TimeSpan.FromSeconds(Json.uptime);

        /// <summary>
        /// Amount of RAM the infrastructure device has onboard
        /// </summary>
        public long MemoryTotal => Json.sys_stats.mem_total.GetValueOrDefault(-1);

        /// <summary>
        /// Amount of RAM currently in use on the infrastructure device
        /// </summary>
        public long MemoryUsed => Json.sys_stats.mem_used.GetValueOrDefault(-1);

        /// <summary>
        /// Version of the infrastructure device's firmware
        /// </summary>
        public string Version => Json.version;

        /// <summary>
        /// Clients attached to the device
        /// </summary>
        public List<IClientNetworkedDevice> Clients { get; internal set; }

        /// <summary>
        /// Other infrastructure devices which are downstream of this device
        /// </summary>
        public List<IInfrastructureNetworkedDevice> InfrastructureDevices { get; internal set; }

        /// <summary>
        /// If the device has a speaker
        /// </summary>
        public bool? HasSpeaker => Json.has_speaker;

        /// <summary>
        /// The volume of the speaker on the device, if one is present
        /// </summary>
        public int Volume => Json.volume;

        protected JsonNetworkDevice Json { get; private set; }

        protected IInfrastructureNetworkedDevice(UniFiApi api, JsonNetworkDevice json) : base(api)
        {
            Json = json;
            Clients = new List<IClientNetworkedDevice>();
            InfrastructureDevices = new List<IInfrastructureNetworkedDevice>();
        }

        /// <summary>
        /// Activate the "locate" function on the device, which causes its LED to flash for a given number of milliseconds
        /// </summary>
        /// <param name="durationOfLocateMs">Amount of time to flash the locator LED for</param>
        /// <returns></returns>
        public async Task Locate(int durationOfLocateMs = 5000)
        {
            await API.NetworkDeviceLocate(MacAddress, true)
                .ContinueWith(t1 => Task.Delay(durationOfLocateMs))
                .ContinueWith(t2 => API.NetworkDeviceLocate(MacAddress, false));
        }

        /// <summary>
        /// Set the user-defined name of the infrastructure device
        /// </summary>
        /// <param name="newName">User-defined name</param>
        /// <returns></returns>
        public async Task SetName(string newName)
        {
            await API.NetworkDeviceConfigure(DeviceId, NetworkDeviceConfigurations.Name(newName));
        }

        /// <summary>
        /// Run the adoption process to bring this infrastructure device under the control of the UniFi controller
        /// </summary>
        /// <returns></returns>
        public async Task Adopt()
        {
            await API.NetworkDeviceAdopt(MacAddress);
        }

        /// <summary>
        /// Instruct the UniFi controller to "forget" about this infrastructure device, making it no longer managed
        /// </summary>
        /// <returns></returns>
        public async Task Forget()
        {
            await API.NetworkDeviceForget(MacAddress);
        }

        public static IInfrastructureNetworkedDevice CreateFromJson(UniFiApi api, JsonNetworkDevice device)
        {
            switch (device.type)
            {
                case "uap":
                    return new AccessPointInfrastructureNetworkedDevice(api, device);
                case "usw":
                    return new SwitchInfrastructureNetworkedDevice(api, device);
                case "ugw":
                    return new RouterInfrastructureNetworkedDevice(api, device);
                default:
                    return new UnknownInfrastructureNetworkedDevice(api, device);
            }
        }

        public class DeviceLink
        {
            /// <summary>
            /// If the link is enabled
            /// </summary>
            public bool IsEnabled => Json.enable;

            /// <summary>
            /// If the link is full or half duplex
            /// </summary>
            public bool IsFullDuplex => Json.full_duplex;

            /// <summary>
            /// Primary gateway IP address for the link
            /// </summary>
            public string Gateway => Json.gateway;

            /// <summary>
            /// All gateway IP addresses for the link
            /// </summary>
            public IList<string> Gateways => Json.gateways;

            /// <summary>
            /// IP address associated with the link
            /// </summary>
            public string Ip => Json.ip;

            /// <summary>
            /// Latency (ping) between each end of the link
            /// </summary>
            public int Latency => Json.latency;

            /// <summary>
            /// MAC Address of the device connected
            /// </summary>
            public string Mac => Json.mac;

            /// <summary>
            /// Maximum speed possible for the link
            /// </summary>
            public int MaxSpeed => Json.max_speed;

            /// <summary>
            /// User-defined name for the link
            /// </summary>
            public string Name => Json.name;

            /// <summary>
            /// DNS nameservers used by the device linked
            /// </summary>
            public IList<string> Nameservers => Json.nameservers;

            /// <summary>
            /// Subnet mask of the device linked
            /// </summary>
            public string NetMask => Json.netmask;

            /// <summary>
            /// Port number this link is present on
            /// </summary>
            public int PortNumber => Json.num_port;

            /// <summary>
            /// Negotiated link speed
            /// </summary>
            public int Speed => Json.speed;

            /// <summary>
            /// Link type
            /// </summary>
            public string Type => Json.type;

            /// <summary>
            /// If the link is currently up (active)
            /// </summary>
            public bool IsUp => Json.up;

            /// <summary>
            /// MAC Address of the infrastructure device upstream of the other device
            /// </summary>
            public string UplinkMac => Json.uplink_mac;

            /// <summary>
            /// Port number the uplink is connected through
            /// </summary>
            public int? UplinkRemotePort => Json.uplink_remote_port;
            
            /// <summary>
            /// Amount of time the link has been active
            /// </summary>
            public TimeSpan Uptime => TimeSpan.FromSeconds(Json.uptime);

            private JsonNetworkDevice.JsonLink Json { get; set; }

            public DeviceLink(JsonNetworkDevice.JsonLink json)
            {
                Json = json;
            }
        }
    }
}
