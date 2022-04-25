using Spectre.Console.Cli;
using System.ComponentModel;

namespace UniFiSharp.CLI.Commands
{
    public class MediaFileSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<MediaFileId>")]
        [Description("Media File ID")]
        public string MediaFileId { get; set; } = string.Empty;
    }

    public class MediaFileCreateSettings : UniFiSharpSettings
    {
        [CommandArgument(3, "<Name>")]
        [Description("Media File Name")]
        public string MediaName { get; set; } = string.Empty;

        [CommandArgument(4, "<SourceFile>")]
        [Description("Source Data for Media File")]
        public string SourceFile { get; set; } = string.Empty;

        [CommandOption("--filename|-f")]
        [Description("Internal Filename")]
        public string InternalFileName { get; set; } = string.Empty;

        [CommandOption("--contenttype|-c")]
        [Description("Media Content-Type")]
        [DefaultValue("audio/ogg")]
        public string ContentType { get; set; } = "audio/ogg";
    }

    // ---

    public class MediaFileCreateCommand : UniFiSharpCommand<MediaFileCreateSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, MediaFileCreateSettings settings)
        {
            Log($"Creating Media File '{settings.MediaName}' from {settings.SourceFile}");
            var fileData = File.ReadAllBytes(settings.SourceFile);
            return await Run(settings, u => u.MediaFileCreate(settings.MediaName, fileData, settings.InternalFileName, settings.ContentType));
        }
    }

    public class MediaFileListCommand : UniFiSharpCommand<UniFiSharpSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, UniFiSharpSettings settings)
        {
            Log("Listing Media Files");
            return await RunWithOutput(settings, u => u.MediaFileList());
        }
    }

    public class MediaFileGetCommand : UniFiSharpCommand<MediaFileSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, MediaFileSettings settings)
        {
            Log($"Getting Media File '{settings.MediaFileId}'");
            return await RunWithOutput(settings, u => u.MediaFileGet(settings.MediaFileId));
        }
    }

    public class MediaFileDeleteCommand : UniFiSharpCommand<MediaFileSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, MediaFileSettings settings)
        {
            Log($"Deleting Media File '{settings.MediaFileId}'");
            return await Run(settings, u => u.MediaFileDelete(settings.MediaFileId));
        }
    }
}
