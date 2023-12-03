/*
    Copyright (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using OneImlx.Terminal.Commands.Checkers;
using OneImlx.Terminal.Commands.Runners;
using OneImlx.Terminal.Extensions;
using OneImlx.Terminal.Hosting;
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
        /// <param name="builder">The <see cref="ITerminalBuilder"/> builder.</param>
        /// <returns>The <see cref="ITerminalBuilder"/> instance.</returns>
        public static ITerminalBuilder AddCommandDescriptors(this ITerminalBuilder builder)
        {
            // Sample stripe root command
            builder.DefineCommand<CommandChecker, StripeRunner>("stripe-cli-org", "stripe", "stripe", "Sample stripe CLI root command.", isGroup: true, isRoot: true)
                   .DefineOption("help", nameof(Boolean), "help for Stripe", alias: "h").Add()
                   .Add();

            // Sample stripe login command
            builder.DefineCommand<CommandChecker, StripeLoginRunner>("stripe-cli-login", "login", "stripe login", "Authenticates the stripe cli session")
                   .DefineOption("interactive", nameof(Boolean), "Authenticate without an existing API secret key or restricted key").Add()
                   .DefineOption("api-key", DataType.Text, "Authenticate with an existing API secret key").Add()
                   .DefineOption("help", nameof(Boolean), "help for Stripe", alias: "h").Add()
                   .Add();

            // Sample stripe api key command
            builder.DefineCommand<CommandChecker, StripeApiKeyRunner>("stripe-cli-apikey", "apikey", "stripe apikey", "Authenticates the stripe cli session")
                   .DefineOption("api-key", DataType.Text, "Authenticate with an existing API secret key").Add()
                   .DefineOption("help", nameof(Boolean), "help for Stripe", alias: "h").Add()
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