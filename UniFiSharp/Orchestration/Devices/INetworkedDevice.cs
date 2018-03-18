namespace UniFiSharp.Orchestration.Devices
{
    public abstract class INetworkedDevice
    {
        public abstract string Id { get; }
        public abstract string Name { get; }

        protected UniFiApi API { get; set; }

        public INetworkedDevice(UniFiApi api)
        {
            API = api;
        }
    }
}
