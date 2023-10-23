using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;
using System;
using System.Threading.Tasks;

namespace UnicodeCli.Runners
{
    /// <summary>
    /// This is the sample <c>unicode</c> root command runner.
    /// </summary>
    public class UnicodeRootRunner : CommandRunner<CommandRunnerResult>
    {
        public UnicodeRootRunner(TerminalOptions options, ILogger<UnicodeRootRunner> logger)
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
