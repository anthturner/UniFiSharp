using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class ClientSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<MacAddress>")]
        [Description("Client MAC Address")]
        public string MacAddress { get; set; } = string.Empty;
    }

    // ---

    public class ClientBlockCommand : UniFiSharpCommand<ClientSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, ClientSettings settings)
        {
            Log("Blocking Client at " + settings.MacAddress);
            return await Run(settings, u => u.ClientBlock(settings.MacAddress));
        }
    }

    public class ClientUnblockCommand : UniFiSharpCommand<ClientSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, ClientSettings settings)
        {
            Log("Unblocking Client at " + settings.MacAddress);
            return await Run(settings, u => u.ClientUnblock(settings.MacAddress));
        }
    }

    public class ClientForceReconnectCommand : UniFiSharpCommand<ClientSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, ClientSettings settings)
        {
            Log("Forcing Reconnect for Client at " + settings.MacAddress);
            return await Run(settings, u => u.ClientForceReconnect(settings.MacAddress));
        }
    }

    public class ClientListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Listing Clients");
            return await RunWithOutputs(settings, u => u.ClientList());
        }
    }

    public class ClientGetCommand : UniFiSharpCommand<ClientSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, ClientSettings settings)
        {
            Log($"Retrieving Information for Client at {settings.MacAddress}");
            return await RunWithOutput(settings, u => u.ClientGet(settings.MacAddress));
        }
    }
}