using Spectre.Console.Cli;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.CLI.Commands
{
    public class NetworkDeviceSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<DeviceMacId>")]
        [Description("Device MAC Address")]
        public string DeviceMacId { get; set; } = string.Empty;
    }

    public class NetworkDeviceLocateSettings : NetworkDeviceSettings
    {
        [CommandArgument(4, "<State>")]
        [Description("Locator Light State (True/False)")]
        public bool LocateState { get; set; } = true;
    }

    public class NetworkDevicePortSettings : NetworkDeviceSettings
    {
        [CommandArgument(4, "<Port>")]
        [Description("Network Device Port")]
        public int Port { get; set; } = 0;
    }

    public class NetworkDeviceVolumeSettings : NetworkDeviceSettings
    {
        [CommandArgument(4, "<Volume>")]
        [Description("Device Volume")]
        public int Volume { get; set; } = 0;
    }

    // ---

    public class NetworkDeviceAdoptCommand : UniFiSharpCommand<NetworkDeviceSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDeviceSettings settings)
        {
            Log($"Adopting Network Device '{settings.DeviceMacId}'");
            return await Run(settings, u => u.NetworkDeviceAdopt(settings.DeviceMacId));
        }
    }

    public class NetworkDeviceForgetCommand : UniFiSharpCommand<NetworkDeviceSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDeviceSettings settings)
        {
            Log($"Forgetting Network Device '{settings.DeviceMacId}'");
            return await Run(settings, u => u.NetworkDeviceForget(settings.DeviceMacId));
        }
    }

    public class NetworkDeviceGetCommand : UniFiSharpCommand<NetworkDeviceSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDeviceSettings settings)
        {
            Log($"Getting Network Device '{settings.DeviceMacId}'");
            return await RunWithOutput(settings, u => u.NetworkDeviceGet(settings.DeviceMacId));
        }
    }

    public class NetworkDeviceListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log($"Listing Network Devices");
            return await RunWithOutputs(settings, u => u.NetworkDeviceList());
        }
    }

    public class NetworkDeviceLocateCommand : UniFiSharpCommand<NetworkDeviceLocateSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDeviceLocateSettings settings)
        {
            Log($"Locating Network Device '{settings.DeviceMacId}'");
            return await Run(settings, u => u.NetworkDeviceLocate(settings.DeviceMacId, settings.LocateState));
        }
    }

    public class NetworkDeviceRestartCommand : UniFiSharpCommand<NetworkDeviceSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDeviceSettings settings)
        {
            Log($"Restarting Network Device '{settings.DeviceMacId}'");
            return await Run(settings, u => u.NetworkDeviceRestart(settings.DeviceMacId));
        }
    }

    public class NetworkDevicePowerCycleCommand : UniFiSharpCommand<NetworkDevicePortSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDevicePortSettings settings)
        {
            Log($"Power-Cycling Port {settings.Port} on Network Device '{settings.DeviceMacId}'");
            return await Run(settings, u => u.NetworkDevicePowerCyclePort(settings.DeviceMacId, settings.Port));
        }
    }

    public class NetworkDeviceRfScanCommand : UniFiSharpCommand<NetworkDeviceSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDeviceSettings settings)
        {
            Log($"Beginning RF Scan on Network Device '{settings.DeviceMacId}'");
            return await Run(settings, u => u.NetworkDeviceRfScan(settings.DeviceMacId));
        }
    }

    public class NetworkDeviceRfScanStatusCommand : UniFiSharpCommand<NetworkDeviceSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDeviceSettings settings)
        {
            Log($"Getting RF Scan Status on Network Device '{settings.DeviceMacId}'");
            return await RunWithOutput(settings, u => u.NetworkDeviceRfScanStatus(settings.DeviceMacId),
                (o) =>
                {
                    WriteHeader("Spectrum Table 5G");
                    DrawMultiRowTable(o.spectrum_table_na, Levels.Basic);
                    WriteHeader("Spectrum Table 2.4G");
                    DrawMultiRowTable(o.spectrum_table_ng, Levels.Basic);
                });
        }
    }

    public class NetworkDeviceVolumeCommand : UniFiSharpCommand<NetworkDeviceVolumeSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDeviceVolumeSettings settings)
        {
            Log($"Setting Volume on Network Device '{settings.DeviceMacId}' to {settings.Volume}");
            return await Run(settings, u => u.NetworkDeviceSetVolume(settings.DeviceMacId, settings.Volume));
        }
    }

    public class NetworkDeviceUpgradeCommand : UniFiSharpCommand<NetworkDeviceSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, NetworkDeviceSettings settings)
        {
            Log($"Upgrading Network Device '{settings.DeviceMacId}'");
            return await Run(settings, u => u.NetworkDeviceUpgrade(settings.DeviceMacId));
        }
    }
}
