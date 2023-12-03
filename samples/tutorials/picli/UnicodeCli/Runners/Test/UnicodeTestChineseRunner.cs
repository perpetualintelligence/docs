﻿using Microsoft.Extensions.Logging;
using OneImlx.Terminal.Commands.Runners;
using OneImlx.Terminal.Configuration.Options;
using System;
using System.Threading.Tasks;

namespace GithubStyleCli.Runners.Alias
{
    /// <summary>
    /// The sample <c>unicode test</c> grouped command runner.
    /// </summary>
    public class UnicodeTestChineseRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public UnicodeTestChineseRunner(TerminalOptions options, ILogger<UnicodeTestChineseRunner> logger)
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

            if (context.Command.Options != null)
            {
                Console.WriteLine("Print arguments and options (Chinese)");
                Console.WriteLine("打印 Unicode 命令參數");
                foreach (var arg in context.Command.Options)
                {
                    Console.WriteLine($"{arg.Id}={arg.Value}");
                }
            }

            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
