using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Configuration.Options;
using PerpetualIntelligence.Cli.Integration;
using PerpetualIntelligence.Cli.Licensing;
using PerpetualIntelligence.Cli.Services;
using System;
using System.Threading.Tasks;

namespace UnicodeCli
{
    /// <summary>
    /// The sample <c>unicode</c> CLI hosted service. This class enables UX customization for the cli terminal.
    /// </summary>
    public class UnicodeHostedService : CliHostedService
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="cliOptions">The configuration options.</param>
        /// <param name="logger">The logger.</param>
        public UnicodeHostedService(IServiceProvider serviceProvider, CliOptions cliOptions, ILogger<UnicodeHostedService> logger) : base(serviceProvider, cliOptions, logger)
        {
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
        protected override Task PrintHostApplicationHeaderAsync()
        {
            Console.WriteLine("Welcome...");
            Console.WriteLine("Build Unicode CLI terminal in any user language like Japanese, Hindi, Marathi, Spanish, French, German, Chinese, etc...");
            ConsoleHelper.WriteLineColor(ConsoleColor.Cyan, "This sample Unicode CLI terminal showcases the Chinese user language...");
            return Task.CompletedTask;
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
