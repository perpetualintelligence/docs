using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;

namespace GithubStyleCli.Runners.Alias
{
    /// <summary>
    /// The sample <c>gh alias set</c> command runner.
    /// </summary>
    public class GhAliasSetRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GhAliasSetRunner(TerminalOptions options, ILogger<GhAliasSetRunner> logger)
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
            Console.WriteLine("The sample gh alias set command. alias={0} expand={1}", context.Command.GetRequiredOptionValue<string>("alias"), context.Command.GetRequiredOptionValue<string>("expand"));
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
