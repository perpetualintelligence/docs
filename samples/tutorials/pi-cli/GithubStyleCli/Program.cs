﻿// Note: This sample tutorial uses the minimal hosting model. See
// https://docs.microsoft.com/en-us/aspnet/core/migration/50-to-60-samples?view=aspnetcore-6.0 for more information. To
// use the traditional Startup and Program classes, just move this code below in the Main method of the Program.cs
using GithubStyleCli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PerpetualIntelligence.Cli.Commands.Checkers;
using PerpetualIntelligence.Cli.Commands.Extractors;
using PerpetualIntelligence.Cli.Commands.Handlers;
using PerpetualIntelligence.Cli.Commands.Mappers;
using PerpetualIntelligence.Cli.Commands.Providers;
using PerpetualIntelligence.Cli.Extensions;
using PerpetualIntelligence.Cli.Stores.InMemory;
using PerpetualIntelligence.Protocols.Licensing;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Diagnostics;

// Init Serilog
InitSerilog();

// Allows cancellation for the
// <c>pi-cli</c>
// terminal.
CancellationTokenSource cancellationTokenSource = new();

// Setup the host builder.
IHostBuilder hostBuilder = CreateHostBuilder(args, ConfigureServices).UseSerilog();

// Start the host. We don't call Run as it will block the thread. We want to listen to user inputs. https://stackoverflow.com/questions/51357799/host-net-core-console-application-like-windows-service
using (var host = await hostBuilder.StartAsync(cancellationTokenSource.Token))
{
    await host.RunRouterAsync("$ ", cancellationTokenSource.Token);
}

/// <summary>
/// Configures the requires <c>pi-cli</c> services.
/// </summary>
void ConfigureServices(IServiceCollection services)
{
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
        options.Checker.StrictArgumentValueType = false;

        // Http
        options.Http.HttpClientName = "gh-demo";

        // Licensing
        options.Licensing.AuthorizedApplicationId = DemoIdentifiers.PiCliDemoAuthorizedApplicationId;
        options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json"; // Download the license file in this location or specify your location 
        options.Licensing.ConsumerTenantId = DemoIdentifiers.PiCliDemoConsumerTenantId;
        options.Licensing.Subject = DemoIdentifiers.PiCliDemoSubject;
        options.Licensing.ProviderId = SaaSProviders.PerpetualIntelligence;

    }).AddExtractor<CommandExtractor, ArgumentExtractor, DefaultArgumentProvider, DefaultArgumentValueProvider>()
      .AddArgumentChecker<DataAnnotationsArgumentDataTypeMapper, ArgumentChecker>()
      .AddDescriptorStore<InMemoryCommandDescriptorStore>()
      .AddErrorHandler<ErrorHandler, ExceptionHandler>()
      .AddStringComparer(StringComparison.Ordinal)
      .AddCommandDescriptors();

    services.AddHostedService<GhCliHostedService>();

    services.AddHttpClient("gh-demo");
}

/// <summary>
/// Creates a host builder.
/// </summary>
/// <param name="args">Arguments.</param>
/// <param name="configureDelegate"></param>
/// <returns></returns>
static IHostBuilder CreateHostBuilder(string[] args, Action<IServiceCollection> configureDelegate)
{
    // https://www.programmingwithwolfgang.com/configure-dependency-injection-for-net-5-console-applications/
    return Host.CreateDefaultBuilder(args).ConfigureServices(configureDelegate);
}

/// <summary>
/// Initialize a Serilog logger.
/// </summary>
static void InitSerilog()
{
    Activity.DefaultIdFormat = ActivityIdFormat.W3C;

    Console.Title = "gh cli sample";

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
