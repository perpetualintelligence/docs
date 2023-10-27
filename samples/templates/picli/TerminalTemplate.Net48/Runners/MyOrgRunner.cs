using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;
using PerpetualIntelligence.Terminal.Runtime;
using System.Threading.Tasks;

namespace TerminalTemplate.Net48.Runners
{
    /// <summary>
    /// The <c>myorg</c> command runner.
    /// </summary>
    public class MyOrgRunner : CommandRunner<CommandRunnerResult>
    {
        private readonly ITerminalConsole terminalConsole;

        /// <summary>
        /// Initializes a new instance of <c>myorg</c> command runner. App authors can add more DI services here.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public MyOrgRunner(ITerminalConsole terminalConsole, TerminalOptions options, ILogger<MyOrgRunner> logger)
        {
            this.terminalConsole = terminalConsole;
        }

        /// <summary>
        /// Runs the <c>myorg</c> command.
        /// </summary>
        /// <param name="context">The run context.</param>
        /// <returns></returns>
        public override async Task<CommandRunnerResult> RunCommandAsync(CommandRunnerContext context)
        {
            // Get the passed argument value
            context.Command.TryGetOptionValue("version", out bool? showVersion);
            if (showVersion.GetValueOrDefault())
            {
                await terminalConsole.WriteLineAsync("Version=5.x-demo");
            }
            else
            {
                await terminalConsole.WriteLineAsync("Running the sample \"myorg\" command without --version option.");
            }

            // Terminal authors can return custom result.
            return new CommandRunnerResult();
        }
    }
}