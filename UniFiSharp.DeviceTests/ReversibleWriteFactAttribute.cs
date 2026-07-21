using Xunit;

namespace UniFiSharp.DeviceTests;

public sealed class ReversibleWriteFactAttribute : FactAttribute
{
    public ReversibleWriteFactAttribute()
    {
        if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("UNIFI_DEVICE_URL")) ||
            string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("UNIFI_DEVICE_USERNAME")) ||
            string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("UNIFI_DEVICE_PASSWORD")))
        {
            Skip = "Run test-device.ps1 with live controller credentials.";
        }
        else if (!string.Equals(Environment.GetEnvironmentVariable("UNIFI_DEVICE_REVERSIBLE_WRITES"),
                     "true", StringComparison.OrdinalIgnoreCase))
        {
            Skip = "Reversible writes are opt-in; run test-device.ps1 -ReversibleWrites.";
        }
    }
}
