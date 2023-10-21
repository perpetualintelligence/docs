using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;
using PerpetualIntelligence.Shared.Exceptions;
using System;
using System.Threading.Tasks;

namespace TerminalTemplate.Net48.Runners.MyOrg.Gen.Id
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
        public MyOrgGenIdRunner(IIdGeneratorSampleService idGeneratorSampleService, TerminalOptions options, ILogger<MyOrgGenRunner> logger)
        {
            this.idGeneratorSampleService = idGeneratorSampleService;
        }

        /// <summary>
        /// Runs the <c>myorg</c> command.
        /// </summary>
        /// <param name="context">The run context.</param>
        /// <returns></returns>
        public override Task<CommandRunnerResult> RunAsync(CommandRunnerContext context)
        {
            context.Command.TryGetOptionValue("type", out string? type);
            if (type == "suid")
            {
                Console.WriteLine(idGeneratorSampleService.GenerateSuid());
            }
            else if (type == "luid")
            {
                Console.WriteLine(idGeneratorSampleService.GenerateLuid());
            }
            else
            {
                // Custom error message
                throw new ErrorException("custom_error", "Custom error message. Invalid type. Please use suid or luid.");
            }

            // Terminal authors can return custom result.
            return Task.FromResult(new CommandRunnerResult());
        }

        private readonly IIdGeneratorSampleService idGeneratorSampleService;
    }
}
