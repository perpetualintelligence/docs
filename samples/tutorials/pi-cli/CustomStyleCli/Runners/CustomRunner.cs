using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;

namespace CustomStyleCli.Runners.Custom
{
    /// <summary>
    /// The sample <c>custom</c> command runner.
    /// </summary>
    public class CustomRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public CustomRunner(CliOptions options, ILogger<CustomRunner> logger) : base(options, logger)
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
            Console.WriteLine($"Running {context.Command.Name} root command.");

            if (context.Command.Arguments != null)
            {
                Console.WriteLine("Printing arguments...");
                foreach (var arg in context.Command.Arguments)
                {
                    Console.WriteLine($"{arg.Id}: {arg.Value}");
                }
            }

            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
