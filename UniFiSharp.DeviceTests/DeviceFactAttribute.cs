using Xunit;
namespace UniFiSharp.DeviceTests;
public sealed class DeviceFactAttribute : FactAttribute
{
    public DeviceFactAttribute() { if (Missing("UNIFI_DEVICE_URL") || Missing("UNIFI_DEVICE_USERNAME") || Missing("UNIFI_DEVICE_PASSWORD")) Skip = "Run test-device.ps1 to supply live controller credentials."; }
    private static bool Missing(string name) => string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(name));
}
