using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp
{
    public partial class UniFiApi
    {
        /// <summary>
        /// Toggle the device LEDs for all devices in the site (who do not override the site settings)
        /// </summary>
        /// <param name="isOn"><c>TRUE</c> if the LED is lit during normal operation, otherwise <c>FALSE</c></param>
        /// <returns></returns>
        public async Task SiteLedToggle(bool isOn)
        {
            await RestClient.UniFiPost($"api/s/{Site}/set/setting/mgmt", new
            {
                led_enabled = isOn
            });
        }

        /// <summary>
        /// Add a new port to be forwarded by a UniFi Security Gateway (router)
        /// </summary>
        /// <param name="name">Rule name</param>
        /// <param name="proto">Protocol</param>
        /// <param name="source">Source IP</param>
        /// <param name="dest">Destination IP</param>
        /// <param name="fromPort">Source Port</param>
        /// <param name="toPort">Destination Port</param>
        /// <returns>JSON object describing the new port forwarding entry</returns>
        public async Task<JsonPortForward> SitePortForwardsCreate(string name, string proto, string source, string dest, int fromPort, int toPort)
        {
            return await RestClient.UniFiPost<JsonPortForward>($"api/s/{Site}/rest/portforward", new {
                name = name,
                proto = proto,
                dst_port = toPort,
                fwd_port = fromPort,
                fwd = dest,
                src = source
            });
        }

        /// <summary>
        /// Delete a port forwarding entry from a UniFi Security Gateway (router)
        /// </summary>
        /// <param name="id">Rule ID</param>
        /// <returns></returns>
        public async Task SitePortForwardsDelete(string id)
        {
            await RestClient.UniFiDelete($"api/s/{Site}/rest/portforward/{id}");
        }

        /// <summary>
        /// Retrieve a list of ports that have been forwarded on a UniFi Security Gateway (router)
        /// </summary>
        /// <returns>List of JSON objects describing configured port forwarding entries</returns>
        public async Task<IList<JsonPortForward>> SitePortForwardsList()
        {
            return await RestClient.UniFiGetMany<JsonPortForward>($"api/s/{Site}/list/portforward");
        }

        /// <summary>
        /// Retrieve a list of rogue access points that have been detected by this site's UniFi controller
        /// </summary>
        /// <returns>List of JSON objects describing rogue access points</returns>
        public async Task<IList<JsonRogueAp>> SiteRogueApList()
        {
            return await RestClient.UniFiGetMany<JsonRogueAp>($"api/s/{Site}/stat/rogueap");
        }

        /// <summary>
        /// Create a new user group on the UniFi controller
        /// </summary>
        /// <param name="name">Name of new user group</param>
        /// <param name="qosRateMaxDown">QoS downstream maximum rate</param>
        /// <param name="qosRateMaxUp">QoS upstream maximum rate</param>
        /// <returns>JSON object describing the new user group</returns>
        public async Task<JsonUserGroup> SiteUserGroupsCreate(string name, int qosRateMaxDown = -1, int qosRateMaxUp = -1)
        {
            return await RestClient.UniFiPost<JsonUserGroup>($"api/s/{Site}/rest/usergroup", new
            {
                qos_rate_max_down = qosRateMaxDown,
                qos_rate_max_up = qosRateMaxUp,
                name = name
            });
        }

        /// <summary>
        /// Delete a user group from the UniFi controller
        /// </summary>
        /// <param name="id">User group ID</param>
        /// <returns></returns>
        public async Task SiteUserGroupsDelete(string id)
        {
            await RestClient.UniFiDelete($"api/s/{Site}/rest/usergroup/{id}");
        }

        /// <summary>
        /// Retrieve a list of user groups configured on the UniFi controller
        /// </summary>
        /// <returns>A list of JSON objects describing configured user groups</returns>
        public async Task<IEnumerable<JsonUserGroup>> SiteUserGroupsList()
        {
            return await RestClient.UniFiGetMany<JsonUserGroup>($"api/s/{Site}/list/usergroup");
        }

        /// <summary>
        /// Create a new WLAN group on the UniFi controller
        /// </summary>
        /// <param name="name">Name of new WLAN group</param>
        /// <param name="radioType">Radio type (na or ng)</param>
        /// <param name="channelNa">Default channel for NA radio</param>
        /// <param name="channelNg">Default channel for NG radio</param>
        /// <param name="pmfMode">Whether or not to use WPA2 protected management frames</param>
        /// <returns>JSON object describing the new WLAN group</returns>
        public async Task<JsonWlanGroup> SiteWlanGroupsCreate(string name, string radioType, int channelNa, int channelNg, bool pmfMode)
        {
            return await RestClient.UniFiPost<JsonWlanGroup>($"api/s/{Site}/rest/wlangroup", new
            {
                roam_radio = radioType,
                roam_channel_na = channelNa,
                roam_channel_ng = channelNg,
                pmf_mode = pmfMode ? "enabled" : "disabled",
                name = name
            });
        }

        /// <summary>
        /// Delete a WLAN group from the UniFi controller
        /// </summary>
        /// <param name="id">WLAN group ID</param>
        /// <returns></returns>
        public async Task SiteWlanGroupsDelete(string id)
        {
            await RestClient.UniFiDelete($"api/s/{Site}/rest/wlangroup/{id}");
        }

        /// <summary>
        /// Retrieve a list of WLAN groups configured on the UniFi controller
        /// </summary>
        /// <returns>A list of JSON objects describing configured WLAN groups</returns>
        public async Task<IEnumerable<JsonWlanGroup>> SiteWlanGroupsList()
        {
            return await RestClient.UniFiGetMany<JsonWlanGroup>($"api/s/{Site}/list/wlangroup");
        }
    }
}
