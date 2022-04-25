using Spectre.Console;
using Spectre.Console.Cli;
using System.Text.Json;

namespace UniFiSharp.CLI
{
    public abstract class UniFiSharpCommand<T> : AsyncCommand<T> where T : UniFiSharpSettings
    {
        internal async Task<int> RunWithOutput<TOutput>(UniFiSharpSettings settings, Func<UniFiApi, Task<TOutput>> action)
        {
            try
            {
                if (settings.DryRun)
                {
                    Warn("Dry Run, Not Running");
                }
                else
                {
                    var output = await action(settings.GetUniFiSharp());
                    if (settings.UseJson)
                        AnsiConsole.WriteLine(JsonSerializer.Serialize(output));
                }
                return 0;
            }
            catch (Exception ex)
            {
                Error(ex);
                return -1;
            }
        }

        internal async Task<int> Run(UniFiSharpSettings settings, Func<UniFiApi, Task> action)
        {
            try
            {
                if (settings.DryRun)
                {
                    Warn("Dry Run, Not Running");
                }
                else
                {
                    await action(settings.GetUniFiSharp());
                }
                return 0;
            }
            catch (Exception ex)
            {
                Error(ex);
                return -1;
            }
        }

        internal void Log(string msg)
        {
            AnsiConsole.WriteLine("[*] " + msg);
        }

        internal void Warn(string msg)
        {
            AnsiConsole.WriteLine("[?] " + msg);
        }

        internal void Error(string msg)
        {
            AnsiConsole.WriteLine("[!] " + msg);
        }

        internal void Error(Exception ex)
        {
            AnsiConsole.WriteException(ex);
        }
    }
}