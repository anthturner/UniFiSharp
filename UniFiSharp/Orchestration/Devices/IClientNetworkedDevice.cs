using System;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    public abstract class IClientNetworkedDevice : INetworkedDevice
    {
        /// <summary>
        /// Client ID
        /// </summary>
        public override string Id => Json._id;

        /// <summary>
        /// User-defined name of the client if it exists, otherwise this will return the MAC address
        /// </summary>
        public override string Name => string.IsNullOrEmpty(Json.name) ? string.IsNullOrEmpty(Json.hostname) ? Json.mac : Json.hostname : Json.name;

        /// <summary>
        /// User ID authenticated on the client
        /// </summary>
        public string UserId => Json.user_id;

        /// <summary>
        /// First time this client was seen on the network
        /// </summary>
        public DateTime FirstSeen => new DateTime(1970, 1, 1).AddSeconds(Json.first_seen);

        /// <summary>
        /// Most recent time this client was seen on the network
        /// </summary>
        public DateTime LastSeen => new DateTime(1970, 1, 1).AddSeconds(Json.last_seen);

        /// <summary>
        /// If the client is running via a guest network/hotspot
        /// </summary>
        public bool IsGuest => Json.is_guest;

        /// <summary>
        /// If the client has gone through a device authorization process
        /// </summary>
        public bool IsAuthorized => Json.authorized;

        /// <summary>
        /// Hostname of the client
        /// </summary>
        public string Hostname => Json.hostname;

        /// <summary>
        /// If the client is configured to use a fixed IP address or DHCP-based address
        /// </summary>
        public bool UseFixedIpAddress => Json.use_fixedip.GetValueOrDefault(false);

        /// <summary>
        /// Fixed IP address the client must use
        /// </summary>
        public string FixedIpAddress => Json.fixed_ip;

        /// <summary>
        /// IP address assigned to the client
        /// </summary>
        public string IpAddress => Json.ip;

        /// <summary>
        /// Amount of time since the client has generated traffic
        /// </summary>
        public long IdleTime => Json.idletime;

        /// <summary>
        /// MAC address of the client
        /// </summary>
        public string MacAddress => Json.mac;

        /// <summary>
        /// Network the client is attached to
        /// </summary>
        public string Network => Json.network;

        /// <summary>
        /// Network ID the client is attached to
        /// </summary>
        public string NetworkId => Json.network_id;

        /// <summary>
        /// Organizationally Unique Identifier (OUI) for the client MAC address
        /// </summary>
        public string OUI => Json.oui;

        /// <summary>
        /// If the client's network card is in power-save mode
        /// </summary>
        public bool PowersaveEnabled => Json.powersave_enabled;

        /// <summary>
        /// If a quality-of-service policy is applied to the client
        /// </summary>
        public bool QosPolicyApplied => Json.qos_policy_applied;

        /// <summary>
        /// Measure of the current receive activity of the device in KBps
        /// </summary>
        public double ActivityKbps => (Json.bytes_r * 8) / 1024.0d;

        /// <summary>
        /// Uptime of the client
        /// </summary>
        public TimeSpan Uptime => TimeSpan.FromSeconds(Json.uptime);

        protected JsonClient Json { get; private set; }

        protected IClientNetworkedDevice(UniFiApi api, JsonClient json) : base(api)
        {
            Json = json;
        }

        /// <summary>
        /// Force the client device to disconnect and reconnect, including any negotiation steps
        /// </summary>
        /// <returns></returns>
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
