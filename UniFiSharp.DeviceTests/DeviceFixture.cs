using Xunit;
using System.Collections.Concurrent;
namespace UniFiSharp.DeviceTests;
public sealed class DeviceFixture : IAsyncLifetime
{
    private readonly ConcurrentQueue<string> cleanupFailures = new();
    public UniFiApi Api { get; private set; } = null!;
    public async Task InitializeAsync()
    {
        var modern = !string.Equals(Environment.GetEnvironmentVariable("UNIFI_DEVICE_MODERN_API"), "false", StringComparison.OrdinalIgnoreCase);
        Api = new UniFiApi(new Uri(Environment.GetEnvironmentVariable("UNIFI_DEVICE_URL")!), Environment.GetEnvironmentVariable("UNIFI_DEVICE_USERNAME")!, Environment.GetEnvironmentVariable("UNIFI_DEVICE_PASSWORD")!, Environment.GetEnvironmentVariable("UNIFI_DEVICE_SITE") ?? "default", true, modern);
        await Api.Authenticate();
    }
    public async Task ReverseOrRecordAsync(string resource, string manualRemediation, Func<Task> reverse)
    {
        try
        {
            await reverse();
        }
        catch (Exception ex)
        {
            cleanupFailures.Enqueue(
                $"RESOURCE: {resource}{Environment.NewLine}" +
                $"MANUAL REMEDIATION: {manualRemediation}{Environment.NewLine}" +
                $"REVERSAL ERROR: {ex.GetType().Name}: {ex.Message}");
        }
    }

    public async Task DisposeAsync()
    {
        if (Api is null) return;
        Exception? logoutFailure = null;
        try { await Api.Logout(); }
        catch (Exception ex) { logoutFailure = ex; }
        finally { Api.Dispose(); }

        if (!cleanupFailures.IsEmpty)
        {
            throw new InvalidOperationException(
                "REVERSIBLE-WRITE CLEANUP FAILED. MANUAL ACTION IS REQUIRED." +
                Environment.NewLine + Environment.NewLine +
                string.Join(Environment.NewLine + Environment.NewLine, cleanupFailures) +
                (logoutFailure is null ? string.Empty :
                    Environment.NewLine + Environment.NewLine +
                    $"SESSION LOGOUT ALSO FAILED: {logoutFailure.GetType().Name}: {logoutFailure.Message}"));
        }

        if (logoutFailure is not null)
            throw logoutFailure;
    }
}
[CollectionDefinition(Name, DisableParallelization = true)]
public sealed class DeviceCollection : ICollectionFixture<DeviceFixture> { public const string Name = "Live UniFi device"; }
