using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{

    public class SiteUserGroupCreateSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<Name>")]
        [Description("User Group Name")]
        public string Name { get; set; } = string.Empty;

        [CommandOption("--down|-d")]
        [Description("QoS Maximum Down Speed")]
        public int QosMaxDown { get; set; } = -1;

        [CommandOption("--up|-u")]
        [Description("QoS Maximum Up Speed")]
        public int QosMaxUp { get; set; } = -1;
    }

    public class SiteUserGroupIdSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<Id>")]
        [Description("User Group Id")]
        public string UserGroupId { get; set; } = string.Empty;
    }

    // ---

    public class SiteUserGroupsCreateCommand : UniFiSharpCommand<SiteUserGroupCreateSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, SiteUserGroupCreateSettings settings)
        {
            Log($"Creating User Group '{settings.Name}'");
            return await RunWithOutput(settings, async u => await u.SiteUserGroupsCreate(
                settings.Name,
                settings.QosMaxDown,
                settings.QosMaxUp),
                OutputMaps.UserGroups);
        }
    }

    public class SiteUserGroupsDeleteCommand : UniFiSharpCommand<SiteUserGroupIdSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, SiteUserGroupIdSettings settings)
        {
            Log($"Deleting User Group '{settings.UserGroupId}'");
            return await Run(settings, async u => await u.SiteUserGroupsDelete(settings.UserGroupId));
        }
    }

    public class SiteUserGroupsListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log($"Listing User Groups");
            return await RunWithOutputs(settings, async u => await u.SiteUserGroupsList(), OutputMaps.UserGroups);
        }
    }
}
