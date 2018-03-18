using System.Net;
using System.Threading.Tasks;

namespace UniFiSharp.Discovery
{
    public abstract class DeviceInformation
    {
        public string Firmware { get; protected set; }
        public string Hostname { get; protected set; }
        public string Platform { get; protected set; }
        public string IPAddress { get; protected set; }
        public string MacAddress { get; protected set; }
        public string ESSID { get; protected set; }
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