using DotnetStyleCli.Runners;
using DotnetStyleCli.Runners.Nuget;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;
using System.ComponentModel.DataAnnotations;

namespace DotnetStyleCli
{
    /// <summary>
    /// The sample <c>dotnet</c> CLI command registry. This class registers some sample commands to show how .NET style
    /// console terminals can be build using <c>pi-cli</c> framework.
    /// </summary>
    public static class CommandRegistry
    {
        /// <summary>
        /// Adds the cli commands to the service collection.
        /// </summary>
        /// <param name="builder">The <see cref="ICliBuilder"/> builder.</param>
        /// <returns>The <see cref="ICliBuilder"/> instance.</returns>
        public static ICliBuilder AddCommandDescriptors(this ICliBuilder builder)
        {
            // sample dotnet
            builder.DefineCommand<CommandChecker, DotNetRunner>("dt-cli-dotnet", "dotnet", "dotnet", "Sample description for dotnet driver.", isGroup: true, isRoot: true)
                   .DefineArgument("info", nameof(Boolean), "Prints out detailed information about a .NET installation and the machine environment, such as the current operating system, and commit SHA of the .NET version.").Add()
                   .DefineArgument("version", nameof(Boolean), "Prints out the version of the .NET SDK used by dotnet commands. Includes the effects of any global.json").Add()
                   .DefineArgument("list-runtimes", nameof(Boolean), "Prints out a list of the installed .NET runtimes. An x86 version of the SDK lists only x86 runtimes, and an x64 version of the SDK lists only x64 runtimes.").Add()
                   .DefineArgument("list-sdks", nameof(Boolean), "Prints out a list of the installed .NET SDKs.").Add()
                   .DefineArgument("help", nameof(Boolean), "Prints out a list of available commands.", alias: "h").Add()
                   .Add();

            // sample dotnet nuget grouped commands
            builder.DefineCommand<CommandChecker, DotNetNugetRunner>("dt-cli-nuget", "nuget", "dotnet nuget", "Sample description for dotnet nuget command", isGroup: true).Add();

            // sample dotnet nuget push
            builder.DefineCommand<CommandChecker, DotNetNugetPushRunner>("dt-cli-nuget-push", "push", "dotnet nuget push", "Sample description for dotnet nuget push command")
                   .DefineArgument("root", DataType.Text, "Specifies the file path to the package to be pushed.").Add()
                   .DefineArgument("disable-buffering", nameof(Boolean), "Disables buffering when pushing to an HTTP(S) server to reduce memory usage.", alias: "d").Add()
                   .DefineArgument("force-english-output", nameof(Boolean), "Forces the application to run using an invariant, English-based culture.").Add()
                   .DefineArgument("interactive", nameof(Boolean), "Allows the command to stop and wait for user input or action. For example, to complete authentication. Available since .NET Core 3.0 SDK.").Add()
                   .DefineArgument("api-key", DataType.Text, "The API key for the server.", alias: "k").Add()
                   .DefineArgument("help", nameof(Boolean), "Prints out a description of how to use the command.", alias: "h").Add()
                   .Add();

            // Exit sub-command
            builder.DefineCommand<CommandChecker, ExitRunner>("dt-cli-exit", "exit", "exit", "Exits the CLI terminal.").Add();

            // Clear screen sub-command
            builder.DefineCommand<CommandChecker, ClearScreenRunner>("dt-cli-cls", "cls", "cls", "Clears the CLI terminal screen.").Add();

            // OS sub-command
            builder.DefineCommand<CommandChecker, RunRunner>("dt-cli-run", "run", "run", "Runs an OS command.").Add();

            // Licensing details sub-command
            builder.DefineCommand<CommandChecker, LicInfoRunner>("dt-cli-lic", "lic", "lic info", "Displays the licensing information.").Add();

            return builder;
        }
    }
}
