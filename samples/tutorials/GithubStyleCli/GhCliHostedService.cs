using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Configuration.Options;
using PerpetualIntelligence.Cli.Integration;
using PerpetualIntelligence.Cli.Licensing;

namespace GithubStyleCli
{
    /// <summary>
    /// The sample <c>gh cli</c> hosted service. This class enables UX customization for the cli terminal.
    /// </summary>
    public class GhCliHostedService : CliHostedService
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="hostApplicationLifetime">The host application lifetime service.</param>
        /// <param name="licenseExtractor">The license extractor.</param>
        /// <param name="licenseChecker">The license checker.</param>
        /// <param name="cliOptions">The configuration options.</param>
        /// <param name="logger">The logger.</param>
        public GhCliHostedService(IHost host, IHostApplicationLifetime hostApplicationLifetime, ILicenseExtractor licenseExtractor, ILicenseChecker licenseChecker, CliOptions cliOptions, ILogger<CliHostedService> logger) : base(host, hostApplicationLifetime, licenseExtractor, licenseChecker, cliOptions, logger)
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
            Console.WriteLine("Overriding PrintHostApplicationHeaderAsync to print custom headers... ");
            return Task.CompletedTask;
        }

        /// <summary>
        /// Print host application licensing information.
        /// </summary>
        /// <param name="license">The extracted license.</param>
        /// <returns></returns>
        protected override Task PrintHostApplicationLicensingAsync(License license)
        {
            Console.WriteLine("Overriding PrintHostApplicationLicensingAsync to print custom licensing information... ");
            return Task.CompletedTask;
        }
    }
}
