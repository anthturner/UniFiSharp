using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// An infrastructure network device which is not known to the API (e.g. not a UniFi managed device)
    /// </summary>
    public class UnknownInfrastructureNetworkedDevice : IInfrastructureNetworkedDevice
    {
        public JsonNetworkDevice Details => Json;

        public UnknownInfrastructureNetworkedDevice(UniFiApi api, JsonNetworkDevice json) : base(api, json) { }
    }
}
