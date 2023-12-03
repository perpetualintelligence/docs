using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Configuration.Options;
using PerpetualIntelligence.Terminal.Hosting;
using PerpetualIntelligence.Terminal.Licensing;
using PerpetualIntelligence.Terminal.Runtime;

namespace DotnetStyleCli
{
    /// <summary>
    /// The sample <c>dotnet</c> CLI hosted service. This class enables UX customization for the cli terminal.
    /// </summary>
    public class DotNetCliHostedService : TerminalHostedService
    {
        private readonly ITerminalConsole terminalConsole;

        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="cliOptions">The configuration options.</param>
        /// <param name="logger">The logger.</param>
        public DotNetCliHostedService(IServiceProvider serviceProvider, ITerminalConsole terminalConsole, TerminalOptions cliOptions, ILogger<DotNetCliHostedService> logger) : base(serviceProvider, cliOptions, logger)
        {
            this.terminalConsole = terminalConsole;
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStarted"/> handler.
        /// </summary>
        protected override void OnStarted()
        {
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStopped"/> handler.
        /// </summary>
        protected override void OnStopped()
        {
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStopping"/> handler.
        /// </summary>
        protected override void OnStopping()
        {
        }

        /// <summary>
        /// Print <c>cli</c> terminal header.
        /// </summary>
        /// <returns></returns>
        protected override async Task PrintHostApplicationHeaderAsync()
        {
            await terminalConsole.WriteLineAsync("Welcome...");
            await terminalConsole.WriteLineAsync("Build enterprise-grade Unicode CLI terminal in standard or custom format.");
            await terminalConsole.WriteLineColorAsync(ConsoleColor.Cyan, "This sample showcases the modern CLI terminal similar to dotnet cli.");
        }

        /// <summary>
        /// Print host application licensing information.
        /// </summary>
        /// <param name="license">The extracted license.</param>
        /// <returns></returns>
        protected override Task PrintHostApplicationLicensingAsync(License license)
        {
            return Task.CompletedTask;
        }
    }
}