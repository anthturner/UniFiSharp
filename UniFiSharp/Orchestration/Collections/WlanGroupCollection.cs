using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Protocol;

namespace UniFiSharp.Orchestration.Collections
{
    public class WlanGroupCollection : RefreshableCollection<WlanGroup>
    {
        public WlanGroupCollection(UniFiApi api) : base(api)
        {
        }

        public WlanGroup GetByName(string name)
        {
            return this.FirstOrDefault(w => w.name == name);
        }

        public override async Task Refresh()
        {
            var wlanGroups = await API.ListWlanGroups();
            ClearLocal();
            AddLocal(wlanGroups);
        }

        public async Task Add(string name)
        {
            await API.CreateWlanGroup(name);
            await Refresh();
        }

        public async new Task Remove(WlanGroup group)
        {
            try
            {
                if (!Contains(group))
                    throw new KeyNotFoundException("WLAN Group not tracked by this site.");

                await API.DeleteWlanGroup(group._id);
                RemoveLocal(group);
            }
            catch (Exception ex)
            {
                throw new Exception("WLAN Group deletion failed", ex);
            }
        }
    }
}