using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Commands;
using PerpetualIntelligence.Terminal.Commands.Checkers;
using PerpetualIntelligence.Terminal.Commands.Routers;
using PerpetualIntelligence.Terminal.Commands.Runners;
using PerpetualIntelligence.Terminal.Events;
using PerpetualIntelligence.Terminal.Runtime;
using System.Threading.Tasks;

namespace TerminalTemplate.Net7
{
    /// <summary>
    /// The example terminal event handler.
    /// </summary>
    public class EventHandler : ITerminalEventHandler
    {
        private readonly ITerminalConsole terminalConsole;
        private readonly ILogger<EventHandler> logger;

        public EventHandler(ITerminalConsole terminalConsole, ILogger<EventHandler> logger)
        {
            this.terminalConsole = terminalConsole;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public Task AfterCommandCheckAsync(Command command, CommandCheckerResult result)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task AfterCommandRouteAsync(CommandRoute commandRoute, Command? command, CommandRouterResult? result)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task AfterCommandRunAsync(Command command, CommandRunnerResult result)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task BeforeCommandCheckAsync(Command command)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task BeforeCommandRouteAsync(CommandRoute commandRoute)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task BeforeCommandRunAsync(Command command)
        {
            return Task.CompletedTask;
        }
    }
}