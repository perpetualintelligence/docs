using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;
using PerpetualIntelligence.Cli.Services;

namespace CustomStyleCli.Runners.Custom.Test
{
    /// <summary>
    /// The sample <c>dotnet nuget</c> command runner.
    /// </summary>
    public class CustomTestGuidRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public CustomTestGuidRunner(CliOptions options, ILogger<CustomTestGuidRunner> logger) : base(options, logger)
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
            Console.WriteLine($"Running {context.Command.Name} command.");
            Console.WriteLine($"Guid: ");
            ConsoleHelper.WriteColor(ConsoleColor.Cyan, Guid.NewGuid().ToString());
            Console.WriteLine();
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
