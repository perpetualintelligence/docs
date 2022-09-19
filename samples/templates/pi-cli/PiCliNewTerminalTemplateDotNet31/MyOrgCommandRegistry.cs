using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;
using PiCliNewTerminalTemplateDotNet31.Runners.MyOrg;
using PiCliNewTerminalTemplateDotNet31.Runners.MyOrg.Gen;
using PiCliNewTerminalTemplateDotNet31.Runners.MyOrg.Gen.Id;
using System;
using System.ComponentModel.DataAnnotations;

namespace PiCliNewTerminalTemplateDotNet31
{
    /// <summary>
    /// The sample command registry. The template contains this file to register all the commands and argument
    /// descriptors. This class can be easily unit tested natively with MSTest, xUnit, or other test frameworks. You can
    /// register a custom command checker and a command runner type for each command.
    /// </summary>
    public static class MyOrgCommandRegistry
    {
        /// <summary>
        /// Adds the cli commands to the service collection.
        /// </summary>
        /// <param name="builder">The <see cref="ICliBuilder"/> builder.</param>
        /// <returns>The <see cref="ICliBuilder"/> instance.</returns>
        public static ICliBuilder AddCommandDescriptors(this ICliBuilder builder)
        {
            // Root command (myorg)
            builder.DefineCommand<CommandChecker, MyOrgRunner>("myorg", "myorg", "myorg", "Sample myorg root command").
                    DefineArgument("version", nameof(Boolean), "Show myorg version", alias: "v", required: false).Add().
                    Add();

            // Grouped command (myorg gen)
            builder.DefineCommand<CommandChecker, MyOrgGenRunner>("myorg-gen", "gen", "myorg gen", "Sample generator grouped command.").
                    Add();

            // Subcommand (myorg gen id)
            builder.DefineCommand<CommandChecker, MyOrgGenIdRunner>("myorg-gen-id", "id", "myorg gen id", "Sample id generator sub command.").
                    DefineArgument("type", DataType.Text, "Id type", alias: "t", required: true).Add().
                    Add();

            // Exit
            builder.DefineCommand<CommandChecker, ExitRunner>("myorg-cli-exit", "exit", "exit", "Exits the CLI terminal.").Add();

            // Clear screen
            builder.DefineCommand<CommandChecker, ClearScreenRunner>("myorg-cli-cls", "cls", "cls", "Clears the CLI terminal screen.").Add();

            // Show licensing details.
            builder.DefineCommand<CommandChecker, LicInfoRunner>("myorg-cli-lic", "lic", "lic info", "Displays the licensing information.").Add();

            return builder;
        }
    }
}
