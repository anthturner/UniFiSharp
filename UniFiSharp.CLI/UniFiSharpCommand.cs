using Spectre.Console;
using Spectre.Console.Cli;
using System.Text.Json;

namespace UniFiSharp.CLI
{
    public class OutputMapping<T>
    {
        public string Header { get; set; } = "Unknown";
        public Func<T, object> GetValue { get; set; } = (a) => string.Empty;
        public static OutputMapping<T> Create(string header, Func<T, object> map)
        {
            return new OutputMapping<T>()
            {
                Header = header,
                GetValue = map
            };
        }
    }

    public abstract class UniFiSharpCommand<T> : AsyncCommand<T> where T : UniFiSharpSettings
    {
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
        internal Task<int> RunWithOutput<TOutput>(UniFiSharpSettings settings, Func<UniFiApi, Task<TOutput>> action, params OutputMapping<TOutput>[] headers) =>
            RunWithOutput(settings, action, (output) => CreateTable(headers, output));

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
        internal Task<int> RunWithOutputs<TOutput>(UniFiSharpSettings settings, Func<UniFiApi, Task<IEnumerable<TOutput>>> action, params OutputMapping<TOutput>[] headers) =>
            RunWithOutputs(settings, action, (outputs) => CreateMultiRowTable(headers, outputs));

        // ---

        internal void CreatePropertyTable<TOutput>(TOutput output)
        {
            var tbl = new Table()
                       .AddColumn("Property")
                       .AddColumn("Value");

            var properties = output.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach (var property in properties)
                // todo: get from decorator?
                tbl.AddRow(property.Name, Markup.Escape($"{property.GetValue(output)}"));

            AnsiConsole.Write(tbl);
        }

        internal void CreateTable<TOutput>(OutputMapping<TOutput>[] properties, TOutput output)
        {
            var tbl = new Table()
                       .AddColumn("Property")
                       .AddColumn("Value");

            foreach (var header in properties)
                tbl.AddRow(header.Header, $"{header.GetValue(output)}");

            AnsiConsole.Write(tbl);
        }

        internal void CreateMultiRowTable<TOutput>(OutputMapping<TOutput>[] headers, IEnumerable<TOutput> outputs)
        {
            var tbl = new Table().AddColumns(headers.Select(h => h.Header).ToArray());
            foreach (var row in outputs)
                tbl.AddRow(headers.Select(h => $"{h.GetValue(row)}").ToArray());

            AnsiConsole.Write(tbl);
        }

        internal void WriteHeader(string header) =>
            AnsiConsole.MarkupLine($"[green]{header}[/]");

        // ---

        internal void Log(string msg)
        {
            if (!Program.Quiet)
                AnsiConsole.MarkupLine($"[blue][[*]][/]  {msg}");
        }

        internal void Warn(string msg)
        {
            if (!Program.Quiet)
                AnsiConsole.MarkupLine($"[yellow][[?]][/]  {msg}");
        }

        internal void Error(string msg)
        {
            if (!Program.Quiet)
                AnsiConsole.MarkupLine($"[red][[!]][/]  {msg}");
        }

        internal void Error(Exception ex)
        {
            AnsiConsole.WriteException(ex);
        }
    }
}