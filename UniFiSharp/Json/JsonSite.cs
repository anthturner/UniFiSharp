using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonSite
    {
        /// <summary>
        /// Site ID
        /// </summary>
        [DisplayName("Site ID")]
        [Complexity(Complexities.Average)]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// Site Name
        /// </summary>
        [DisplayName("Site Name")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Description of the site
        /// </summary>
        [DisplayName("Description")]
        [Complexity(Complexities.Average)]
        [JsonProperty("desc")]
        public string desc { get; set; }

        /// <summary>
        /// Number of access points managed by the site
        /// </summary>
        [DisplayName("APs")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_ap")]
        public int num_ap { get; set; }

        /// <summary>
        /// Number of clients managed by the site
        /// </summary>
        [DisplayName("Clients")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("num_sta")]
        public int num_sta { get; set; }

        // TODO
        [JsonProperty("role")]
        public string role { get; set; }
    }
}
