using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;
using System;
using System.Threading.Tasks;

namespace TerminalTemplate.Net7.Runners
{
    /// <summary>
    /// The <c>myorg</c> command runner.
    /// </summary>
    public class MyOrgRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initializes a new instance of <c>myorg</c> command runner. App authors can add more DI services here.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public MyOrgRunner(TerminalOptions options, ILogger<MyOrgRunner> logger)
        {
        }

        /// <summary>
        /// Runs the <c>myorg</c> command.
        /// </summary>
        /// <param name="context">The run context.</param>
        /// <returns></returns>
        public override Task<CommandRunnerResult> RunCommandAsync(CommandRunnerContext context)
        {
            // Get the passed argument value
            context.Command.TryGetOptionValue("version", out bool? showVersion);
            if (showVersion.GetValueOrDefault())
            {
                Console.WriteLine("Version=5.x-demo");
            }
            else
            {
                Console.WriteLine("Running the sample \"myorg\" command without --version option.");
            }

            // Terminal authors can return custom result.
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}