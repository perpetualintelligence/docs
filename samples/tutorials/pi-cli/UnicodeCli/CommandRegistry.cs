using GithubStyleCli.Runners.Alias;
using PerpetualIntelligence.Cli.Commands.Checkers;
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
            // Sample Unicode root command
            builder.DefineCommand<CommandChecker, UnicodeRootRunner>("uc-cli-root", "統一碼", "統一碼", "示例根命令描述", isGroup: true, isRoot: true).Add();

            // Sample unicode test commands
            builder.DefineCommand<CommandChecker, UnicodeTestRunner>("uc-cli-test", "測試", "統一碼 測試", "示例分組命令", isGroup: true).Add();

            // unicode test chinese
            builder.DefineCommand<CommandChecker, UnicodeTestChineseRunner>("uc-cli-sub", "打印", "統一碼 測試 打印", "測試命令")
                   .DefineArgument("第一的", System.ComponentModel.DataAnnotations.DataType.Text, "第一個命令參數").Add()
                   .DefineArgument("第二", nameof(Boolean), "第二個命令參數").Add()
                   .DefineArgument("第三", System.ComponentModel.DataAnnotations.DataType.Text, "第三個命令參數").Add()
                   .DefineArgument("第四", nameof(Double), "第四個命令參數").Add()
                   .Add();

            // Exit sub - command
            builder.DefineCommand<CommandChecker, ExitRunner>("uc-cli-exit", "出口", "出口", "退出 CLI 終端。").Add();

            // Clear screen sub-command
            builder.DefineCommand<CommandChecker, ClearScreenRunner>("uc-cli-cls", "清除", "清除", "清除 CLI 終端屏幕。").Add();

            return builder;
        }
    }
}
