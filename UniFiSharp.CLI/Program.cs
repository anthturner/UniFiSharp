using Spectre.Console;
using Spectre.Console.Cli;
using UniFiSharp.CLI.Commands;

namespace UniFiSharp.CLI
{
    internal class Program
    {
        private static string Version => "v1.5.1";
        internal static bool Quiet { get; private set; } = false;
        internal static CommandApp App { get; private set; } = new CommandApp();
        static void Main(string[] args)
        {
            Console.WriteLine();

            if (!args.Any(a => a == "-q" || a == "--quiet"))
                DrawUniFiSharpLogo();
            else Quiet = true;

            App.Configure(config =>
            {
#if DEBUG
                config.ValidateExamples();
                config.PropagateExceptions();
#endif
                config.SetApplicationName("unifi-cli");

                config.AddCommand<ExploreModeCommand>("explore")
                      .WithDescription("Allows interactive exploration of the network topology")
                      .WithExample(new[] { "explore", "https://192.168.1.1", "admin", "password" });
                config.AddCommand<TopologyCommand>("topology")
                      .WithDescription("Visualizes the topology of the network including devices and clients")
                      .WithExample(new[] { "topology", "https://192.168.1.1", "admin", "password" });
                config.AddCommand<InteractiveModeCommand>("interactive")
                      .WithDescription("Run CLI tool in interactive mode; allows multiple commands to be run")
                      .WithExample(new[] { "interactive", "https://192.168.1.1", "admin", "password" });

                config.AddBranch<UniFiSharpSettings>("broadcast-group", bg =>
                {
                    bg.SetDescription("Manage Broadcast Groups");
                    bg.AddExample(new[] { "broadcast-group", "https://192.168.1.1", "admin", "password", "list" });

                    bg.AddCommand<BroadcastGroupCreateCommand>("create");
                    bg.AddCommand<BroadcastGroupDeleteCommand>("delete");
                    bg.AddCommand<BroadcastGroupGetCommand>("get");
                    bg.AddCommand<BroadcastGroupListCommand>("list");
                });

                config.AddBranch<UniFiSharpSettings>("client", client =>
                {
                    client.SetDescription("Manage Clients");
                    client.AddExample(new[] { "client", "https://192.168.1.1", "admin", "password", "list" });

                    client.AddCommand<ClientBlockCommand>("block");
                    client.AddCommand<ClientUnblockCommand>("unblock");
                    client.AddCommand<ClientForceReconnectCommand>("force-reconnect");
                    client.AddCommand<ClientListCommand>("list");
                    client.AddCommand<ClientGetCommand>("get");
                });

                config.AddBranch<UniFiSharpSettings>("hotspot", hotspot =>
                {
                    hotspot.SetDescription("Manage Hotspot Settings");
                    hotspot.AddBranch("operator", op =>
                    {
                        op.SetDescription("Manage Hotspot Operators");
                        op.AddExample(new[] { "hotspot", "https://192.168.1.1", "admin", "password", "operator", "list" });

                        op.AddCommand<HotspotOperatorAddCommand>("add");
                        op.AddCommand<HotspotOperatorListCommand>("list");
                    });
                    hotspot.AddBranch("voucher", voucher =>
                    {
                        voucher.SetDescription("Manage Hotspot Vouchers");
                        voucher.AddExample(new[] { "hotspot", "https://192.168.1.1", "admin", "password", "voucher", "list" });

                        voucher.AddCommand<HotspotVoucherListCommand>("list");
                        voucher.AddCommand<HotspotVoucherDeleteCommand>("delete");
                    });
                    hotspot.AddBranch("payment", payment =>
                    {
                        payment.SetDescription("Manage Hotspot Payments");
                        payment.AddExample(new[] { "hotspot", "https://192.168.1.1", "admin", "password", "payment", "list" });

                        payment.AddCommand<HotspotPaymentListCommand>("list");
                    });
                    hotspot.AddBranch("guest", guest =>
                    {
                        guest.SetDescription("Manage Hotspot Guests");
                        guest.AddExample(new[] { "hotspot", "https://192.168.1.1", "admin", "password", "guest", "list" });

                        guest.AddCommand<HotspotGuestListCommand>("list");
                    });
                });

                config.AddBranch<UniFiSharpSettings>("media", media =>
                {
                    media.SetDescription("Manage Media Files");
                    media.AddExample(new[] { "media", "https://192.168.1.1", "admin", "password", "list" });

                    media.AddCommand<MediaFileCreateCommand>("create");
                    media.AddCommand<MediaFileDeleteCommand>("delete");
                    media.AddCommand<MediaFileListCommand>("list");
                    media.AddCommand<MediaFileGetCommand>("get");
                });

                config.AddBranch<UniFiSharpSettings>("device", device =>
                {
                    device.SetDescription("Manage UniFi Network Devices");
                    device.AddExample(new[] { "device", "https://192.168.1.1", "admin", "password", "list" });
                    device.AddExample(new[] { "device", "https://192.168.1.1", "admin", "password", "restart", "aabbccddeeff" });

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
                    site.SetDescription("Manage Site Settings and Information");
                    site.AddExample(new[] { "site", "https://192.168.1.1", "admin", "password", "list" });

                    site.AddCommand<SiteHealthGetCommand>("health");
                    site.AddCommand<SiteLedCommand>("led");
                    site.AddCommand<SiteListCommand>("list");
                    site.AddCommand<SiteRogueApListCommand>("rogue-aps");

                    site.AddBranch("port-forward", pf =>
                    {
                        pf.SetDescription("Manage Port Forwarding");
                        pf.AddExample(new[] { "site", "https://192.168.1.1", "admin", "password", "port-forward", "list" });

                        pf.AddCommand<SitePortForwardsCreateCommand>("create");
                        pf.AddCommand<SitePortForwardsDeleteCommand>("delete");
                        pf.AddCommand<SitePortForwardsListCommand>("list");
                    });

                    site.AddBranch("user-group", ug =>
                    {
                        ug.SetDescription("Manage User Groups");
                        ug.AddExample(new[] { "site", "https://192.168.1.1", "admin", "password", "user-group", "list" });

                        ug.AddCommand<SiteUserGroupsCreateCommand>("create");
                        ug.AddCommand<SiteUserGroupsDeleteCommand>("delete");
                        ug.AddCommand<SiteUserGroupsListCommand>("list");
                    });

                    site.AddBranch("wlan-group", wg =>
                    {
                        wg.SetDescription("Manage WLAN Groups");
                        wg.AddExample(new[] { "site", "https://192.168.1.1", "admin", "password", "wlan-group", "list" });

                        wg.AddCommand<SiteWlanGroupsCreateCommand>("create");
                        wg.AddCommand<SiteWlanGroupsDeleteCommand>("delete");
                        wg.AddCommand<SiteWlanGroupsListCommand>("list");
                    });
                });

                config.AddBranch<UniFiSharpSettings>("user", user =>
                {
                    user.SetDescription("Manage Site Users");
                    user.AddExample(new[] { "user", "https://192.168.1.1", "admin", "password", "list" });

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
            var v = "[green]";
            var e = "[/]";
            var l = "[underline cyan]";

            AnsiConsole.Write(new Rule().RuleStyle("blue dim"));
            AnsiConsole.MarkupLine($"{c1} __ {e}{c3}   __ {e}{c1}  __ __{e}");
            AnsiConsole.MarkupLine($"{c1}|  |{e}{c3}  |  |{e}{c1}_/ // /_{e}\t{c1}UniFi Command Line Tool{e} {v}{Version}{e}");
            AnsiConsole.MarkupLine($"{c1}|  |{e}{c3}  |  {e}{c1}/_  _  __/{e}\t{l}https://github.com/anthturner/UniFiSharp{e}");
            AnsiConsole.MarkupLine($"{c1}|  |{e}{c3}  | {e}{c1}/_  _  __/{e}");
            AnsiConsole.MarkupLine($"{c1}|  \\{e}{c2}--{e}{c3}^-`{e}{c1}/_//_/{e}\t\t{c2}This tool is not supported or affiliated{e}");
            AnsiConsole.MarkupLine($"{c1} \\__\\{e}{c2}___/ {e}\t\t{c2}with Ubiquiti Networks in any way.{e}");
            AnsiConsole.MarkupLine("");
            AnsiConsole.Write(new Rule().RuleStyle("blue dim"));
            AnsiConsole.MarkupLine("");
        }
    }
}