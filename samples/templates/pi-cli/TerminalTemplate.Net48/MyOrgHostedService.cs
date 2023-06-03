using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Terminal.Configuration.Options;
using PerpetualIntelligence.Terminal.Hosting;
using PerpetualIntelligence.Terminal.Licensing;
using PerpetualIntelligence.Terminal.Services;
using System;
using System.Threading.Tasks;

namespace TerminalTemplate.Net48
{
    /// <summary>
    /// The sample <c>myorg</c> hosted service. This class enables UX customization for your cli terminal.
    /// </summary>
    public class MyOrgHostedService : TerminalHostedService
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="cliOptions">The configuration options.</param>
        /// <param name="logger">The logger.</param>
        public MyOrgHostedService(IServiceProvider serviceProvider, TerminalOptions cliOptions, ILogger<MyOrgHostedService> logger) : base(serviceProvider, cliOptions, logger)
        {
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
            Console.WriteLine("Server started on {0}.", DateTime.UtcNow.ToLocalTime().ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStopped"/> handler.
        /// </summary>
        protected override void OnStopped()
        {
            ConsoleHelper.WriteLineColor(ConsoleColor.Red, "Server stopped on {0}.", DateTime.UtcNow.ToLocalTime().ToString());
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStopping"/> handler.
        /// </summary>
        protected override void OnStopping()
        {
            Console.WriteLine("Stopping server...");
        }

        /// <summary>
        /// Print <c>cli</c> terminal header.
        /// </summary>
        /// <returns></returns>
        protected override Task PrintHostApplicationHeaderAsync()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Copyright (c) My Organization. All Rights Reserved.");
            Console.WriteLine("For license, terms, and data policies, go to:");
            Console.WriteLine("https://sampleyourorgurl.com");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            Console.WriteLine($"Starting server myorg version=2.6.1-sample");
            return Task.CompletedTask;
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