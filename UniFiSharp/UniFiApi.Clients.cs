using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp
{
    public partial class UniFiApi
    {
        public async Task<IEnumerable<JsonClient>> ClientList()
        {
            return await RestClient.UniFiGetMany<JsonClient>($"api/s/{Site}/stat/sta");
        }

        public async Task<JsonClient> ClientGet(string macAddress)
        {
            return await RestClient.UniFiGet<JsonClient>($"api/s/{Site}/stat/sta/{macAddress}");
        }

        public async Task ClientForceReconnect(string macAddress)
        {
            await RestClient.UniFiPost($"api/s/{Site}/cmd/stamgr", new
            {
                cmd = "kick-sta",
                mac = macAddress
            });
        }

        public async Task ClientBlock(string macAddress)
        {
            await RestClient.UniFiPost($"api/s/{Site}/cmd/stamgr", new
            {
                cmd = "block-sta",
                mac = macAddress
            });
        }

        public async Task ClientUnblock(string macAddress)
        {
            await RestClient.UniFiPost($"api/s/{Site}/cmd/stamgr", new
            {
                cmd = "unblock-sta",
                mac = macAddress
            });
        }
    }
}
