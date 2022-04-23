![in-progress](https://img.shields.io/badge/status-in--progress-yellow)

> **Note:** This is a ***preview*** release. It is also subject to design changes without any advance notice.

# pi-cli
"pi-cli" is the Perpetual Intelligence's cross-platform framework for building command-line systems or CLI terminals in the .NET ecosystem. The framework makes it easy to build CLIs for your company, product, service, SaaS, or development and testing needs. Enterprises can create CLIs with few flags or advanced complex CLIs with organization commands, grouped commands, subcommands, arguments, and options.

> _**Take your app or service to the command line with Unicode support and build your front-end CLI in any language.**_

# Craftsmanship
We crafted the "pi-cli" framework to be cross-platform, hosting and deployment agnostic, and fully customizable. We strongly believe .NET provides a rich set of [DSL](https://docs.microsoft.com/en-us/visualstudio/modeling/about-domain-specific-languages?view=vs-2022) and [DDD](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice) tools and languages, and "pi-cli" directly supports the .NET core, ASP.NET Core, and NET6+ framework. Thus it is naturally the defacto standard in developing cross-platform CLI systems for your apps, services, and developer tools in the entire .NET ecosystem. It lets enterprises build ground-up CLI terminals or migrate their existing CLI apps and terminals with the modern and scalable micro-services-based architecture. 

> _**In short, if what you want to achieve is doable in the .NET ecosystem, it is possible with pi-cli.**_

# Getting Started
## Open Source
Our entire source code is on [GitHub](https://github.com/perpetualintelligence/cli). It enables community collaboration, troubleshoot issues, and helps get us your feedback on the features and documentation. It also promotes a better understanding of architecture and design.

> _**See our [licensing terms](https://terms.perpetualintelligence.com/articles/licensing.html)**_.

## OS
![macOS](https://img.shields.io/badge/macOS-Catalina%2010.15-blue?style=flat-square&logo=macos)
![ubuntu](https://img.shields.io/badge/linux-ubuntu--20.04-blue?style=flat-square&logo=ubuntu)
![windows](https://img.shields.io/badge/windows-2019-blue?style=flat-square&logo=windows)

## Nuget Packages
[![Nuget](https://img.shields.io/nuget/vpre/PerpetualIntelligence.Cli?label=PerpetualIntelligence.Cli)](https://www.nuget.org/packages/PerpetualIntelligence.Cli)

## Classes
[API and Classes](/api/index.md)

## Learn to Use
To build a modern CLI terminal for simple use cases, a CLI terminal that handles authentication, or a CLI terminal that interacts with a complex distributed system via protected APIs, you don't have to be a microservices or distributed systems expert. But eventually, you can be :) similar to an [eventually-consistent system](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/distributed-data-management). We believe in agile development and agile learning. So, pick a learning model that works for you!

### I want to create my first modern CLI and learn as I go on
- Please create an account with us at https://www.perpetualintelligence.com
- Pick a pricing plan that works for you. Our community edition is free for educational, research, and non-commercial use. You must have a commercial license to use the service in a non-educational, commercial, or production environment.
- Browse our code samples [here](https://docs.perpetualintelligence.com/articles/featured_samples.html), clone the [repo](https://github.com/perpetualintelligence/docs/tree/main/samples/tutorials)
- Set your License Key (a valid license key is required for both community and commercial licenses)
- Build, debug make changes and learn the concepts and you go on
- We cant wait to see the fantastic CLI terminals you build !

### I want to understand the concepts first
Continue reading, and we will explain all the concepts. We recommend you get familiar with the common architectural principles first as they enable our framework to be extendible, customizable, and remain scalable.

- [Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Dependency Inversion](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)
- [Options Patterns](https://docs.microsoft.com/en-us/dotnet/core/extensions/options)
- [Separation of concerns](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns)
- [Single Responsibility](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns)
- [Bounded Context](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#bounded-contexts)


# Hosting
The pi-cli framework is hosting agnostic, meaning no hosting limitations at all. Application authors can host their CLI apps, terminals, or servers on their self-hosting environment, use a managed-hosting environment, or rely on a third party to provide a hosting environment. You can configure your server and provide your self-hosting implementations for stores and host in an environment of your choice, e.g., Windows, Linux, macOS, Docker, Kubernetes, etc.

# Deployment
With pi-cli, you build deployment agnostic secured CLI terminals and services, test them in local environments and deploy the production apps and services on-premise, cloud (public, private, or government), or hybrid. You can also automate the deployment of your apps and services as portable, self-sufficient containers that can run on the cloud or on-premises.

## Public Client CLI Terminals

## Server Deployed CLI Terminals

# Concepts & Code

## Terminal
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

### [ArgumentDescriptor](xref:PerpetualIntelligence.Cli.ArgumentDescriptor)
The <a href="xref:PerpetualIntelligence.Cli.ArgumentDescriptor?displayProperty=fullName"/> class defines the command argument identity, data type, and data validation behavior. We also refer to arguments as command options or command flags. An argument <xref:PerpetualIntelligence.Cli.Commands.ArgumentDescriptor.Id> is always unique within a command. By design it implements the default equality <xref:System.IEquatable`1> using <xref:PerpetualIntelligence.Cli.Commands.ArgumentDescriptor.Id> property. Thus, two arguments with the same id are equal irrespective of other property values. This is done to improve performance during lookup and avoid multiple arguments with same identifiers.

### [Argument](xref:PerpetualIntelligence.Cli.Commands.Argument)
The <a href="xref:PerpetualIntelligence.Cli.Commands.Argument?displayProperty=fullName"/> is a runtime validated representation of an actual command argument, option, or a flag and its value passed by a user or an application.

## [Integration](xref:PerpetualIntelligence.Cli.Integration)
The <a href="xref:PerpetualIntelligence.Cli.Integration?displayProperty=fullName"/> namespace defines all the code constructs to integrate your CLI terminal with the pi-cli framework. It provides a service builder for [dependency injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) and hosts a service to manage terminal lifetime and customization.

### [CliHostedService](xref:PerpetualIntelligence.Cli.Integration.CliHostedService)
The <a href="xref:PerpetualIntelligence.Cli.Integration.CliHostedService?displayProperty=fullName"/> is a hosted service that manages application lifetime, performs licensing checks, and enables terminal UX customization.

#### Terminal Lifetime
You can override the following terminal lifetime methods in your application context.

##### [RegisterHostApplicationEventsAsync](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.RegisterHostApplicationEventsAsync(Microsoft.Extensions.Hosting.IHostApplicationLifetime))
Allows the application to register its custom events. The default implementation registers OnStarted, OnStopping, and OnStopped events that application authors can override.
```
    protected virtual Task RegisterHostApplicationEventsAsync(IHostApplicationLifetime hostApplicationLifetime)
    {
        hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
        hostApplicationLifetime.ApplicationStopping.Register(OnStopping);
        hostApplicationLifetime.ApplicationStopped.Register(OnStopped);
        return Task.CompletedTask;
    }
```

> **Note:** OnStarted, OnStopping, and OnStopped are not triggered if you override RegisterHostApplicationEventsAsync and register your custom events.

##### [OnStarted](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.OnStarted)
Triggered when the <c>pi-cli</c> application host has fully started.
```
    protected virtual void OnStarted()
    {
        Console.WriteLine("Server started on {0}.", DateTime.UtcNow.ToLocalTime().ToString());
        Console.WriteLine();
    }
```
##### [OnStopping](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.OnStopping)
Triggered when the <c>pi-cli</c> application host is starting a graceful shutdown. Shutdown will block until all callbacks registered on this token have completed.
```
    protected virtual void OnStopping()
    {
        Console.WriteLine("Stopping server...");
    }
```
##### [OnStopped](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.OnStopped)
Triggered when the <c>pi-cli</c> application host has completed a graceful shutdown. The application will not exit until all callbacks registered on this token have completed.
```
    protected virtual void OnStopped()
    {
        ConsoleHelper.WriteLineColor(ConsoleColor.Red, "Server stopped on {0}.", DateTime.UtcNow.ToLocalTime().ToString());
    }
```  

#### Terminal Header
You can override the following method to print the terminal header in your application context.

##### [PrintHostApplicationHeaderAsync](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.PrintHostApplicationHeaderAsync)
Allows the host application to print the custom header.
```
    protected virtual Task PrintHostApplicationHeaderAsync()
    {
        Console.WriteLine("---------------------------------------------------------------------------------------------");
        Console.WriteLine("Copyright (c) Perpetual Intelligence L.L.C. All Rights Reserved.");
        Console.WriteLine("For license, terms, and data policies, go to:");
        Console.WriteLine("https://terms.perpetualintelligence.com");
        Console.WriteLine("---------------------------------------------------------------------------------------------");

        Console.WriteLine($"Starting server \"{Protocols.Constants.CliUrn}\" version={typeof(CliHostedService).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? " < none > "}");
        return Task.CompletedTask;
    }
```

#### Terminal Licensing Information
You can override the following method to print the terminal licensing information in your application context.

##### [PrintHostApplicationLicensingAsync](xref:PerpetualIntelligence.Cli.Integration.CliHostedService.PrintHostApplicationLicensingAsync(PerpetualIntelligence.Cli.Licensing.License))
Allows host application to print custom licensing information.
```
        protected virtual Task PrintHostApplicationLicensingAsync(PerpetualIntelligence.Cli.Licensing.License license)
        {
            // Print the license information
            ConsoleHelper.WriteLineColor(ConsoleColor.Cyan, $"consumer={license.Claims.Name} ({license.Claims.TenantId})");
            ConsoleHelper.WriteLineColor(ConsoleColor.Cyan, $"country={license.Claims.TenantCountry}");
            ConsoleHelper.WriteLineColor(ConsoleColor.Cyan, $"subject={cliOptions.Licensing.Subject}");
            ConsoleHelper.WriteLineColor(ConsoleColor.Cyan, $"check={license.CheckMode}");
            ConsoleHelper.WriteLineColor(ConsoleColor.Cyan, $"usage={license.Usage}");
            ConsoleHelper.WriteLineColor(ConsoleColor.Green, $"edition={license.Plan}");
            ConsoleHelper.WriteLineColor(ConsoleColor.Cyan, $"key_source={cliOptions.Licensing.KeySource}");
            if (license.LicenseKeySource == SaaSKeySources.JsonFile)
            {
                // Don't dump the key, just the lic file path
                ConsoleHelper.WriteLineColor(ConsoleColor.Cyan, $"key_file={license.LicenseKey}");
            }

            return Task.CompletedTask;
        }
```

### [ICliBuilder](xref:PerpetualIntelligence.Cli.Integration.ICliBuilder)
The <a href="xref:PerpetualIntelligence.Cli.ICliBuilder?displayProperty=fullName"/> class provides extension methods to register the command descriptors and injects the required and optional services.

## Behind the scenes

### Runtime

#### Why Descriptor By Actual Classes

#### Default Values

#### Argument Alias

## Routing

## Extractors

### Handlers

### Comparers

### Providers

### Checkers

### Runners

### Pubishers



## Configurations and Customizations

### Options

### Regex Patterns

### Unicode

# Extensions

# Integration

# Stores

# Licensing & Pricing

# Errors

# Authentication

# Support

# Pricing

# References
- [Microservices](https://github.com/dotnet/docs/tree/main/docs/architecture/microservices)
- [.NET application architecture](https://docs.microsoft.com/en-us/dotnet/architecture/)


