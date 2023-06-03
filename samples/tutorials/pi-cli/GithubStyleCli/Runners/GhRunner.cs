using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;

namespace GithubStyleCli.Runners
{
    /// <summary>
    /// The sample <c>gh</c> command runner.
    /// </summary>
    public class GhRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GhRunner(CliOptions options, ILogger<GhRunner> logger) : base(options, logger)
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
            Console.WriteLine("3.0.1-preview");
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
