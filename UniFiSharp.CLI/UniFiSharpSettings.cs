using Spectre.Console.Cli;
using System.ComponentModel;
using UniFiSharp;

public class UniFiSharpSettings : CommandSettings
{
    [CommandArgument(0, "[URI]")]
    [Description("Controller URI")]
    public string Uri { get; set; } = string.Empty;

    [CommandArgument(1, "[Username]")]
    [Description("Controller Username")]
    public string Username { get; set; } = string.Empty;

    [CommandArgument(2, "[Password]")]
    [Description("Controller Password")]
    public string Password { get; set; } = string.Empty;

    [CommandOption("-s|--site <SITE>")]
    [Description("Site name")]
    [DefaultValue("default")]
    public string Site { get; set; } = "default";

    [CommandOption("--json")]
    [Description("If true, output will be in JSON")]
    public bool UseJson { get; set; }

    [CommandOption("--dryrun")]
    [Description("If true, the commands will not be executed")]
    public bool DryRun { get; set; }

    public UniFiApi GetUniFiSharp() =>
        new UniFiApi(
            new Uri(Uri),
            Username,
            Password,
            Site, true, true);
}
