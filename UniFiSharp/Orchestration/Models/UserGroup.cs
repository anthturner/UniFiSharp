using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Models
{
    public class UserGroup
    {
        /// <summary>
        /// User group ID
        /// </summary>
        public string UserGroupId => Json._id;

        /// <summary>
        /// Maximum download rate in KBps
        /// </summary>
        public int QoSRateMaxDown => Json.qos_rate_max_down;

        /// <summary>
        /// Maximum upload rate in KBps
        /// </summary>
        public int QoSRateMaxUp => Json.qos_rate_max_up;

        /// <summary>
        /// User group name
        /// </summary>
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
