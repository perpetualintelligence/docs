using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;

namespace DotnetStyleCli.Runners.Nuget
{
    /// <summary>
    /// The sample <c>dotnet nuget</c> command runner.
    /// </summary>
    public class DotNetNugetRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public DotNetNugetRunner(TerminalOptions options, ILogger<DotNetNugetRunner> logger)
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
