using Spectre.Console.Cli;
using UniFiSharp.CLI.Commands;

namespace UniFiSharp.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandApp();
            app.Configure(config =>
            {
#if DEBUG
                config.ValidateExamples();
                config.PropagateExceptions();
#endif
                config.SetApplicationName("unifi-cli");

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
            app.Run(args);
        }
    }
}