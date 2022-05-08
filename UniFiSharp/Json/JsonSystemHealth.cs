using Newtonsoft.Json;
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
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("ip")]
        public string ip { get; set; }

        // TODO: Verify below
        /// <summary>
        /// LAN IP address of router
        /// </summary>
        [DisplayName("LAN IP")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("lan_ip")]
        public string lanIp { get; set; }

        // TODO: Verify below
        /// <summary>
        /// Current network latency
        /// </summary>
        [DisplayName("Latency")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
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
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_adopted")]
        public float numAdopted { get; set; }

        /// <summary>
        /// Number of access points
        /// </summary>
        [DisplayName("# APs")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_ap")]
        public float numAp { get; set; }

        /// <summary>
        /// Number of disabled devices
        /// </summary>
        [DisplayName("# Disabled")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_disabled")]
        public float numDisabled { get; set; }

        /// <summary>
        /// Number of adopted devices which are disconnected
        /// </summary>
        [DisplayName("# Disconnected")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_disconnected")]
        public float numDisconnected { get; set; }

        /// <summary>
        /// Number of guests
        /// </summary>
        [DisplayName("# Guests")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_guest")]
        public float numGuest { get; set; }

        /// <summary>
        /// Number of gateways
        /// </summary>
        [DisplayName("# Gateways")]
        [Complexity(Complexities.Average)]
        [JsonProperty("num_gw")]
        public float numGw { get; set; }

        /// <summary>
        /// Number of pending devices
        /// </summary>
        [DisplayName("# Pending")]
        [Complexity(Complexities.Average)]
        [JsonProperty("num_pending")]
        public float numPending { get; set; }

        /// <summary>
        /// Number of clients
        /// </summary>
        [DisplayName("# Clients")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_sta")]
        public float numSta { get; set; }

        /// <summary>
        /// Number of switches
        /// </summary>
        [DisplayName("# Switches")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_sw")]
        public float numSw { get; set; }

        /// <summary>
        /// Number of users
        /// </summary>
        [DisplayName("# Users")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_user")]
        public float numUser { get; set; }

        // TODO: Verify this
        /// <summary>
        /// Current receive rate in bytes
        /// </summary>
        [DisplayName("RX Rate")]
        [Complexity(Complexities.Average)]
        [JsonProperty("rx_bytes-r")]
        public float rxBytesR { get; set; }

        /// <summary>
        /// Last speedtest run
        /// </summary>
        [DisplayName("Last Speed Test Run")]
        [Complexity(Complexities.Average)]
        [JsonProperty("speedtest_lastrun")]
        public float speedtestLastrun { get; set; }

        /// <summary>
        /// Latency from last speedtest run
        /// </summary>
        [DisplayName("Speed Test Ping")]
        [Complexity(Complexities.Average)]
        [JsonProperty("speedtest_ping")]
        public float speedtestPing { get; set; }

        /// <summary>
        /// Status of speed test
        /// </summary>
        [DisplayName("Speed Test Status")]
        [Complexity(Complexities.Average)]
        [JsonProperty("speedtest_status")]
        public string speedtestStatus { get; set; }

        /// <summary>
        /// System status
        /// </summary>
        [DisplayName("System Status")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("status")]
        public string status { get; set; }

        /// <summary>
        /// System status text
        /// </summary>
        [DisplayName("System Status Text")]
        [Complexity(Complexities.Average)]
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
        [Complexity(Complexities.Average)]
        [JsonProperty("tx_bytes-r")]
        public float txBytesR { get; set; }

        /// <summary>
        /// System uptime
        /// </summary>
        [DisplayName("Uptime")]
        [Complexity(Complexities.Average)]
        [JsonProperty("uptime")]
        public float uptime { get; set; }

        /// <summary>
        /// User-defined downstream throughput
        /// </summary>
        [DisplayName("Downstream Expected")]
        [Complexity(Complexities.Average)]
        [JsonProperty("xput_down")]
        public float xputDown { get; set; }

        /// <summary>
        /// User-defined upstream throughput
        /// </summary>
        [DisplayName("Upstream Expected")]
        [Complexity(Complexities.Average)]
        [JsonProperty("xput_up")]
        public float xputUp { get; set; }
    }
}
