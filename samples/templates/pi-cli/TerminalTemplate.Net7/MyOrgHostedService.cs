using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Configuration.Options;
using PerpetualIntelligence.Terminal.Hosting;
using PerpetualIntelligence.Terminal.Licensing;
using PerpetualIntelligence.Terminal.Runtime;

namespace TerminalTemplate.Net7
{
    /// <summary>
    /// The sample <c>myorg</c> hosted service. This class enables UX customization for your cli terminal.
    /// </summary>
    public class MyOrgHostedService : TerminalHostedService
    {
        private readonly ITerminalConsole terminalConsole;

        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="cliOptions">The configuration options.</param>
        /// <param name="logger">The logger.</param>
        public MyOrgHostedService(IServiceProvider serviceProvider, ITerminalConsole terminalConsole, TerminalOptions cliOptions, ILogger<TerminalHostedService> logger) : base(serviceProvider, cliOptions, logger)
        {
            this.terminalConsole = terminalConsole;
        }

        /// <summary>
        /// Perform custom configuration option checks at startup.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        protected override Task CheckHostApplicationConfigurationAsync(TerminalOptions options)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStarted"/> handler.
        /// </summary>
        protected override void OnStarted()
        {
            Task.WaitAll(
                terminalConsole.WriteLineAsync("Server started on {0}.", DateTime.UtcNow.ToLocalTime().ToString()),
                terminalConsole.WriteLineAsync()
                );
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStopped"/> handler.
        /// </summary>
        protected override void OnStopped()
        {
            terminalConsole.WriteLineColorAsync(ConsoleColor.Red, "Server stopped on {0}.", DateTime.UtcNow.ToLocalTime().ToString()).Wait();
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStopping"/> handler.
        /// </summary>
        protected override void OnStopping()
        {
            terminalConsole.WriteLineAsync("Server stopped on {0}.", DateTime.UtcNow.ToLocalTime().ToString()).Wait();
        }

        /// <summary>
        /// Print <c>cli</c> terminal header.
        /// </summary>
        /// <returns></returns>
        protected override async Task PrintHostApplicationHeaderAsync()
        {
            await terminalConsole.WriteLineAsync("---------------------------------------------------------------------------------------------");
            await terminalConsole.WriteLineAsync("Copyright (c) My Organization. All Rights Reserved.");
            await terminalConsole.WriteLineAsync("For license, terms, and data policies, go to:");
            await terminalConsole.WriteLineAsync("https://sampleyourorgurl.com");
            await terminalConsole.WriteLineAsync("---------------------------------------------------------------------------------------------");

            await terminalConsole.WriteLineAsync($"Starting server myorg version=2.6.1-sample");
        }

        /// <summary>
        /// Print host application licensing information.
        /// </summary>
        /// <param name="license">The extracted license.</param>
        /// <returns></returns>
        protected override async Task PrintHostApplicationLicensingAsync(License license)
        {
            // Print custom licensing info or remove it completely.
            await base.PrintHostApplicationLicensingAsync(license);
        }
    }
}