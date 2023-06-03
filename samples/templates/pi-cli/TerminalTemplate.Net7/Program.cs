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
using TerminalTemplate.Net7;
using TerminalTemplate.Net7.Runners.MyOrg.Gen.Id;

// Allows cancellation for the terminal.
CancellationTokenSource cancellationTokenSource = new();

// Setup the host builder.
IHostBuilder hostBuilder = CreateHostBuilder(args, ConfigureServices);

// Start the host. We don't call Run as it will block the thread. We want to listen to user inputs.
using (var host = await hostBuilder.StartAsync(cancellationTokenSource.Token))
{
    await host.RunRouterAsTerminalAsync(new RoutingServiceContext(cancellationTokenSource.Token));
}

/// <summary>
/// Configures the required <c>pi-cli</c> services.
/// </summary>
static void ConfigureServices(IServiceCollection services)
{
    Console.Title = "pi-cli demo  (.NET 7)";

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
        options.Http.HttpClientName = "pi-demo";

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
      .AddCommands();

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
static IHostBuilder CreateHostBuilder(string[] args, Action<IServiceCollection> configurePiCli)
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