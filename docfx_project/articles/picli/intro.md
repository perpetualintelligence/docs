# Introduction
`pi-cli` (oneterminal) is a cross-platform adaptable framework designed for building modern CLI and terminal apps. It empowers software teams to create enterprise-grade Unicode terminals tailored to specific needs, from simple CLI apps with basic flags to advanced terminals with complex command structures.

> ***Take Your App to the Command Line:*** Easily build CLI and terminal applications with Unicode support.

Crafted with modularity and customization in mind, `pi-cli` supports a wide range of .NET platforms including .NET (traditional), .NET Standard, .NET6+ (.NET Core), and ASP.NET Core. This allows for seamless development of terminals from scratch or migration of existing console apps to more sophisticated terminals.

- Utilize microservices architecture, Dependency Injection (DI), and options pattern to design and configure your terminal apps.
- Access built-in features or develop your own solutions for terminal UX, input parsing, error handling, command validation, data storage, and type verification.
- Opt for high-performance in-memory command storage or integrate with remote storage solutions.
- Compatible with Windows, Linux, macOS, Docker, Kubernetes, and more.
- Create deployment-agnostic CLI terminals, test locally, and deploy on-premise, cloud (public, private, or government), or in hybrid environments.
- Build secure enterprise-level CLI or terminal applications.
- Engage with our open-source community to resolve issues and contribute to feature enhancements and documentation.
- Quickly onboard, evaluate, and test with our [demo license](gs/demo.md). Dive in with our [samples](gs/samples.md).

`pi-cli` cuts through infrastructure complexity, letting you concentrate on crafting your CLI applications.

> ***Transform any .NET ecosystem feature into a CLI or terminal app with ease.***

## Open Source
`pi-cli` framework is fully open-source, with the entire source code available on [GitHub](https://github.com/perpetualintelligence/oneterminal). This encourages community collaboration and feedback.

![repo](../../images/picli/framework/repo.png)

Our DevOps builds the framework with Github [hosted runners](https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners) for the following OS platform. However, it supports all the additional platforms that .NET supports.

![macOS](https://img.shields.io/badge/macOS-grey?style=flat-square&logo=macos)
![ubuntu](https://img.shields.io/badge/ubuntu-grey?style=flat-square&logo=ubuntu)
![windows](https://img.shields.io/badge/windows-grey?style=flat-square&logo=windows)

The licensed libraries can be accessed via Nuget:

[![Nuget](https://img.shields.io/nuget/vpre/PerpetualIntelligence.Terminal?label=PerpetualIntelligence.Terminal)](https://www.nuget.org/packages/PerpetualIntelligence.Terminal)

## User Experience (UX)

`pi-cli` decouples the terminal's backend logic from the frontend, providing a scalable and flexible framework that caters to developers looking to integrate command-line functionalities into various applications.

### Native Integration with .NET Ecosystem

`pi-cli` seamlessly integrates with the .NET stack, offering a native experience for developing terminal applications.

- **Console Applications**: Embed `pi-cli` directly to enhance command handling in console applications.
- **Servers and Backend Services**: Utilize `pi-cli` in backend services, ensuring robust terminal operations and efficient communication via native TCP/IP support.
- **ASP.NET Core and Blazor**: Directly integrate with ASP.NET Core and Blazor for responsive user interfaces, with backend terminal operations handled by `pi-cli`.

This native integration ensures a smooth development workflow and full debugging capabilities within the .NET environment.

### Integration and Protocol Support

With `pi-cli`, you have the freedom to create a terminal frontend in various programming languages and frameworks, communicating seamlessly with the backend terminal server.

- **Web Applications**: Use JavaScript frameworks like React or Vue.js for web integration.
- **Desktop Applications**: Build cross-platform desktop applications with Electron or other technologies.
- **Server-Side Applications**: Choose server-side languages like Python, Java, or C# for backend integration.

The `pi-cli` backend currently supports TCP/IP, with plans to expand to gRPC, Named Pipes, and HTTP for diverse communication needs.

### Flexible Deployment Options

Deploy the backend terminal server according to your needs:

- **On-Premise**: For full control and adherence to internal policies.
- **Cloud**: To leverage the scalability of cloud infrastructure.
- **Containerized Environments**: For simplified deployment and scaling.

By separating terminal functionalities from the frontend, `pi-cli` provides flexibility, ensuring you can choose the best tools for your use case while maintaining a robust backend.

## Feedback
Submit [issues or feature requests](https://github.com/perpetualintelligence/oneterminal/issues) directly on GitHub.

## References
- [Microservices](https://github.com/dotnet/docs/tree/main/docs/architecture/microservices)
- [.NET application architecture](https://docs.microsoft.com/en-us/dotnet/architecture/)