using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class HotspotOperatorSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<OperatorName>")]
        [Description("Operator Username")]
        public string OperatorName { get; set; } = string.Empty;

        [CommandArgument(4, "<OperatorPassword>")]
        [Description("Operator Password")]
        public string OperatorPassword { get; set; } = string.Empty;

        [CommandArgument(5, "[Note]")]
        [Description("Operator Note")]
        public string Note { get; set; } = string.Empty;
    }

    // ---

    public class HotspotOperatorAddCommand : UniFiSharpCommand<HotspotOperatorSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, HotspotOperatorSettings settings)
        {
            Log($"Adding Hotspot Operator '{settings.OperatorName}'");
            return await RunWithOutput(settings, u => u.HotspotOperatorAdd(settings.OperatorName, settings.OperatorPassword, settings.Note));
        }
    }

    public class HotspotOperatorListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Listing Hotspot Operators");
            return await RunWithOutput(settings, u => u.HotspotOperatorList());
        }
    }
}
