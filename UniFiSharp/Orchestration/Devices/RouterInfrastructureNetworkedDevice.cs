using System.Collections.Generic;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Devices
{
    /// <summary>
    /// A UniFi-managed router attached to the UniFi network
    /// </summary>
    public class RouterInfrastructureNetworkedDevice : IInfrastructureNetworkedDevice
    {
        /// <summary>
        /// Networks which are managed by this router
        /// </summary>
        public List<RouterNetworkTableEntry> NetworkTable { get; }

        public RouterInfrastructureNetworkedDevice(UniFiApi api, JsonNetworkDevice json) : base(api, json) { }

        /// <summary>
        /// Description of a network managed by a UniFi router
        /// </summary>
        public class RouterNetworkTableEntry
        {
            /// <summary>
            /// Network ID
            /// </summary>
            public string NetworkId => Json._id;

            /// <summary>
            /// If <c>TRUE</c>, DHCP services are enabled
            /// </summary>
            public bool DhcpdEnabled => Json.dhcpd_enabled;

            /// <summary>
            /// Amount of time in seconds which a DHCP lease is valid for before it must be renewed
            /// </summary>
            public int DhcpdLeaseTime => Json.dhcpd_leasetime;

            /// <summary>
            /// IP address which is the start of the DHCP issued IP address range
            /// </summary>
            public string DhcpdRangeStart => Json.dhcpd_start;

            /// <summary>
            /// IP address which is the end of the DHCP issued IP address range
            /// </summary>
            public string DhcpdRangeStop => Json.dhcpd_stop;

            /// <summary>
            /// Network domain name for DNS resolution
            /// </summary>
            public string DomainName => Json.domain_name;

            /// <summary>
            /// If the network is currently enabled
            /// </summary>
            public bool IsEnabled => Json.enabled;

            /// <summary>
            /// IP address of the router controlling the network
            /// </summary>
            public string RouterIp => Json.ip;

            /// <summary>
            /// Subnet mask of the network's IP range
            /// </summary>
            public string Subnet => Json.ip_subnet;

            /// <summary>
            /// If the network is a guest network
            /// </summary>
            public bool IsGuest => Json.is_guest;

            /// <summary>
            /// If the network uses Network Address Translation (NAT)
            /// </summary>
            public bool IsNat => Json.is_nat;

            /// <summary>
            /// MAC address of the router managing the network
            /// </summary>
            public string MacAddress => Json.mac;

            /// <summary>
            /// User-defined name of the network
            /// </summary>
            public string Name => Json.name;

            /// <summary>
            /// Network group this belongs to
            /// </summary>
            public string NetworkGroup => Json.networkgroup;

            /// <summary>
            /// Number of client devices currently on the network
            /// </summary>
            public int ClientCount => Json.num_sta;

            /// <summary>
            /// If the network is up
            /// </summary>
            public bool IsUp => Json.up;

            /// <summary>
            /// VLAN ID for this network's traffic
            /// </summary>
            public int? Vlan => Json.vlan;

            /// <summary>
            /// If this network uses VLAN tagging
            /// </summary>
            public bool VlanEnabled => Json.vlan_enabled;

            private JsonNetworkDevice.JsonNetworkTable Json { get; set; }

            public RouterNetworkTableEntry(JsonNetworkDevice.JsonNetworkTable json)
            {
                Json = json;
            }
        }
    }
}
