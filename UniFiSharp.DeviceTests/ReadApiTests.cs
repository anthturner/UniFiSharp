using Xunit.Abstractions;
using Xunit;
namespace UniFiSharp.DeviceTests;
[Collection(DeviceCollection.Name)]
public sealed class ReadApiTests(DeviceFixture device, ITestOutputHelper output)
{
    [DeviceFact] public void Authenticate_completes() => Assert.NotNull(device.Api);
    [DeviceFact] public async Task ControllerSiteList_works() => Assert.NotNull(await device.Api.ControllerSiteList());
    [DeviceFact] public async Task SiteHealthGet_works() => Assert.NotNull(await device.Api.SiteHealthGet());
    [DeviceFact] public async Task ClientList_works() => Assert.NotNull(await device.Api.ClientList());
    [DeviceFact] public async Task UserList_works() => Assert.NotNull(await device.Api.UserList());
    [DeviceFact] public async Task NetworkDeviceList_works() => Assert.NotNull(await device.Api.NetworkDeviceList());
    [DeviceFact] public async Task MediaFileList_works() => Assert.NotNull(await device.Api.MediaFileList());
    [DeviceFact] public async Task SampleFileList_works() => Assert.NotNull(await device.Api.SampleFileList());
    [DeviceFact] public async Task HotspotOperatorList_works() => Assert.NotNull(await device.Api.HotspotOperatorList());
    [DeviceFact] public async Task HotspotVoucherList_works() => Assert.NotNull(await device.Api.HotspotVoucherList());
    [DeviceFact] public async Task HotspotGuestList_works() => Assert.NotNull(await device.Api.HotspotGuestList());
    [DeviceFact] public async Task HotspotPaymentList_works() => Assert.NotNull(await device.Api.HotspotPaymentList());
    [DeviceFact] public async Task SitePortForwardsList_works() => Assert.NotNull(await device.Api.SitePortForwardsList());
    [DeviceFact] public async Task SiteRogueApList_works() => Assert.NotNull(await device.Api.SiteRogueApList());
    [DeviceFact] public async Task SiteUserGroupsList_works() => Assert.NotNull(await device.Api.SiteUserGroupsList());
    [DeviceFact] public async Task SiteWlanGroupsList_works() => Assert.NotNull(await device.Api.SiteWlanGroupsList());
    [DeviceFact] public async Task BroadcastGroupList_works() => Assert.NotNull(await device.Api.BroadcastGroupList());
    [DeviceFact] public async Task ActiveStreamList_works() => Assert.NotNull(await device.Api.ActiveStreamList());
    [DeviceFact] public async Task ClientGet_works() { var x=(await device.Api.ClientList()).FirstOrDefault(x=>!string.IsNullOrWhiteSpace(x.mac)); if(x is null){NoData("client");return;} Assert.NotNull(await device.Api.ClientGet(x.mac)); }
    [DeviceFact] public async Task UserGet_works() { var x=(await device.Api.UserList()).FirstOrDefault(x=>!string.IsNullOrWhiteSpace(x.mac)); if(x is null){NoData("user");return;} Assert.NotNull(await device.Api.UserGet(x.mac)); }
    [DeviceFact] public async Task NetworkDeviceGet_works() { var x=(await device.Api.NetworkDeviceList()).FirstOrDefault(x=>!string.IsNullOrWhiteSpace(x.mac)); if(x is null){NoData("network device");return;} Assert.NotNull(await device.Api.NetworkDeviceGet(x.mac)); }
    [DeviceFact] public async Task NetworkDeviceRfScanStatus_works() { var x=(await device.Api.NetworkDeviceList()).FirstOrDefault(x=>x.type=="uap"&&!string.IsNullOrWhiteSpace(x.mac)); if(x is null){NoData("access point");return;} await device.Api.NetworkDeviceRfScanStatus(x.mac); }
    [DeviceFact] public async Task MediaFileGet_works() { var x=(await device.Api.MediaFileList()).FirstOrDefault(x=>!string.IsNullOrWhiteSpace(x._id)); if(x is null){NoData("media file");return;} Assert.NotNull(await device.Api.MediaFileGet(x._id)); }
    [DeviceFact] public async Task HotspotVoucherGet_works() { var x=(await device.Api.HotspotVoucherList()).FirstOrDefault(); if(x is null){NoData("hotspot voucher");return;} Assert.NotNull(await device.Api.HotspotVoucherGet(x.createTime)); }
    [DeviceFact] public async Task BroadcastGroupGet_works() { var x=(await device.Api.BroadcastGroupList()).FirstOrDefault(x=>!string.IsNullOrWhiteSpace(x._id)); if(x is null){NoData("broadcast group");return;} Assert.NotNull(await device.Api.BroadcastGroupGet(x._id)); }
    private void NoData(string kind) => output.WriteLine($"No {kind} exists; item lookup was not applicable.");
}
