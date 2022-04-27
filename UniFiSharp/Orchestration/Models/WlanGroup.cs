using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Models
{
    public class WlanGroup
    {
        /// <summary>
        /// WLAN group ID
        /// </summary>
        public string WlanGroupId => Json._id;

        /// <summary>
        /// Radio used with this WLAN group
        /// </summary>
        public string RoamRadio => Json.roam_radio;

        /// <summary>
        /// WLAN group name
        /// </summary>
        public string Name => Json.name;

        /// <summary>
        /// If the WLAN group uses Protected Management Frames (PMF)
        /// </summary>
        public string PmfMode => Json.pmf_mode;

        /// <summary>
        /// 5GHz Radio channel for this group
        /// </summary>
        public int RoamChannelNA => Json.roam_channel_na.GetValueOrDefault(0);

        /// <summary>
        /// 2.4GHz Radio channel for this group
        /// </summary>
        public int RoamChannelNG => Json.roam_channel_ng.GetValueOrDefault(0);
        
        private JsonWlanGroup Json { get; set; }
        public WlanGroup(JsonWlanGroup json)
        {
            Json = json;
        }

        public static WlanGroup CreateFromJson(JsonWlanGroup json)
        {
            return new WlanGroup(json);
        }
    }
}
