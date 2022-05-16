# Concepts

## [Terminal](xref:PerpetualIntelligence.Cli.Terminal)
Terminals, also known as command lines, consoles, or CLI applications, allow organizations and users to accomplish and automate tasks on a computer without using a graphical user interface. If a CLI app supports user interaction, the UX is the terminal.

## [Commands](xref:PerpetualIntelligence.Cli.Commands)
The <a href="xref:PerpetualIntelligence.Cli.Commands?displayProperty=fullName"/> namespace defines all the code constructs to describe the command and its arguments, extract command from the command string, route to the registered command handler, perform data type and strict type checks, and finally run the command.

### [CommandString](xref:PerpetualIntelligence.Cli.Commands.CommandString)
The <a href="xref:PerpetualIntelligence.Cli.Commands.CommandString?displayProperty=fullName"/> class is an immutable Unicode textual form representing the command and its arguments or options that a user or an application wants to execute.

Example:
> gh issue list
> 
> gh issue create --label bug
> 
> dotnet build --runtime ubuntu.18.04-x64

### [CommandDescriptor](xref:PerpetualIntelligence.Cli.Commands.CommandDescriptor)
The <a href="xref:PerpetualIntelligence.Cli.Commands.CommandDescriptor?displayProperty=fullName"/> class defines the command identity and its supported arguments that an end-user or an application can use. You can also describe the command behavior, such as whether the command is a root, grouped, or subcommand.

#### Root Command
A root command is the top CLI command. It can represent your organization, a product, or a service. For instance, Github CLI [gh](https://cli.github.com/manual/gh) is an example of an organization root command. Microsoft, however, uses [dotnet](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet) as a root command for the .NET CLI. 

#### Grouped Command
A grouped command provides a context for a set of related sub-commands. For instance, Github CLI [gh auth](https://cli.github.com/manual/gh_auth) is an example of a grouped command to authenticate gh and git with GitHub. 

#### Sub Command
A subcommand is an individual executable command that performs a specific action. For instance, Github CLI [gh auth login](https://cli.github.com/manual/gh_auth_login) is an example of a subcommand that authenticates with GitHub host. [dotnet build](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build) is a sub-command that builds a project and all of its dependencies.

> **Note:** A command is a subcommand unless you designate it as a root or a grouped command.

### [Command](xref:PerpetualIntelligence.Cli.Commands.Command)
The <a href="xref:PerpetualIntelligence.Cli.Commands.Command?displayProperty=fullName"/> class is a runtime validated representation of an actual command and its argument values passed by a user or an application. It represents a specific action or a set of actions that a user or an application requests the underlying system to perform. It can be a simple action such as invoking a system method or an OS command or representing a complex operation that calls a set of protected APIs over the internal or external network. A command can virtually do anything in the context of your application or service.

### [ArgumentDescriptor](xref:PerpetualIntelligence.Cli.Commands.ArgumentDescriptor)
The <a href="xref:PerpetualIntelligence.Cli.Commands.ArgumentDescriptor?displayProperty=fullName"/> class defines the command argument identity, data type, and data validation behavior. We also refer to arguments as command options or command flags. An argument <xref:PerpetualIntelligence.Cli.Commands.ArgumentDescriptor.Id> is always unique within a command. By design it implements the default equality <xref:System.IEquatable`1> using <xref:PerpetualIntelligence.Cli.Commands.ArgumentDescriptor.Id> property. Thus, two arguments with the same id are equal irrespective of other property values. This is done to improve performance during lookup and avoid multiple arguments with same identifiers.

### [Argument](xref:PerpetualIntelligence.Cli.Commands.Argument)
The <a href="xref:PerpetualIntelligence.Cli.Commands.Argument?displayProperty=fullName"/> is a runtime validated representation of an actual command argument, option, or a flag and its value passed by a user or an application.

## [Integration](xref:PerpetualIntelligence.Cli.Integration)
The <a href="xref:PerpetualIntelligence.Cli.Integration?displayProperty=fullName"/> namespace defines all the code constructs to integrate your CLI terminal with the pi-cli framework. It provides a service builder for [dependency injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) and hosts a service to manage terminal lifetime and customization.

### [CliHostedService](xref:PerpetualIntelligence.Cli.Integration.CliHostedService)
The <a href="xref:PerpetualIntelligence.Cli.Integration.CliHostedService?displayProperty=fullName"/> is a hosted service that manages application lifetime, performs licensing and configuration checks, and enables terminal UX customization.

#### Terminal Lifetime
You can override the following terminal lifetime methods in your application context.

##### [RegisterHostApplicationEventsAsync](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.RegisterHostApplicationEventsAsync(Microsoft.Extensions.Hosting.IHostApplicationLifetime))
Allows the application to register its custom events. The default implementation registers OnStarted, OnStopping, and OnStopped events that application authors can override.
```
    protected override Task RegisterHostApplicationEventsAsync(IHostApplicationLifetime hostApplicationLifetime)
    {
        // Your custom application event registry.

        return Task.CompletedTask;
    }
```

> **Note:** OnStarted, OnStopping, and OnStopped are not triggered if you override RegisterHostApplicationEventsAsync and register your custom events.

##### [OnStarted](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.OnStarted)
Triggered when the <c>pi-cli</c> application host has fully started.
```
    protected override void OnStarted()
    {
        Console.WriteLine("Server started on {0}.", DateTime.UtcNow.ToLocalTime().ToString());
        Console.WriteLine();
    }
```
##### [OnStopping](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.OnStopping)
Triggered when the <c>pi-cli</c> application host is starting a graceful shutdown. Shutdown will block until all callbacks registered on this token have completed.
```
    protected override void OnStopping()
    {
        Console.WriteLine("Stopping server...");
    }
```
##### [OnStopped](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.OnStopped)
Triggered when the <c>pi-cli</c> application host has completed a graceful shutdown. The application will not exit until all callbacks registered on this token have completed.
```
    protected override void OnStopped()
    {
        ConsoleHelper.WriteLineColor(ConsoleColor.Red, "Server stopped on {0}.", DateTime.UtcNow.ToLocalTime().ToString());
    }
```  

#### Terminal Header
You can override the following method to print the terminal header in your application context.

##### [PrintHostApplicationHeaderAsync](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.PrintHostApplicationHeaderAsync)
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

##### [PrintHostApplicationLicensingAsync](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.PrintHostApplicationLicensingAsync(PerpetualIntelligence.Cli.Licensing.License))
Allows host application to print custom licensing information.
```
    protected override Task PrintHostApplicationLicensingAsync(PerpetualIntelligence.Cli.Licensing.License license)
    {
        Console.WriteLine("Print your CLI terminal licensing info...");
        return Task.CompletedTask;
    }
```

#### Terminal Options
You can override the following method to perform the terminal configuration options checks.

##### [CheckHostApplicationConfigurationAsync](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.CheckHostApplicationConfigurationAsync(PerpetualIntelligence.Cli.Configuration.Options.CliOptions))
Allows the host application to perform additional configuration option checks.
```
    protected override Task CheckHostApplicationConfigurationAsync(PerpetualIntelligence.Cli.Configuration.Options.CliOptions options)
    {
        // Perform your custom checks here
        return Task.CompletedTask;
    }
```

> **Note:** The `pi-cli` framework performs certain mandatory configuration option checks. Applications cannot customize or change the mandatory configuration option checks, but they can perform additional configuration checks as shown above. For more information see [defaults and limits](defaults.md).


### [ICliBuilder](xref:PerpetualIntelligence.Cli.Integration.ICliBuilder)
You enable the pi-cli framework to any .NET, .NET Core, or .NET6+ console application by adding the relevant services to the [dependency injection (DI)](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) system.

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

    // Add pi-cli to the console app
    public void ConfigureServices(IServiceCollection services)
    {
        ICliBuilder builder = services.AddCli(options => { ... });
    }
```

Many of the fundamental CLI terminal configuration settings can be set on the options. The @"PerpetualIntelligence.Cli.Extensions.ICliBuilderExtensions" provides dependency injection extension methods to register required and optional services. For more information see the following:
- [Configuration options](options.md)
- [DI Services](services.md)




