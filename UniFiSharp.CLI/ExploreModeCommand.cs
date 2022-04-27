using Spectre.Console;
using Spectre.Console.Cli;
using UniFiSharp.Orchestration;
using UniFiSharp.Orchestration.Devices;

namespace UniFiSharp.CLI
{
    internal class NamedSelectionElement
    {
        public string Header { get; set; }
        public object Data { get; set; }

        public static NamedSelectionElement Create<T>(string header, T data)
        {
            return new NamedSelectionElement()
            {
                Header = header,
                Data = data
            };
        }

        public override string ToString() => Header;
    }

    public class ExploreModeCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        private UniFiOrchestrator Orchestrator { get; set; }
        private INetworkedDevice CurrentDevice { get; set; }
        private string WhereAmI
        {
            get
            {
                var markupElements = new List<string>();
                var path = Orchestrator.GeneratePathTo(CurrentDevice).Reverse().ToList();
                path.Add(Tuple.Create(CurrentDevice, 0));
                foreach (var item in path)
                {
                    // item2 is port number
                    var itemMarkup = GetDeviceMarkup(item.Item1);
                    if (item.Item2 > 0)
                        itemMarkup += $"/[#66ff66]Port {item.Item2}[/]";
                    markupElements.Add(itemMarkup);
                }
                return string.Join("/", markupElements);
            }
        }

        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log($"Running in topology exploration mode. Type 'quit' or 'exit' to end.\n");

            await AnsiConsole.Status()
                .Spinner(Spinner.Known.Aesthetic)
                .StartAsync("Retrieving current topology...", async cxt =>
                {
                    var api = settings.GetUniFiSharp();
                    await api.Authenticate();
                    Orchestrator = new UniFiOrchestrator(api);
                    await Orchestrator.Refresh();
                    CurrentDevice = Orchestrator.TopologicalRoot;
                });

            while (true)
            {
                var promptText = AnsiConsole.Prompt(new TextPrompt<string>($"[cyan]UniFi[/]://{WhereAmI}> "));

                // parse and inject the auth info into each subsequent command
                var args = ParseMultiSpacedArguments(promptText);

                switch (args[0])
                {
                    case "cd": ChangeDeviceCommand(args); break;
                    case "ls": ListDevicesCommand(); break;
                    case "info": CreatePropertyTable(CurrentDevice); break;
                    case "clear": AnsiConsole.Clear(); break;

                    case "locate": RunOnInfra(i => i.Locate()); break;
                    case "adopt": RunOnInfra(i => i.Adopt()); break;
                    case "forget": RunOnInfra(i => i.Forget()); break;
                    case "set-name": RunOnInfra(i => i.SetName(args[1])); break;
                    case "activity": 
                        await ShowClientChart<IClientNetworkedDevice>(
                        "[green bold underline]Client Activity (KBps)[/] - Refreshes every 5s - Press <ESC> to stop",
                        n => n.Name,
                        v => (int)Math.Floor(v.ActivityKbps),
                        g => g > 1); break;
                    case "rssi":
                        await ShowClientChart<WirelessClientNetworkedDevice>(
                        "[cyan bold underline]Wi-Fi Client RSSI[/] - Refreshes every 5s - Press <ESC> to stop",
                        n => n.Name,
                        v => v.Rssi); break;
                    case "signal":
                        await ShowClientChart<WirelessClientNetworkedDevice>(
                        "[cyan bold underline]Wi-Fi Client Signal[/] - Refreshes every 5s - Press <ESC> to stop",
                        n => n.Name,
                        v => 100 - Math.Abs(v.Signal)); break;

                    case "force-reconnect": RunOnClient(c => c.ForceReconnect()); break;

                    case "help":
                        AnsiConsole.WriteLine();
                        AnsiConsole.Write(new Rule("[blue]Topology Navigation[/]"));
                        AnsiConsole.MarkupLine("[green]cd[/]\t\tChanges to a device or client");
                        AnsiConsole.MarkupLine("[green]ls[/]\t\tLists child devices and clients on this device");
                        AnsiConsole.MarkupLine("[green]info[/]\t\tDump all information on this device");
                        AnsiConsole.MarkupLine("[green]clear[/]\t\tClear window");

                        AnsiConsole.Write(new Rule("[purple]Device Management[/]"));
                        AnsiConsole.MarkupLine("[green]locate[/]\t\tBlink the device locator light for 10 seconds");
                        AnsiConsole.MarkupLine("[green]adopt[/]\t\tAdopt this device");
                        AnsiConsole.MarkupLine("[green]forget[/]\t\tForget this device");
                        AnsiConsole.MarkupLine("[green]set-name[/]\tSet this device's name");
                        AnsiConsole.MarkupLine("[green]activity[/]\tShow activity of all clients on this device and children");
                        AnsiConsole.MarkupLine("[green]rssi[/]\t\tShow RSSI of all wireless clients on this device and children");
                        AnsiConsole.MarkupLine("[green]signal[/]\t\tShow signal strength of all wireless clients on this device and children");

                        AnsiConsole.Write(new Rule("[cyan]Client Management[/]"));
                        AnsiConsole.MarkupLine("[green]force-reconnect[/]\tForce a device to reconnect");

                        AnsiConsole.Write(new Rule("[gray]Other[/]"));
                        AnsiConsole.MarkupLine("[green]help[/]\t\tShows this help screen");
                        AnsiConsole.MarkupLine("[green]quit[/]\t\tExit this application");
                        AnsiConsole.WriteLine();
                        break;
                    case "quit":
                    case "exit": return 0;
                }
            }
        }

        private void RunOnClient(Func<IClientNetworkedDevice, Task> func)
        {
            if (CurrentDevice is IClientNetworkedDevice)
                func((IClientNetworkedDevice)CurrentDevice).Wait();
            else
                Warn("Devices cannot run this command");
        }

        private void RunOnInfra(Func<IInfrastructureNetworkedDevice, Task> func)
        {
            if (CurrentDevice is IInfrastructureNetworkedDevice)
                func((IInfrastructureNetworkedDevice)CurrentDevice).Wait();
            else
                Warn("Clients cannot run this command");
        }

        private async Task ShowClientChart<TDevice>(string title, Func<TDevice, string> nameFunc, Func<TDevice, int> valueFunc, Func<int, bool> valueGateFunc = null, int refreshTime = 5000)
            where TDevice : IClientNetworkedDevice
        {
            if (valueGateFunc == null) valueGateFunc = (i) => true;
            if (CurrentDevice is IInfrastructureNetworkedDevice)
            {
                var thisDeviceMacAddress = ((IInfrastructureNetworkedDevice)CurrentDevice).MacAddress;
                await ConsoleDrawHelper.ShowDynamicBarChart(title, nameFunc, valueFunc, valueGateFunc, refreshTime, async () =>
                {
                    await Orchestrator.Refresh();
                    return Orchestrator.InfrastructureDevices
                                       .First(d => d.MacAddress == thisDeviceMacAddress)
                                       .ClientsRecursive
                                       .OfType<TDevice>();
                });
            }
        }

        private void ListDevicesCommand()
        {
            if (CurrentDevice is IInfrastructureNetworkedDevice)
            {
                var dev = (IInfrastructureNetworkedDevice)CurrentDevice;
                foreach (var item in dev.InfrastructureDevices)
                {
                    var path = Orchestrator.GeneratePathTo(item).Reverse().Last();
                    AnsiConsole.MarkupLine("[green]Port " + path.Item2 + "[/]\t" + GetDeviceMarkup(item));
                }
                foreach (var item in dev.Clients)
                {
                    var path = Orchestrator.GeneratePathTo(item).Reverse().Last();
                    AnsiConsole.MarkupLine("[green]Port " + path.Item2 + "[/]\t" + GetDeviceMarkup(item));
                }
            }
        }

        private void ChangeDeviceCommand(string[] args)
        {
            if (args.Length == 1)
            {
                if (CurrentDevice is IInfrastructureNetworkedDevice)
                {
                    var dev = (IInfrastructureNetworkedDevice)CurrentDevice;
                    var result = AnsiConsole.Prompt(
                        new SelectionPrompt<NamedSelectionElement>()
                              .AddChoices(dev.InfrastructureDevices.Select(d =>
                              {
                                  var path = Orchestrator.GeneratePathTo(d).Reverse().Last();
                                  return NamedSelectionElement.Create("[green]Port " + path.Item2 + "[/]\t[blue]" + d.Name + "[/]", d);
                              }))
                              .AddChoices(dev.Clients.Select(c =>
                              {
                                  var path = Orchestrator.GeneratePathTo(c).Reverse().Last();
                                  return NamedSelectionElement.Create("[green]Port " + path.Item2 + "[/]\t[purple]" + c.Name + "[/]", c);
                              })));
                    if (result != null)
                    {
                        CurrentDevice = (INetworkedDevice)result.Data;
                    }
                }
            }
            else if (args[1] == "..")
            {
                var path = Orchestrator.GeneratePathTo(CurrentDevice);
                CurrentDevice = path.SkipLast(1).Last().Item1;
            }
            else
            {
                if (CurrentDevice is IInfrastructureNetworkedDevice)
                {
                    var dev = (IInfrastructureNetworkedDevice)CurrentDevice;
                    INetworkedDevice? target = dev.InfrastructureDevices.FirstOrDefault(d => d.Name == args[1] || d.MacAddress.EndsWith(args[1]));
                    if (target == null)
                        target = dev.Clients.FirstOrDefault(d => d.Name == args[1] || d.MacAddress.EndsWith(args[1]) || d.IpAddress == args[1]);

                    if (target == null)
                        Error("Device not found");
                    else
                        CurrentDevice = target;
                }
            }
        }

        private static string[] ParseMultiSpacedArguments(string commandLine)
        {
            var isLastCharSpace = false;
            char[] parmChars = commandLine.ToCharArray();
            bool inQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"')
                    inQuote = !inQuote;
                if (!inQuote && parmChars[index] == ' ' && !isLastCharSpace)
                    parmChars[index] = '\n';

                isLastCharSpace = parmChars[index] == '\n' || parmChars[index] == ' ';
            }

            return (new string(parmChars)).Replace("\"", "").Split('\n');
        }

        private static string GetDeviceMarkup(INetworkedDevice device)
        {
            var markup = string.Empty;

            if (device is IInfrastructureNetworkedDevice)
            {
                var infra = (IInfrastructureNetworkedDevice)device;
                var mac = infra.MacAddress.Substring(infra.MacAddress.Length-5);
                if (infra is AccessPointInfrastructureNetworkedDevice)
                    markup = $"[blue]{infra.Name}[/] ({mac})";
                else if (infra is SwitchInfrastructureNetworkedDevice)
                    markup = $"[green]{infra.Name}[/] ({mac})";
                else if (infra is RouterInfrastructureNetworkedDevice)
                    markup = $"[yellow]{infra.Name}[/] ({mac})";
            }
            else if (device is IClientNetworkedDevice)
            {
                var client = (IClientNetworkedDevice)device;
                if (client.IsGuest)
                    markup = $"[fuschia]{client.Name}[/] ({client.IpAddress})";
                else
                    markup = $"[purple]{client.Name}[/] ({client.IpAddress})";
            }
            else
                markup = device.Name;

            return markup;
        }
    }
}
