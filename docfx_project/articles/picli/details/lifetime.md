#### Terminal Lifetime
You can override the following terminal lifetime methods in your application context.

##### [RegisterHostApplicationEventsAsync](xref:PerpetualIntelligence.Terminal.Integration.CliHostedService.RegisterHostApplicationEventsAsync(Microsoft.Extensions.Hosting.IHostApplicationLifetime))
Allows the application to register its custom events. The default implementation registers OnStarted, OnStopping, and OnStopped events that application authors can override.
```
    protected override Task RegisterHostApplicationEventsAsync(IHostApplicationLifetime hostApplicationLifetime)
    {
        // Your custom application event registry.

        return Task.CompletedTask;
    }
```

> **Note:** OnStarted, OnStopping, and OnStopped are not triggered if you override RegisterHostApplicationEventsAsync and register your custom events.

##### [OnStarted](xref:PerpetualIntelligence.Terminal.Integration.CliHostedService.OnStarted)
Triggered when the <c>pi-cli</c> application host has fully started.
```
    protected override void OnStarted()
    {
        Console.WriteLine("Server started on {0}.", DateTime.UtcNow.ToLocalTime().ToString());
        Console.WriteLine();
    }
```
##### [OnStopping](xref:PerpetualIntelligence.Terminal.Integration.CliHostedService.OnStopping)
Triggered when the <c>pi-cli</c> application host is starting a graceful shutdown. Shutdown will block until all callbacks registered on this token have completed.
```
    protected override void OnStopping()
    {
        Console.WriteLine("Stopping server...");
    }
```
##### [OnStopped](xref:PerpetualIntelligence.Terminal.Integration.CliHostedService.OnStopped)
Triggered when the <c>pi-cli</c> application host has completed a graceful shutdown. The application will not exit until all callbacks registered on this token have completed.
```
    protected override void OnStopped()
    {
        ConsoleHelper.WriteLineColor(ConsoleColor.Red, "Server stopped on {0}.", DateTime.UtcNow.ToLocalTime().ToString());
    }
```  

#### Terminal Header
You can override the following method to print the terminal header in your application context.

##### [PrintHostApplicationHeaderAsync](xref:PerpetualIntelligence.Terminal.Integration.CliHostedService.PrintHostApplicationHeaderAsync)
Allows the host application to print the custom header.
```
    protected override Task PrintHostApplicationHeaderAsync()
    {
        Console.WriteLine("Print your CLI terminal header...");
        return Task.CompletedTask;
    }
```

#### Terminal Licensing Information
You can override the following method to print the terminal licensing information in your application context.

##### [PrintHostApplicationLicensingAsync](xref:PerpetualIntelligence.Terminal.Integration.CliHostedService.PrintHostApplicationLicensingAsync(PerpetualIntelligence.Terminal.Licensing.License))
Allows host application to print custom licensing information.
```
    protected override Task PrintHostApplicationLicensingAsync(PerpetualIntelligence.Terminal.Licensing.License license)
    {
        Console.WriteLine("Print your CLI terminal licensing info...");
        return Task.CompletedTask;
    }
```

#### Terminal Options
You can override the following method to perform the terminal configuration options checks.

##### [CheckHostApplicationConfigurationAsync](xref:PerpetualIntelligence.Terminal.Integration.CliHostedService.CheckHostApplicationConfigurationAsync(PerpetualIntelligence.Terminal.Configuration.Options.CliOptions))
Allows the host application to perform additional configuration option checks.
```
    protected override Task CheckHostApplicationConfigurationAsync(PerpetualIntelligence.Terminal.Configuration.Options.CliOptions options)
    {
        // Perform your custom checks here
        return Task.CompletedTask;
    }
```

> **Note:** The `pi-cli` framework performs certain mandatory configuration option checks. Applications cannot customize or change the mandatory configuration option checks, but they can perform additional configuration checks as shown above. For more information see [defaults and limits](defaults.md).


### [ICliBuilder](xref:PerpetualIntelligence.Terminal.Integration.ICliBuilder)
You enable the terminal framework to any .NET, .NET Core, or .NET6+ console application by adding the relevant services to the [dependency injection (DI)](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) system.

```
    public static async Task Main(string[] args)
    {
        // The cancellation token routing commands.
        CancellationTokenSource cancellationTokenSource = new();

        // Setup the host builder
        IHostBuilder hostBuilder = CreateHostBuilder(args, Startup.ConfigureServices);

        // Start the host. We don't call Run as it will block the thread. We want to listen to user inputs.
        using (var host = await hostBuilder.StartAsync(cancellationTokenSource.Token))
        {
            // Run the router loop to listen to the user input and process the command string
            await host.RunRouterAsync("_> ", cancellationTokenSource.Token);
        }
    }

    // Add terminal to the console app
    public void ConfigureServices(IServiceCollection services)
    {
        ICliBuilder builder = services.AddCli(options => { ... });
    }
```