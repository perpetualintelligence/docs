/*
    Copyright (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com
*/

using GithubStyleCliTerminal.Runners;
using GithubStyleCliTerminal.Runners.Alias;
using PerpetualIntelligence.Cli.Commands;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Comparers;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;

namespace GithubStyleCliTerminal
{
    /// <summary>
    /// The sample <c>gh cli</c> command registry.
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
            // Todo: We have to use StringComparisonComparer multiple times. For now, app authors need to make sure the
            // StringComparisonComparer and AddStringComparer instances are the same.
            StringComparisonComparer stringComparison = new StringComparisonComparer(StringComparison.Ordinal);

            // gh
            {
                CommandDescriptor pi = new(
                    "gh-cli-gh",
                    "gh",
                    "gh",
                    "Sample description to work seamlessly with GitHub from the command line.",
                    new ArgumentDescriptors(stringComparison, new[]
                    {
                        new ArgumentDescriptor("version", nameof(Boolean), false, "Show gh version") { Alias = "v" }
                    })
                );
                builder.AddDescriptor<GhRunner, CommandChecker>(pi);
            };

            // alias
            {
                // gh alias
                CommandDescriptor alias = new(
                    "gh-cli-alias",
                    "alias",
                    "gh alias",
                    "Sample description for aliases that can be used to make shortcuts for gh commands or to compose multiple commands."
                );
                builder.AddDescriptor<GhAliasRunner, CommandChecker>(alias);

                // gh alias delete
                CommandDescriptor aliasDelete = new(
                    "gh-cli-alias-delete",
                    "delete",
                    "gh alias delete",
                    "Sample description for delete an alias.",
                    new ArgumentDescriptors(stringComparison, new[]
                    {
                        new ArgumentDescriptor("alias", System.ComponentModel.DataAnnotations.DataType.Text, true, "The alias to delete")
                    }),
                    defaultArgument: "alias"
                );
                builder.AddDescriptor<GhAliasDeleteRunner, CommandChecker>(aliasDelete);

                // gh alias list
                CommandDescriptor aliasList = new(
                    "gh-cli-alias-list",
                    "list",
                    "gh alias list",
                    "Sample description to list all aliases."
                );
                builder.AddDescriptor<GhAliasListRunner, CommandChecker>(aliasList);

                // gh alias set
                CommandDescriptor aliasSet = new(
                    "gh-cli-alias-set",
                    "set",
                    "gh alias set",
                    "Sample description to set the alias.",
                 new ArgumentDescriptors(stringComparison, new[]
                    {
                        new ArgumentDescriptor("alias", System.ComponentModel.DataAnnotations.DataType.Text, true, "The alias to set"),
                        new ArgumentDescriptor("expand", System.ComponentModel.DataAnnotations.DataType.Text, true, "The alias expansion may specify additional arguments and flags")
                    }),
                    defaultArgument: "alias"
                );
                builder.AddDescriptor<GhAliasSetRunner, CommandChecker>(aliasSet);
            };

            // Exit
            CommandDescriptor exit = new("gh-cli-exit", "exit", "exit", "Exits the CLI terminal.");
            builder.AddDescriptor<ExitRunner, CommandChecker>(exit);

            // Clear screen
            CommandDescriptor cls = new("gh-cli-cls", "cls", "cls", "Clears the CLI terminal screen.");
            builder.AddDescriptor<ClearScreenRunner, CommandChecker>(cls);

            // Runs an OS command
            CommandDescriptor run = new("gh-cli-run", "run", "run", "Runs an OS command.");
            builder.AddDescriptor<RunRunner, CommandChecker>(run);

            // lic
            {
                // Show licensing details.
                CommandDescriptor licInfo = new("gh-cli-lic", "lic", "lic info", "Displays the licensing information.");
                builder.AddDescriptor<LicInfoRunner, CommandChecker>(licInfo);
            }

            return builder;
        }
    }
}
