using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Models
{
    public class WlanGroup
    {
        public string WlanGroupId => Json._id;
        public string RoamRadio => Json.roam_radio;
        public string Name => Json.name;
        public string PmfMode => Json.pmf_mode;
        public int RoamChannelNA => Json.roam_channel_na.GetValueOrDefault(0);
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
