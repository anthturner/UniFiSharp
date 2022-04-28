using System.Net;
using System.Threading.Tasks;

namespace UniFiSharp.Discovery
{
    /// <summary>
    /// Provides information about a discovered UniFi-based device
    /// </summary>
    public abstract class DeviceInformation
    {
        /// <summary>
        /// Firmware version running on the device
        /// </summary>
        public string Firmware { get; protected set; }

        /// <summary>
        /// Hostname of the device
        /// </summary>
        public string Hostname { get; protected set; }

        /// <summary>
        /// Platform for the device
        /// </summary>
        public string Platform { get; protected set; }

        /// <summary>
        /// IP Address assigned to the device
        /// </summary>
        public string IPAddress { get; protected set; }

        /// <summary>
        /// MAC (Hardware) Address to identify the device
        /// </summary>
        public string MacAddress { get; protected set; }

        /// <summary>
        /// ESSID which the device is broadcasting
        /// </summary>
        public string ESSID { get; protected set; }

        /// <summary>
        /// Model information for the device
        /// </summary>
        public string Model { get; protected set; }

        public int WMode { get; protected set; }

        internal DeviceInformation()
        {
        }

        public override bool Equals(object obj)
        {
            var item = obj as DeviceInformation;
            if (item == null) return false;
            return this.MacAddress == item.MacAddress;
        }

        public override int GetHashCode()
        {
            return this.MacAddress.GetHashCode();
        }

        /// <summary>
        /// Parse a reply packet from a discovery request into either a V1 or V2 information payload
        /// </summary>
        /// <param name="endpoint">IP Endpoint of device</param>
        /// <param name="packet">Packet bytes</param>
        /// <returns>Device information payload</returns>
        public static async Task<DeviceInformation> Parse(IPEndPoint endpoint, byte[] packet)
        {
            var version = packet[0];
            var cmd = packet[1];
            var length = packet[2];

            if (length + 4 > packet.Length)
                return null;
            if (version == 1 && cmd == 0 && length == 0)
                return null; // drop ubnt-dp request

            if (version == 1 && cmd == 0)
                return await Task.FromResult(DeviceInformationV1.Parse(packet));
            else if (version == 2)
                return await DeviceInformationV2.Parse(endpoint, cmd, packet);
            else
                return null;
        }
    }
}