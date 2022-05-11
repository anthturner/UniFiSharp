using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Rendering;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using UniFiSharp.Json;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.CLI
{
    public abstract class UniFiSharpCommand<T> : AsyncCommand<T> where T : UniFiSharpSettings
    {
        private const string LOG_FMT = "[blue][[*]][/]  {0}";
        private const string WARN_FMT = "[yellow][[%]][/]  {0}";
        private const string ERROR_FMT = "[red][[!]][/]  {0}";

        internal Task<int> Run(UniFiSharpSettings settings, Func<UniFiApi, Task> action) =>
            TryRunning(settings, () => action(settings.GetUniFiSharp()));

        private async Task<int> TryRunning(UniFiSharpSettings settings, Func<Task> a)
        {
            if (settings.Password == "<>" || string.IsNullOrEmpty(settings.Password))
            {
                var prompt = AnsiConsole.Prompt<string>(
                    new TextPrompt<string>("Enter Password").Secret());
                settings.Password = prompt;
            }
            if (settings.DryRun)
            {
                Warn("Dry Run, Not Executing!");
                return 0;
            }
            else
            {
                try
                {
                    if (!Program.Quiet)
                    {
                        await AnsiConsole.Status()
                            .Spinner(Spinner.Known.Aesthetic)
                            .StartAsync("Executing", async (c) => await a());
                    }
                    else await a();
                    return 0;
                }
                catch (Exception ex)
                {
                    Error(ex);
                }
            }

            return -1;
        }

        // ---

        internal Task<int> RunWithOutput<TOutput>(UniFiSharpSettings settings, Func<UniFiApi, Task<TOutput>> action, Action<TOutput> generateOutput)
        {
            return TryRunning(settings, async () =>
            {
                var output = await action(settings.GetUniFiSharp());
                if (settings.UseJson)
                    AnsiConsole.WriteLine(JsonSerializer.Serialize(output));
                generateOutput(output);
            });
        }
        internal Task<int> RunWithOutput<TOutput>(UniFiSharpSettings settings, Func<UniFiApi, Task<TOutput>> action) =>
            RunWithOutput(settings, action, (output) => DrawObjectTable(output, Levels.Basic));

        // ---

        internal Task<int> RunWithOutputs<TOutput>(UniFiSharpSettings settings, Func<UniFiApi, Task<IEnumerable<TOutput>>> action, Action<IEnumerable<TOutput>> generateOutputs)
        {
            return TryRunning(settings, async () =>
            {
                var outputs = await action(settings.GetUniFiSharp());
                if (settings.UseJson)
                    AnsiConsole.WriteLine(JsonSerializer.Serialize(outputs));
                else if (outputs.Any())
                    generateOutputs(outputs);
            });
        }
        internal Task<int> RunWithOutputs<TOutput>(UniFiSharpSettings settings, Func<UniFiApi, Task<IEnumerable<TOutput>>> action) =>
            RunWithOutputs(settings, action, (outputs) => DrawMultiRowTable(outputs, Levels.Basic));

        // ---

        internal void DrawObjectTable<TObject>(TObject obj, Levels level) => AnsiConsole.Write(new TableGenerator(level).GenerateSingleObjectTable(obj));
        internal void DrawMultiRowTable<TOutput>(IEnumerable<TOutput> outputs, Levels level) => AnsiConsole.Write(new TableGenerator(level).GenerateMultipleObjectListTable(outputs));

        internal void WriteHeader(string header) =>
            AnsiConsole.MarkupLine($"[green]{header}[/]");

        // ---

        internal void Log(string msg) => WriteConsole(LOG_FMT, msg);
        internal void Warn(string msg) => WriteConsole(WARN_FMT, msg);
        internal void Error(string msg) => WriteConsole(ERROR_FMT, msg);
        internal void Error(Exception ex) => AnsiConsole.WriteException(ex);

        private void WriteConsole(string format, string msg)
        {
            if (!Program.Quiet) AnsiConsole.MarkupLine(format, msg);
        }
    }
}