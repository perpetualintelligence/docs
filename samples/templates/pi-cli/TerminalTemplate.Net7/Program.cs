using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Shared.Licensing;
using PerpetualIntelligence.Terminal.Commands.Handlers;
using PerpetualIntelligence.Terminal.Extensions;
using PerpetualIntelligence.Terminal.Runtime;
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
    TerminalStartContext startContext = new(new TerminalStartInfo(TerminalStartMode.Console), cancellationTokenSource.Token);
    await host.RunConsoleRoutingAsync(new(startContext));
}

/// <summary>
/// Configures the required <c>pi-cli</c> services.
/// </summary>
static void ConfigureServices(IServiceCollection services)
{
    Console.Title = "pi-cli demo  (.NET 7)";

    services.AddTerminalDefault(options =>
    {
        // Terminal Identifier
        options.Id = "my-terminal-id";

        // Error info
        options.Logging.ObsureInvalidOptions = false;

        // Commands, arguments and options
        options.Extractor.OptionPrefix = "--";
        options.Extractor.OptionAliasPrefix = "-";
        options.Extractor.ValueDelimiter = "\"";
        options.Extractor.OptionValueSeparator = " ";
        options.Extractor.Separator = " ";

        // Checkers
        options.Checker.StrictValueType = true;

        // Http
        options.Http.HttpClientName = "pi-demo";

        // Licensing
        options.Licensing.AuthorizedApplicationId = DemoIdentifiers.PiCliDemoAuthorizedApplicationId;
        options.Licensing.LicenseKey = "C:\\lic\\demo_lic.json"; // Download the license file in this location or specify your location
        options.Licensing.ConsumerTenantId = DemoIdentifiers.PiCliDemoConsumerTenantId;
        options.Licensing.Subject = DemoIdentifiers.PiCliDemoSubject;
        options.Licensing.ProviderId = LicenseProviders.PerpetualIntelligence;
    }).AddTerminalRouting<TerminalConsoleRouting, TerminalConsoleRoutingContext, TerminalConsoleRoutingResult>()
      .AddTerminalConsole<TerminalSystemConsole>()
      .AddStoreHandler<InMemoryCommandStore>()
      .AddTextHandler<UnicodeTextHandler>()
      .AddCommandDescriptors();

    // Add the hosted serce for terminal customization
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

        // Configure the framework
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