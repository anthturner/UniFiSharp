using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class SiteWlanGroupCreateSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<Name>")]
        [Description("WLAN Group Name")]
        public string Name { get; set; } = string.Empty;

        [CommandArgument(4, "<RadioType>")]
        [Description("Radio Type")]
        public string RadioType { get; set; } = string.Empty;

        [CommandArgument(5, "<ChannelNa>")]
        [Description("Channel (5Ghz)")]
        public int ChannelNa { get; set; } = 0;

        [CommandArgument(6, "<ChannelNg>")]
        [Description("Channel (2.4Ghz)")]
        public int ChannelNg { get; set; } = 0;

        [CommandOption("--pmf")]
        [Description("PMF Mode")]
        public bool PmfMode { get; set; } = false;
    }

    public class SiteWlanGroupIdSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<Id>")]
        [Description("WLAN Group ID")]
        public string WlanGroupId { get; set; } = string.Empty;
    }

    // ---

    public class SiteWlanGroupsCreateCommand : UniFiSharpCommand<SiteWlanGroupCreateSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, SiteWlanGroupCreateSettings settings)
        {
            Log($"Creating WLAN Group '{settings.Name}'");
            return await RunWithOutput(settings, async u => await u.SiteWlanGroupsCreate(
                settings.Name,
                settings.RadioType,
                settings.ChannelNa,
                settings.ChannelNg,
                settings.PmfMode));
        }
    }

    public class SiteWlanGroupsDeleteCommand : UniFiSharpCommand<SiteWlanGroupIdSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, SiteWlanGroupIdSettings settings)
        {
            Log($"Deleting WLAN Group '{settings.WlanGroupId}'");
            return await Run(settings, async u => await u.SiteWlanGroupsDelete(settings.WlanGroupId));
        }
    }

    public class SiteWlanGroupsListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log($"Listing WLAN Groups");
            return await RunWithOutputs(settings, async u => await u.SiteWlanGroupsList());
        }
    }
}
