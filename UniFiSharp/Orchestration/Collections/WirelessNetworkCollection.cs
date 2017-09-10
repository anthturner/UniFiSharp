using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Protocol;

namespace UniFiSharp.Orchestration.Collections
{
    public class WirelessNetworkCollection : RefreshableCollection<Wlan>
    {
        public WirelessNetworkCollection(UniFiApi api) : base(api)
        {
        }

        public override async Task Refresh()
        {
            var wlans = await API.ListWlans();
            ClearLocal();
            AddLocal(wlans);
        }

        public async Task Add(string name, string key, UserGroup userGroup, WlanGroup wlanGroup)
        {
            await API.CreateWlan(name, key, userGroup._id, wlanGroup._id);
            await Refresh();
        }

        public async Task RemoveByGroup(WlanGroup group)
        {
            var tracked = new List<Wlan>(this);
            foreach (var wlan in tracked)
                if (wlan.wlangroup_id == group._id)
                    await Remove(wlan);
        }

        public async new Task Remove(Wlan network)
        {
            try
            {
                if (!Contains(network))
                    throw new KeyNotFoundException("Wireless network not tracked by this site.");

                await API.DeleteWlan(network._id);
                RemoveLocal(network);
            }
            catch (Exception ex)
            {
                throw new Exception("WLAN deletion failed", ex);
            }
        }
    }
}