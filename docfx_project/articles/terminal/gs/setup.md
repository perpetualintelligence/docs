# Setup
Ensure you have your license file ready. Follow these steps to set up your terminal application with the `OneImlx.Terminal` framework.

## TestApp Setup
The TestApp demonstrates the `OneImlx.Terminal` framework. It's suitable for learning and building terminal applications.

### Steps:
1. **GitHub**: Browse TestApp on [GitHub](https://github.com/perpetualintelligence/terminal/apps)
2. **License**: Clone the `apps` folder and replace our internal development license with your demo or commercial license.
3. **Nuget**: Remove the conditional check in .csproj and use Nuget packages directly.
3. **Build**: Build the TestApp and you can start terminal development.

## Details
You can use the test app to build new terminals or migrate your legacy console apps and modernize them. 

This section explains the code changes in the `TestApp`. To enable `OneImlx.Terminal` you need to:
1. Install NuGet Package
2. Add terminal hosted service
3. Add terminal service
4. Configure your terminal options
5. Use default terminal routing service or implement your custom routing service
6. Add command runners
7. Stop the router

### Install NuGet Package
The `OneImlx.Terminal` framework is accessible by installing the following Nuget package.

[![Nuget](https://img.shields.io/nuget/vpre/OneImlx.Terminal?label=OneImlx.Terminal)](https://www.nuget.org/packages/OneImlx.Terminal)
[![Nuget](https://img.shields.io/nuget/vpre/OneImlx.Terminal?label=OneImlx.Terminal.Authentication)](https://www.nuget.org/packages/OneImlx.Terminal.Authentication)

Apart from that you will need the following nuget packges:

[![Nuget](https://img.shields.io/nuget/v/Microsoft.Extensions.Hosting?label=Microsoft.Extensions.Hosting)](https://www.nuget.org/packages/Microsoft.Extensions.Hosting)

> **Note**: Remove the `DEV CONFIG:` from the the .csproj file and add our Nuget package directly. This project reference is for our internal development.

```
    <!--
        DEV CONFIG: REMOVE THIS SECTION IN YOUR APP AND ONLY ADD NUGET PACKAGE REFERENCE
    -->
    <Choose>
        <When Condition="'$(PI_CI_REFERENCE)'=='cross'">
            <ItemGroup>
                <ProjectReference Include="..\..\src\OneImlx.Terminal.Authentication\OneImlx.Terminal.Authentication.csproj" />
            </ItemGroup>
        </When>
        <Otherwise>
            <ItemGroup>
                <PackageReference Include="OneImlx.Terminal.Authentication" Version="5.8.5-rc.253242921" />
            </ItemGroup>
        </Otherwise>
    </Choose>
```

### Add Terminal Hosted Service
The @OneImlx.Terminal.Hosting.TerminalHostedService is a hosted service that manages application lifetime, performs licensing, configuration checks, and enables terminal UX customization.

The example below shows the default console view when you run the `TestApp`. You can customize it by overriding the methods shown below.

![Hostedservice](../../../images/terminal/templates/add-hosted-service.png)

```
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OneImlx.Terminal.Configuration.Options;
using OneImlx.Terminal.Hosting;
using OneImlx.Terminal.Licensing;
using OneImlx.Terminal.Runtime;

namespace OneImlx.Terminal.Apps.TestApp
{
    /// <summary>
    /// The <see cref="TerminalHostedService"/> for the test app.
    /// </summary>
    public sealed class TestAppHostedService : TerminalHostedService
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="serviceProvider">The DI service provider.</param>
        /// <param name="options">The terminal configuration options.</param>
        /// <param name="terminalConsole">The terminal console.</param>
        /// <param name="logger">The logger.</param>
        public TestAppHostedService(
            IServiceProvider serviceProvider,
            TerminalOptions options,
            ITerminalConsole terminalConsole,
            ILogger<TerminalHostedService> logger) : base(serviceProvider, options, terminalConsole, logger)
        {
        }

        /// <summary>
        /// Perform custom configuration option checks at startup.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        protected override Task CheckHostApplicationConfigurationAsync(TerminalOptions options)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStarted"/> handler.
        /// </summary>
        protected override void OnStarted()
        {
            // These are async calls, but we are blocking here for as the  of the test.
            TerminalConsole.WriteLineAsync("Application started on {0}.", DateTime.UtcNow.ToLocalTime().ToString()).Wait();
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStopped"/> handler.
        /// </summary>
        protected override void OnStopped()
        {
            TerminalConsole.WriteLineColorAsync(ConsoleColor.Red, "Application stopped on {0}.", DateTime.UtcNow.ToLocalTime().ToString()).Wait();
        }

        /// <summary>
        /// The <see cref="IHostApplicationLifetime.ApplicationStopping"/> handler.
        /// </summary>
        protected override void OnStopping()
        {
            TerminalConsole.WriteLineAsync("Stopping application...").Wait();
        }

        /// <summary>
        /// Print <c>cli</c> terminal header.
        /// </summary>
        /// <returns></returns>
        protected override async Task PrintHostApplicationHeaderAsync()
        {
            await TerminalConsole.WriteLineAsync("---------------------------------------------------------------------------------------------");
            await TerminalConsole.WriteLineAsync("Copyright (c) Test App. All Rights Reserved.");
            await TerminalConsole.WriteLineAsync("For license, terms, and data policies, go to:");
            await TerminalConsole.WriteLineAsync("https://mytestapp.com");
            await TerminalConsole.WriteLineAsync("---------------------------------------------------------------------------------------------");

            await TerminalConsole.WriteLineAsync($"Starting application...");
        }

        /// <summary>
        /// Print host application licensing information.
        /// </summary>
        /// <param name="license">The extracted license.</param>
        /// <returns></returns>
        protected override Task PrintHostApplicationLicensingAsync(License license)
        {
            // Print custom licensing info or remove it completely.
            return base.PrintHostApplicationLicensingAsync(license);
        }
    }
}
```

### Add `OneImlx.Terminal` and configure the options
You enable `OneImlx.Terminal` framework by adding the DI services in your `Program.cs` file. This example code shows the default configuration when you run the template.

```
/// <summary>
/// Configures the required <c>OneImlx.Terminal</c> services.
/// </summary>
void ConfigureServices(IServiceCollection services)
{
    Console.Title = "terminal demo  (.NET 6)";

    services.AddCli(options =>
    {
        // Error info
        options.Logging.ObsureErrorArguments = false;

        // Commands, arguments and options
        options.Parser.ArgumentAlias = true;
        options.Parser.ArgumentPrefix = "--";
        options.Parser.ArgumentAliasPrefix = "-";
        options.Parser.DefaultArgumentValue = true;
        options.Parser.DefaultArgument = true;
        options.Parser.ArgumentValueWithIn = "\"";
        options.Parser.ArgumentValueSeparator = " ";
        options.Parser.Separator = " ";

        // Checkers
        options.Checker.StrictArgumentValueType = true;

        // Http
        options.Http.HttpClientName = "onedemo";

        // Licensing
        options.Licensing.AuthorizedApplicationId = DemoIdentifiers.terminalDemoAuthorizedApplicationId;
        options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json"; // Download the license file in this location or specify your location
        options.Licensing.ConsumerTenantId = DemoIdentifiers.terminalDemoConsumerTenantId;
        options.Licensing.Subject = DemoIdentifiers.terminalDemoSubject;
        options.Licensing.ProviderId = LicenseProviders.PerpetualIntelligence;
    }).AddExtractor<CommandExtractor, ArgumentExtractor, DefaultArgumentProvider, DefaultArgumentValueProvider>()
      .AddArgumentChecker<DataAnnotationsArgumentDataTypeMapper, ArgumentChecker>()
      .AddStoreHandler<InMemoryCommandStore>()
      .AddErrorHandler<ErrorHandler, ExceptionHandler>()
      .AddTextHandler<UnicodeTextHandler>()
      .AddCommandDescriptors();

    // Add the terminal hosted serce for terminal customization
    services.AddHostedService<MyOrgHostedService>();

    // Add the HTTP client factory to perform license checks
    services.AddHttpClient("onedemo");

    // Add custom DI services
    services.AddScoped<IIdGeneratorSampleService, DefaultIdGeneratorSampleService>();
}
```
### Add descriptors and runners
The template contains a `MyOrgCommandRegistry.cs` file to register all the commands and argument descriptors. This class can be easily unit tested natively with MSTest, xUnit, or other test frameworks.

> **Note**: A command descriptor has a command runner type and an optional custom command checker.

For runners, we recommend you create the `Runners` folder and place all your command runners in a subdirectory as per their command prefix.

Example:
`myorg gen id`  command string has a runner in `\Runners\MyOrg\Gen\Id` folder. It enables having a clear separation of concerns for each command, and you can also have custom services for your command at the same place.

![Hostedservice](../../../images/terminal/templates/runners.png)


### Add handlers and checkers
The template will register various default handlers and checkers. You can provide custom handler implementations as per your application needs. For more information see [handlers](../concepts/handlers.md) and [checkers](../concepts/checkers.md).
```
.AddArgumentChecker<DataAnnotationsArgumentDataTypeMapper, ArgumentChecker>()
.AddStoreHandler<InMemoryCommandStore>()
.AddErrorHandler<ErrorHandler, ExceptionHandler>()
.AddTextHandler<UnicodeTextHandler>()
```

By default, the `OneImlx.Terminal` terminal supports Unicode text handler. You can build your CLI terminals for any Unicode supported `left-to-right` langauge.

### Start command router
The last step is to start the command router in the `Main` method to receive and run the user commands. 

![Hostedservice](../../../images/terminal/templates/start-router.png)

```
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
```

### Stop command router
You can stop the command router explicitly or programmatically in the following ways:
- User can send the standard `CNTRL+C` signal to the hosted service 
- User can use the `exit` command to issue a cancellation token
- Application can programmatically issue a cancellation token 

![Hostedservice](../../../images/terminal/templates/stop-router.png)

