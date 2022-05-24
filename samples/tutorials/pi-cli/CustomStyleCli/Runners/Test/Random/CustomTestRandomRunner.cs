using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;
using PerpetualIntelligence.Cli.Services;

namespace CustomStyleCli.Runners.Custom.Test
{
    /// <summary>
    /// The sample <c>dotnet nuget push</c> command runner.
    /// </summary>
    public class CustomTestRandomRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public CustomTestRandomRunner(CliOptions options, ILogger<CustomTestRandomRunner> logger) : base(options, logger)
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
            Console.WriteLine($"Random number: ");
            ConsoleHelper.WriteColor(ConsoleColor.Cyan, Random.Shared.NextDouble().ToString());
            Console.WriteLine();
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
