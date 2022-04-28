using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonSystemHealth
    {
        // TODO
        [JsonProperty("drops")]
        public float drops { get; set; }

        /// <summary>
        /// Gateways known on the network
        /// </summary>
        [DisplayName("Gateways")]
        [JsonProperty("gateways")]
        public List<string> gateways { get; set; } = new List<string>();

        /// <summary>
        /// Primary gateway MAC address
        /// </summary>
        [DisplayName("Gateway MAC Address")]
        [JsonProperty("gw_mac")]
        public string gwMac { get; set; }

        /// <summary>
        /// Public IP address
        /// </summary>
        [DisplayName("Public IP")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("ip")]
        public string ip { get; set; }

        // TODO: Verify below
        /// <summary>
        /// LAN IP address of router
        /// </summary>
        [DisplayName("LAN IP")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("lan_ip")]
        public string lanIp { get; set; }

        // TODO: Verify below
        /// <summary>
        /// Current network latency
        /// </summary>
        [DisplayName("Latency")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("latency")]
        public float latency { get; set; }

        /// <summary>
        /// Nameservers in use on this network
        /// </summary>
        [DisplayName("Nameservers")]
        [JsonProperty("nameservers")]
        public List<string> nameservers { get; set; } = new List<string>();

        /// <summary>
        /// Number of adopted devices
        /// </summary>
        [DisplayName("# Adopted")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("num_adopted")]
        public float numAdopted { get; set; }

        /// <summary>
        /// Number of access points
        /// </summary>
        [DisplayName("# APs")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("num_ap")]
        public float numAp { get; set; }

        /// <summary>
        /// Number of disabled devices
        /// </summary>
        [DisplayName("# Disabled")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("num_disabled")]
        public float numDisabled { get; set; }

        /// <summary>
        /// Number of adopted devices which are disconnected
        /// </summary>
        [DisplayName("# Disconnected")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("num_disconnected")]
        public float numDisconnected { get; set; }

        /// <summary>
        /// Number of guests
        /// </summary>
        [DisplayName("# Guests")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("num_guest")]
        public float numGuest { get; set; }

        /// <summary>
        /// Number of gateways
        /// </summary>
        [DisplayName("# Gateways")]
        [IncludedInVisualization]
        [JsonProperty("num_gw")]
        public float numGw { get; set; }

        /// <summary>
        /// Number of pending devices
        /// </summary>
        [DisplayName("# Pending")]
        [IncludedInVisualization]
        [JsonProperty("num_pending")]
        public float numPending { get; set; }

        /// <summary>
        /// Number of clients
        /// </summary>
        [DisplayName("# Clients")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("num_sta")]
        public float numSta { get; set; }

        /// <summary>
        /// Number of switches
        /// </summary>
        [DisplayName("# Switches")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("num_sw")]
        public float numSw { get; set; }

        /// <summary>
        /// Number of users
        /// </summary>
        [DisplayName("# Users")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("num_user")]
        public float numUser { get; set; }

        // TODO: Verify this
        /// <summary>
        /// Current receive rate in bytes
        /// </summary>
        [DisplayName("RX Rate")]
        [IncludedInVisualization]
        [JsonProperty("rx_bytes-r")]
        public float rxBytesR { get; set; }

        /// <summary>
        /// Last speedtest run
        /// </summary>
        [DisplayName("Last Speed Test Run")]
        [IncludedInVisualization]
        [JsonProperty("speedtest_lastrun")]
        public float speedtestLastrun { get; set; }

        /// <summary>
        /// Latency from last speedtest run
        /// </summary>
        [DisplayName("Speed Test Ping")]
        [IncludedInVisualization]
        [JsonProperty("speedtest_ping")]
        public float speedtestPing { get; set; }

        /// <summary>
        /// Status of speed test
        /// </summary>
        [DisplayName("Speed Test Status")]
        [IncludedInVisualization]
        [JsonProperty("speedtest_status")]
        public string speedtestStatus { get; set; }

        /// <summary>
        /// System status
        /// </summary>
        [DisplayName("System Status")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("status")]
        public string status { get; set; }

        /// <summary>
        /// System status text
        /// </summary>
        [DisplayName("System Status Text")]
        [IncludedInVisualization]
        [JsonProperty("status_text")]
        public string statusText { get; set; }

        // TODO
        [JsonProperty("subsystem")]
        public string subsystem { get; set; }

        // TODO: Verify this
        /// <summary>
        /// Current transmit rate in bytes
        /// </summary>
        [DisplayName("TX Rate")]
        [IncludedInVisualization]
        [JsonProperty("tx_bytes-r")]
        public float txBytesR { get; set; }

        /// <summary>
        /// System uptime
        /// </summary>
        [DisplayName("Uptime")]
        [IncludedInVisualization]
        [JsonProperty("uptime")]
        public float uptime { get; set; }

        /// <summary>
        /// User-defined downstream throughput
        /// </summary>
        [DisplayName("Downstream Expected")]
        [IncludedInVisualization]
        [JsonProperty("xput_down")]
        public float xputDown { get; set; }

        /// <summary>
        /// User-defined upstream throughput
        /// </summary>
        [DisplayName("Upstream Expected")]
        [IncludedInVisualization]
        [JsonProperty("xput_up")]
        public float xputUp { get; set; }
    }
}
