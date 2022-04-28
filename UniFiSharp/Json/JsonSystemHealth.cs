using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UniFiSharp.Json
{
    public class JsonSystemHealth
    {
        [JsonProperty("drops")]
        public float drops { get; set; }

        [JsonProperty("gateways")]
        public List<string> gateways { get; set; } = new List<string>();

        [JsonProperty("gw_mac")]
        public string gwMac { get; set; }

        [JsonProperty("ip")]
        public string ip { get; set; }

        [JsonProperty("lan_ip")]
        public string lanIp { get; set; }
        
        [JsonProperty("latency")]
        public float latency { get; set; }

        [JsonProperty("nameservers")]
        public List<string> nameservers { get; set; } = new List<string>();

        [JsonProperty("num_adopted")]
        public float numAdopted { get; set; }

        [JsonProperty("num_ap")]
        public float numAp { get; set; }

        [JsonProperty("num_disabled")]
        public float numDisabled { get; set; }

        [JsonProperty("num_disconnected")]
        public float numDisconnected { get; set; }

        [JsonProperty("num_guest")]
        public float numGuest { get; set; }

        [JsonProperty("num_gw")]
        public float numGw { get; set; }

        [JsonProperty("num_pending")]
        public float numPending { get; set; }

        [JsonProperty("num_sta")]
        public float numSta { get; set; }

        [JsonProperty("num_sw")]
        public float numSw { get; set; }

        [JsonProperty("num_user")]
        public float numUser { get; set; }

        [JsonProperty("rx_bytes-r")]
        public float rxBytesR { get; set; }

        [JsonProperty("speedtest_lastrun")]
        public float speedtestLastrun { get; set; }

        [JsonProperty("speedtest_ping")]
        public float speedtestPing { get; set; }

        [JsonProperty("speedtest_status")]
        public String speedtestStatus { get; set; }

        [JsonProperty("status")]
        public String status { get; set; }

        [JsonProperty("status_text")]
        public String statusText { get; set; }

        [JsonProperty("subsystem")]
        public String subsystem { get; set; }

        [JsonProperty("tx_bytes-r")]
        public float txBytesR { get; set; }

        [JsonProperty("uptime")]
        public float uptime { get; set; }

        [JsonProperty("xput_down")]
        public float xputDown { get; set; }

        [JsonProperty("xput_up")]
        public float xputUp { get; set; }
    }
}
