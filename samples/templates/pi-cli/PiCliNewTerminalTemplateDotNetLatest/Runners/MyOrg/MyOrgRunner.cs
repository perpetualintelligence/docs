using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;

namespace PiCliNewTerminalTemplateDotNetLatest.Runners.MyOrg
{
    /// <summary>
    /// The <c>myorg</c> command runner.
    /// </summary>
    public class MyOrgRunner : CommandRunner
    {
        /// <summary>
        /// Initializes a new instance of <c>myorg</c> command runner. App authors can add more DI services here.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public MyOrgRunner(CliOptions options, ILogger<MyOrgRunner> logger) : base(options, logger)
        {
        }

        /// <summary>
        /// Runs the <c>myorg</c> command.
        /// </summary>
        /// <param name="context">The run context.</param>
        /// <returns></returns>
        public override Task<CommandRunnerResult> RunAsync(CommandRunnerContext context)
        {
            // Get the passed argument value
            bool? showVersion = context.Command.GetOptionalArgumentValue<bool>("version");
            if (showVersion.GetValueOrDefault())
            {
                Console.WriteLine("Version=2.6.1-demo");
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
