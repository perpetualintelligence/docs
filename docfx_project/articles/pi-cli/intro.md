# Overview

## What is pi-cli?
`pi-cli` is the most flexible cross-platform framework for building modern CLI terminals for your company, product, service, SaaS, development, and testing needs. Users, customers, and enterprises across engineering, manufacturing, technology, digital industries, digital twins, artificial intelligence, machine learning, finance, media, creative design, etc., can create CLI apps with few flags or advanced CLIs with roots, groups, sub-commands, arguments, and options.

> ***Take your app or service to the command line with Unicode support and build CLI terminals in a user language of your choice.***

> ***Note: The pi-cli framework is in pe-release. It is not ready for production deployment.***

## Craftsmanship
We crafted the `pi-cli` framework to be cross-platform, hosting and deployment agnostic, and fully customizable. We strongly believe .NET provides a rich set of [DSL](https://docs.microsoft.com/en-us/visualstudio/modeling/about-domain-specific-languages?view=vs-2022) and [DDD](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice) tools and languages, and `pi-cli` directly supports the .NET (traditional), .NET core, ASP.NET Core, and NET6+ framework. Thus it is naturally the defacto standard in developing cross-platform CLI systems for your apps, services, and developer tools in the entire .NET ecosystem. It lets enterprises build ground-up CLI terminals or migrate their existing CLI apps and terminals with the modern, scalable and distributed architecture.

- Build and configure your CLI terminal using microservices-based architecture principles, Dependency Injection(DI services), and options pattern.
- Use default handlers or provide custom implementations to handle terminal UX, command parsing, error handling, command validations, storage, and type checking.
- Provide self-hosting implementations for stores and hosts in an environment of your choice, e.g., Windows, Linux, macOS, Docker, Kubernetes, etc. 
- Build deployment agnostic CLI terminals with all dependencies, test them in local environments and deploy the production terminals on-premise, cloud (public, private, or government), or hybrid.
- Enable enterprise-grade secured CLI applications for your products and services similar to [Github CLI](https://cli.github.com/), [.NET CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/), [Stripe CLI](https://stripe.com/docs/stripe-cli) or CLI terminals with custom formats.
- Collaborate in an open-source environment, troubleshoot issues, and provide your feedback on the features and documentation
- Use [demo license](https://docs.perpetualintelligence.com/articles/pi-demo/intro.html) for quick onboarding, testing, and evaluating ready-to-use samples on GitHub. No account is needed.

The framework handles the entire CLI infrastructure, so your focus is on building modern CLI apps and services.

> ***In short, if what you want to achieve is doable in the .NET ecosystem, it is possible with `pi-cli`.***

## Open Source
Our entire source code is on [GitHub](https://github.com/perpetualintelligence/cli). It enables community collaboration, troubleshoot issues, and helps get us your feedback on the features and documentation. It also promotes a better understanding of architecture and design.

> ***See our [licensing terms](https://terms.perpetualintelligence.com/articles/licensing.html), [licenses](licensing/intro.md) and [pricing](https://www.perpetualintelligence.com/products/picli#pricing).***

## OS
Our CICD pipeline builds the framework with Github [hosted runners](https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners) for the following OS platform. However, it supports all the additional platforms that .NET supports.

![macOS](https://img.shields.io/badge/macOS-grey?style=flat-square&logo=macos)
![ubuntu](https://img.shields.io/badge/ubuntu-grey?style=flat-square&logo=ubuntu)
![windows](https://img.shields.io/badge/windows-grey?style=flat-square&logo=windows)

## Packaging
The licensed libraries can be accessed via Nuget:

[![Nuget](https://img.shields.io/nuget/vpre/PerpetualIntelligence.Cli?label=PerpetualIntelligence.Cli)](https://www.nuget.org/packages/PerpetualIntelligence.Cli)

## Build
The [GitHub](https://github.com/perpetualintelligence/cli) repo contains all the build and release artifacts to build, test and publish the `pi-cli` source.

 ![build](../../images/picli/framework/build.png)

## Terminal UX
The `pi-cli` framework does not enforce any specific terminal or console UX experience because this is always custom to the project. However, we provide you with a starting point for your terminal lifetime and UX customization.
- [CliHostedService](xref:PerpetualIntelligence.Cli.Integration.CliHostedService)

## Classes
[Classes and Object browser](../../api/index.md)

## Learn to Use
With the `pi-cli` framework, you don't have to be a microservices or distributed systems expert to build a modern and scalable CLI terminal. You create and learn as you go on, and eventually, you become an expert :) similar to an [eventually-consistent system](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/distributed-data-management). Build CLIs for simple use cases, CLI terminals that handle authentication, or CLI terminals that interact with a complex distributed system via protected APIs. We believe in agile development and agile learning. So, pick a learning model that works for you!

### I want to explore the samples on GitHub
- Use our [demo license](../pi-demo/intro.md) for quick onboarding, evaluation, and testing sample code base on [GitHub](https://github.com/perpetualintelligence/docs/tree/main/samples)
- No account is needed

### I want to create my first modern CLI
- Start by [subscribing or buying](../buying/intro.md) the `pi-cli` SaaS service.
- Pick a pricing plan that works for you. Our community edition is free for educational, research, and non-production use.
- Activate your subscription on our [SaaS Consumer Portal](https://consumer.perpetualintelligence.com/).
- Generate your [license keys](licensing/licensekeys.md).
- Browse our [read-to-use templates and tutorials](../samples.md).
- Build, debug, make changes and learn the concepts as you go.
- We cant wait to see the fantastic CLI terminals you build!

### I want to understand the concepts first
Continue reading, and we will explain all the concepts. We recommend you get familiar with the common architectural principles first as they enable our framework to be extendible, customizable, and remain scalable.

- [Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Dependency Inversion](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)
- [Options Patterns](https://docs.microsoft.com/en-us/dotnet/core/extensions/options)
- [Separation of concerns](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns)
- [Single Responsibility](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns)
- [Bounded Context](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#bounded-contexts)

## Code Samples and Tutorials
Our [ready-to-use templates](https://github.com/perpetualintelligence/docs/tree/main/samples/templates/pi-cli) and [sample tutorials](https://github.com/perpetualintelligence/docs/tree/main/samples/tutorials/pi-cli) will get you started in no time.

## Licensing and Pricing
The software license and pricing model is flexible and fits all, whether you are a community member, solo entrepreneur, small-medium business, large enterprise, or a service vendor.
- [Licensing](licensing/intro.md)
- [Pricing](https://perpetualintelligence.com/products/picli#pricing)

## Issues and feature requests
Please report [issue or feature request](https://github.com/perpetualintelligence/cli/issues) directly on our official github repo.

## References
- [Microservices](https://github.com/dotnet/docs/tree/main/docs/architecture/microservices)
- [.NET application architecture](https://docs.microsoft.com/en-us/dotnet/architecture/)


