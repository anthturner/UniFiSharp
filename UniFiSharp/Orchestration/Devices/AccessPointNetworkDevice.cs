using System.Threading.Tasks;
using UniFiSharp.Protocol;

namespace UniFiSharp.Orchestration.Devices
{
    public class AccessPointNetworkDevice : IUniFiNetworkDevice
    {
        public AccessPointNetworkDevice(UniFiApi api, string macAddress) : base(api, macAddress)
        {
        }

        public AccessPointNetworkDevice(UniFiApi api, NetworkDevice deviceData) : base(api, deviceData)
        {
        }

        /// <summary>
        /// Run RF Scan (takes AP offline for 5-10 minutes)
        /// </summary>
        /// <returns></returns>
        public async Task RunRFScan()
        {
            await _api.RFScan(MacAddress);
        }

        /// <summary>
        /// Get status of RF scan
        /// </summary>
        /// <returns></returns>
        public async Task RFScanStatus()
        {
            // todo: return status
            await _api.RFScanStatus(MacAddress);
        }
    }
}