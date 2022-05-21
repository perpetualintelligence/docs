using StripeStyleCli.Runners;
using PerpetualIntelligence.Cli.Commands;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Handlers;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;
using StripeStyleCli.Runners.Login;
using System.ComponentModel.DataAnnotations;

namespace StripeStyleCli
{
    /// <summary>
    /// The sample <c>stripe</c> CLI command registry. This class registers some sample commands to show how
    /// Stripe CLI style console terminals can be build using <c>pi-cli</c> framework.
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
            // App authors need to make sure the UnicodeTextHandler used here and in AddTextHandler DI service are the same.
            UnicodeTextHandler unicodeTextHandler = new ();

            // Sample stripe org command
            {
                CommandDescriptor pi = new(
                    "stripe-cli-org",
                    "stripe",
                    "stripe",
                    "Sample stripe CLI org command.",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                        new ArgumentDescriptor("help", nameof(Boolean), false, "help for Stripe") { Alias = "h" }
                    })
                );
                builder.AddDescriptor<StripeRunner, CommandChecker>(pi, isGroup: true, isRoot: true);
            };

            // login
            {
                // Sample stripe login command
                CommandDescriptor login = new(
                    "stripe-cli-login",
                    "login",
                    "stripe login",
                    "Authenticates the stripe cli session",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                        new ArgumentDescriptor("interactive", nameof(Boolean), false, "Authenticate without an existing API secret key or restricted key"),
                        new ArgumentDescriptor("api-key", DataType.Text, false, "Authenticate with an existing API secret key"),
                        new ArgumentDescriptor("help", nameof(Boolean), false, "help for Stripe") { Alias = "h" }
                    })

                );
                builder.AddDescriptor<StripeLoginRunner, CommandChecker>(login, isGroup: true);
            };

            // Exit
            CommandDescriptor exit = new("stripe-cli-exit", "exit", "exit", "Exits the CLI terminal.");
            builder.AddDescriptor<ExitRunner, CommandChecker>(exit);

            // Clear screen
            CommandDescriptor cls = new("stripe-cli-cls", "cls", "cls", "Clears the CLI terminal screen.");
            builder.AddDescriptor<ClearScreenRunner, CommandChecker>(cls);

            // Runs an OS command
            CommandDescriptor run = new("stripe-cli-run", "run", "run", "Runs an OS command.");
            builder.AddDescriptor<RunRunner, CommandChecker>(run);

            // Show licensing information
            {
                // Show licensing details.
                CommandDescriptor licInfo = new("stripe-cli-lic", "lic", "lic info", "Displays the licensing information.");
                builder.AddDescriptor<LicInfoRunner, CommandChecker>(licInfo);
            }

            return builder;
        }
    }
}
