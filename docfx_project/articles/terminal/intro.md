# Terminal Framework
`OneImlx.Terminal` is a cross-platform, adaptable framework designed for developing modern and secured terminal applications. It simplifies terminal infrastructure complexity, enabling developers to focus on building enterprise-grade terminal applications with Unicode support and extensive command hierarchies.

- Utilize microservices architecture, Dependency Injection (DI), and options pattern to design and configure your terminal apps.
- Access built-in features or develop custom solutions for terminal UX, runtime, parsing, routing, error handling, command validation, and storage.
- Choose in-memory command storage or integrate with your custom storage solutions.
- Create platform and deployment agnostic terminals, servers, and custom applications for on-premise, cloud, hybrid, highly-secured OSAT, or factory environments.
- Integrate with OAuth and OpenID Connect (OIDC) authentication providers
- Engage with our team on GitHub for support and feature enhancements.
- Quickly onboard with our [demo license](https://docs.perpetualintelligence.com/articles/pi-demo/intro.html) and GitHub samples, no payment required.

> ***Easily transform any .NET ecosystem feature into a modern Unicode terminal app.***

## Open Source
The terminal framework is open-source hosted on [GitHub](https://github.com/perpetualintelligence/terminal), encouraging community collaboration and feedback.

![repo](../../images/terminal/framework/repo.png)

Our DevOps builds the framework with [hosted runners](https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners) for various OS platforms, supporting platforms compatible with .NET.

![macOS](https://img.shields.io/badge/macOS-grey?style=flat-square&logo=macos)
![ubuntu](https://img.shields.io/badge/ubuntu-grey?style=flat-square&logo=ubuntu)
![windows](https://img.shields.io/badge/windows-grey?style=flat-square&logo=windows)

Access licensed packages via Nuget:

![NuGet](https://img.shields.io/nuget/v/OneImlx.Terminal?label=OneImlx.Terminal)
![NuGet](https://img.shields.io/nuget/v/OneImlx.Terminal.Authentication?label=OneImlx.Terminal.Authentication)

## Integration
The `OneImlx.Terminal` framework separates the terminal's backend logic from the frontend, making it ideal for building terminal applications, servers, and command-line interfaces.

### Enhanced Integration with .NET Ecosystem
`OneImlx.Terminal` ensures seamless integration with the .NET stack, streamlining the development and deployment.

#### Console
Enhance console applications with advanced command routing and execution capabilities by integrating the `OneImlx.Terminal` framework.

#### Custom UX
Utilize ASP.NET Core, Blazor, and Blazor WebAssembly (WASM) with `OneImlx.Terminal` to craft custom, responsive terminal user interfaces. 

The framework, acting as a comprehensive terminal parsing and execution engine, allows developers to create dynamic UX for server-side and client-side terminal applications. It handles complex command executions efficiently and adapts to various .NET frameworks, supporting flexible command execution syntax for sophisticated, secure terminal applications.

#### Backend
Use the `OneImlx.Terminal` framework to develop server applications capable of managing complex client-server and service-to-service communications using TCP, UDP, or custom routers. This setup enables robust and scalable communication solutions tailored to your specific infrastructure needs.

It also enables developers and product owners to expose complex APIs as simple command strings with arguments and options, facilitating the creation of products as CLI apps, diagnostic tools, and administrative interfaces.

#### On-Premise
`OneImlx.Terminal` excels in on-premise server applications, aligning with internal policies and infrastructure. It offers tools and flexibility for managing and deploying terminal applications in secure, zero-trust, and controlled environments.

### Other Integrations
Develop various frontend terminal applications using technologies like React, Vue.js, Electron, or MAUI, communicating with a .NET-based terminal server for command processing and execution.

#### Web and Cloud Native
Create web and cloud native terminal applications using JavaScript frameworks, interacting with a .NET-based terminal server for command execution.

#### Other Languages
Build terminal applications in Python, Java, or other languages, integrating with the .NET-based terminal server for robust command execution.

> **Note:** `OneImlx.Terminal` currently supports TCP/IP, UDP, and custom routers. Future plans include adding support for gRPC and HTTP.

## Deployment
Deploy the terminal server and apps as needed:
- **On-Premise**: Maintain full control and comply with internal policies.
- **Cloud**: Leverage cloud infrastructure.
- **Containerized Environments**: Simplify deployment and scaling.

## Feedback
Submit [issues or feature requests](https://github.com/perpetualintelligence/terminal/issues) directly on GitHub.

## References
- [Microservices Architecture](https://github.com/dotnet/docs/tree/main/docs/architecture/microservices)
- [.NET Application Architecture](https://docs.microsoft.com/en-us/dotnet/architecture/).
