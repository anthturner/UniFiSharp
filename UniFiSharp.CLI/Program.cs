using Spectre.Console;
using Spectre.Console.Cli;
using UniFiSharp.CLI.Commands;

namespace UniFiSharp.CLI
{
    internal class Program
    {
        internal static bool Quiet { get; private set; } = false;
        internal static CommandApp App { get; private set; }
        static void Main(string[] args)
        {
            Console.WriteLine();

            if (!args.Any(a => a == "-q" || a == "--quiet"))
                DrawUniFiSharpLogo();
            else Quiet = true;

            App = new CommandApp();
            App.Configure(config =>
            {
#if DEBUG
                config.ValidateExamples();
                config.PropagateExceptions();
#endif
                config.SetApplicationName("unifi-cli");

                config.AddCommand<TopologyCommand>("topology");
                config.AddCommand<InteractiveModeCommand>("interactive");

                config.AddBranch<UniFiSharpSettings>("broadcast-group", bg =>
                {
                    bg.AddCommand<BroadcastGroupCreateCommand>("create");
                    bg.AddCommand<BroadcastGroupDeleteCommand>("delete");
                    bg.AddCommand<BroadcastGroupGetCommand>("get");
                    bg.AddCommand<BroadcastGroupListCommand>("list");
                });

                config.AddBranch<UniFiSharpSettings>("client", client =>
                {
                    client.AddCommand<ClientBlockCommand>("block");
                    client.AddCommand<ClientUnblockCommand>("unblock");
                    client.AddCommand<ClientForceReconnectCommand>("force-reconnect");
                    client.AddCommand<ClientListCommand>("list");
                    client.AddCommand<ClientGetCommand>("get");
                });

                config.AddBranch<UniFiSharpSettings>("hotspot", hotspot =>
                {
                    hotspot.AddBranch("operator", op =>
                    {
                        op.AddCommand<HotspotOperatorAddCommand>("add");
                        op.AddCommand<HotspotOperatorListCommand>("list");
                    });
                    hotspot.AddBranch("voucher", voucher =>
                    {
                        voucher.AddCommand<HotspotVoucherListCommand>("list");
                        voucher.AddCommand<HotspotVoucherDeleteCommand>("delete");
                    });
                    hotspot.AddBranch("payment", payment =>
                    {
                        payment.AddCommand<HotspotPaymentListCommand>("list");
                    });
                    hotspot.AddBranch("guest", guest =>
                    {
                        guest.AddCommand<HotspotGuestListCommand>("list");
                    });
                });

                config.AddBranch<UniFiSharpSettings>("media", media =>
                {
                    media.AddCommand<MediaFileCreateCommand>("create");
                    media.AddCommand<MediaFileDeleteCommand>("delete");
                    media.AddCommand<MediaFileListCommand>("list");
                    media.AddCommand<MediaFileGetCommand>("get");
                });

                config.AddBranch<UniFiSharpSettings>("device", device =>
                {
                    device.AddCommand<NetworkDeviceAdoptCommand>("adopt");
                    device.AddCommand<NetworkDeviceForgetCommand>("forget");
                    device.AddCommand<NetworkDeviceListCommand>("list");
                    device.AddCommand<NetworkDeviceGetCommand>("get");
                    device.AddCommand<NetworkDeviceLocateCommand>("locate");
                    device.AddCommand<NetworkDevicePowerCycleCommand>("power-cycle");
                    device.AddCommand<NetworkDeviceRestartCommand>("restart");
                    device.AddCommand<NetworkDeviceRfScanCommand>("rf-scan");
                    device.AddCommand<NetworkDeviceUpgradeCommand>("upgrade");
                    device.AddCommand<NetworkDeviceVolumeCommand>("volume");
                });

                config.AddBranch<UniFiSharpSettings>("site", site =>
                {
                    site.AddCommand<SiteHealthGetCommand>("health");
                    site.AddCommand<SiteLedCommand>("led");
                    site.AddCommand<SiteListCommand>("list");
                    site.AddCommand<SiteRogueApListCommand>("rogue-aps");

                    site.AddBranch("port-forward", pf =>
                    {
                        pf.AddCommand<SitePortForwardsCreateCommand>("create");
                        pf.AddCommand<SitePortForwardsDeleteCommand>("delete");
                        pf.AddCommand<SitePortForwardsListCommand>("list");
                    });

                    site.AddBranch("user-group", ug =>
                    {
                        ug.AddCommand<SiteUserGroupsCreateCommand>("create");
                        ug.AddCommand<SiteUserGroupsDeleteCommand>("delete");
                        ug.AddCommand<SiteUserGroupsListCommand>("list");
                    });

                    site.AddBranch("wlan-group", wg =>
                    {
                        wg.AddCommand<SiteWlanGroupsCreateCommand>("create");
                        wg.AddCommand<SiteWlanGroupsDeleteCommand>("delete");
                        wg.AddCommand<SiteWlanGroupsListCommand>("list");
                    });
                });

                config.AddBranch<UniFiSharpSettings>("user", user =>
                {
                    user.AddCommand<UserGetCommand>("get");
                    user.AddCommand<UserListCommand>("list");
                });
            });

            App.Run(args);
            Console.WriteLine();
        }

        private static void DrawUniFiSharpLogo()
        {
            var c1 = "[blue]";
            var c2 = "[#666666]";
            var c3 = "[#333333]";
            var e = "[/]";
            var l = "[underline cyan]";

            AnsiConsole.Write(new Rule().RuleStyle("blue dim"));
            AnsiConsole.MarkupLine($"{c1} __ {e}{c3}   __ {e}{c1}  __ __{e}");
            AnsiConsole.MarkupLine($"{c1}|  |{e}{c3}  |  |{e}{c1}_/ // /_{e}");
            AnsiConsole.MarkupLine($"{c1}|  |{e}{c3}  |  {e}{c1}/_  _  __/{e}\t{c1}UniFi Command Line Tool{e} {c2}v1.0.0{e}");
            AnsiConsole.MarkupLine($"{c1}|  |{e}{c3}  | {e}{c1}/_  _  __/{e}\t{l}https://github.com/anthturner/UniFiSharp{e}");
            AnsiConsole.MarkupLine($"{c1}|  \\{e}{c2}--{e}{c3}^-`{e}{c1}/_//_/{e}");
            AnsiConsole.MarkupLine($"{c1} \\__\\{e}{c2}___/ {e}");
            AnsiConsole.Write(new Rule().RuleStyle("blue dim"));
            AnsiConsole.MarkupLine("");
        }
    }
}