using Spectre.Console;
using Spectre.Console.Cli;

namespace UniFiSharp.CLI
{
    public class InteractiveModeCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log($"Running in interactive mode. Type '--help' or '-h' for help. Type 'quit' or 'exit' to end.\n");

            while (true)
            {
                var promptText = AnsiConsole.Prompt(new TextPrompt<string>("[cyan]UniFi>[/] "));
                if (promptText == "quit" || promptText == "exit")
                    return 0;

                // parse and inject the auth info into each subsequent command
                var args = ParseMultiSpacedArguments(promptText);
                var newArgs = new List<string>();
                newArgs.Add(args[0]);
                newArgs.Add(settings.Uri);
                newArgs.Add(settings.Username);
                newArgs.Add(settings.Password);
                newArgs.AddRange(args.Skip(1));

                try
                {
                    await Program.App.RunAsync(newArgs.ToArray()); ;
                }
                catch (CommandParseException ex)
                {
                    Error(ex.Message);
                }
                catch (CommandRuntimeException ex)
                {
                    Error(ex.Message);
                }
                catch (Exception ex)
                {
                    Error(ex);
                }

                AnsiConsole.WriteLine();
                AnsiConsole.Write(new Rule().RuleStyle("blue dim"));
                AnsiConsole.WriteLine();
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

            return (new string(parmChars)).Split('\n');
        }
    }
}
