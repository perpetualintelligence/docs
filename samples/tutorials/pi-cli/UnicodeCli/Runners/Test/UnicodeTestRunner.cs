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
    public class UnicodeTestRunner : CommandRunner
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public UnicodeTestRunner(CliOptions options, ILogger<UnicodeTestRunner> logger) : base(options, logger)
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
            Console.WriteLine("Running grouped command (Chinese)");
            Console.WriteLine($"運行示例分組命令 '{context.Command.Name}'.");
            Console.WriteLine("以任何用戶語言展示 Unicode CLI 命令。");
            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
