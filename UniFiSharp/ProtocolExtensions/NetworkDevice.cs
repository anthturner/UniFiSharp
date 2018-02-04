namespace UniFiSharp.Protocol
{
    public partial class NetworkDevice
    {
        public enum NetworkDeviceState
        {
            AdoptionFailed,
            Disconnected,
            Connected,
            Unadopted,
            Inaccessible,
            Provisioning,
            Unknown
        };

        public NetworkDeviceState StateEnum
        {
            get
            {
                switch (this.state)
                {
                    case 0:
                        return NetworkDeviceState.Disconnected;

                    case 1:
                        return NetworkDeviceState.Connected;

                    case 2:
                        if (this.defaultSettings) // if we're not on default settings, the controller can't adopt
                            return NetworkDeviceState.Unadopted;
                        else
                            return NetworkDeviceState.Inaccessible;

                    case 5:
                        return NetworkDeviceState.Provisioning;

                    case 10:
                        return NetworkDeviceState.AdoptionFailed;
                }

                return NetworkDeviceState.Unknown;
            }
        }
    }
}