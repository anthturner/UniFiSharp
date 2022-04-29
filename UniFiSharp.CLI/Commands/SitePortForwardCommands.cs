using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class SitePortForwardIdSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<Id>")]
        [Description("Port Forward ID")]
        public string PortForwardId { get; set; } = string.Empty;
    }

    public class SitePortForwardCreateSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<Name>")]
        [Description("Port Forward Name")]
        public string Name { get; set; } = string.Empty;

        [CommandArgument(4, "<Protocol>")]
        [Description("Forwarded Protocol")]
        public string Protocol { get; set; } = string.Empty;

        [CommandArgument(5, "<SourceIp>")]
        [Description("Source IP")]
        public string Source { get; set; } = string.Empty;

        [CommandArgument(6, "<DestinationIp>")]
        [Description("Destination IP")]
        public string Destination { get; set; } = string.Empty;

        [CommandArgument(7, "<SourcePort>")]
        [Description("Source Port")]
        public int FromPort { get; set; }

        [CommandArgument(8, "<DestinationPort>")]
        [Description("Destination Port")]
        public int ToPort { get; set; }
    }

    // ---

    public class SitePortForwardsListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Getting List of Port Forwards");
            return await RunWithOutputs(settings, async u => await u.SitePortForwardsList(), OutputMaps.PortForwards);
        }
    }

    public class SitePortForwardsDeleteCommand : UniFiSharpCommand<SitePortForwardIdSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, SitePortForwardIdSettings settings)
        {
            Log($"Deleting Port Forward '{settings.PortForwardId}'");
            return await Run(settings, async u => await u.SitePortForwardsDelete(settings.PortForwardId));
        }
    }

    public class SitePortForwardsCreateCommand : UniFiSharpCommand<SitePortForwardCreateSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, SitePortForwardCreateSettings settings)
        {
            Log($"Creating Port Forward '{settings.Name}'");
            return await RunWithOutput(settings, async u => await u.SitePortForwardsCreate(
                settings.Name,
                settings.Protocol,
                settings.Source,
                settings.Destination,
                settings.FromPort,
                settings.ToPort),
                OutputMaps.PortForwards);
        }
    }
}
