using System;
using System.Linq;
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
        public async Task<RFSpectrumScan> RFScanStatus()
        {
            return await _api.RFScanStatus(MacAddress);
        }

        public async Task<Tuple<int, int>> PickBestChannel()
        {
            var results = await RFScanStatus();
            var orderedNa = results.spectrum_table_na.OrderBy(s => s.Weight);
            var orderedNg = results.spectrum_table_ng.OrderBy(s => s.Weight);
            return Tuple.Create(orderedNa.First().channel, orderedNg.First().channel);
        }
    }
}