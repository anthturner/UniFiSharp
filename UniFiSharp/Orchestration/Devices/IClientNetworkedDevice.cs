using System;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    public abstract class IClientNetworkedDevice : INetworkedDevice
    {
        public override string Id => Json._id;
        public override string Name => string.IsNullOrEmpty(Json.name) ? string.IsNullOrEmpty(Json.hostname) ? Json.mac : Json.hostname : Json.name;
        public string UserId => Json.user_id;
        public DateTime FirstSeen => new DateTime(1970, 1, 1).AddSeconds(Json.first_seen);
        public DateTime LastSeen => new DateTime(1970, 1, 1).AddSeconds(Json.last_seen);
        public bool IsGuest => Json.is_guest;
        public bool IsAuthorized => Json.authorized;
        public string Hostname => Json.hostname;
        public bool UseFixedIpAddress => Json.use_fixedip.GetValueOrDefault(false);
        public string FixedIpAddress => Json.fixed_ip;
        public string IpAddress => Json.ip;
        public long IdleTime => Json.idletime;
        public string MacAddress => Json.mac;
        public string Network => Json.network;
        public string NetworkId => Json.network_id;
        public string OUI => Json.oui;
        public bool PowersaveEnabled => Json.powersave_enabled;
        public bool QosPolicyApplied => Json.qos_policy_applied;
        public double ActivityKbps => (Json.bytes_r * 8) / 1024.0d;
        public TimeSpan Uptime => TimeSpan.FromSeconds(Json.uptime);

        protected JsonClient Json { get; private set; }

        protected IClientNetworkedDevice(UniFiApi api, JsonClient json) : base(api)
        {
            Json = json;
        }

        public async Task ForceReconnect()
        {
            await API.ClientForceReconnect(MacAddress);
        }

        public static IClientNetworkedDevice CreateFromJson(UniFiApi api, JsonClient client)
        {
            if (client.is_wired)
                return new WiredClientNetworkedDevice(api, client);
            else
                return new WirelessClientNetworkedDevice(api, client);
        }
    }
}
