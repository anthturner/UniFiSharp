using Newtonsoft.Json;

namespace UniFiSharp.Protocol
{
    public class Dashboard : IMessageBase
    {
        [JsonProperty("latency_avg")]
        public double latency_avg { get; set; }

        [JsonProperty("latency_max")]
        public double latency_max { get; set; }

        [JsonProperty("latency_min")]
        public double latency_min { get; set; }

        [JsonProperty("max_rx_bytes-r")]
        public double max_rx_bytes_r { get; set; }

        [JsonProperty("max_tx_bytes-r")]
        public double max_tx_bytes_r { get; set; }

        [JsonProperty("rx_bytes-r")]
        public long rx_bytes_r { get; set; }

        [JsonProperty("time")]
        public object time { get; set; }

        [JsonProperty("tx_bytes-r")]
        public long tx_bytes_r { get; set; }

        [JsonProperty("wan-rx_bytes")]
        public double wan_rx_bytes { get; set; }

        [JsonProperty("wan-tx_bytes")]
        public double wan_tx_bytes { get; set; }
    }
}