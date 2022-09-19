using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;
using StripeStyleCli.Runners;
using StripeStyleCli.Runners.Login;
using System.ComponentModel.DataAnnotations;

namespace StripeStyleCli
{
    /// <summary>
    /// The sample <c>stripe</c> CLI command registry. This class registers some sample commands to show how Stripe CLI
    /// style console terminals can be build using <c>pi-cli</c> framework.
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
            // Sample stripe root command
            builder.DefineCommand<CommandChecker, StripeRunner>("stripe-cli-org", "stripe", "stripe", "Sample stripe CLI root command.", isGroup:true, isRoot:true)
                   .DefineArgument("help", nameof(Boolean), "help for Stripe", alias: "h").Add()
                   .Add();

            // Sample stripe login command
            builder.DefineCommand<CommandChecker, StripeLoginRunner>("stripe-cli-login", "login", "stripe login", "Authenticates the stripe cli session")
                   .DefineArgument("interactive", nameof(Boolean), "Authenticate without an existing API secret key or restricted key").Add()
                   .DefineArgument("api-key", DataType.Text, "Authenticate with an existing API secret key").Add()
                   .DefineArgument("help", nameof(Boolean), "help for Stripe", alias: "h").Add()
                   .Add();

            // Sample stripe api key command
            builder.DefineCommand<CommandChecker, StripeApiKeyRunner>("stripe-cli-apikey", "apikey", "stripe apikey", "Authenticates the stripe cli session")
                   .DefineArgument("api-key", DataType.Text, "Authenticate with an existing API secret key").Add()
                   .DefineArgument("help", nameof(Boolean), "help for Stripe", alias: "h").Add()
                   .Add();

            // Exit sub - command
            builder.DefineCommand<CommandChecker, ExitRunner>("stripe-cli-exit", "exit", "exit", "Exits the CLI terminal.").Add();

            // Clear screen sub-command
            builder.DefineCommand<CommandChecker, ClearScreenRunner>("stripe-cli-cls", "cls", "cls", "Clears the CLI terminal screen.").Add();

            // OS sub-command
            builder.DefineCommand<CommandChecker, RunRunner>("stripe-cli-run", "run", "run", "Runs an OS command.").Add();

            // Licensing details sub-command
            builder.DefineCommand<CommandChecker, LicInfoRunner>("stripe-cli-lic", "lic", "lic info", "Displays the licensing information.").Add();

            return builder;
        }
    }
}
