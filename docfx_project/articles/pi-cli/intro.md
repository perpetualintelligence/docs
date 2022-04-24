![in-progress](https://img.shields.io/badge/status-in--progress-yellow)

> **Note:** This is a ***preview*** release. It is also subject to design changes without any advance notice.

# Introducing pi-cli
`pi-cli` is the cross-platform developer framework for building all your CLI terminals or command-line systems in the .NET ecosystem. The framework makes it easy to build CLIs for your company, product, service, SaaS, or development and testing needs. Enterprises can create CLIs with few flags or advanced complex CLIs with organization commands, grouped commands, subcommands, arguments, and options.

> _**Take your app or service to the command line with Unicode support and build your front-end CLI in any language.**_

# Craftsmanship
We crafted the `pi-cli` framework to be cross-platform, hosting and deployment agnostic, and fully customizable. We strongly believe .NET provides a rich set of [DSL](https://docs.microsoft.com/en-us/visualstudio/modeling/about-domain-specific-languages?view=vs-2022) and [DDD](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice) tools and languages, and `pi-cli` directly supports the .NET (traditional), .NET core, ASP.NET Core, and NET6+ framework. Thus it is naturally the defacto standard in developing cross-platform CLI systems for your apps, services, and developer tools in the entire .NET ecosystem. It lets enterprises build ground-up CLI terminals or migrate their existing CLI apps and terminals with the modern and scalable micro-services-based architecture. 

> _**In short, if what you want to achieve is doable in the .NET ecosystem, it is possible with `pi-cli`.**_

# Getting Started
## Open Source
Our entire source code is on [GitHub](https://github.com/perpetualintelligence/cli). It enables community collaboration, troubleshoot issues, and helps get us your feedback on the features and documentation. It also promotes a better understanding of architecture and design.

> _**See our [licensing terms](https://terms.perpetualintelligence.com/articles/licensing.html) and [pricing](pricing.md) **_.

## OS
Our CICD pipeline builds the framework with Github [hosted runners](https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners) for the following OS platform. However, it supports all the additional platforms that .NET supports.

![macOS](https://img.shields.io/badge/macos-11-blue?style=flat-square&logo=macos)
![ubuntu](https://img.shields.io/badge/linux-ubuntu--20.04-blue?style=flat-square&logo=ubuntu)
![windows](https://img.shields.io/badge/windows-2022-blue?style=flat-square&logo=windows)

## Packaging
The licensed libraries can be accessed via Nuget:

[![Nuget](https://img.shields.io/nuget/vpre/PerpetualIntelligence.Cli?label=PerpetualIntelligence.Cli)](https://www.nuget.org/packages/PerpetualIntelligence.Cli)

## Build
The [GitHub](https://github.com/perpetualintelligence/cli) repo contains all the build and release artifacts to build, test and publish the `pi-cli` source.

 ![build](/images/picli/framework/build.png)

## Terminal UX
The `pi-cli` framework does not enforce any specific terminal or console UX experience because this is always custom to the project. However, we provide you with a starting point for your terminal lifetime and UX customization.
- [CliHostedService](xref:PerpetualIntelligence.Cli.Integration.CliHostedService)

## Classes
[Classes and Object browser](/api/index.html)

## Learn to Use
With the `pi-cli` framework, you don't have to be a microservices or distributed systems expert to build a modern and scalable CLI terminal. You build and learn as you go on, and eventually, you become an expert :) similar to an [eventually-consistent system](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/distributed-data-management). You can quickly build CLIs for simple use cases, a CLI terminal that handles authentication, or a CLI terminal that interacts with a complex distributed system via protected APIs. We believe in an agile development and agile learning. So, pick a learning model that works for you!

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

# Test License
If you want to evaluate the pi-cli framework quickly, you can use our test license with shared limits. 

We recommend creating an account to generate a license for your specific use case. Our community edition is free for educational, research and development, and non-commercial use. You do need a commercial license for a non-educational or production environment.

> **Note:** Our test license feature is under development and will be available soon.

# Issues and feature requests
Please report [issue or feature request](https://github.com/perpetualintelligence/cli/issues) directly on our official github repo.

# References
- [Microservices](https://github.com/dotnet/docs/tree/main/docs/architecture/microservices)
- [.NET application architecture](https://docs.microsoft.com/en-us/dotnet/architecture/)


