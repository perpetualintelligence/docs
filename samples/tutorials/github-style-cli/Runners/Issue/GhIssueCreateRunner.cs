using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;

namespace GithubStyleCliTerminal.Runners.Alias
{
    /// <summary>
    /// The sample <c>gh issue</c> command runner.
    /// </summary>
    public class GhIssueCreateRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GhIssueCreateRunner(CliOptions options, ILogger<GhIssueCreateRunner> logger) : base(options, logger)
        {
        }

        /// <summary>
        /// Runs the command.
        /// </summary>
        /// <param name="context">The runner context.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<CommandRunnerResult> RunAsync(CommandRunnerContext context)
        {
            Console.WriteLine($"Running sample {context.Command.Name} command.");
            Console.WriteLine("Options");
            Console.WriteLine("repo={0}", context.Command.GetRequiredArgumentValue<string>("repo"));
            Console.WriteLine("title={0}", context.Command.GetRequiredArgumentValue<string>("title"));
            Console.WriteLine("body={0}", context.Command.GetRequiredArgumentValue<string>("body"));
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
