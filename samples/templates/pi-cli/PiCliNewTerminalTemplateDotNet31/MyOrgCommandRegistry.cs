using PerpetualIntelligence.Cli.Commands;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Handlers;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;
using PiCliNewTerminalTemplateDotNet31.Runners.MyOrg;
using PiCliNewTerminalTemplateDotNet31.Runners.MyOrg.Gen;
using PiCliNewTerminalTemplateDotNet31.Runners.MyOrg.Gen.Id;
using System;

namespace PiCliNewTerminalTemplateDotNet31
{
    /// <summary>
    /// The sample command registry. The template contains this file to register all the commands
    /// and argument descriptors. This class can be easily unit tested natively with MSTest, xUnit, or other test
    /// frameworks. You can register a custom command checker and a command runner type for each command.
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
            // TODO:
            // - For now, app authors need to make sure the UnicodeTextHandler used here and in AddTextHandler DI
            // service are the same.
            UnicodeTextHandler unicodeTextHandler = new UnicodeTextHandler();

            // Root command (myorg)
            {
                CommandDescriptor myorg = new CommandDescriptor(
                    "myorg-root",
                    "myorg",
                    "myorg",
                    "Sample myorg root command.",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                        new ArgumentDescriptor("version", nameof(Boolean), false, "Show myorg version") { Alias = "v" }
                    })
                );
                builder.AddDescriptor<MyOrgRunner, CommandChecker>(myorg);
            };

            // Grouped command (myorg gen)
            {
                // myorg gen group
                CommandDescriptor myOrgGen = new CommandDescriptor(
                    "myorg-gen-id",
                    "gen",
                    "myorg gen",
                    "Sample generator grouped command."
                );
                builder.AddDescriptor<MyOrgGenRunner, CommandChecker>(myOrgGen);

                // myorg gen id subcommand
                CommandDescriptor myOrgGenId = new CommandDescriptor(
                    "myorg-gen",
                    "id",
                    "myorg gen id",
                    "Sample id generator sub command.",
                    new ArgumentDescriptors(unicodeTextHandler, new[] {
                        new ArgumentDescriptor("type", System.ComponentModel.DataAnnotations.DataType.Text, true, "Id type") { Alias = "t" }
                    })
                );
                builder.AddDescriptor<MyOrgGenIdRunner, CommandChecker>(myOrgGenId);
            };

            // OOTB command runner
            {
                // Exit
                CommandDescriptor exit = new CommandDescriptor("myorg-cli-exit", "exit", "exit", "Exits the CLI terminal.");
                builder.AddDescriptor<ExitRunner, CommandChecker>(exit);

                // Clear screen
                CommandDescriptor cls = new CommandDescriptor("myorg-cli-cls", "cls", "cls", "Clears the CLI terminal screen.");
                builder.AddDescriptor<ClearScreenRunner, CommandChecker>(cls);

                // Show licensing information
                {
                    // Show licensing details.
                    CommandDescriptor licInfo = new CommandDescriptor("myorg-cli-lic", "lic", "lic info", "Displays the licensing information.");
                    builder.AddDescriptor<LicInfoRunner, CommandChecker>(licInfo);
                }
            }

            return builder;
        }
    }
}
