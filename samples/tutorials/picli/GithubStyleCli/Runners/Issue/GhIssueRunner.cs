using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;

namespace GithubStyleCli.Runners.Alias
{
    /// <summary>
    /// The sample <c>gh issue</c> command runner.
    /// </summary>
    public class GhIssueRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GhIssueRunner(TerminalOptions options, ILogger<GhIssueRunner> logger)
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
            Console.WriteLine("Option --repo={0}", context.Command.GetRequiredOptionValue<string>("repo"));
            Console.WriteLine("Option Alias -R={0}", context.Command.GetRequiredOptionValue<string>("repo"));
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
