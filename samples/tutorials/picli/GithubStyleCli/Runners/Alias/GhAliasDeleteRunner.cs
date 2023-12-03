using Microsoft.Extensions.Logging;
using OneImlx.Terminal.Commands.Runners;
using OneImlx.Terminal.Configuration.Options;

namespace GithubStyleCli.Runners.Alias
{
    /// <summary>
    /// The sample <c>gh alias delete</c> command runner.
    /// </summary>
    public class GhAliasDeleteRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GhAliasDeleteRunner(TerminalOptions options, ILogger<GhAliasDeleteRunner> logger)
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
            Console.WriteLine("The sample gh alias delete command. alias={0}", context.Command.GetRequiredOptionValue<string>("alias"));
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
