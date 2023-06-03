using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;

namespace StripeStyleCli.Runners.Login
{
    /// <summary>
    /// The sample <c>stripe login</c> command runner.
    /// </summary>
    public class StripeLoginRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public StripeLoginRunner(TerminalOptions options, ILogger<StripeLoginRunner> logger)
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

            if(context.Command.Options != null)
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
