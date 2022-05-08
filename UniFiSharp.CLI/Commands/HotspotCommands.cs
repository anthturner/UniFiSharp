using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class HotspotGuestListSettings : UniFiSharpSettings
    {
        [CommandOption("--within|-w")]
        [Description("Filter within last N hours")]
        public int WithinLastNHours { get; set; } = -1;
    }

    // ---

    public class HotspotGuestListCommand : UniFiSharpCommand<HotspotGuestListSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, HotspotGuestListSettings settings)
        {
            Log("Listing Hotspot Guests");
            return await RunWithOutputs(settings, u => u.HotspotGuestList(settings.WithinLastNHours));
        }
    }

    public class HotspotPaymentListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Listing Hotspot Payments");
            return await RunWithOutputs(settings, u => u.HotspotPaymentList());
        }
    }
}