using Microsoft.Extensions.Logging;
using OneImlx.Terminal.Commands.Runners;
using OneImlx.Terminal.Configuration.Options;

namespace GithubStyleCli.Runners.Alias
{
    /// <summary>
    /// The sample <c>gh issue</c> command runner.
    /// </summary>
    public class GhIssueCreateRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public GhIssueCreateRunner(TerminalOptions options, ILogger<GhIssueCreateRunner> logger)
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
            Console.WriteLine("repo={0}", context.Command.GetRequiredOptionValue<string>("repo"));
            Console.WriteLine("title={0}", context.Command.GetRequiredOptionValue<string>("title"));
            Console.WriteLine("body={0}", context.Command.GetRequiredOptionValue<string>("body"));
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
