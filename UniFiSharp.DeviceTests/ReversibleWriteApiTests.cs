using Xunit;

namespace UniFiSharp.DeviceTests;

[Collection(DeviceCollection.Name)]
public sealed class ReversibleWriteApiTests(DeviceFixture device)
{
    private static string UniqueName(string kind) =>
        $"unifisharp-it-{kind}-{Guid.NewGuid():N}";

    [ReversibleWriteFact]
    public async Task UserGroup_can_be_created_and_deleted()
    {
        string? id = null;
        var name = UniqueName("usergroup");
        try
        {
            var created = await device.Api.SiteUserGroupsCreate(name);
            id = created?._id;
            Assert.False(string.IsNullOrWhiteSpace(id));
            Assert.Contains(await device.Api.SiteUserGroupsList(), x => x._id == id);
        }
        finally
        {
            if (!string.IsNullOrWhiteSpace(id))
                await device.ReverseOrRecordAsync(
                    $"user group '{name}' (ID {id})",
                    $"Delete the user group named '{name}' from the test site.",
                    () => device.Api.SiteUserGroupsDelete(id));
        }
    }

    [ReversibleWriteFact]
    public async Task WlanGroup_can_be_created_and_deleted()
    {
        string? id = null;
        var name = UniqueName("wlangroup");
        try
        {
            var created = await device.Api.SiteWlanGroupsCreate(
                name, "ng", 0, 0, false);
            id = created?._id;
            Assert.False(string.IsNullOrWhiteSpace(id));
            Assert.Contains(await device.Api.SiteWlanGroupsList(), x => x._id == id);
        }
        finally
        {
            if (!string.IsNullOrWhiteSpace(id))
                await device.ReverseOrRecordAsync(
                    $"WLAN group '{name}' (ID {id})",
                    $"Delete the WLAN group named '{name}' from the test site.",
                    () => device.Api.SiteWlanGroupsDelete(id));
        }
    }

    [ReversibleWriteFact]
    public async Task HotspotVoucher_can_be_created_and_deleted()
    {
        // Recover leftovers from an interrupted earlier integration run before creating a new
        // voucher. The prefix is reserved exclusively for this suite.
        var staleVouchers = (await device.Api.HotspotVoucherList())
            .Where(x => x.note?.StartsWith("unifisharp-it-voucher-", StringComparison.Ordinal) == true &&
                        !string.IsNullOrWhiteSpace(x.id))
            .ToList();
        foreach (var staleVoucher in staleVouchers)
            await device.Api.HotspotVoucherDelete(staleVoucher.id);

        string? id = null;
        var note = UniqueName("voucher");
        var creationCompleted = false;
        try
        {
            var created = await device.Api.HotspotVoucherAdd(
                bytes: null, down: null, up: null, expire: "1", quota: 1,
                note: note, count: 1);
            creationCompleted = true;
            id = created?.id;

            // Current controllers return command metadata rather than the created voucher.
            // Recover its ID from the uniquely tagged list result so it can be removed.
            for (var attempt = 0; string.IsNullOrWhiteSpace(id) && attempt < 5; attempt++)
            {
                if (attempt > 0)
                    await Task.Delay(250);
                id = (await device.Api.HotspotVoucherList())
                    .FirstOrDefault(x => x.note == note)?.id;
            }

            Assert.False(string.IsNullOrWhiteSpace(id));
        }
        finally
        {
            if (creationCompleted)
            {
                await device.ReverseOrRecordAsync(
                    $"hotspot voucher '{note}'" +
                    (string.IsNullOrWhiteSpace(id) ? string.Empty : $" (ID {id})"),
                    $"Delete the hotspot voucher with note '{note}' from the test site.",
                    async () =>
                    {
                        var voucherIds = (await device.Api.HotspotVoucherList())
                            .Where(x => x.note == note && !string.IsNullOrWhiteSpace(x.id))
                            .Select(x => x.id)
                            .Distinct()
                            .ToList();
                        if (voucherIds.Count == 0)
                            throw new InvalidOperationException(
                                $"Could not find the created voucher with note '{note}'.");
                        foreach (var voucherId in voucherIds)
                            await device.Api.HotspotVoucherDelete(voucherId);
                    });
            }
        }
    }

    [ReversibleWriteFact]
    public async Task High_port_forward_can_be_created_and_deleted()
    {
        string? id = null;
        var name = UniqueName("portforward");
        var usedPorts = (await device.Api.SitePortForwardsList()).Select(x => x.dst_port).ToHashSet();
        var port = Enumerable.Range(49152, 65535 - 49152 + 1)
            .OrderBy(_ => Random.Shared.Next())
            .First(x => !usedPorts.Contains(x));

        try
        {
            var created = await device.Api.SitePortForwardsCreate(
                name, "tcp", "203.0.113.1", "192.0.2.1", port, port);
            id = created?._id;
            Assert.False(string.IsNullOrWhiteSpace(id));
            Assert.Contains(await device.Api.SitePortForwardsList(), x => x._id == id);
        }
        finally
        {
            if (!string.IsNullOrWhiteSpace(id))
                await device.ReverseOrRecordAsync(
                    $"port forward '{name}' (ID {id}, TCP port {port})",
                    $"Delete the port-forward rule named '{name}' from the test site.",
                    () => device.Api.SitePortForwardsDelete(id));
        }
    }

    [ReversibleWriteFact]
    public async Task Device_locate_can_be_enabled_and_disabled()
    {
        var target = (await device.Api.NetworkDeviceList())
            .FirstOrDefault(x => x.adopted && !string.IsNullOrWhiteSpace(x.mac));
        if (target is null)
            return;

        try
        {
            await device.Api.NetworkDeviceLocate(target.mac, true);
        }
        finally
        {
            await device.ReverseOrRecordAsync(
                $"Locate state on device {target.mac}",
                $"Disable Locate for device {target.mac} in the UniFi console.",
                () => device.Api.NetworkDeviceLocate(target.mac, false));
        }
    }

    [ReversibleWriteFact]
    public async Task Site_led_setting_can_be_toggled()
    {
        try
        {
            await device.Api.SiteLedToggle(false);
        }
        finally
        {
            // The API has no matching read operation, so leave the common/default state enabled.
            await device.ReverseOrRecordAsync(
                "site-wide LED setting",
                "Enable the site LED setting in UniFi Network settings.",
                () => device.Api.SiteLedToggle(true));
        }
    }

    [ReversibleWriteFact]
    public async Task Device_led_override_can_be_changed_and_restored()
    {
        var target = (await device.Api.NetworkDeviceList())
            .FirstOrDefault(x => x.adopted && !string.IsNullOrWhiteSpace(x._id));
        if (target is null)
            return;

        var original = string.IsNullOrWhiteSpace(target.led_override) ? "default" : target.led_override;
        try
        {
            await device.Api.NetworkDeviceConfigure(
                target._id, NetworkDeviceConfigurations.LedOverride("off"));
        }
        finally
        {
            await device.ReverseOrRecordAsync(
                $"LED override on device {target.mac} (ID {target._id})",
                $"Set the LED override for device {target.mac} back to '{original}'.",
                () => device.Api.NetworkDeviceConfigure(
                    target._id, NetworkDeviceConfigurations.LedOverride(original)));
        }
    }
}
