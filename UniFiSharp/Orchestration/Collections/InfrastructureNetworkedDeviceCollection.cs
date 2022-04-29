using System;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Devices;

namespace UniFiSharp.Orchestration.Collections
{
    /// <summary>
    /// Collection of infrastructure (managed) devices attached to the UniFi network
    /// </summary>
    public class InfrastructureNetworkedDeviceCollection : RemotedDataCollection<IInfrastructureNetworkedDevice>
    {
        internal InfrastructureNetworkedDeviceCollection(UniFiApi api) : base(api) { }

        /// <summary>
        /// Retrieve an infrastructure device by its MAC address
        /// </summary>
        /// <param name="macAddress">MAC Address of infrastructure device</param>
        /// <returns>Infrastructure device or <c>NULL</c></returns>
        public IInfrastructureNetworkedDevice GetByMac(string macAddress)
        {
            return CachedCollection.FirstOrDefault(c => c.mac.Equals(macAddress, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieve an infrastructure device by its Device ID
        /// </summary>
        /// <param name="id">Device ID of infrastructure device</param>
        /// <returns>Infrastructure device or <c>NULL</c></returns>
        public IInfrastructureNetworkedDevice GetById(string id)
        {
            return CachedCollection.FirstOrDefault(c => c.device_id.Equals(id));
        }

        /// <summary>
        /// Refresh the collection of infrastructure devices
        /// </summary>
        /// <returns></returns>
        public override async Task Refresh()
        {
            CachedCollection = (await API.NetworkDeviceList())
                .Select(d => IInfrastructureNetworkedDevice.CreateFromJson(API, d)).ToList();
        }
    }
}
