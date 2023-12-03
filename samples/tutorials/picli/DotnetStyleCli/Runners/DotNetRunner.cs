using Microsoft.Extensions.Logging;
using OneImlx.Terminal.Commands.Runners;
using OneImlx.Terminal.Configuration.Options;

namespace DotnetStyleCli.Runners
{
    /// <summary>
    /// The sample <c>dotnet</c> command runner.
    /// </summary>
    public class DotNetRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public DotNetRunner(TerminalOptions options, ILogger<DotNetRunner> logger)
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
            Console.WriteLine($"Running sample {context.Command.Name} command.");
            Console.WriteLine("The SAMPLE generic driver for the .NET CLI.");

            if (context.Command.Options != null)
            {
                Console.WriteLine("Printing arguments...");
                foreach (var arg in context.Command.Options)
                {
                    Console.WriteLine($"{arg.Id}: {arg.Value}");
                }
            }

            return Task.FromResult(new CommandRunnerResult());
        }
    }
}
