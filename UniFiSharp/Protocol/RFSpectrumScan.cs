using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UniFiSharp.Protocol
{
    public class SpectrumTable
    {

        [JsonProperty("bss_histogram")]
        public IList<int> bss_histogram { get; set; }

        [JsonProperty("center_freq")]
        public int center_freq { get; set; }

        [JsonProperty("channel")]
        public int channel { get; set; }

        [JsonProperty("interference")]
        public int interference { get; set; }

        [JsonProperty("interference_type")]
        public IList<string> interference_type { get; set; }

        [JsonProperty("other_bss_count")]
        public int other_bss_count { get; set; }

        [JsonProperty("perf_index")]
        public int perf_index { get; set; }

        [JsonProperty("rssi_histogram")]
        public IList<int> rssi_histogram { get; set; }

        [JsonProperty("total_samples")]
        public int total_samples { get; set; }

        [JsonProperty("utilization")]
        public int utilization { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }

        public double Weight
        {
            get
            {
                var clamped = 1/(((interference * -1.0) - 48) / (96 - 48));
                return clamped * (utilization / 100.0);
            }
        }
    }

    public class RFSpectrumScan : IMessageBase
    {

        [JsonProperty("mac")]
        public string mac { get; set; }

        [JsonProperty("spectrum_scanning")]
        public bool spectrum_scanning { get; set; }

        [JsonProperty("spectrum_table_na")]
        public IList<SpectrumTable> spectrum_table_na { get; set; }

        [JsonProperty("spectrum_table_ng")]
        public IList<SpectrumTable> spectrum_table_ng { get; set; }

        [JsonProperty("spectrum_table_time_na")]
        public int spectrum_table_time_na { get; set; }

        [JsonProperty("spectrum_table_time_ng")]
        public int spectrum_table_time_ng { get; set; }
    }
}
