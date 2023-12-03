using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Shared.Infrastructure;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;
using PerpetualIntelligence.Terminal.Runtime;
using System.Threading.Tasks;

namespace TerminalTemplate.Net7.Runners
{
    /// <summary>
    /// The <c>myorg gen id</c> command runner.
    /// </summary>
    public class MyOrgGenIdRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initializes a new instance of <c>myorg gen</c> command runner. App authors can add more DI services here.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public MyOrgGenIdRunner(ITerminalConsole terminalConsole, ISampleService idGeneratorSampleService, TerminalOptions options, ILogger<MyOrgGenRunner> logger)
        {
            this.terminalConsole = terminalConsole;
            this.idGeneratorSampleService = idGeneratorSampleService;
        }

        /// <summary>
        /// Runs the <c>myorg</c> command.
        /// </summary>
        /// <param name="context">The run context.</param>
        /// <returns></returns>
        public override async Task<CommandRunnerResult> RunCommandAsync(CommandRunnerContext context)
        {
            context.Command.TryGetOptionValue("type", out string? type);
            if (type == "suid")
            {
                await terminalConsole.WriteLineAsync(idGeneratorSampleService.GenerateSuid());
            }
            else if (type == "luid")
            {
                await terminalConsole.WriteLineAsync(idGeneratorSampleService.GenerateLuid());
            }
            else
            {
                // Custom error message
                throw new ErrorException("custom_error", "Custom error message. Invalid type. Please use suid or luid.");
            }

            return new CommandRunnerResult();
        }

        private readonly ITerminalConsole terminalConsole;
        private readonly ISampleService idGeneratorSampleService;
    }
}