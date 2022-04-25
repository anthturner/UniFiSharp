using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class BroadcastGroupSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<BroadcastGroupId>")]
        [Description("Broadcast Group ID")]
        public string BroadcastGroupId { get; set; } = string.Empty;
    }

    public class BroadcastGroupCreateSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<BroadcastGroupName>")]
        [Description("Broadcast Group Name")]
        public string BroadcastGroupName { get; set; } = string.Empty;

        [CommandOption("--mac|-m")]
        [Description("MAC Address of Members (Multiple)")]
        public string[] MacAddresses { get; set; } = new string[0];
    }

    // ---

    public class BroadcastGroupListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Listing Broadcast Groups");
            return await RunWithOutputs(settings, u => u.BroadcastGroupList(), OutputMaps.BroadcastGroup);
        }
    }

    public class BroadcastGroupCreateCommand : UniFiSharpCommand<BroadcastGroupCreateSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, BroadcastGroupCreateSettings settings)
        {
            Log($"Creating Broadcast Group '{settings.BroadcastGroupName}'");
            foreach (var m in settings.MacAddresses)
                Log($"Adding Member '{m}'");
            return await RunWithOutput(settings, u => u.BroadcastGroupCreate(settings.BroadcastGroupName, settings.MacAddresses), OutputMaps.BroadcastGroup);
        }
    }

    public class BroadcastGroupDeleteCommand : UniFiSharpCommand<BroadcastGroupSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, BroadcastGroupSettings settings)
        {
            Log($"Deleting Broadcast Group '{settings.BroadcastGroupId}'");
            return await Run(settings, u => u.BroadcastGroupDelete(settings.BroadcastGroupId));
        }
    }

    public class BroadcastGroupGetCommand : UniFiSharpCommand<BroadcastGroupSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, BroadcastGroupSettings settings)
        {
            Log($"Retrieving Broadcast Group '{settings.BroadcastGroupId}'");
            return await RunWithOutput(settings, u => u.BroadcastGroupGet(settings.BroadcastGroupId), OutputMaps.BroadcastGroup);
        }
    }
}