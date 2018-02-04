using System.Linq;
using System.Net;
using UniFiSharp.Orchestration.Collections;

namespace UniFiSharp.Orchestration.Devices
{
    public abstract class INetworkDevice
    {
        /// <summary>
        /// Network devices attached to this device
        /// </summary>
        public ChildConnectionCollection Children { get; private set; }

        protected UniFiApi _api;

        public INetworkDevice()
        {
            Children = new ChildConnectionCollection();
        }

        public INetworkDevice(UniFiApi api) : this()
        {
            _api = api;
        }

        public virtual string Identifier => "UNKNOWN_" + GetHashCode();
    }
}