/*
    Copyright (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Shared.Licensing;
using PerpetualIntelligence.Terminal.Commands.Checkers;
using PerpetualIntelligence.Terminal.Commands.Extractors;
using PerpetualIntelligence.Terminal.Commands.Handlers;
using PerpetualIntelligence.Terminal.Commands.Mappers;
using PerpetualIntelligence.Terminal.Commands.Providers;
using PerpetualIntelligence.Terminal.Commands.Routers;
using PerpetualIntelligence.Terminal.Extensions;
using PerpetualIntelligence.Terminal.Stores.InMemory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnicodeCli
{
    internal class Program
    {
        /// <summary>
        /// Configures the required <c>pi-cli</c> services.
        /// </summary>
        private static void ConfigureServices(IServiceCollection services)
        {
            // Ensure unicode encoding
            Console.Title = "unicode cli sample";
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            services.AddTerminal(options =>
            {
                // Error info
                options.Logging.ObsureInvalidOptions = false;

                // Commands, arguments and options
                options.Extractor.OptionAlias = true;
                options.Extractor.OptionPrefix = "--";
                options.Extractor.OptionAliasPrefix = "-";
                options.Extractor.DefaultOptionValue = true;
                options.Extractor.DefaultOption = true;
                options.Extractor.OptionValueWithIn = "\"";
                options.Extractor.OptionValueSeparator = " ";
                options.Extractor.Separator = " ";

                // Checkers
                options.Checker.StrictOptionValueType = true;

                // Http
                options.Http.HttpClientName = "unicode-demo";

                // Licensing
                options.Licensing.AuthorizedApplicationId = DemoIdentifiers.PiCliDemoAuthorizedApplicationId;
                options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json"; // Download the license file in this location or specify your location
                options.Licensing.ConsumerTenantId = DemoIdentifiers.PiCliDemoConsumerTenantId;
                options.Licensing.Subject = DemoIdentifiers.PiCliDemoSubject;
                options.Licensing.ProviderId = LicenseProviders.PerpetualIntelligence;
            }).AddRoutingService<ConsoleRoutingService>()
              .AddExtractor<CommandExtractor, OptionExtractor, DefaultOptionProvider, DefaultOptionValueProvider>()
              .AddOptionChecker<DataAnnotationsOptionDataTypeMapper, OptionChecker>()
              .AddStoreHandler<InMemoryCommandStore>()
              .AddErrorHandler<ErrorHandler, ExceptionHandler>()
              .AddTextHandler<UnicodeTextHandler>()
              .AddCommandDescriptors();

            services.AddHostedService<UnicodeHostedService>();

            services.AddHttpClient("unicode-demo");
        }

        /// <summary>
        /// Creates a host builder.
        /// </summary>
        /// <param name="args">Options.</param>
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
            // Allows cancellation for the pi-cli terminal.
            CancellationTokenSource cancellationTokenSource = new();

            // Setup the host builder.
            IHostBuilder hostBuilder = CreateHostBuilder(args, ConfigureServices);

            // Start the host. We don't call Run as it will block the thread. We want to listen to user inputs.
            using (var host = await hostBuilder.StartAsync(cancellationTokenSource.Token))
            {
                await host.RunRouterAsTerminalAsync(new RoutingServiceContext(cancellationTokenSource.Token));
            }
        }
    }
}