using GithubStyleCli.Runners;
using GithubStyleCli.Runners.Alias;
using PerpetualIntelligence.Cli.Commands;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Handlers;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;

namespace GithubStyleCli
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
            // TODO:
            // - We have to use UnicodeTextHandler multiple times.
            // - For now, app authors need to make sure the StringComparisonComparer and AddTextHandler instances are
            //   the same.
            UnicodeTextHandler unicodeTextHandler = new UnicodeTextHandler();

            // gh
            {
                CommandDescriptor pi = new(
                    "gh-cli-gh",
                    "gh",
                    "gh",
                    "Sample description to work seamlessly with GitHub from the command line.",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
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
                    new ArgumentDescriptors(unicodeTextHandler, new[]
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
                 new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                        new ArgumentDescriptor("alias", System.ComponentModel.DataAnnotations.DataType.Text, true, "The alias to set"),
                        new ArgumentDescriptor("expand", System.ComponentModel.DataAnnotations.DataType.Text, true, "The alias expansion may specify additional arguments and flags")
                    }),
                    defaultArgument: "alias"
                );
                builder.AddDescriptor<GhAliasSetRunner, CommandChecker>(aliasSet);
            };

            // Issue
            {
                // gh issue
                CommandDescriptor issue = new(
                    "gh-cli-issue",
                    "issue",
                    "gh issue",
                    "Sample command to work with GitHub issues.",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                        new ArgumentDescriptor("repo", System.ComponentModel.DataAnnotations.DataType.Text, required: true) { Alias = "R"},
                    })
                );
                builder.AddDescriptor<GhIssueRunner, CommandChecker>(issue);

                // gh issue create
                CommandDescriptor create = new(
                    "gh-cli-issue-create",
                    "create",
                    "gh issue create",
                    "Sample command to create GitHub issue.",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                        new ArgumentDescriptor("repo", System.ComponentModel.DataAnnotations.DataType.Text, required: true) { Alias = "R"},
                        new ArgumentDescriptor("assignee", System.ComponentModel.DataAnnotations.DataType.Text) { Alias = "a"},
                        new ArgumentDescriptor("body", System.ComponentModel.DataAnnotations.DataType.Text) { Alias = "b"},
                        new ArgumentDescriptor("body-file", System.ComponentModel.DataAnnotations.DataType.Text) { Alias = "F"},
                        new ArgumentDescriptor("milestone", System.ComponentModel.DataAnnotations.DataType.Text) { Alias = "m"},
                        new ArgumentDescriptor("project", System.ComponentModel.DataAnnotations.DataType.Text) { Alias = "p"},
                        new ArgumentDescriptor("recover", System.ComponentModel.DataAnnotations.DataType.Text),
                        new ArgumentDescriptor("title", System.ComponentModel.DataAnnotations.DataType.Text, required: true) { Alias = "t"},
                        new ArgumentDescriptor("web", System.ComponentModel.DataAnnotations.DataType.Text) { Alias = "w"},
                    })
                );
                builder.AddDescriptor<GhIssueCreateRunner, CommandChecker>(create);
            }

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
