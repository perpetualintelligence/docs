using PerpetualIntelligence.Terminal.Commands.Checkers;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Extensions;
using TerminalTemplate.Net7.Runners.MyOrg;
using TerminalTemplate.Net7.Runners.MyOrg.Gen;
using TerminalTemplate.Net7.Runners.MyOrg.Gen.Id;
using PerpetualIntelligence.Terminal.Hosting;
using PerpetualIntelligence.Terminal.Commands;

namespace TerminalTemplate.Net7
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
        /// <param name="builder">The <see cref="ITerminalBuilder"/> builder.</param>
        /// <returns>The <see cref="ITerminalBuilder"/> instance.</returns>
        public static ITerminalBuilder AddCommandDescriptors(this ITerminalBuilder builder)
        {
            // Root command (myorg)
            builder.DefineCommand<CommandChecker, MyOrgRunner>("myorg", "myorg name", "Sample myorg root command", CommandType.Root, CommandFlags.None).
                    DefineOption("version", nameof(Boolean), "Show myorg version", OptionFlags.None, alias: "v").Add().
                    Add();

            // Grouped command (myorg gen)
            builder.DefineCommand<CommandChecker, MyOrgGenRunner>("gen", "gen name", "Sample generator grouped command.", CommandType.Group, CommandFlags.None).
                    Add();

            // Subcommand (myorg gen id)
            builder.DefineCommand<CommandChecker, MyOrgGenIdRunner>("id", "id name", "Sample id generator sub command.", CommandType.SubCommand, CommandFlags.None).
                    DefineOption("type", nameof(String), "Id type", OptionFlags.Required, alias: "t").Add().
                    Add();

            // Exit
            builder.DefineCommand<CommandChecker, ExitRunner>("exit", "exit name", "Exits the CLI terminal.", CommandType.SubCommand, CommandFlags.None).Add();

            // Clear screen
            builder.DefineCommand<CommandChecker, ClearScreenRunner>("cls", "cls name", "Clears the CLI terminal screen.", CommandType.SubCommand, CommandFlags.None).Add();

            // Show licensing details.
            builder.DefineCommand<CommandChecker, LicenseInfoRunner>("lic", "lic name", "Displays the licensing information.", CommandType.SubCommand, CommandFlags.None).Add();

            return builder;
        }
    }
}
