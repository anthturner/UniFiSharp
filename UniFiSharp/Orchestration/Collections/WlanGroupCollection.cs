using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp.Orchestration.Collections
{
    /// <summary>
    /// Represents a collection of WLAN groups for this UniFi network
    /// </summary>
    public class WlanGroupCollection : RemotedDataCollection<JsonWlanGroup>, IMutableRemotedDataCollection<JsonWlanGroup>
    {
        internal WlanGroupCollection(UniFiApi api) : base(api) { }

        /// <summary>
        /// Create a new WLAN group
        /// </summary>
        /// <param name="item">New WLAN group to create on UniFi controller</param>
        /// <returns></returns>
        public async Task Add(JsonWlanGroup item)
        {
            await API.SiteWlanGroupsCreate(item.name, item.roam_radio, item.roam_channel_na.GetValueOrDefault(0), item.roam_channel_ng.GetValueOrDefault(0), item.pmf_mode != "disabled");
            await Refresh();
        }

        /// <summary>
        /// Clear all WLAN groups
        /// </summary>
        /// <returns></returns>
        public async Task Clear()
        {
            var tasks = new List<Task>();
            foreach (var item in CachedCollection)
                tasks.Add(API.SiteWlanGroupsDelete(item._id));
            await Task.WhenAll(tasks);
            await Refresh();
        }

        /// <summary>
        /// Retrieve a WLAN group by its WLAN Group ID
        /// </summary>
        /// <param name="id">WLAN Group ID</param>
        /// <returns>WLAN group or <c>NULL</c></returns>
        public JsonWlanGroup GetById(string id)
        {
            return CachedCollection.FirstOrDefault(g => g._id.Equals(id));
        }

        /// <summary>
        /// Refresh the collection of WLAN groups
        /// </summary>
        /// <returns></returns>
        public override async Task Refresh()
        {
            CachedCollection = (await API.SiteWlanGroupsList()).ToList();
        }

        /// <summary>
        /// Remove a WLAN group from the UniFi controller
        /// </summary>
        /// <param name="item">WLAN group to remove</param>
        /// <returns><c>TRUE</c> if there was an item to remove, otherwise <c>FALSE</c></returns>
        public async Task<bool> Remove(JsonWlanGroup item)
        {
            if (!CachedCollection.Contains(item))
                return false;

            await API.SiteWlanGroupsDelete(item._id);
            await Refresh();
            return true;
        }

        /// <summary>
        /// Remove a WLAN group from the UniFi controller by its index
        /// </summary>
        /// <param name="index">Index of WLAN group to remove</param>
        /// <returns></returns>
        public async Task RemoveAt(int index)
        {
            var item = CachedCollection[index];
            await Remove(item);
        }
    }
}
