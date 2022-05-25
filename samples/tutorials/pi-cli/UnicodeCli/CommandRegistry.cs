using GithubStyleCli.Runners.Alias;
using PerpetualIntelligence.Cli.Commands;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Handlers;
using PerpetualIntelligence.Cli.Commands.Runners;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Integration;
using System;
using UnicodeCli.Runners;

namespace UnicodeCli
{
    /// <summary>
    /// The sample <c>unicode</c> CLI command registry. This class registers some sample Unicode commands to show how
    /// GitHub CLI style console terminals can be build using <c>pi-cli</c> framework.
    /// </summary>
    public static class CommandRegistry
    {
        /// <summary>
        /// Adds the cli commands to the service collection.
        /// </summary>
        /// <param name="builder">The <see cref="ICliBuilder"/> builder.</param>
        /// <returns>The <see cref="ICliBuilder"/> instance.</returns>
        public static ICliBuilder AddCommandDescriptors(this ICliBuilder builder)
        {
            // App authors need to make sure the UnicodeTextHandler used here and in AddTextHandler DI service are the same.
            UnicodeTextHandler unicodeTextHandler = new();

            // Sample Unicode root command
            {
                CommandDescriptor pi = new(
                    "uc-cli-root",
                    "統一碼",
                    "統一碼",
                    "示例根命令描述"
                );
                builder.AddDescriptor<UnicodeRootRunner, CommandChecker>(pi, isRoot: true, isGroup: true);
            };

            // Sample unicode test commands
            {
                // unicode test
                CommandDescriptor test = new(
                    "uc-cli-test",
                    "測試",
                    "統一碼 測試",
                    "示例分組命令"
                );
                builder.AddDescriptor<UnicodeTestRunner, CommandChecker>(test, isGroup: true);

                // unicode test chinese
                CommandDescriptor testCmd = new(
                    "uc-cli-sub",
                    "打印",
                    "統一碼 測試 打印",
                    "測試命令",
                    new ArgumentDescriptors(unicodeTextHandler, new[]
                    {
                     new ArgumentDescriptor("第一的", System.ComponentModel.DataAnnotations.DataType.Text, false, "第一個命令參數"),
                     new ArgumentDescriptor("第二", nameof(Boolean), false, "第二個命令參數"),
                     new ArgumentDescriptor("第三", System.ComponentModel.DataAnnotations.DataType.Text, false, "第三個命令參數"),
                     new ArgumentDescriptor("第四", nameof(Double), false, "第四個命令參數")
                    })
                );
                builder.AddDescriptor<UnicodeTestChineseRunner, CommandChecker>(testCmd);
            };

            // Exit
            CommandDescriptor exit = new("uc-cli-exit", "出口", "出口", "退出 CLI 終端。");
            builder.AddDescriptor<ExitRunner, CommandChecker>(exit);

            // Clear screen
            CommandDescriptor cls = new("uc-cli-cls", "清除", "清除", "清除 CLI 終端屏幕。");
            builder.AddDescriptor<ClearScreenRunner, CommandChecker>(cls);

            return builder;
        }
    }
}
