using Microsoft.Extensions.Logging;
using OneImlx.Terminal.Commands.Runners;
using OneImlx.Terminal.Configuration.Options;
using OneImlx.Terminal.Runtime;
using System.Threading.Tasks;

namespace TerminalTemplate.Net48.Runners
{
    /// <summary>
    /// The <c>myorg gen</c> command runner.
    /// </summary>
    public class MyOrgGenRunner : CommandRunner<CommandRunnerResult>
    {
        private readonly ITerminalConsole terminalConsole;

        /// <summary>
        /// Initializes a new instance of <c>myorg gen</c> command runner. App authors can add more DI services here.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public MyOrgGenRunner(ITerminalConsole terminalConsole, TerminalOptions options, ILogger<MyOrgGenRunner> logger)
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
            await terminalConsole.WriteLineAsync("Running the sample grouped command  \"myorg gen\"");

            return new CommandRunnerResult();
        }
    }
}