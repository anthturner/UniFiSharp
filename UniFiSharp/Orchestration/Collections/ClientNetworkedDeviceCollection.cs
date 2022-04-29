using System;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Devices;

namespace UniFiSharp.Orchestration.Collections
{
    /// <summary>
    /// Collection of client devices attached to the UniFi network
    /// </summary>
    public class ClientNetworkedDeviceCollection : RemotedDataCollection<IClientNetworkedDevice>
    {
        internal ClientNetworkedDeviceCollection(UniFiApi api) : base(api) { }

        /// <summary>
        /// Retrieve a client device by its MAC address
        /// </summary>
        /// <param name="macAddress">MAC Address of client</param>
        /// <returns>Client device or <c>NULL</c></returns>
        public IClientNetworkedDevice GetByMac(string macAddress)
        {
            return CachedCollection.FirstOrDefault(c => c.mac.Equals(macAddress, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieve a client device by its Client ID
        /// </summary>
        /// <param name="id">Client ID of client</param>
        /// <returns>Client device or <c>NULL</c></returns>
        public IClientNetworkedDevice GetById(string id)
        {
            return CachedCollection.FirstOrDefault(c => c._id.Equals(id));
        }

        /// <summary>
        /// Refresh the collection of client devices
        /// </summary>
        /// <returns></returns>
        public override async Task Refresh()
        {
            CachedCollection = (await API.ClientList())
                .Select(c => IClientNetworkedDevice.CreateFromJson(API, c)).ToList();
        }
    }
}
