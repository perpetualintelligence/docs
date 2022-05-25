using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;
using System;
using System.Threading.Tasks;

namespace UnicodeCli.Runners
{
    /// <summary>
    /// This is the sample <c>unicode</c> root command runner.
    /// </summary>
    public class UnicodeRootRunner : CommandRunner
    {
        public UnicodeRootRunner(CliOptions options, ILogger<UnicodeRootRunner> logger) : base(options, logger)
        {
        }

        /// <inheritdoc/>
        public override Task<CommandRunnerResult> RunAsync(CommandRunnerContext context)
        {
            Console.WriteLine("Running root command (Chinese)");
            Console.WriteLine($"運行示例 `{context.Command.Name}`.");            
            Console.WriteLine("將您的應用、服務或工具帶到命令行。");
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
