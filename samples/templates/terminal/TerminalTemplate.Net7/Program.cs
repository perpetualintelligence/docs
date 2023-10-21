using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerpetualIntelligence.Shared.Licensing;
using PerpetualIntelligence.Terminal.Commands.Handlers;
using PerpetualIntelligence.Terminal.Commands.Providers;
using PerpetualIntelligence.Terminal.Extensions;
using PerpetualIntelligence.Terminal.Runtime;
using PerpetualIntelligence.Terminal.Stores;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Diagnostics;
using TerminalTemplate.Net7;
using TerminalTemplate.Net7.Runners.MyOrg.Gen.Id;

// Allows cancellation for the terminal.
CancellationTokenSource cancellationTokenSource = new();

// Init Serilog
InitSerilog();

// Setup the host builder.
IHostBuilder hostBuilder = CreateHostBuilder(args, ConfigureServices);

// Start the host. We don't call Run as it will block the thread. We want to listen to user inputs.
using (var host = await hostBuilder.StartAsync(cancellationTokenSource.Token))
{
    TerminalStartContext startContext = new(new TerminalStartInfo(TerminalStartMode.Console), cancellationTokenSource.Token);
    await host.RunTerminalRoutingAsync<TerminalConsoleRouting, TerminalConsoleRoutingContext>(new(startContext));
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
        options.Licensing.AuthorizedApplicationId = DemoIdentifiers.TerminalDemoAuthorizedApplicationId;
        options.Licensing.LicenseKey = "C:\\lic\\demo_lic.json"; // Download the license file in this location or specify your location
        options.Licensing.ConsumerTenantId = DemoIdentifiers.TerminalDemoConsumerTenantId;
        options.Licensing.Subject = DemoIdentifiers.TerminalDemoSubject;
    }).AddRouting<TerminalConsoleRouting, TerminalConsoleRoutingContext>()
      .AddConsole<TerminalSystemConsole>()
      .AddStoreHandler<InMemoryCommandStore>()
      .AddTextHandler<UnicodeTextHandler>()
      .AddHelpProvider<HelpLoggerProvider>()
      .AddCommandDescriptors();

    // Add the hosted service for terminal customization
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
static IHostBuilder CreateHostBuilder(string[] args, Action<IServiceCollection> configureTerminal)
{
    return Host.CreateDefaultBuilder(args)

        // Configure the framework
        .ConfigureServices(configureTerminal)

        // Configure terminal logging based on your application need.
        .ConfigureLogging(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Information);
            logging.ClearProviders();
            logging.AddFilter("System", LogLevel.Error);
            logging.AddFilter("Microsoft", LogLevel.Error);
            logging.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.Error);
            logging.AddFilter("Microsoft.AspNetCore.Authentication", LogLevel.Error);
        })

        // Enable Serilog
       .UseSerilog();
}

static void InitSerilog()
{
    Activity.DefaultIdFormat = ActivityIdFormat.W3C;

    Console.Title = PerpetualIntelligence.Shared.Constants.TerminalUrn;

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Error)
        .MinimumLevel.Override("System", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Error)
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: "[{Timestamp:yy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
        .CreateLogger();
}