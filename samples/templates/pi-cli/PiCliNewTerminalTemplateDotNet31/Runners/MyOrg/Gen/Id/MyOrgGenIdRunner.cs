using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;
using PerpetualIntelligence.Shared.Exceptions;
using System;
using System.Threading.Tasks;

namespace PiCliNewTerminalTemplateDotNet31.Runners.MyOrg.Gen.Id
{
    /// <summary>
    /// The <c>myorg gen id</c> command runner.
    /// </summary>
    public class MyOrgGenIdRunner : CommandRunner
    {
        /// <summary>
        /// Initializes a new instance of <c>myorg gen</c> command runner. App authors can add more DI services here.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public MyOrgGenIdRunner(IIdGeneratorSampleService idGeneratorSampleService, CliOptions options, ILogger<MyOrgGenRunner> logger) : base(options, logger)
        {
            this.idGeneratorSampleService = idGeneratorSampleService;
            this.options = options;
            this.logger = logger;
        }

        /// <summary>
        /// Runs the <c>myorg</c> command.
        /// </summary>
        /// <param name="context">The run context.</param>
        /// <returns></returns>
        public override Task<CommandRunnerResult> RunAsync(CommandRunnerContext context)
        {
            string type = context.Command.GetRequiredArgumentValue<string>("type");
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
                throw new ErrorException("custom_error", "Invalid id type custom error message");
            }

            // Terminal authors can return custom result.
            return Task.FromResult(new CommandRunnerResult());
        }

        private readonly IIdGeneratorSampleService idGeneratorSampleService;
        private readonly ILogger<MyOrgGenRunner> logger;
        private readonly CliOptions options;
    }
}
