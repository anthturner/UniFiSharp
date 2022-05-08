using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class UserSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<MacAddress>")]
        [Description("User MAC Address")]
        public string MacAddress { get; set; } = string.Empty;
    }

    // ---

    public class UserListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Listing Users");
            return await RunWithOutputs(settings, async u => await u.UserList());
        }
    }

    public class UserGetCommand : UniFiSharpCommand<UserSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UserSettings settings)
        {
            Log($"Getting User '{settings.MacAddress}'");
            return await RunWithOutput(settings, async u => await u.UserGet(settings.MacAddress));
        }
    }
}