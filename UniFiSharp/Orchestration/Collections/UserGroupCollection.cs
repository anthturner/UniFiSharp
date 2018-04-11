using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Orchestration.Models;

namespace UniFiSharp.Orchestration.Collections
{
    /// <summary>
    /// Represents a collection of user groups for this UniFi controller
    /// </summary>
    public class UserGroupCollection : RemotedDataCollection<UserGroup>, IMutableRemotedDataCollection<UserGroup>
    {
        internal UserGroupCollection(UniFiApi api) : base(api) { }

        /// <summary>
        /// Create a new user group
        /// </summary>
        /// <param name="item">New user group to create on UniFi controller</param>
        /// <returns></returns>
        public async Task Add(UserGroup item)
        {
            await API.SiteUserGroupsCreate(item.Name);
            await Refresh();
        }

        /// <summary>
        /// Clear all user groups
        /// </summary>
        /// <returns></returns>
        public async Task Clear()
        {
            // todo: don't clear default
            var tasks = new List<Task>();
            foreach (var item in CachedCollection)
                tasks.Add(API.SiteUserGroupsDelete(item.UserGroupId));
            await Task.WhenAll(tasks);
            await Refresh();
        }

        /// <summary>
        /// Retrieve a user group by its User Group ID
        /// </summary>
        /// <param name="id">User Group ID</param>
        /// <returns>User group or <c>NULL</c></returns>
        public UserGroup GetById(string id)
        {
            return CachedCollection.FirstOrDefault(g => g.UserGroupId.Equals(id));
        }

        /// <summary>
        /// Refresh the collection of user groups
        /// </summary>
        /// <returns></returns>
        public override async Task Refresh()
        {
            CachedCollection = (await API.SiteUserGroupsList())
                .Select(g => UserGroup.CreateFromJson(g)).ToList();
        }

        /// <summary>
        /// Remove a user group from the UniFi controller
        /// </summary>
        /// <param name="item">User group to remove</param>
        /// <returns><c>TRUE</c> if there was an item to remove, otherwise <c>FALSE</c></returns>
        public async Task<bool> Remove(UserGroup item)
        {
            if (!CachedCollection.Contains(item))
                return false;

            await API.SiteUserGroupsDelete(item.UserGroupId);
            await Refresh();
            return true;
        }

        /// <summary>
        /// Remove a user group from the UniFi controller by its index
        /// </summary>
        /// <param name="index">Index of user group to remove</param>
        /// <returns></returns>
        public async Task RemoveAt(int index)
        {
            var item = CachedCollection[index];
            await Remove(item);
        }
    }
}
