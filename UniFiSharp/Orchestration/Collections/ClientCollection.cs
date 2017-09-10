using System.Threading.Tasks;
using UniFiSharp.Orchestration.Devices;
using UniFiSharp.Protocol;

namespace UniFiSharp.Orchestration.Collections
{
    public class ClientCollection : RefreshableCollection<Client>
    {
        public ClientCollection(UniFiApi api) : base(api)
        {
        }

        public override async Task Refresh()
        {
            var clients = await API.ListClients();
            ClearLocal();
            AddLocal(clients);
        }

        public void ApplyToDeviceTopology(PhysicalNetworkDeviceCollection devices)
        {
            foreach (var client in this)
            {
                IUniFiNetworkDevice uplinkDevice = null;
                if (client.ap_mac != null)
                    uplinkDevice = devices.GetByMacAddress(client.ap_mac);
                else if (client.sw_mac != null)
                    uplinkDevice = devices.GetByMacAddress(client.sw_mac);

                if (uplinkDevice != null)
                    uplinkDevice.RegisterClient(client);
            }
        }
    }
}