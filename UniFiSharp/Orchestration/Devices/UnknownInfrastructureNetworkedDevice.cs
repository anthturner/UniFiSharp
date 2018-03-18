using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    public class UnknownInfrastructureNetworkedDevice : IInfrastructureNetworkedDevice
    {
        public JsonNetworkDevice Details => Json;

        public UnknownInfrastructureNetworkedDevice(UniFiApi api, JsonNetworkDevice json) : base(api, json) { }
    }
}
