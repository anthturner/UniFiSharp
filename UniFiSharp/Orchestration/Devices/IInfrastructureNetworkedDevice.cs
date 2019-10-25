using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
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

        public override string Id => Json._id;
        public int State => Json.state;
        public bool IsAdopted => Json.adopted;
        public bool UsingDefaultSettings => Json.defaultSettings;
        public string MacAddress => Json.mac;
        public string IpAddress => Json.ip;
        public override string Name => string.IsNullOrEmpty(Json.name) ? Json.mac : Json.name;
        public string Model => Json.model;
        public string Type => Json.type;
        public string SerialNumber => Json.serial;
        public string DeviceId => Json.device_id;

        public int DesktopClientCount => Json.num_desktop;
        public int MobileClientCount => Json.num_mobile;
        public int HandheldClientCount => Json.num_handheld;
        public int ClientCount => Json.num_sta;

        public DeviceLink Uplink => Json.uplink != null ? new DeviceLink(Json.uplink) : null;

        public double[] LoadAverage => new double[] {
            Json.sys_stats.loadavg_1.GetValueOrDefault(-1),
            Json.sys_stats.loadavg_5.GetValueOrDefault(-1),
            Json.sys_stats.loadavg_15.GetValueOrDefault(-1),
        };

        public TimeSpan Uptime => TimeSpan.FromSeconds(Json.uptime);

        public int MemoryTotal => Json.sys_stats.mem_total.GetValueOrDefault(-1);
        public int MemoryUsed => Json.sys_stats.mem_used.GetValueOrDefault(-1);

        public string Version => Json.version;

        public List<IClientNetworkedDevice> Clients { get; internal set; }
        public List<IInfrastructureNetworkedDevice> InfrastructureDevices { get; internal set; }

        public bool? HasSpeaker => Json.has_speaker;
        public int Volume => Json.volume;

        protected JsonNetworkDevice Json { get; private set; }

        protected IInfrastructureNetworkedDevice(UniFiApi api, JsonNetworkDevice json) : base(api)
        {
            Json = json;
            Clients = new List<IClientNetworkedDevice>();
            InfrastructureDevices = new List<IInfrastructureNetworkedDevice>();
        }

        public async Task Locate(int durationOfLocateMs = 5000)
        {
            await API.NetworkDeviceLocate(MacAddress, true)
                .ContinueWith(t1 => Task.Delay(durationOfLocateMs))
                .ContinueWith(t2 => API.NetworkDeviceLocate(MacAddress, false));
        }

        public async Task SetName(string newName)
        {
            await API.NetworkDeviceConfigure(DeviceId, NetworkDeviceConfigurations.Name(newName));
        }

        public async Task Adopt()
        {
            await API.NetworkDeviceAdopt(MacAddress);
        }

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
            public bool IsEnabled => Json.enable;
            public bool IsFullDuplex => Json.full_duplex;
            public string Gateway => Json.gateway;
            public IList<string> Gateways => Json.gateways;
            public string Ip => Json.ip;
            public int Latency => Json.latency;
            public string Mac => Json.mac;
            public int MaxSpeed => Json.max_speed;
            public string Name => Json.name;
            public IList<string> Nameservers => Json.nameservers;
            public string NetMask => Json.netmask;
            public int PortNumber => Json.num_port;
            public int Speed => Json.speed;
            public string Type => Json.type;
            public bool IsUp => Json.up;
            public string UplinkMac => Json.uplink_mac;
            public int? UplinkRemotePort => Json.uplink_remote_port;
            public TimeSpan Uptime => TimeSpan.FromSeconds(Json.uptime);

            private JsonNetworkDevice.JsonLink Json { get; set; }

            public DeviceLink(JsonNetworkDevice.JsonLink json)
            {
                Json = json;
            }
        }
    }
}
