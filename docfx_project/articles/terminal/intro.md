# Terminal Framework

`OneImlx.Terminal` is the cross-platform adaptable framework designed for crafting modern CLI and terminal applications. We cut through the terminal infrastructure complexity, letting you concentrate on building enterprise grade terminal applications with Unicode support, and extensive command hierarchies.

- Utilize microservices architecture, Dependency Injection (DI), and options pattern to design and configure your terminal apps.
- Access built-in features or develop your own solutions for terminal UX, input parsing, error handling, command validation, data storage, and type verification.
- Opt for high-performance in-memory command storage or integrate with remote storage solutions.
- Compatible with Windows, Linux, macOS, Docker, Kubernetes, and more.
- Create deployment-agnostic CLI terminals, test locally, and deploy on-premise, cloud (public, private, or government), or in hybrid environments.
- Develop enterprise-level CLI and terminal applications with secure, zero-trust architecture, complying with OAuth and OpenID Connect (OIDC) standards.
- Engage with our open-source community to resolve issues and contribute to feature enhancements and documentation.
- Quickly onboard, evaluate, and test with our [demo license](https://docs.perpetualintelligence.com/articles/pi-demo/intro.html) and ready samples on GitHub, no signup required.

> ***Transform any .NET ecosystem feature into a modern Unicode terminal app with ease.***

## Open Source
The terminal framework is fully open-source, with the entire source code available on [GitHub](https://github.com/perpetualintelligence/terminal). This encourages community collaboration and feedback.

![repo](../../images/terminal/framework/repo.png)

Our DevOps builds the framework with Github [hosted runners](https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners) for the following OS platform. However, it supports all the additional platforms that .NET supports.

![macOS](https://img.shields.io/badge/macOS-grey?style=flat-square&logo=macos)
![ubuntu](https://img.shields.io/badge/ubuntu-grey?style=flat-square&logo=ubuntu)
![windows](https://img.shields.io/badge/windows-grey?style=flat-square&logo=windows)

The licensed packages can be accessed via Nuget:

![NuGet](https://img.shields.io/nuget/v/OneImlx.Terminal?label=OneImlx.Terminal)
![NuGet](https://img.shields.io/nuget/v/OneImlx.Terminal.Authentication?label=OneImlx.Terminal.Authentication)

## User Experience (UX)
`OneImlx.Terminal` decouples the terminal's backend logic from the frontend, providing a scalable and flexible framework that caters to developers looking to integrate command-line functionalities into various applications.

### Native Integration with .NET Ecosystem
`OneImlx.Terminal` seamlessly integrates with the .NET stack, offering a native experience for developing terminal applications.

- **Console Applications**: Embed `OneImlx.Terminal` directly to enhance command handling in console applications.
- **Servers and Backend Services**: Utilize `OneImlx.Terminal` in backend services, ensuring robust terminal operations and efficient communication via native TCP/IP support.
- **ASP.NET Core and Blazor Server**: Directly integrate with ASP.NET Core and Blazor for responsive user interfaces, with backend terminal operations handled by `OneImlx.Terminal`.
- **Blazor Webassembly (WASM)**: Directly integrate with Blazor Webassembly and MSAL for responsive user interfaces, with a secured terminal operations handled by `OneImlx.Terminal`.

This native integration ensures a smooth development workflow and full debugging capabilities within the .NET environment.

### Integration and Protocol Support

With `OneImlx.Terminal`, you have the freedom to create a terminal frontend in various programming languages and frameworks, communicating seamlessly with the backend terminal server.

- **Web Applications**: Use JavaScript frameworks like React or Vue.js for web integration.
- **Desktop Applications**: Build cross-platform desktop applications with Electron or other technologies.
- **Server-Side Applications**: Choose server-side languages like Python, Java, or C# for backend integration.

The `OneImlx.Terminal` backend currently supports TCP/IP, with plans to expand to gRPC, Named Pipes, and HTTP for diverse communication needs.

### Flexible Deployment Options

Deploy the backend terminal server according to your needs:

- **On-Premise**: For full control and adherence to internal policies.
- **Cloud**: To leverage the scalability of cloud infrastructure.
- **Containerized Environments**: For simplified deployment and scaling.

By separating terminal functionalities from the frontend, `OneImlx.Terminal` provides flexibility, ensuring you can choose the best tools for your use case while maintaining a robust backend.

## Feedback
Submit [issues or feature requests](https://github.com/perpetualintelligence/terminal/issues) directly on GitHub.

## References
- [Microservices](https://github.com/dotnet/docs/tree/main/docs/architecture/microservices)
- [.NET application architecture](https://docs.microsoft.com/en-us/dotnet/architecture/)