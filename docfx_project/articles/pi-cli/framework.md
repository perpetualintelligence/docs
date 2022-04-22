![in-progress](https://img.shields.io/badge/status-in--progress-yellow)

> **Note:** This is a ***preview*** release. It is also subject to design changes without any advance notice.

# pi-cli
"pi-cli" is the Perpetual Intelligence's cross-platform framework for building command-line systems or CLI terminals in the .NET ecosystem. The framework makes it easy to build CLIs for your company, product, service, SaaS, or development and testing needs. Enterprises can create CLIs with few flags or advanced complex CLIs with organization commands, grouped commands, subcommands, arguments, and options.

> _**Take your app or service to the command line with Unicode support and build your front-end CLI in any language.**_

# Craftsmanship
We crafted the "pi-cli" framework to be cross-platform, hosting and deployment agnostic, and fully customizable. We strongly believe .NET provides a rich set of [DSL](https://docs.microsoft.com/en-us/visualstudio/modeling/about-domain-specific-languages?view=vs-2022) and [DDD](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice) tools and languages, and "pi-cli" directly supports the .NET core, ASP.NET Core, and NET6+ framework. Thus it is naturally the defacto standard in developing cross-platform CLI systems for your apps, services, and developer tools in the entire .NET ecosystem. It lets enterprises build ground-up CLI applications or migrate their existing CLI apps and terminals with the modern and scalable micro-services-based architecture. 

> _**In short, if what you want to achieve is doable in the .NET ecosystem, it is possible with pi-cli.**_

# Learn to Use
To build a modern CLI terminal for simple use cases, a CLI terminal that handles authentication, or a CLI terminal that interacts with a complex distributed system via protected APIs, you don't have to be a microservices or distributed systems expert. But eventually, you can be :) similar to an [eventually-consistent system](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/distributed-data-management). We believe in agile development and agile learning. So, pick a learning model that works for you!

## I want to create my first modern CLI and learn as I go on
- Please create an account with us at https://www.perpetualintelligence.com
- Pick a pricing plan that works for you. Our community edition is free for educational, research, and non-commercial use. You must have a commercial license to use the service in a non-educational, commercial, or production environment.
- Browse our code samples [here](https://docs.perpetualintelligence.com/articles/featured_samples.html), clone the [repo](https://github.com/perpetualintelligence/docs/tree/main/samples/tutorials)
- Set your License Key (a valid license key is required for both community and commercial licenses)
- Build, debug make changes and learn the concepts and you go on
- We cant wait to see the fantastic CLI terminals you build !

## I want to understand the concepts first
Continue reading, and we will explain all the concepts. We recommend you get familiar with the common architectural principles first.

# Architectural Principles
Here are some valuable links that you should be familiar with as they enable our framework to be extendible, customizable, and remain scalable.

- [Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Dependency Inversion](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)
- [Options Patterns](https://docs.microsoft.com/en-us/dotnet/core/extensions/options)
- [Separation of concerns](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns)
- [Single Responsibility](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns)
- [Bounded Context](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#bounded-contexts)

# Hosting
The pi-cli framework is hosting agnostic, meaning no hosting limitations at all. Application authors can host their CLI apps, terminals, or servers on their self-hosting environment, use a managed-hosting environment, or rely on a third party to provide a hosting environment. You can configure your server and provide your self-hosting implementations for stores and host in an environment of your choice, e.g., Windows, Linux, macOS, Docker, Kubernetes, etc.

# Deployment
With pi-cli, you build deployment agnostic secured CLI applications and services, test them in local environments and deploy the production apps and services on-premise, cloud (public, private, or government), or hybrid. You can also automate the deployment of your apps and services as portable, self-sufficient containers that can run on the cloud or on-premises.

## Public Client CLI Terminals

## Server Deployed CLI Terminals

## 

# Packages
[![Nuget](https://img.shields.io/nuget/vpre/PerpetualIntelligence.Cli?label=PerpetualIntelligence.Cli)](https://www.nuget.org/packages/PerpetualIntelligence.Cli)

# OS Platform
![macOS](https://img.shields.io/badge/macOS-Catalina%2010.15-blue?style=flat-square&logo=macos)
![ubuntu](https://img.shields.io/badge/linux-ubuntu--20.04-blue?style=flat-square&logo=ubuntu)
![windows](https://img.shields.io/badge/windows-2019-blue?style=flat-square&logo=windows)



# Concepts

## Commands
A command is a specific action or a set of actions that a user or an application requests the underlying system to perform. It can be a simple action such as invoking a system method or an OS command or representing a complex operation that calls a set of protected APIs over the internal or external network. A command can virtually do anything in the context of your application or service. The pi-cli framework defines the following code constructs to describe the command and its runtime behavior.

### CommandDescriptor
<xref:id_of_another_file>
[PerpetualIntelligence.Cli.Commands.CommandDescriptor](xref:id_of_another_file)


### Descriptors

### Runtime

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


