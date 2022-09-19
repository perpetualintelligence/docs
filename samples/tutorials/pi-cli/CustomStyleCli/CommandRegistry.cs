using CustomStyleCli.Runners.Custom;
using CustomStyleCli.Runners.Custom.Test;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;
using System.ComponentModel.DataAnnotations;

namespace CustomStyleCli
{
    /// <summary>
    /// The sample <c>custom</c> CLI command registry. This class registers some sample commands to show how .NET style
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
            // Custom root command
            builder.DefineCommand<CommandChecker, CustomRunner>("ct-cli-root", "custom", "custom", "Sample description for custom root command.", isGroup: true, isRoot: true).Add();

            // Custom grouped command
            builder.DefineCommand<CommandChecker, CustomTestRunner>("ct-cli-group", "test", "custom test", "Custom test grouped command", isGroup: true)
                   .DefineArgument("arg1", nameof(Boolean), "Arg1 description").Add()
                   .DefineArgument("arg2", DataType.Text, "Arg2 description").Add()
                   .DefineArgument("arg3", DataType.Date, "Arg3 description").Add()
                   .DefineArgument("arg4", nameof(Int32), "Arg4 description").Add()
                   .DefineArgument("arg5", nameof(Double), "Arg5 description", alias: "h").Add()
                   .Add();

            // Custom random sub-command
            builder.DefineCommand<CommandChecker, CustomTestRandomRunner>("ct-cli-random", "random", "custom test random", "Custom test random description").Add();

            // Custom guid sub-command
            builder.DefineCommand<CommandChecker, CustomTestRandomRunner>("ct-cli-guid", "guid", "custom test guid", "Custom test guid description").Add();

            // Exit sub-command
            builder.DefineCommand<CommandChecker, ExitRunner>("ct-cli-exit", "exit", "exit", "Exits the CLI terminal.").Add();

            // Clear screen sub-command
            builder.DefineCommand<CommandChecker, ClearScreenRunner>("ct-cli-cls", "cls", "cls", "Clears the CLI terminal screen.").Add();

            // OS sub-command
            builder.DefineCommand<CommandChecker, RunRunner>("ct-cli-run", "run", "run", "Runs an OS command.").Add();

            // Licensing details sub-command
            builder.DefineCommand<CommandChecker, LicInfoRunner>("ct-cli-lic", "lic", "lic info", "Displays the licensing information.").Add();

            return builder;
        }
    }
}
