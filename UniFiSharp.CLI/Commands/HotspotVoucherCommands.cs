using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class HotspotVoucherIdSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<VoucherId>")]
        [Description("Voucher ID")]
        public string VoucherId { get; set; } = string.Empty;
    }

    // ---

    public class HotspotVoucherListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Listing Hotspot Vouchers");
            return await RunWithOutput(settings, u => u.HotspotVoucherList());
        }
    }

    public class HotspotVoucherDeleteCommand : UniFiSharpCommand<HotspotVoucherIdSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, HotspotVoucherIdSettings settings)
        {
            Log($"Deleting Hotspot Voucher '{settings.VoucherId}'");
            return await Run(settings, u => u.HotspotVoucherDelete(settings.VoucherId));
        }
    }

    // TODO: Voucher Add
}
