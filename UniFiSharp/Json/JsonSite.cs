using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// Managed site information
    /// </summary>
    [DisplayName("Management Site")]
    public class JsonSite
    {
        /// <summary>
        /// Site ID
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// Site Name
        /// </summary>
        [DisplayName("Site Name")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Description of the site
        /// </summary>
        [DisplayName("Description")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("desc")]
        public string desc { get; set; }

        /// <summary>
        /// Number of access points managed by the site
        /// </summary>
        [DisplayName("APs")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("num_ap")]
        public int num_ap { get; set; }

        /// <summary>
        /// Number of clients managed by the site
        /// </summary>
        [DisplayName("Clients")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("num_sta")]
        public int num_sta { get; set; }

        // TODO
        [JsonProperty("role")]
        public string role { get; set; }
    }
}
