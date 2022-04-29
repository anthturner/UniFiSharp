using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class SiteLedSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<LedState>")]
        [Description("Site LED State (True/False)")]
        public bool LedState { get; set; } = true;
    }

    // ---

    public class SiteHealthGetCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Getting Site Health");
            return await RunWithOutputs(settings, u => u.SiteHealthGet(), OutputMaps.SystemHealth);
        }
    }

    public class SiteLedCommand : UniFiSharpCommand<SiteLedSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, SiteLedSettings settings)
        {
            Log($"Setting Site LED to {settings.LedState}");
            return await Run(settings, u => u.SiteLedToggle(settings.LedState));
        }
    }

    public class SiteListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Getting List of Sites on this Controller");
            return await RunWithOutputs(settings, u => u.ControllerSiteList(), OutputMaps.Sites);
        }
    }

    public class SiteRogueApListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Getting List of Rogue APs");
            return await RunWithOutputs(settings, async u => await u.SiteRogueApList(), OutputMaps.RogueAps);
        }
    }
}