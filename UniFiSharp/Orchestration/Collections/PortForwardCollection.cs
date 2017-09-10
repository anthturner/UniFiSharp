using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Protocol;

namespace UniFiSharp.Orchestration.Collections
{
    public class PortForwardCollection : RefreshableCollection<PortForward>
    {
        public PortForwardCollection(UniFiApi api) : base(api)
        {
        }

        public PortForward GetByName(string name)
        {
            return this.FirstOrDefault(w => w.name == name);
        }

        public override async Task Refresh()
        {
            var portForwards = await API.ListPortForwards();
            ClearLocal();
            AddLocal(portForwards);
        }

        public async Task Add(string name, string proto, string source, string dest, int fromPort, int toPort)
        {
            await API.CreatePortForward(name, proto, source, dest, fromPort, toPort);
            await Refresh();
        }

        public async new Task Remove(PortForward forward)
        {
            try
            {
                if (!Contains(forward))
                    throw new KeyNotFoundException("User Group not tracked by this site.");

                throw new NotImplementedException("Cannot remove port forwards at this time (not yet implemented)");
                RemoveLocal(forward);
            }
            catch (Exception ex)
            {
                throw new Exception("User Group deletion failed", ex);
            }
        }
    }
}