using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UniFiSharp.Discovery;

namespace UniFiSharp
{
    public partial class UniFiApi
    {
        // This partial class contains the constants and functions to facilitate device discovery

        private static IPAddress MULTICAST_ADDRESS = IPAddress.Parse("233.89.188.1");
        private const int MULTICAST_PORT = 10001;
        private static byte[] MULTICAST_MESSAGE = new byte[] { 0x01, 0x00, 0x00, 0x00 };
        private static byte[] MULTICAST_MESSAGE_V2 = new byte[] { 0x02, 0x08, 0x00, 0x00 };

        private const int UDP_TIMEOUT_MS = 1000;

        /// <summary>
        /// Discover Ubiquiti UniFi devices by sending requests to a given list of IP addresses on the standard multicast port (10001).
        /// </summary>
        /// <param name="ipAddresses">IEnumerable of IP addresses to scan</param>
        /// <returns>List of discovered devices from given range</returns>
        public async static Task<List<DeviceInformation>> DiscoverControllers(IEnumerable<IPAddress> ipAddresses)
        {
            var tasks = new List<Task<DeviceInformation>>();
            foreach (var ip in ipAddresses)
            {
                if (IPAddress.Broadcast.Equals(ip))
                {
                    tasks.Add(DiscoverController(ip, MULTICAST_PORT, MULTICAST_MESSAGE, SocketFlags.Broadcast));
                    tasks.Add(DiscoverController(ip, MULTICAST_PORT, MULTICAST_MESSAGE_V2, SocketFlags.Broadcast));
                }
                else if (MULTICAST_ADDRESS.Equals(ip))
                {
                    tasks.Add(DiscoverController(ip, MULTICAST_PORT, MULTICAST_MESSAGE, SocketFlags.Multicast));
                    tasks.Add(DiscoverController(ip, MULTICAST_PORT, MULTICAST_MESSAGE_V2, SocketFlags.Multicast));
                }
                else
                {
                    tasks.Add(DiscoverController(ip, MULTICAST_PORT, MULTICAST_MESSAGE, SocketFlags.None));
                    tasks.Add(DiscoverController(ip, MULTICAST_PORT, MULTICAST_MESSAGE_V2, SocketFlags.None));
                }
            }

            await Task.WhenAll(tasks);
            return tasks.Where(t => t.Result != null).Select(t => t.Result).Distinct().ToList();
        }

        public async static Task<List<DeviceInformation>> DiscoverControllers()
        {
            return await DiscoverControllers(new[]
            {
                IPAddress.Broadcast,
                MULTICAST_ADDRESS,
            });
        }

        private async static Task<DeviceInformation> DiscoverController(IPAddress ip, int port, byte[] message, SocketFlags flags)
        {
            var endpoint = new IPEndPoint(ip, port);

            var udp = new UdpClient();
            var result = await udp.SendAsync(message, message.Length, endpoint);

            var receiveTask = udp.ReceiveAsync();
            await Task.WhenAny(receiveTask, Task.Delay(UDP_TIMEOUT_MS));

            if (receiveTask.IsCompleted)
                return await DeviceInformation.Parse(receiveTask.Result.RemoteEndPoint, receiveTask.Result.Buffer);
            return null;
        }
    }
}