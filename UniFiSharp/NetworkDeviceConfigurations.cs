using System;

namespace UniFiSharp
{
    public class NetworkDeviceConfigurations<T> : NetworkDeviceConfigurations
    {
        internal override object Value { get; set; }

        internal NetworkDeviceConfigurations(object value)
        {
            Value = value;
        }
    }

    public abstract class NetworkDeviceConfigurations
    {
        internal abstract object Value { get; set; }

        public static Func<bool, NetworkDeviceConfigurations<bool>> AtfEnabled =>
            new Func<bool, NetworkDeviceConfigurations<bool>>((v) =>
                new NetworkDeviceConfigurations<bool>((object)new { atf_enabled = v }));

        public static Func<string, NetworkDeviceConfigurations<string>> BandsteeringMode =>
            new Func<string, NetworkDeviceConfigurations<string>>((v) =>
                new NetworkDeviceConfigurations<string>((object)new { bandsteering_mode = v }));

        public static Func<bool, NetworkDeviceConfigurations<bool>> Dot1xPortCtrlEnabled =>
            new Func<bool, NetworkDeviceConfigurations<bool>>((v) =>
                new NetworkDeviceConfigurations<bool>((object)new { dot1x_portctrl_enabled = v }));

        public static Func<bool, NetworkDeviceConfigurations<bool>> FlowCtrlEnabled =>
            new Func<bool, NetworkDeviceConfigurations<bool>>((v) =>
                new NetworkDeviceConfigurations<bool>((object)new { flowctrl_enabled = v }));

        public static Func<bool, NetworkDeviceConfigurations<bool>> JumboFramesEnabled =>
            new Func<bool, NetworkDeviceConfigurations<bool>>((v) =>
                new NetworkDeviceConfigurations<bool>((object)new { jumboframe_enabled = v }));

        public static Func<string, NetworkDeviceConfigurations<string>> LedOverride =>
            new Func<string, NetworkDeviceConfigurations<string>>((v) =>
                new NetworkDeviceConfigurations<string>((object)new { led_override = v }));

        public static Func<string, NetworkDeviceConfigurations<string>> ManagementNetworkId =>
            new Func<string, NetworkDeviceConfigurations<string>>((v) =>
                new NetworkDeviceConfigurations<string>((object)new { mgmt_network_id = v }));

        public static Func<string, NetworkDeviceConfigurations<string>> Name =>
            new Func<string, NetworkDeviceConfigurations<string>>((v) =>
                new NetworkDeviceConfigurations<string>((object)new { @name = v }));

        public static Func<string, NetworkDeviceConfigurations<string>> ResetButtonEnabled =>
            new Func<string, NetworkDeviceConfigurations<string>>((v) =>
                new NetworkDeviceConfigurations<string>((object)new { resetbtn_enabled = v }));

        public static Func<string, NetworkDeviceConfigurations<string>> StpPriority =>
            new Func<string, NetworkDeviceConfigurations<string>>((v) =>
                new NetworkDeviceConfigurations<string>((object)new { stp_priority = v }));

        public static Func<string, NetworkDeviceConfigurations<string>> StpVersion =>
            new Func<string, NetworkDeviceConfigurations<string>>((v) =>
                new NetworkDeviceConfigurations<string>((object)new { stp_version = v }));

        public static Func<bool, NetworkDeviceConfigurations<bool>> SwitchVlanEnabled =>
            new Func<bool, NetworkDeviceConfigurations<bool>>((v) =>
                new NetworkDeviceConfigurations<bool>((object)new { switch_vlan_enabled = v }));

        public static Func<string, NetworkDeviceConfigurations<string>> WlanGroupIdNA =>
            new Func<string, NetworkDeviceConfigurations<string>>((v) =>
                new NetworkDeviceConfigurations<string>((object)new { wlangroup_id_na = v }));

        public static Func<string, NetworkDeviceConfigurations<string>> WlanGroupIdNG =>
            new Func<string, NetworkDeviceConfigurations<string>>((v) =>
                new NetworkDeviceConfigurations<string>((object)new { wlangroup_id_ng = v }));
    }
}
