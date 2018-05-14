using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp
{
    public partial class UniFiApi
    {
        public async Task<IEnumerable<JsonUser>> UserList()
        {
            return await RestClient.UniFiGetMany<JsonUser>($"api/s/{Site}/stat/alluser");
        }

        public async Task<JsonUser> UserGet(string macAddress)
        {
            return await RestClient.UniFiGet<JsonUser>($"api/s/{Site}/stat/user/{macAddress}");
        }


        public async Task UserSetUsergroup(JsonUser client, JsonUserGroup userGroup)
        {
            await RestClient.UniFiPut($"api/s/{Site}/rest/user/{client._id}", new
            {
                usergroup_id = userGroup?._id ?? string.Empty
            });
        }

        public async Task UserUnsetUsergroup(JsonUser client)
        {
            await RestClient.UniFiPut($"api/s/{Site}/rest/user/{client._id}", new
            {
                usergroup_id = string.Empty
            });
        }
    }
}
