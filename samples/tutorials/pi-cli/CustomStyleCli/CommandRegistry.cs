using CustomStyleCli.Runners.Custom.Test;
using PerpetualIntelligence.Cli.Commands;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Handlers;
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
            // app authors need to make sure the UnicodeTextHandler used here and in AddTextHandler DI service are the same.
            UnicodeTextHandler unicodeTextHandler = new();

            // custom root command
            {
                CommandDescriptor ct = new(
                    "aab63b52-ec5c-4e19-8c62-b9514351deca",
                    "custom",
                    "custom",
                    "Sample description for custom root command."
                );
                builder.AddDescriptor<CustomTestRunner, CommandChecker>(ct, isRoot: true, isGroup: true);
            };

            // custom test grouped command
            {
                // custom test
                CommandDescriptor customTest = new(
                    "custom-test-id",
                    "test",
                    "custom test",
                    "Custom test grouped command",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                        new ArgumentDescriptor("arg1", nameof(Boolean), false, "Arg1 description"),
                        new ArgumentDescriptor("arg2", DataType.Text, false, "Arg2 description"),
                        new ArgumentDescriptor("arg3", DataType.Date, false, "Arg3 description"),
                        new ArgumentDescriptor("arg4", nameof(Int32), false, "Arg4 description"),
                        new ArgumentDescriptor("arg5", nameof(Double), false, "Arg5 description") {Alias = "h"}
                    })
                    );
                builder.AddDescriptor<CustomTestRunner, CommandChecker>(customTest, isGroup: true);

                // test random
                CommandDescriptor randomRunner = new(
                    "custom-test-random",
                    "random",
                    "custom test random",
                    "Custom test random description"
                );
                builder.AddDescriptor<CustomTestRandomRunner, CommandChecker>(randomRunner);

                // test guid
                CommandDescriptor guidRunner = new(
                    "custom-test-guid",
                    "guid",
                    "custom test guid",
                    "Custom test guid description"
                );
                builder.AddDescriptor<CustomTestGuidRunner, CommandChecker>(guidRunner);
            };

            // Exit
            CommandDescriptor exit = new("ct-cli-exit", "exit", "exit", "Exits the CLI terminal.");
            builder.AddDescriptor<ExitRunner, CommandChecker>(exit);

            // Clear screen
            CommandDescriptor cls = new("ct-cli-cls", "cls", "cls", "Clears the CLI terminal screen.");
            builder.AddDescriptor<ClearScreenRunner, CommandChecker>(cls);

            // Runs an OS command
            CommandDescriptor run = new("ct-cli-run", "run", "run", "Runs an OS command.");
            builder.AddDescriptor<RunRunner, CommandChecker>(run);

            // Show licensing information
            {
                // Show licensing details.
                CommandDescriptor licInfo = new("ct-cli-lic", "lic", "lic info", "Displays the licensing information.");
                builder.AddDescriptor<LicInfoRunner, CommandChecker>(licInfo);
            }

            return builder;
        }
    }
}
