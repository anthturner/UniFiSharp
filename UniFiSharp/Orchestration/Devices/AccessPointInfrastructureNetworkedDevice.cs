﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Json;

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
                Tuple.Create(c, ((WirelessClientNetworkedDevice)c).Essid)).ToList();

        /// <summary>
        /// Radio configuration for the 5GHz radio
        /// </summary>
        public AccessPointRadio RadioNA => new AccessPointRadio(Json.radio_na);

        /// <summary>
        /// Radio configuration for the 2.4GHz radio
        /// </summary>
        public AccessPointRadio RadioNG => new AccessPointRadio(Json.radio_ng);

        /// <summary>
        /// Radio configurations for all radios onboard this access point
        /// </summary>
        public List<AccessPointRadio> Radios => Json.radio_table.Select(r => new AccessPointRadio(r)).ToList();

        /// <summary>
        /// ESSID configurations for all ESSIDs offered by this access point
        /// </summary>
        public List<AccessPointEssid> Essids => Json.vap_table.Select(v => new AccessPointEssid(v)).ToList();
        
        internal AccessPointInfrastructureNetworkedDevice(UniFiApi api, JsonNetworkDevice json) : base(api, json) { }

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
                await API.NetworkDeviceRfScan(MacAddress);
                while (true)
                {
                    var result = await API.NetworkDeviceRfScanStatus(MacAddress);
                    if (result != null && !result.spectrum_scanning)
                        return result;
                    await Task.Delay(msBetweenResultChecks);
                }
            });
        }

        public class AccessPointEssid
        {
            /// <summary>
            /// MAC Address of the Access Point
            /// </summary>
            public string ApMac => Json.ap_mac;

            /// <summary>
            /// BSSID for this Access Point's ESSID
            /// </summary>
            public string Bssid => Json.bssid;
            public int CCQ => Json.ccq;
            public int Channel => Json.channel;
            public int? ExtChannel => Json.extchannel;
            public string Id => Json.id;
            public bool IsGuestNetwork => Json.is_guest;
            public bool IsWepEnabled => Json.is_wep;
            public string Name => Json.name;
            public int ClientCount => Json.num_sta;
            public string RadioType => Json.radio;

            /// <summary>
            /// Received bytes
            /// </summary>
            public long RxBytes => Json.rx_bytes;

            /// <summary>
            /// Received packets which were encrypted and had errors
            /// </summary>
            public long RxCrypts => Json.rx_crypts;

            /// <summary>
            /// Received packets which were dropped
            /// </summary>
            public long RxDropped => Json.rx_dropped;

            /// <summary>
            /// Received packets which were errors
            /// </summary>
            public long RxErrors => Json.rx_errors;

            /// <summary>
            /// Received fragments
            /// </summary>
            public long RxFrags => Json.rx_frags;

            /// <summary>
            /// Received network IDs
            /// </summary>
            public long RxNwIds => Json.rx_nwids;

            /// <summary>
            /// Received packets
            /// </summary>
            public long RxPackets => Json.rx_packets;

            // ---

            /// <summary>
            /// Transmitted bytes
            /// </summary>
            public long TxBytes => Json.tx_bytes;

            /// <summary>
            /// Transmitted packets which were dropped
            /// </summary>
            public long TxDropped => Json.tx_dropped;

            /// <summary>
            /// Transmitted packets which were errors
            /// </summary>
            public long TxErrors => Json.tx_errors;

            /// <summary>
            /// Transmitted packges
            /// </summary>
            public long TxPackets => Json.tx_packets;

            /// <summary>
            /// Transmit power for this ESSID
            /// </summary>
            public int TxPower => Json.tx_power;

            /// <summary>
            /// Number of transmit retries
            /// </summary>
            public long TxRetries => Json.tx_retries;

            /// <summary>
            /// If the ESSID is currently active
            /// </summary>
            public bool IsUp => Json.up;

            public string UsageMode => Json.usage;

            private JsonNetworkDevice.JsonVapTable Json { get; set; }

            public AccessPointEssid(JsonNetworkDevice.JsonVapTable json)
            {
                Json = json;
            }
        }

        public class AccessPointRadio
        {
            public int AntennaGain => Json.antenna_gain;
            public int BuiltInAntennaGain => Json.builtin_ant_gain;
            public bool HasBuiltInAntenna => Json.builtin_antenna;
            public bool? HardNoiseFloorEnabled => Json.hard_noise_floor_enabled;
            public bool? HasDFS => Json.has_dfs;
            public bool? HasFCCDFS => Json.has_fccdfs;
            public int HTMode => Json.ht;
            public bool? Is11ac => Json.is_11ac;
            public int MaxTxPower => Json.max_txpower;
            public bool MinRssiEnabled => Json.min_rssi_enabled;
            public int MinTxPower => Json.min_txpower;
            public string Name => Json.name;
            public int NSS => Json.nss;
            public string RadioType => Json.radio;
            public string TxPowerMode => Json.tx_power_mode;

            private JsonNetworkDevice.JsonRadioTable Json { get; set; }

            public AccessPointRadio(JsonNetworkDevice.JsonRadioTable json)
            {
                Json = json;
            }
        }
    }
}
