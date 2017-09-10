using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFiSharp.Protocol;

namespace UniFiSharp.Orchestration.Collections
{
    public class UserGroupCollection : RefreshableCollection<UserGroup>
    {
        public UserGroupCollection(UniFiApi api) : base(api)
        {
        }

        public UserGroup GetByName(string name)
        {
            return this.FirstOrDefault(w => w.name == name);
        }

        public override async Task Refresh()
        {
            var userGroups = await API.ListUserGroups();
            ClearLocal();
            AddLocal(userGroups);
        }

        public async Task Add(string name)
        {
            await API.CreateUserGroup(name);
            await Refresh();
        }

        public async new Task Remove(UserGroup group)
        {
            try
            {
                if (!Contains(group))
                    throw new KeyNotFoundException("User Group not tracked by this site.");

                await API.DeleteUserGroup(group._id);
                RemoveLocal(group);
            }
            catch (Exception ex)
            {
                throw new Exception("User Group deletion failed", ex);
            }
        }
    }
}