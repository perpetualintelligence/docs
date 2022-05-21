using DotnetStyleCli.Runners;
using PerpetualIntelligence.Cli.Commands;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Handlers;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;
using System.ComponentModel.DataAnnotations;

namespace DotnetStyleCli
{
    /// <summary>
    /// The sample <c>dotnet cli</c> command registry. This class registers some of sample commands to show how
    /// <c>dotnet cli</c> style console terminals can be build using <c>pi-cli</c> framework.
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
            // app authors need to make sure the UnicodeTextHandler used here and in AddTextHandler DI service are the same.
            UnicodeTextHandler unicodeTextHandler = new();

            // dotnet
            {
                CommandDescriptor dt = new(
                    "dt-cli-dotnet",
                    "dotnet",
                    "dotnet",
                    "Sample description for dotnet driver.",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                        new ArgumentDescriptor("info", nameof(Boolean), false, "Prints out detailed information about a .NET installation and the machine environment, such as the current operating system, and commit SHA of the .NET version."),
                        new ArgumentDescriptor("version", nameof(Boolean), false, "Prints out the version of the .NET SDK used by dotnet commands. Includes the effects of any global.json"),
                        new ArgumentDescriptor("list-runtimes", nameof(Boolean), false, "Prints out a list of the installed .NET runtimes. An x86 version of the SDK lists only x86 runtimes, and an x64 version of the SDK lists only x64 runtimes."),
                        new ArgumentDescriptor("list-sdks", nameof(Boolean), false, "Prints out a list of the installed .NET SDKs."),
                        new ArgumentDescriptor("help", nameof(Boolean), false, "Prints out a list of available commands.") {Alias = "h"}
                    })
                );
                builder.AddDescriptor<DotNetRunner, CommandChecker>(dt);
            };

            // dotnet nuget grouped commands
            {
                // dotnet nuget
                CommandDescriptor nuget = new(
                    "dt-cli-nuget",
                    "nuget",
                    "dotnet nuget",
                    "Sample description for dotnet nuget command"
                    );
                builder.AddDescriptor<DotNetNugetRunner, CommandChecker>(nuget);

                // dotnet nuget push
                CommandDescriptor nugetPush = new(
                    "dt-cli-nuget-push",
                    "push",
                    "dotnet nuget push",
                    "Sample description for dotnet nuget push command",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                        new ArgumentDescriptor("root", DataType.Text, false, "Specifies the file path to the package to be pushed."),
                        new ArgumentDescriptor("disable-buffering", nameof(Boolean), false, "Disables buffering when pushing to an HTTP(S) server to reduce memory usage.") {Alias = "d"},
                        new ArgumentDescriptor("force-english-output", nameof(Boolean), false, "Forces the application to run using an invariant, English-based culture."),
                        new ArgumentDescriptor("interactive", nameof(Boolean), false, "Allows the command to stop and wait for user input or action. For example, to complete authentication. Available since .NET Core 3.0 SDK."),
                        new ArgumentDescriptor("api-key", DataType.Text, false, "The API key for the server.") {Alias = "k"},
                        new ArgumentDescriptor("help", nameof(Boolean), false, "Prints out a description of how to use the command.") {Alias = "h"}
                    }),
                    defaultArgument: "root"
                );
                builder.AddDescriptor<DotNetNugetPushRunner, CommandChecker>(nugetPush);
            };

            return builder;
        }
    }
}
