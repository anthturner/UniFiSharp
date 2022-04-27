namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// Base class for any device, client or infrastructure, which is on the network
    /// </summary>
    public abstract class INetworkedDevice
    {
        /// <summary>
        /// Network device ID
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// User-defined name of device
        /// </summary>
        public abstract string Name { get; }

        protected UniFiApi API { get; set; }

        public INetworkedDevice(UniFiApi api)
        {
            API = api;
        }
    }
}
