using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Configuration.Options;
using System;
using System.Threading.Tasks;

namespace GithubStyleCli.Runners.Alias
{
    /// <summary>
    /// The sample <c>unicode test</c> grouped command runner.
    /// </summary>
    public class UnicodeTestChineseRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public UnicodeTestChineseRunner(CliOptions options, ILogger<UnicodeTestChineseRunner> logger) : base(options, logger)
        {
        }

        /// <summary>
        /// Runs the command.
        /// </summary>
        /// <param name="context">The runner context.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<CommandRunnerResult> RunAsync(CommandRunnerContext context)
        {
            Console.WriteLine("Running sub-command (Chinese)");
            Console.WriteLine("你好 CLI 終端");

            if (context.Command.Arguments != null)
            {
                Console.WriteLine("Print arguments and options (Chinese)");
                Console.WriteLine("打印 Unicode 命令參數");
                foreach (var arg in context.Command.Arguments)
                {
                    Console.WriteLine($"{arg.Id}={arg.Value}");
                }
            }

            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
