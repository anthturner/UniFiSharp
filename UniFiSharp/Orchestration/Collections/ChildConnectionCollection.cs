using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Devices;
using UniFiSharp.Protocol;

namespace UniFiSharp.Orchestration.Collections
{
    public class ChildConnectionCollection : RefreshableCollection<ChildPortBinding>
    {
        public ChildConnectionCollection() : base(null)
        {
        }

        public IReadOnlyList<INetworkDevice> AttachedDevices => this.Select(d => d.Device).ToList().AsReadOnly();

        public bool HasChild(INetworkDevice device)
        {
            return this.Any(c => c.Device == device);
        }

        internal void Add(NetworkDevice.PortTable port, INetworkDevice device)
        {
            this.AddLocal(new ChildPortBinding(port, device));
        }

        public override async Task Refresh()
        {
            await Task.Yield();
        }
    }

    public class ChildPortBinding
    {
        public NetworkDevice.PortTable Port { get; private set; }
        public INetworkDevice Device { get; private set; }

        internal ChildPortBinding(NetworkDevice.PortTable port, INetworkDevice device)
        {
            Port = port;
            Device = device;
        }
    }
}