using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UniFiSharp.Json
{
    public class JsonSystemHealth
    {
        [JsonProperty("drops")]
        public float drops;

        [JsonProperty("gateways")]
        public List<String> gateways = null;

        [JsonProperty("gw_mac")]
        public String gwMac;

        [JsonProperty("ip")]
        public String ip;

        [JsonProperty("lan_ip")]
        public String lanIp;

        [JsonProperty("latency")]
        public float latency;

        [JsonProperty("nameservers")]
        public List<String> nameservers = null;

        [JsonProperty("num_adopted")]
        public float numAdopted;

        [JsonProperty("num_ap")]
        public float numAp;

        [JsonProperty("num_disabled")]
        public float numDisabled;

        [JsonProperty("num_disconnected")]
        public float numDisconnected;

        [JsonProperty("num_guest")]
        public float numGuest;

        [JsonProperty("num_gw")]
        public float numGw;

        [JsonProperty("num_pending")]
        public float numPending;

        [JsonProperty("num_sta")]
        public float numSta;

        [JsonProperty("num_sw")]
        public float numSw;

        [JsonProperty("num_user")]
        public float numUser;

        [JsonProperty("rx_bytes-r")]
        public float rxBytesR;

        [JsonProperty("speedtest_lastrun")]
        public float speedtestLastrun;

        [JsonProperty("speedtest_ping")]
        public float speedtestPing;

        [JsonProperty("speedtest_status")]
        public String speedtestStatus;

        [JsonProperty("status")]
        public String status;

        [JsonProperty("status_text")]
        public String statusText;

        [JsonProperty("subsystem")]
        public String subsystem;

        [JsonProperty("tx_bytes-r")]
        public float txBytesR;

        [JsonProperty("uptime")]
        public float uptime;

        [JsonProperty("xput_down")]
        public float xputDown;

        [JsonProperty("xput_up")]
        public float xputUp;
    }
}
