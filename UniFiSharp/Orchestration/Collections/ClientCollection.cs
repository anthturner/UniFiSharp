using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Devices;

namespace UniFiSharp.Orchestration.Collections
{
    public class ClientDeviceCollection : RefreshableCollection<ClientDevice>
    {
        public ClientDeviceCollection(UniFiApi api) : base(api)
        {
        }

        public override async Task Refresh()
        {
            var clients = await API.ListClients();
            ClearLocal();
            AddLocal(clients.Select(c => new ClientDevice(API, c)));
        }
    }
}