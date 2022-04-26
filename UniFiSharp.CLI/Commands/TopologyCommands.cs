using Spectre.Console;
using Spectre.Console.Cli;
using UniFiSharp.Orchestration.Devices;

namespace UniFiSharp.CLI.Commands
{
    public class TopologyCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Generating Network Topology");
            return await Run(settings, async u =>
            {
                var authenticated = await u.Authenticate();
                var orchestrator = new UniFiSharp.Orchestration.UniFiOrchestrator(u);
                await orchestrator.Refresh();

                var tree = new Tree($"Network ({u.Site})");
                var root = (IInfrastructureNetworkedDevice)orchestrator.TopologicalRoot;
                var rootNode = tree.AddNode(GetDeviceMarkup(root));
                GenerateChildNodes(rootNode, root);

                AnsiConsole.Write(tree);
            });
        }

        private string GetDeviceMarkup(INetworkedDevice dev)
        {
            var markup = string.Empty;

            if (dev is IInfrastructureNetworkedDevice)
            {
                var infra = (IInfrastructureNetworkedDevice)dev;
                if (infra is AccessPointInfrastructureNetworkedDevice)
                    markup = $"[blue]{dev.Name}[/] ({infra.MacAddress})";
                else if (infra is SwitchInfrastructureNetworkedDevice)
                    markup = $"[green]{dev.Name}[/] ({infra.MacAddress})";
                else if (infra is RouterInfrastructureNetworkedDevice)
                    markup = $"[yellow]{dev.Name}[/] ({infra.MacAddress})";
            }
            else if (dev is IClientNetworkedDevice)
            {
                var client = (IClientNetworkedDevice)dev;
                if (client.IsGuest)
                    markup = $"[fuschia]{client.Name}[/] ({client.IpAddress})";
                else
                    markup = $"[purple]{client.Name}[/] ({client.IpAddress})";
            }
            else
                markup = dev.Name;

            return markup;
        }

        private void GenerateChildNodes(TreeNode tree, IInfrastructureNetworkedDevice node)
        {
            foreach (var dev in node.InfrastructureDevices)
            {
                var newNode = tree.AddNode(GetDeviceMarkup(dev));
                GenerateChildNodes(newNode, dev);
            }

            foreach (var client in node.Clients)
                tree.AddNode(GetDeviceMarkup(client));
        }
    }
}