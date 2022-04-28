using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonBroadcastGroup
    {
        /// <summary>
        /// Broadcast Group ID
        /// </summary>
        [DisplayName("ID")]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// Site ID which Broadcast Group applies to
        /// </summary>
        [DisplayName("Site ID")]
        [IncludedInVisualization]
        [JsonProperty("site_id")]
        public string site_id { get; set; }

        /// <summary>
        /// Name of the Broadcast Group
        /// </summary>
        [DisplayName("Broadcast Group Name")]
        [IncludedInVisualization(VisualizationModes.Both)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Members of the Broadcast Group
        /// </summary>
        [DisplayName("Broadcast Group Members")]
        [JsonProperty("member_table")]
        public string[] member_table { get; set; }

        // TODO
        [JsonProperty("attr_hidden_id")]
        public string attr_hidden_id { get; set; }

        // TODO
        [JsonProperty("attr_no_delete")]
        public bool attr_no_delete { get; set; }

        // TODO
        [JsonProperty("attr_no_edit")]
        public bool attr_no_edit { get; set; }
    }
}
