using System.Collections.Generic;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    public class RouterInfrastructureNetworkedDevice : IInfrastructureNetworkedDevice
    {
        public List<RouterNetworkTableEntry> NetworkTable { get; }

        public RouterInfrastructureNetworkedDevice(UniFiApi api, JsonNetworkDevice json) : base(api, json) { }

        public class RouterNetworkTableEntry
        {
            public string NetworkId => Json._id;
            public bool DhcpdEnabled => Json.dhcpd_enabled;
            public int DhcpdLeaseTime => Json.dhcpd_leasetime;
            public string DhcpdRangeStart => Json.dhcpd_start;
            public string DhcpdRangeStop => Json.dhcpd_stop;
            public string DomainName => Json.domain_name;
            public bool IsEnabled => Json.enabled;
            public string RouterIp => Json.ip;
            public string Subnet => Json.ip_subnet;
            public bool IsGuest => Json.is_guest;
            public bool IsNat => Json.is_nat;
            public string MacAddress => Json.mac;
            public string Name => Json.name;
            public string NetworkGroup => Json.networkgroup;
            public int ClientCount => Json.num_sta;
            public bool IsUp => Json.up;
            public int? Vlan => Json.vlan;
            public bool VlanEnabled => Json.vlan_enabled;

            private JsonNetworkDevice.JsonNetworkTable Json { get; set; }

            public RouterNetworkTableEntry(JsonNetworkDevice.JsonNetworkTable json)
            {
                Json = json;
            }
        }
    }
}
