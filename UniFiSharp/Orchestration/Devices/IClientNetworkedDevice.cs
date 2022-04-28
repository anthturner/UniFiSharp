using System;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    public abstract class IClientNetworkedDevice : JsonClient, INetworkedDevice
    {
        /// <summary>
        /// User-defined name of the client if it exists, otherwise this will return the MAC address
        /// </summary>
        public string NameOrMac => string.IsNullOrEmpty(name) ? string.IsNullOrEmpty(hostname) ? mac : hostname : name;

        /// <summary>
        /// First time this client was seen on the network
        /// </summary>
        public DateTime FirstSeen => new DateTime(1970, 1, 1).AddSeconds(first_seen);

        /// <summary>
        /// Most recent time this client was seen on the network
        /// </summary>
        public DateTime LastSeen => new DateTime(1970, 1, 1).AddSeconds(last_seen);

        /// <summary>
        /// Measure of the current receive activity of the device in KBps
        /// </summary>
        public double ActivityKbps => (bytes_r * 8) / 1024.0d;

        /// <summary>
        /// Uptime of the client
        /// </summary>
        public TimeSpan Uptime => TimeSpan.FromSeconds(uptime);

        protected UniFiApi API { get; set; }
        internal IClientNetworkedDevice() { }

        /// <summary>
        /// Force the client device to disconnect and reconnect, including any negotiation steps
        /// </summary>
        /// <returns></returns>
        public async Task ForceReconnect()
        {
            await API.ClientForceReconnect(mac);
        }
         
        internal static IClientNetworkedDevice CreateFromJson(UniFiApi api, JsonClient client)
        {
            if (client.is_wired)
                return client.CloneAs<WiredClientNetworkedDevice>(d => d.API = api);
            else
                return client.CloneAs<WirelessClientNetworkedDevice>(d => d.API = api);
        }
    }
}
