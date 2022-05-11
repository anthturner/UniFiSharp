using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// One set of RF spectrum scanning results, given a specific radio frequency
    /// </summary>
    [DisplayName("Spectrum Table")]
    public class JsonSpectrumTable
    {
        /// <summary>
        /// Basic Service Set Histogram
        /// </summary>
        [DisplayName("BSS Histogram")]
        [JsonProperty("bss_histogram")]
        public IList<int> bss_histogram { get; set; }

        /// <summary>
        /// Center frequency for this slice of the scan
        /// </summary>
        [DisplayName("Center Frequency")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("center_freq")]
        public int center_freq { get; set; }

        /// <summary>
        /// Channel for this slice of the scan
        /// </summary>
        [DisplayName("Channel")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("channel")]
        public int channel { get; set; }

        /// <summary>
        /// Amount of interference on this frequency/channel
        /// </summary>
        [DisplayName("Interference")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("interference")]
        public int interference { get; set; }

        /// <summary>
        /// Type of interference detected
        /// </summary>
        [DisplayName("Interference Type")]
        [JsonProperty("interference_type")]
        public IList<string> interference_type { get; set; }

        /// <summary>
        /// Number of other BSSes found in this channel
        /// </summary>
        [DisplayName("# Other BSS")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("other_bss_count")]
        public int other_bss_count { get; set; }

        /// <summary>
        /// Performance index for this channel
        /// </summary>
        [DisplayName("Performance Index")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("perf_index")]
        public int perf_index { get; set; }

        /// <summary>
        /// Histogram of RSSI values
        /// </summary>
        [DisplayName("RSSI Histogram")]
        [JsonProperty("rssi_histogram")]
        public IList<int> rssi_histogram { get; set; }

        /// <summary>
        /// Number of samples collected
        /// </summary>
        [DisplayName("Total Samples")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("total_samples")]
        public int total_samples { get; set; }

        /// <summary>
        /// Utilization of the channel
        /// </summary>
        [DisplayName("Utilization")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("utilization")]
        public int utilization { get; set; }

        /// <summary>
        /// Width of the channel in MHz
        /// </summary>
        [DisplayName("Channel Width")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("width")]
        public int width { get; set; }

        /// <summary>
        /// Inferred weight to cheaply determine best channel
        /// </summary>
        [DisplayName("Weight")]
        [ShowWith(Levels.Minimal)]
        public double Weight
        {
            get
            {
                var clamped = 1 / (((interference * -1.0) - 48) / (96 - 48));
                return clamped * (utilization / 100.0);
            }
        }
    }

    /// <summary>
    /// Output of an RF spectrum scan
    /// </summary>
    [DisplayName("Spectrum Scan Result")]
    public class JsonSpectrumScan
    {
        /// <summary>
        /// MAC Address of access point performing scan
        /// </summary>
        [DisplayName("Scanning AP MAC")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        /// <summary>
        /// If the scan is in progress
        /// </summary>
        [DisplayName("Scan Running?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("spectrum_scanning")]
        public bool spectrum_scanning { get; set; }

        /// <summary>
        /// Scan records for the spectrum table based on the 5G radio
        /// </summary>
        [DisplayName("5GHz Spectrum Table")]
        [JsonProperty("spectrum_table_na")]
        public IList<JsonSpectrumTable> spectrum_table_na { get; set; }

        /// <summary>
        /// Scan records for the spectrum table based on the 2.4G radio
        /// </summary>
        [DisplayName("2.4GHz Spectrum Table")]
        [JsonProperty("spectrum_table_ng")]
        public IList<JsonSpectrumTable> spectrum_table_ng { get; set; }

        /// <summary>
        /// Amount of time in seconds spent scanning on the 5G radio
        /// </summary>
        [DisplayName("5GHz Scan Time")]
        [JsonProperty("spectrum_table_time_na")]
        public int spectrum_table_time_na { get; set; }

        /// <summary>
        /// Amount of time in seconds spent scanning on the 2.4G radio
        /// </summary>
        [DisplayName("2.4GHz Scan Time")]
        [JsonProperty("spectrum_table_time_ng")]
        public int spectrum_table_time_ng { get; set; }
    }
}
