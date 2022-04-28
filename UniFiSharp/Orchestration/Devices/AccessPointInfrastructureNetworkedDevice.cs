using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// Represents a UniFi wireless access point infrastructure device
    /// </summary>
    public class AccessPointInfrastructureNetworkedDevice : IInfrastructureNetworkedDevice
    {
        /// <summary>
        /// List of client devices and the ESSIDs on which they are connected to this AP
        /// </summary>
        public List<Tuple<IClientNetworkedDevice, string>> ClientsWithEssids =>
            Clients.Select(c =>
                Tuple.Create(c, ((WirelessClientNetworkedDevice)c).essid)).ToList();

        internal AccessPointInfrastructureNetworkedDevice() { }

        /// <summary>
        /// Start an RF spectrum scan from this access point. It will be unavailable for approximately 15 minutes while the scan is running.
        /// </summary>
        /// <param name="msBetweenResultChecks">Time (in ms) to wait between checking for results</param>
        /// <remarks>The task returned will live until the result is returned to the caller</remarks>
        /// <returns>Long-living task which will return results of the RF spectrum scan once complete</returns>
        public Task<Json.JsonSpectrumScan> RunRfScan(int msBetweenResultChecks = 10000)
        {
            return Task.Run(async () =>
            {
                await API.NetworkDeviceRfScan(mac);
                while (true)
                {
                    var result = await API.NetworkDeviceRfScanStatus(mac);
                    if (result != null && !result.spectrum_scanning)
                        return result;
                    await Task.Delay(msBetweenResultChecks);
                }
            });
        }
    }
}
