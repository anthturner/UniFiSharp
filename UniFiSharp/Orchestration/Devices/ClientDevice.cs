using UniFiSharp.Protocol;

namespace UniFiSharp.Orchestration.Devices
{
    public class ClientDevice : INetworkDevice
    {
        public Client State { get; private set; }
        
        public ClientDevice(UniFiApi api, Client clientData) : base(api)
        {
            State = clientData;
        }
    }
}
