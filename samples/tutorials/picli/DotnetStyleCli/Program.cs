// Note:
// - This sample template uses the new .NET 6 minimal hosting model. See https://docs.microsoft.com/en-us/aspnet/core/migration/50-to-60-samples?view=aspnetcore-6.0 for more information.
// - To use the traditional Startup and Program classes, just move this code below in the Main method of the Program.cs or refer to .NET3.1 sample template

using DotnetStyleCli;
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

// Init Serilog
InitSerilog();

// Allows cancellation for the terminal.
CancellationTokenSource cancellationTokenSource = new();

// Setup the host builder.
IHostBuilder hostBuilder = CreateHostBuilder(args, ConfigureServices);

// Start the host. We don't call Run as it will block the thread. We want to listen to user inputs.
using (var host = await hostBuilder.StartAsync(cancellationTokenSource.Token))
{
    await host.RunTerminalRoutingAsync <TerminalConsoleRouting, TerminalConsoleRoutingContext> (new ( new TerminalStartContext( new TerminalStartInfo(TerminalStartMode.Console), cancellationTokenSource.Token)));
}

/// <summary>
/// Configures the required <c>pi-cli</c> services.
/// </summary>
void ConfigureServices(IServiceCollection services)
{
    services.AddTerminalConsole<InMemoryCommandStore, AsciiTextHandler, HelpConsoleProvider, TerminalSystemConsole>(options =>
    {
        // Commands, arguments and options
        options.Parser.OptionPrefix = "--";
        options.Parser.OptionAliasPrefix = "-";
        options.Parser.ValueDelimiter = "\"";
        options.Parser.OptionValueSeparator = " ";
        options.Parser.Separator = " ";

        // Checkers
        options.Checker.StrictValueType = true;

        // Http
        options.Http.HttpClientName = "dt-demo";

        // Licensing
        options.Licensing.AuthorizedApplicationId = DemoIdentifiers.TerminalDemoAuthorizedApplicationId;
        options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json"; // Download the license file in this location or specify your location
        options.Licensing.ConsumerTenantId = DemoIdentifiers.TerminalDemoConsumerTenantId;
        options.Licensing.Subject = DemoIdentifiers.TerminalDemoSubject;
    }).AddCommandDescriptors();

    services.AddHostedService<DotNetCliHostedService>();

    services.AddHttpClient("dt-demo");
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
               });
}

/// <summary>
/// Initialize a Serilog logger.
/// </summary>
static void InitSerilog()
{
    Activity.DefaultIdFormat = ActivityIdFormat.W3C;

    Console.Title = "dotnet cli sample";

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Warning()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Error)
        .MinimumLevel.Override("System", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Error)
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:w4}] {Message:lj}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
        .CreateLogger();
}