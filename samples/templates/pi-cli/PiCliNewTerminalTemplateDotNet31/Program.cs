/*
    Copyright (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com
*/

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Extractors;
using PerpetualIntelligence.Cli.Commands.Handlers;
using PerpetualIntelligence.Cli.Commands.Mappers;
using PerpetualIntelligence.Cli.Commands.Providers;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Stores.InMemory;
using PerpetualIntelligence.Protocols.Licensing;
using PiCliNewTerminalTemplateDotNet31.Runners.MyOrg.Gen.Id;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PiCliNewTerminalTemplateDotNet31
{
    internal class Program
    {
        /// <summary>
        /// Configures the required <c>pi-cli</c> services.
        /// </summary>
        private static void ConfigureServices(IServiceCollection services)
        {
            Console.Title = "pi-cli demo (.NET 3.1)";

            services.AddCli(options =>
            {
                // Error info
                options.Logging.ObsureErrorArguments = false;

                // Commands, arguments and options
                options.Extractor.ArgumentAlias = true;
                options.Extractor.ArgumentPrefix = "--";
                options.Extractor.ArgumentAliasPrefix = "-";
                options.Extractor.DefaultArgumentValue = true;
                options.Extractor.DefaultArgument = true;
                options.Extractor.ArgumentValueWithIn = "\"";
                options.Extractor.ArgumentValueSeparator = " ";
                options.Extractor.Separator = " ";

                // Checkers
                options.Checker.StrictArgumentValueType = true;

                // Http
                options.Http.HttpClientName = "pi-demo";

                // Licensing
                options.Licensing.AuthorizedApplicationId = DemoIdentifiers.PiCliDemoAuthorizedApplicationId;
                options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json"; // Download the license file in this location or specify your location
                options.Licensing.ConsumerTenantId = DemoIdentifiers.PiCliDemoConsumerTenantId;
                options.Licensing.Subject = DemoIdentifiers.PiCliDemoSubject;
                options.Licensing.ProviderId = LicenseProviders.PerpetualIntelligence;
            }).AddExtractor<CommandExtractor, ArgumentExtractor, DefaultArgumentProvider, DefaultArgumentValueProvider>()
              .AddArgumentChecker<DataAnnotationsArgumentDataTypeMapper, ArgumentChecker>()
              .AddStoreHandler<InMemoryCommandStore>()
              .AddErrorHandler<ErrorHandler, ExceptionHandler>()
              .AddTextHandler<UnicodeTextHandler>()
              .AddCommandDescriptors();

            // Add the pi-cli hosted serce for terminal customization
            services.AddHostedService<MyOrgHostedService>();

            // Add the HTTP client factory to perform license checks
            services.AddHttpClient("pi-demo");

            // Add custom DI services
            services.AddScoped<IIdGeneratorSampleService, DefaultIdGeneratorSampleService>();
        }

        /// <summary>
        /// Creates a host builder.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <param name="configurePiCli"></param>
        /// <returns></returns>
        private static IHostBuilder CreateHostBuilder(string[] args, Action<IServiceCollection> configurePiCli)
        {
            return Host.CreateDefaultBuilder(args)

                // Configure the pi-cli framework
                .ConfigureServices(configurePiCli)

                // Configure terminal logging based on your application need.
                .ConfigureLogging(logging =>
                {
                    logging.AddFilter("System", LogLevel.Error);
                    logging.AddFilter("Microsoft", LogLevel.Error);
                    logging.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.Error);
                    logging.AddFilter("Microsoft.AspNetCore.Authentication", LogLevel.Error);
                });
        }

        private static async Task Main(string[] args)
        {
            // Allows cancellation for the terminal.
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            // Setup the host builder.
            IHostBuilder hostBuilder = CreateHostBuilder(args, ConfigureServices);

            // Start the host. We don't call Run as it will block the thread. We want to listen to user inputs.
            using (var host = await hostBuilder.StartAsync(cancellationTokenSource.Token))
            {
                await host.RunRouterAsync("$ ", cancellationTokenSource.Token);
            }
        }
    }
}
