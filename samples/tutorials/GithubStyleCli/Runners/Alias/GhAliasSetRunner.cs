using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;

namespace GithubStyleCli.Runners.Alias
{
    /// <summary>
    /// The sample <c>gh alias set</c> command runner.
    /// </summary>
    public class GhAliasSetRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GhAliasSetRunner(CliOptions options, ILogger<GhAliasSetRunner> logger) : base(options, logger)
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
            Console.WriteLine("The sample gh alias set command. alias={0} expand={1}", context.Command.GetRequiredArgumentValue<string>("alias"), context.Command.GetRequiredArgumentValue<string>("expand"));
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
