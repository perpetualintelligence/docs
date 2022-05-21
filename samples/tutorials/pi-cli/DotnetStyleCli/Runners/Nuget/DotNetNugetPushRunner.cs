using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;

namespace DotnetStyleCli.Runners
{
    /// <summary>
    /// The sample <c>dotnet nuget push</c> command runner.
    /// </summary>
    public class DotNetNugetPushRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public DotNetNugetPushRunner(CliOptions options, ILogger<DotNetNugetPushRunner> logger) : base(options, logger)
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

            if(context.Command.Arguments != null)
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
