using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;

namespace PiCliNewTerminalTemplate.Runners.MyOrg.Gen
{
    /// <summary>
    /// The <c>myorg gen</c> command runner.
    /// </summary>
    public class MyOrgGenRunner : CommandRunner
    {
        /// <summary>
        /// Initializes a new instance of <c>myorg gen</c> command runner. App authors can add more DI services here.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public MyOrgGenRunner(CliOptions options, ILogger<MyOrgGenRunner> logger) : base(options, logger)
        {
        }

        /// <summary>
        /// Runs the <c>myorg</c> command.
        /// </summary>
        /// <param name="context">The run context.</param>
        /// <returns></returns>
        public override Task<CommandRunnerResult> RunAsync(CommandRunnerContext context)
        {
            Console.WriteLine("Running the sample grouped command  \"myorg gen\"");

            // Terminal authors can return custom result.
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
