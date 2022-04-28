namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// An infrastructure network device which is not known to the API (e.g. not a UniFi managed device)
    /// </summary>
    public class UnknownInfrastructureNetworkedDevice : IInfrastructureNetworkedDevice
    {
        internal UnknownInfrastructureNetworkedDevice() { }
    }
}
