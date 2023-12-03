/*
    Copyright (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/
// Note:
// - This sample template uses the new .NET 6 minimal hosting model. See https://docs.microsoft.com/en-us/aspnet/core/migration/50-to-60-samples?view=aspnetcore-6.0 for more information.
// - To use the traditional Startup and Program classes, just move this code below in the Main method of the Program.cs or refer to .NET3.1 sample template

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
using PerpetualIntelligence.Terminal.Runtime;
using PerpetualIntelligence.Terminal.Stores.InMemory;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using StripeStyleCli;
using System.Diagnostics;

// Init Serilog
InitSerilog();

// Allows cancellation for the
// <c>pi-cli</c>
// terminal.
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
void ConfigureServices(IServiceCollection services)
{
    services.AddTerminal(options =>
    {
        // Error info
        options.Logging.ObsureInvalidOptions = false;

        // Commands, arguments and options
        options.Parser.OptionAlias = true;
        options.Parser.OptionPrefix = "--";
        options.Parser.OptionAliasPrefix = "-";
        options.Parser.DefaultOptionValue = true;
        options.Parser.DefaultOption = true;
        options.Parser.OptionValueWithIn = "\"";
        options.Parser.OptionValueSeparator = " ";
        options.Parser.Separator = " ";

        // Checkers
        options.Checker.StrictOptionValueType = true;

        // Http
        options.Http.HttpClientName = "stripe-demo";

        // Licensing
        options.Licensing.AuthorizedApplicationId = DemoIdentifiers.terminalDemoAuthorizedApplicationId;
        options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json"; // Download the license file in this location or specify your location
        options.Licensing.ConsumerTenantId = DemoIdentifiers.terminalDemoConsumerTenantId;
        options.Licensing.Subject = DemoIdentifiers.terminalDemoSubject;
        options.Licensing.ProviderId = LicenseProviders.PerpetualIntelligence;
    }).AddExtractor<CommandExtractor, OptionExtractor, DefaultOptionProvider, DefaultOptionValueProvider>()
      .AddOptionChecker<DataAnnotationsOptionDataTypeMapper, OptionChecker>()
      .AddStoreHandler<InMemoryCommandStore>()
      .AddErrorHandler<ErrorHandler, ExceptionHandler>()
      .AddTextHandler<UnicodeTextHandler>()
      .AddCommandDescriptors();

    services.AddHostedService<StripeCliHostedService>();

    services.AddHttpClient("stripe-demo");
}

/// <summary>
/// Creates a host builder.
/// </summary>
/// <param name="args">Options.</param>
/// <param name="configureDelegate"></param>
/// <returns></returns>
static IHostBuilder CreateHostBuilder(string[] args, Action<IServiceCollection> configureDelegate)
{
    return Host.CreateDefaultBuilder(args)
               .UseSerilog()
               .ConfigureServices(configureDelegate)
               .ConfigureLogging(options =>
               {
                   options.ClearProviders();
                   options.AddTerminalLogger<TerminalConsoleLogger>();
               });
}

/// <summary>
/// Initialize a Serilog logger.
/// </summary>
static void InitSerilog()
{
    Activity.DefaultIdFormat = ActivityIdFormat.W3C;

    Console.Title = "stripe cli sample";

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Warning()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Error)
        .MinimumLevel.Override("System", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Error)
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:w5}] {Message:lj}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
        .CreateLogger();
}