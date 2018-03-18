using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Models
{
    public class UserGroup
    {
        public string UserGroupId => Json._id;
        public int QoSRateMaxDown => Json.qos_rate_max_down;
        public int QoSRateMaxUp => Json.qos_rate_max_up;
        public string Name => Json.name;
        
        private JsonUserGroup Json { get; set; }
        public UserGroup(JsonUserGroup json)
        {
            Json = json;
        }

        public static UserGroup CreateFromJson(JsonUserGroup json)
        {
            return new UserGroup(json);
        }
    }
}
