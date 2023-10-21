using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Configuration.Options;

namespace StripeStyleCli.Runners
{
    /// <summary>
    /// The sample <c>stripe</c> command runner.
    /// </summary>
    public class StripeRunner : CommandRunner<CommandRunnerResult>
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        public StripeRunner(TerminalOptions options, ILogger<StripeRunner> logger)
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
            Console.WriteLine("The SAMPLE Stripe CLI tutorial");

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
