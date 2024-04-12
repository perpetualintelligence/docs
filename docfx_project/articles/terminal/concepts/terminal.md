## [Terminal](xref:OneImlx.Terminal.Runtime.Terminal)
In `OneImlx.Terminal` framework, a terminal is a Unicode text-based construct designed for executing commands, automating workflows, and processing scripts. Each terminal session is uniquely identified, allowing for clear differentiation and management of multiple instances.

A terminal is not just a console; it's a logical construct designed to execute commands and automate tasks. It can be implemented as a console, server, browser-based interface, or any other UX format, making it adaptable for various development environments.

## [Hosting](xref:OneImlx.Terminal.Hosting)
The `OneImlx.Terminal` framework uses extension methods like `<AddTerminal*>` or `<Add*>` for easy setup and terminal customization. It deploys dependency injection at its core to setup and run the terminal host. Developers can utilize the `TerminalHostedService` to configure services, customize terminal behavior, and ensure smooth execution throughout the terminal's lifecycle. For details refer [services](../configuration/services.md).

## [Configuration](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions)
The `OneImlx.Terminal` supports flexible configuration via Dependency Injection and the options pattern, enabling customization of terminal behaviors and settings through code, or configuration files. For comprehensive setup instructions, see the [configuration documentation](../configuration/intro.md).

## [Router](xref:OneImlx.Terminal.Runtime.ITerminalRouter`1)
Terminal router orchestrates the execution within the application context. It starts the host and runs indefinitely until the application stops or a cancellation token is received. Developers can implement the `ITerminalRouting<TContext>` interface and define the `RunAsync` method to establish the custom routing logic. 

The framework provides the following ready-to-use router implementations:

- @OneImlx.Terminal.Runtime.TerminalConsoleRouter: Suitable for standalone terminal or CLI applications.
- @OneImlx.Terminal.Runtime.TerminalTcpRouter: Designed for server terminals managing commands from multiple clients concurrently over TCP/IP.
- @OneImlx.Terminal.Runtime.TerminalUdpRouter: Designed for server terminals managing commands from multiple clients concurrently over UDP.
- @OneImlx.Terminal.Runtime.TerminalCustomRouter: Allows for custom router strategies.

**Note:** Future versions of the framework will introduce `gRPC`, `HTTP` and `Apache Pulsar` terminal routers.

## [Driver](xref:OneImlx.Terminal.Configuration.Options.DriverOptions)
In native console environments, a terminal may act as a driver, allowing for direct command execution, similar to `dotnet.exe` in the .NET CLI. 

Consider executing the command `dotnet build test.csproj --configuration Release` directly from the native command prompt:

1. Identify Executable and Root Command: The framework recognizes `dotnet.exe` as the driver and `dotnet` as the root command.
2. Pass Command Line Arguments: The entire string `build test.csproj --configuration Release` is passed as command line arguments.
3. Parse Arguments and Options: The framework parses these arguments and options.
4. Execute Command: Ultimately, the `build` command is executed with the specified project file and configuration.

To enable this functionality, configure the @OneImlx.Terminal.Configuration.Options.DriverOptions in your terminal settings. Utilize the `Enabled` property to toggle the driver functionality on or off.

> **Note**: This feature is an enhancement and being tracked by [github issue](https://github.com/perpetualintelligence/terminal/issues/107).

## [Events](xref:OneImlx.Terminal.Events.ITerminalEventHandler)
Events play an important role in extending and customizing the behavior of the terminal to meet specific application requirements. Events are hooks that allow developers to inject custom logic and asynchronous operations at various stages of command routing.

- `BeforeCommandRouteAsync`: Called before the command routing process begins.
- `AfterCommandRouteAsync`: Called after the command routing process completes.
- `BeforeCommandRunAsync`: Called before a command starts execution.
- `AfterCommandRunAsync`: Called after a command finishes execution.
- `BeforeCommandCheckAsync`: Called before a command's integrity check.
- `AfterCommandCheckAsync`: Called after a command's integrity check completes.

## [Integration](xref:OneImlx.Terminal.Integration)
The `OneImlx.Terminal` framework enables developers to seamlessly integrate both first-party and third-party command sources. A command source is a provider of terminal commands. It can be a local or remote source. By default, the framework supports assembly loader command source that dynamically loads DLLs containing command runners.

## [Stores](xref:OneImlx.Terminal.Stores)
The `OneImlx.Terminal` framework manages @OneImlx.Terminal.Commands.CommandDescriptor instances through stores. The @OneImlx.Terminal.Stores.ITerminalCommandStore interface provides methods for adding, finding, and retrieving command descriptors asynchronously.

Developers can use the default @OneImlx.Terminal.Stores.TerminalInMemoryCommandStore or create custom store implementations to meet specific requirements.

## [Internationalization](xref:OneImlx.Terminal.Runtime.ITerminalTextHandler)
The `OneImlx.Terminal` framework supports internationalization with @OneImlx.Terminal.Runtime.ITerminalTextHandler, offering Unicode and ASCII encoding options. This interface handles text comparisons and encoding, simplifying the development of applications that require multilingual support. See the @OneImlx.Terminal.Runtime.TerminalUnicodeTextHandler and @OneImlx.Terminal.Runtime.TerminalAsciiTextHandler for more details.

## [Exception Handling](xref:OneImlx.Terminal.Runtime.ITerminalExceptionHandler)
The `OneImlx.Terminal` provides exception handling through the @OneImlx.Terminal.Runtime.ITerminalExceptionHandler. The default implementation @OneImlx.Terminal.Runtime.TerminalExceptionHandler logs the exception based on severity. 

Developers can implement the interface to create custom exception handlers, enabling tailored error management and logging in their applications.

## [Console Abstraction](xref:OneImlx.Terminal.Runtime.ITerminalConsole)
The `OneImlx.Terminal` framework provides console abstraction @OneImlx.Terminal.Runtime.ITerminalConsole. It enables developers to create custom console implementations such as web-based or multi-platform consoles.

The framework offers default implementations @OneImlx.Terminal.Runtime.TerminalSystemConsole for standard .NET System Console, and @OneImlx.Terminal.Runtime.TerminalNoConsole for non-interactive console.