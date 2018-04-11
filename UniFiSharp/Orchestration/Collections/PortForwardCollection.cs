using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Models;

namespace UniFiSharp.Orchestration.Collections
{
    /// <summary>
    /// Represents a collection of port forwarding rules for the UniFi Security Gateway on this network
    /// </summary>
    public class PortForwardCollection : RemotedDataCollection<PortForward>, IMutableRemotedDataCollection<PortForward>
    {
        internal PortForwardCollection(UniFiApi api) : base(api) { }

        /// <summary>
        /// Create a new port forwarding entry
        /// </summary>
        /// <param name="item">New port forwarding entry to create on UniFi controller</param>
        /// <returns></returns>
        public async Task Add(PortForward item)
        {
            await API.SitePortForwardsCreate(item.Name, item.Proto, item.Source, item.Destination, item.FromPort, item.DestinationPort);
            await Refresh();
        }

        /// <summary>
        /// Clear all port forwarding rules
        /// </summary>
        /// <returns></returns>
        public async Task Clear()
        {
            var tasks = new List<Task>();
            foreach (var item in CachedCollection)
                tasks.Add(API.SitePortForwardsDelete(item.PortForwardId));
            await Task.WhenAll(tasks);
            await Refresh();
        }

        /// <summary>
        /// Retrieve a client device by its Port Forward ID
        /// </summary>
        /// <param name="id">Port Forward ID</param>
        /// <returns>Port forwarding entry or <c>NULL</c></returns>
        public PortForward GetById(string id)
        {
            return CachedCollection.FirstOrDefault(g => g.PortForwardId.Equals(id));
        }

        /// <summary>
        /// Refresh the collection of port forwarding rules
        /// </summary>
        /// <returns></returns>
        public override async Task Refresh()
        {
            CachedCollection = (await API.SitePortForwardsList())
                .Select(p => PortForward.CreateFromJson(p)).ToList();
        }

        /// <summary>
        /// Remove a port forwarding rule from the UniFi controller
        /// </summary>
        /// <param name="item">Port forwarding rule to remove</param>
        /// <returns><c>TRUE</c> if there was an item to remove, otherwise <c>FALSE</c></returns>
        public async Task<bool> Remove(PortForward item)
        {
            if (!CachedCollection.Contains(item))
                return false;

            await API.SitePortForwardsDelete(item.PortForwardId);
            await Refresh();
            return true;
        }

        /// <summary>
        /// Remove a port forwarding rule from the UniFi controller by its index
        /// </summary>
        /// <param name="index">Index of port forwarding rule to remove</param>
        /// <returns></returns>
        public async Task RemoveAt(int index)
        {
            var item = CachedCollection[index];
            await Remove(item);
        }
    }
}
