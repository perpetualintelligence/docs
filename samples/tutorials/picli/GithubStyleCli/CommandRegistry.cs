﻿/*
    Copyright (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using GithubStyleCli.Runners;
using GithubStyleCli.Runners.Alias;
using PerpetualIntelligence.Terminal.Commands.Checkers;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Extensions;
using PerpetualIntelligence.Terminal.Hosting;

namespace GithubStyleCli
{
    /// <summary>
    /// The sample <c>gh</c> CLI command registry. This class registers some sample commands to show how GitHub CLI
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
            // sample gh
            builder.DefineCommand<CommandChecker, GhRunner>("gh-cli-gh", "gh", "gh", "Sample description to work seamlessly with GitHub from the command line.", isGroup: true, isRoot: true)
                   .DefineOption("version", nameof(Boolean), "Show gh version", alias: "v").Add()
                   .Add();

            // sample gh alias
            builder.DefineCommand<CommandChecker, GhAliasRunner>("gh-cli-alias", "alias", "gh alias", "Sample description for aliases that can be used to make shortcuts for gh commands or to compose multiple commands.", isGroup: true).Add();

            // sample gh alias delete
            builder.DefineCommand<CommandChecker, GhAliasDeleteRunner>("gh-cli-alias-delete", "delete", "gh alias delete", "Sample description for delete an alias.", defaultOption: "alias")
                   .DefineOption("alias", System.ComponentModel.DataAnnotations.DataType.Text, "The alias to delete", required: true).Add()
                   .Add();

            // sample gh alias list
            builder.DefineCommand<CommandChecker, GhAliasListRunner>("gh-cli-alias-list", "list", "gh alias list", "Sample description to list all aliases.").Add();

            // sample gh alias set
            builder.DefineCommand<CommandChecker, GhAliasSetRunner>("gh-cli-alias-set", "set", "gh alias set", "Sample description to set the alias.", defaultOption: "alias")
                   .DefineOption("alias", System.ComponentModel.DataAnnotations.DataType.Text, "The alias to set", required: true).Add()
                   .DefineOption("expand", System.ComponentModel.DataAnnotations.DataType.Text, "The alias expansion may specify additional arguments and flags", required: true).Add()
                   .Add();

            // sample gh issue
            builder.DefineCommand<CommandChecker, GhIssueRunner>("gh-cli-issue", "issue", "gh issue", "Sample command to work with GitHub issues.", isGroup: true)
                   .DefineOption("repo", System.ComponentModel.DataAnnotations.DataType.Text, "Repo argument", required: true, alias: "R").Add()
                   .Add();

            // sample gh issue create
            builder.DefineCommand<CommandChecker, GhIssueCreateRunner>("gh-cli-issue-create", "create", "gh issue create", "Sample command to create GitHub issue.")
                   .DefineOption("repo", System.ComponentModel.DataAnnotations.DataType.Text, "", required: true, alias: "R").Add()
                   .DefineOption("assignee", System.ComponentModel.DataAnnotations.DataType.Text, "", alias: "a").Add()
                   .DefineOption("body", System.ComponentModel.DataAnnotations.DataType.Text, "", alias: "b").Add()
                   .DefineOption("body-file", System.ComponentModel.DataAnnotations.DataType.Text, "", alias: "F").Add()
                   .DefineOption("milestone", System.ComponentModel.DataAnnotations.DataType.Text, "", alias: "m").Add()
                   .DefineOption("project", System.ComponentModel.DataAnnotations.DataType.Text, "", alias: "p").Add()
                   .DefineOption("recover", System.ComponentModel.DataAnnotations.DataType.Text, "").Add()
                   .DefineOption("title", System.ComponentModel.DataAnnotations.DataType.Text, "", required: true, alias: "t").Add()
                   .DefineOption("web", System.ComponentModel.DataAnnotations.DataType.Text, "", alias: "w").Add()
                   .Add();

            // Exit sub-command
            builder.DefineCommand<CommandChecker, ExitRunner>("gh-cli-exit", "exit", "exit", "Exits the CLI terminal.").Add();

            // Clear screen sub-command
            builder.DefineCommand<CommandChecker, ClearScreenRunner>("gh-cli-cls", "cls", "cls", "Clears the CLI terminal screen.").Add();

            // OS sub-command
            builder.DefineCommand<CommandChecker, RunRunner>("gh-cli-run", "run", "run", "Runs an OS command.").Add();

            // Licensing details sub-command
            builder.DefineCommand<CommandChecker, LicInfoRunner>("gh-cli-lic", "lic", "lic info", "Displays the licensing information.").Add();

            return builder;
        }
    }
}