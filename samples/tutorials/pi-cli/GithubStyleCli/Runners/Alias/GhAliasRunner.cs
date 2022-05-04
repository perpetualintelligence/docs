using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;

namespace GithubStyleCli.Runners.Alias
{
    /// <summary>
    /// The sample <c>gh alias</c> command runner.
    /// </summary>
    public class GhAliasRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GhAliasRunner(CliOptions options, ILogger<GhAliasRunner> logger) : base(options, logger)
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
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
