using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// User record which represents a person who can authenticate to the network
    /// </summary>
    [DisplayName("User")]
    public class JsonUser
    {
        /// <summary>
        /// User ID
        /// </summary>
        [DisplayName("User ID")]
        [Identifier]
        [JsonProperty("_id")]
        public string _id { get; set; }

        /// <summary>
        /// Amount of time in seconds that the user has been online
        /// </summary>
        [DisplayName("Duration")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("duration")]
        public int duration { get; set; }

        /// <summary>
        /// First time the user was seen (in seconds since epoch)
        /// </summary>
        [DisplayName("Date/Time First Seen (sec)")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("first_seen")]
        public long first_seen { get; set; }

        /// <summary>
        /// Hostname the user is connecting from
        /// </summary>
        [DisplayName("Hostname")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("hostname")]
        public string hostname { get; set; }

        /// <summary>
        /// If the user is a guest
        /// </summary>
        [DisplayName("Guest?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("is_guest")]
        public bool is_guest { get; set; }

        /// <summary>
        /// If the user is on a wired device
        /// </summary>
        [DisplayName("Wired?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("is_wired")]
        public bool is_wired { get; set; }

        /// <summary>
        /// Date/time when the user was most recently seen (in seconds since epoch)
        /// </summary>
        [DisplayName("Date/Time Last Seen (sec)")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("last_seen")]
        public int last_seen { get; set; }

        /// <summary>
        /// MAC Address of the client the user is connecting from
        /// </summary>
        [DisplayName("MAC Address")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("mac")]
        public string mac { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [DisplayName("Name")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("name")]
        public string name { get; set; }

        // TODO
        [JsonProperty("noted")]
        public bool noted { get; set; }

        /// <summary>
        /// OUI (Organizationally Unique Identifier) identifying the vendor/manufacturer of the client network interface associated with this user
        /// </summary>
        [DisplayName("OUI")]
        [JsonProperty("oui")]
        public string oui { get; set; }

        /// <summary>
        /// Total number of bytes received by the user
        /// </summary>
        [DisplayName("Total RX Bytes")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("rx_bytes")]
        public long rx_bytes { get; set; }

        /// <summary>
        /// Total number of packets received by the user
        /// </summary>
        [DisplayName("Total RX Packets")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("rx_packets")]
        public long rx_packets { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the user
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        public string site_id { get; set; }

        /// <summary>
        /// Total number of bytes sent by this user
        /// </summary>
        [DisplayName("Total TX Bytes")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("tx_bytes")]
        public long tx_bytes { get; set; }

        /// <summary>
        /// Total number of packets sent by this user
        /// </summary>
        [DisplayName("Total TX Packets")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("tx_packets")]
        public long tx_packets { get; set; }

        /// <summary>
        /// User Group ID associated with user
        /// </summary>
        [DisplayName("User Group ID")]
        [JsonProperty("usergroup_id")]
        public string usergroup_id { get; set; }
    }
}
