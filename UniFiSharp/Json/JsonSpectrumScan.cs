using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace UniFiSharp.Json
{
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
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("center_freq")]
        public int center_freq { get; set; }

        /// <summary>
        /// Channel for this slice of the scan
        /// </summary>
        [DisplayName("Channel")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("channel")]
        public int channel { get; set; }

        /// <summary>
        /// Amount of interference on this frequency/channel
        /// </summary>
        [DisplayName("Interference")]
        [IncludedInVisualization(VisualizationModes.Both)]
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
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("other_bss_count")]
        public int other_bss_count { get; set; }

        /// <summary>
        /// Performance index for this channel
        /// </summary>
        [DisplayName("Performance Index")]
        [IncludedInVisualization(VisualizationModes.Both)]
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
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("total_samples")]
        public int total_samples { get; set; }

        /// <summary>
        /// Utilization of the channel
        /// </summary>
        [DisplayName("Utilization")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("utilization")]
        public int utilization { get; set; }

        /// <summary>
        /// Width of the channel in MHz
        /// </summary>
        [DisplayName("Channel Width")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("width")]
        public int width { get; set; }

        /// <summary>
        /// Inferred weight to cheaply determine best channel
        /// </summary>
        [DisplayName("Weight")]
        [IncludedInVisualization(VisualizationModes.Both)]
        public double Weight
        {
            get
            {
                var clamped = 1 / (((interference * -1.0) - 48) / (96 - 48));
                return clamped * (utilization / 100.0);
            }
        }
    }

    public class JsonSpectrumScan
    {
        /// <summary>
        /// MAC Address of access point performing scan
        /// </summary>
        [DisplayName("Scanning AP MAC")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        /// <summary>
        /// If the scan is in progress
        /// </summary>
        [DisplayName("Scan Running?")]
        [IncludedInVisualization(VisualizationModes.Both)]
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
