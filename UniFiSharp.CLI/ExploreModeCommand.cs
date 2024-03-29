﻿using Spectre.Console;
using Spectre.Console.Cli;
using UniFiSharp.Json.Attributes;
using UniFiSharp.Orchestration;
using UniFiSharp.Orchestration.Devices;

namespace UniFiSharp.CLI
{
    internal class NamedSelectionElement
    {
        public string? Header { get; set; }
        public object? Data { get; set; }

        public static NamedSelectionElement Create<T>(string header, T data) => new()
        {
            Header = header,
            Data = data
        };

        public override string ToString() => Header ?? string.Empty;
    }

    public class ExploreModeCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        private UniFiOrchestrator Orchestrator { get; set; } = new UniFiOrchestrator(null);
        private INetworkedDevice? CurrentDevice { get; set; }
        private string WhereAmI
        {
            get
            {
                if (Orchestrator == null || CurrentDevice == null) return string.Empty;
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
                    case "info": DrawObjectTable(CurrentDevice, args.Length > 1 ? 5 - (Levels)Int32.Parse(args[1]) : Levels.Basic); break;
                    case "clear": AnsiConsole.Clear(); break;
                    case "refresh": await Orchestrator.Refresh();  break; // TODO: Re-locate device/client by MAC addr and update CurrentDevice

                    case "locate": RunOnInfra(i => i.Locate()); break;
                    case "adopt": RunOnInfra(i => i.Adopt()); break;
                    case "forget": RunOnInfra(i => i.Forget()); break;
                    case "set-name": RunOnInfra(i => i.SetName(args[1])); break;
                    case "activity": 
                        await ShowClientChart<IClientNetworkedDevice>(
                        "[green bold underline]Client Activity (KBps)[/] - Refreshes every 5s - Press <ESC> to stop",
                        n => n.NameOrMac,
                        v => (int)Math.Floor(v.ActivityKbps),
                        g => g > 1); break;
                    case "rssi":
                        await ShowClientChart<WirelessClientNetworkedDevice>(
                        "[cyan bold underline]Wi-Fi Client RSSI[/] - Refreshes every 5s - Press <ESC> to stop",
                        n => n.NameOrMac,
                        v => v.rssi); break;
                    case "signal":
                        await ShowClientChart<WirelessClientNetworkedDevice>(
                        "[cyan bold underline]Wi-Fi Client Signal[/] - Refreshes every 5s - Press <ESC> to stop",
                        n => n.NameOrMac,
                        v => 100 - Math.Abs(v.signal)); break;

                    case "force-reconnect": RunOnClient(c => c.ForceReconnect()); break;

                    case "help":
                        AnsiConsole.WriteLine();
                        AnsiConsole.Write(new Rule("[blue]Topology Navigation[/]"));
                        AnsiConsole.MarkupLine("[green]cd[/]\t\tChanges to a device or client");
                        AnsiConsole.MarkupLine("[green]ls[/]\t\tLists child devices and clients on this device");
                        AnsiConsole.MarkupLine("[green]info[/] [cyan]{1-4}\tDump all information on this device; optionally specify a detail level, higher is more detail");
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
            if (CurrentDevice is IClientNetworkedDevice device)
                func(device).Wait();
            else
                Warn("Devices cannot run this command");
        }

        private void RunOnInfra(Func<IInfrastructureNetworkedDevice, Task> func)
        {
            if (CurrentDevice is IInfrastructureNetworkedDevice device)
                func(device).Wait();
            else
                Warn("Clients cannot run this command");
        }

        private async Task ShowClientChart<TDevice>(string title, Func<TDevice, string> nameFunc, Func<TDevice, int> valueFunc, Func<int, bool>? valueGateFunc = null, int refreshTime = 5000)
            where TDevice : IClientNetworkedDevice
        {
            if (valueGateFunc == null) valueGateFunc = (i) => true;
            if (CurrentDevice is IInfrastructureNetworkedDevice device)
            {
                var thisDeviceMacAddress = device.mac;
                await ConsoleDrawHelper.ShowDynamicBarChart(title, nameFunc, valueFunc, valueGateFunc, refreshTime, async () =>
                {
                    await Orchestrator.Refresh();
                    return Orchestrator.InfrastructureDevices
                                       .First(d => d.mac == thisDeviceMacAddress)
                                       .ClientsRecursive
                                       .OfType<TDevice>();
                });
            }
        }

        private void ListDevicesCommand()
        {
            if (CurrentDevice is IInfrastructureNetworkedDevice dev)
            {
                foreach (var item in dev.InfrastructureDevices)
                {
                    var path = Orchestrator.GeneratePathTo(item).Reverse().Last();
                    AnsiConsole.MarkupLine("[green]Port " + path.Item2 + "[/]\t" + GetDeviceMarkup(item));
                }
                foreach (var item in dev.Clients)
                {
                    var path = Orchestrator.GeneratePathTo(item).Reverse().Last();
                    if (path.Item2 == 0) AnsiConsole.MarkupLine("[green]WiFi[/]\t" + GetDeviceMarkup(item));
                    else AnsiConsole.MarkupLine("[green]Port " + path.Item2 + "[/]\t" + GetDeviceMarkup(item));
                }
            }
        }

        private void ChangeDeviceCommand(string[] args)
        {
            if (args.Length == 1)
            {
                if (CurrentDevice is IInfrastructureNetworkedDevice dev)
                {
                    var result = AnsiConsole.Prompt(
                        new SelectionPrompt<NamedSelectionElement>()
                              .AddChoices(dev.InfrastructureDevices.Select(d =>
                              {
                                  var path = Orchestrator.GeneratePathTo(d).Reverse().Last();
                                  return NamedSelectionElement.Create("[green]Port " + path.Item2 + "[/]\t[blue]" + d.NameOrMac + "[/]", d);
                              }))
                              .AddChoices(dev.Clients.Select(c =>
                              {
                                  var path = Orchestrator.GeneratePathTo(c).Reverse().Last();
                                  return NamedSelectionElement.Create("[green]Port " + path.Item2 + "[/]\t[purple]" + c.NameOrMac + "[/]", c);
                              })));
                    if (result != null)
                    {
                        CurrentDevice = result.Data as INetworkedDevice;
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
                if (CurrentDevice is IInfrastructureNetworkedDevice dev)
                {
                    INetworkedDevice? target = dev.InfrastructureDevices.FirstOrDefault(d => d.name == args[1] || d.mac.EndsWith(args[1]));
                    if (target == null)
                        target = dev.Clients.FirstOrDefault(d => d.name == args[1] || d.mac.EndsWith(args[1]) || d.ip == args[1]);

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

            if (device is IInfrastructureNetworkedDevice infra)
            {
                var mac = infra.mac[^5..];
                if (infra is AccessPointInfrastructureNetworkedDevice)
                    markup = $"[blue]{infra.NameOrMac}[/] ({mac})";
                else if (infra is SwitchInfrastructureNetworkedDevice)
                    markup = $"[green]{infra.NameOrMac}[/] ({mac})";
                else if (infra is RouterInfrastructureNetworkedDevice)
                    markup = $"[yellow]{infra.NameOrMac}[/] ({mac})";
            }
            else if (device is IClientNetworkedDevice client)
            {
                if (client.is_guest)
                    markup = $"[fuschia]{client.NameOrMac}[/] ({client.ip})";
                else
                    markup = $"[purple]{client.NameOrMac}[/] ({client.ip})";
            }
            else
                markup = "?";

            return markup;
        }
    }
}
