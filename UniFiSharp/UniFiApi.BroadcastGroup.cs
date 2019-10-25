using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp
{
    public partial class UniFiApi
    {
		// This partial class is for management of Broadcast Groups. These are used for simultaneously broadcasting streams to groups of UniFI EDU APs

		/// <summary>
        /// Get all broadcast groups on the controller
        /// </summary>
        /// <returns>Collection of JSON objects containing the broadcast groups and devices in each group</returns>
        public async Task<IEnumerable<JsonBroadcastGroup>> BroadcastGroupList()
        {
            return await RestClient.UniFiGetMany<JsonBroadcastGroup>($"api/s/{Site}/rest/broadcastgroup");
        }

		/// <summary>
        /// Retrieve info about a single broadcast group
        /// </summary>
        /// <param name="groupId">ID of the group to query</param>
        /// <returns>JSON object describing the group and listing the devices in the group</returns>
        public async Task<JsonBroadcastGroup> BroadcastGroupGet(string groupId)
        {
            return await RestClient.UniFiGet<JsonBroadcastGroup>($"api/s/{Site}/rest/broadcastgroup/{groupId}");
        }

		/// <summary>
        /// Delete a broadcast group
        /// </summary>
        /// <param name="groupId">ID of the broadcast group</param>
        /// <returns></returns>
        public async Task BroadcastGroupDelete(string groupId)
        {
            await RestClient.UniFiDelete($"api/s/{Site}/rest/broadcastgroup/{groupId}");
        }

		/// <summary>
        /// Create a new broadcast group
        /// </summary>
        /// <param name="groupName">Name of the broadcast group</param>
        /// <param name="memberTable">MAC addresses of the devices to include in the group</param>
        /// <returns>JSON object containing details of the created group</returns>
        public async Task<JsonBroadcastGroup> BroadcastGroupCreate(string groupName, string[] memberTable)
        {
            return await RestClient.UniFiPost<JsonBroadcastGroup>($"api/s/{Site}/rest/broadcastgroup", new
            {
				name = groupName,
				member_table = memberTable
            });
        }

        /// <summary>
        /// Update an existing broadcast group
        /// </summary>
        /// <param name="groupId">ID of the group to update</param>
        /// <param name="groupName">Name of the broadcast group</param>
        /// <param name="memberTable">MAC addresses of the devices to include in the group</param>
        /// <returns></returns>
        public async Task<JsonBroadcastGroup> BroadcastGroupUpdate(string groupId, string groupName, string[] memberTable)
        {
            return await RestClient.UniFiPut<JsonBroadcastGroup>($"api/s/{Site}/rest/broadcastgroup/{groupId}", new
            {
                name = groupName,
                member_table = memberTable
            });
        }
    }
}
