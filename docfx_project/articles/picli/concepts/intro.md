# Concepts
This section introduces the basic concepts within the `pi-cli` terminal framework. It covers fundamental components and their roles in command processing, routing and execution.

## [Terminal](xref:PerpetualIntelligence.Terminal.Runtime.Terminal)
A terminal is a Unicode text-based construct designed for executing commands, automating workflows, and processing scripts. Each terminal session is uniquely identified, allowing for clear differentiation and management of multiple instances.

## [Terminal Routing](xref:PerpetualIntelligence.Terminal.Runtime.ITerminalRouting`1)
Terminal routing orchestrates the execution within the application context. It starts the host and runs indefinitely until the application stops or a cancellation token is received. Developers can implement the `ITerminalRouting<TContext>` interface and define the `RunAsync` method to establish the custom routing logic. 

The framework provides the following ready-to-use routing implementations:

- `TerminalConsoleRouting`: Suitable for standalone terminal or CLI applications.
- `TerminalTcpRouting`: Designed for server terminals managing commands from multiple clients concurrently over TCP/IP.
- `TerminalCustomRouting`: Allows for custom routing strategies.

**Note:** Future versions of the framework will introduce `gRPC` and `HTTP` terminal routing.

## [Command Route](xref:PerpetualIntelligence.Terminal.Commands.CommandRoute)
The CommandRoute is a crucial component, encapsulating the raw command string alongside a unique identifier for each command run. The raw command string represents the command as entered by the user or passed by an application, while the identifier ensures that each command run can be distinctly tracked and managed.

Example:
```
gh issue list
 
gh issue create --label bug
 
dotnet build --runtime ubuntu.18.04-x64
```

## [Command Route Parsing](xref:PerpetualIntelligence.Terminal.Commands.Extractors.CommandRouteParser)
The command route parser interprets raw command strings using predefined descriptors. It is adaptable to various command structures, and processes command strings by segmenting them into commands, arguments and options. The parser identifies different types of commands, including root commands, command groups, and subcommands, providing the necessary context for subsequent processing. 

For applications requiring complex command structures, the parser supports hierarchical parsing, though this is optional and can be configured based on needs. 

> **Note**: While it is designed to handle a wide range of parsing scenarios, developers have the option to implement custom parsers for unique applicaiton requirements.

## [Command](xref:PerpetualIntelligence.Terminal.Commands.Command)
A command in the context of the `pi-cli` framework represents a specific requested action or a set of actions to be performed by the system. It is immutable, ensuring consistency and stability once defined. Commands can range from simple actions like invoking a system method or an operating system command, to more complex operations involving calls to protected APIs across internal or external networks. Essentially, a command has the potential to perform any operation within the context of your application or service.

The [`CommandDescriptor`](xref:PerpetualIntelligence.Terminal.Commands.CommandDescriptor) define the command's identity and its supported options available for end-users or applications. The `CommandDescriptor` also allows for the description of the command's behavior, indicating whether it is a root command, grouped command, or a subcommand.

- Root Command: A root command is the top CLI command. It can represent your organization, a product, or a service. For instance, Github CLI [gh](https://cli.github.com/manual/gh) is an example of an organization root command. Microsoft, however, uses [dotnet](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet) as a root command for the .NET CLI. 
- Grouped Command: A grouped command provides a context for a set of related sub-commands. For instance, Github CLI [gh auth](https://cli.github.com/manual/gh_auth) is an example of a grouped command to authenticate gh and git with GitHub. 
- Sub Command: A subcommand is an individual executable command that performs a specific action. For instance, Github CLI [gh auth login](https://cli.github.com/manual/gh_auth_login) is an example of a subcommand that authenticates with GitHub host. [dotnet build](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build) is a sub-command that builds a project and all of its dependencies.

## [Driver](xref:PerpetualIntelligence.Terminal.Configuration.Options.DriverOptions)
In native console environments, a root command may act as a driver, allowing for direct command execution, akin to `dotnet.exe` in the .NET CLI. To enable this functionality, configure the `DriverOptions` in your terminal settings. Utilize the `Enabled` property to toggle the driver functionality on or off.

Consider executing the command `dotnet build test.csproj --configuration Release` directly from the command prompt:

1. Identify Executable and Root Command: The framework recognizes `dotnet.exe` as the driver and `dotnet` as the root command.
2. Pass Command Line Arguments: The entire string `build test.csproj --configuration Release` is passed as command line arguments.
3. Parse Arguments and Options: The framework parses these arguments and options.
4. Execute Command: Ultimately, the `build` command is executed with the specified project file and configuration.

> **Note**: This feature is an enhancement and being tracked by [github issue](https://github.com/perpetualintelligence/oneterminal/issues/107).

## [Argument](xref:PerpetualIntelligence.Terminal.Commands.Argument)
Arguments within the raw command string are provided directly as values, following a specific sequence when the command supports multiple arguments. Unlike options, which are defined as key-value pairs, arguments are enumerated plainly without keys.

Example:
```
copy "/path/to/source" "/path/to/destination"
```

In this example for a copy command, the source and destination paths are the arguments provided directly in the required order.

## [Option](xref:PerpetualIntelligence.Terminal.Commands.Option)
Options within the raw command string are specified as key-value pairs and are order-independent, providing flexibility in how commands are structured. Each option is identified by its key, and can also be referred to by its alias, if one is defined.

Example:
```
copy "/path/to/source" "/path/to/destination" --recursive -o "/path/to/log"
```

## [Command Router](xref:PerpetualIntelligence.Terminal.Commands.Routers.CommandRouter)
The command router orchestrates the workflow of command processing. It routes raw command string through several steps such as parsing the command string to understand its structure, extracting any arguments and options provided, checking for licensing requirements, and validating the integrity of the command. Once these steps are completed, the command router then automatically invokes the corresponding command runner to execute the command. This entire process is handled seamlessly by the command router.

## [Command Runner](xref:PerpetualIntelligence.Terminal.Commands.Runners.CommandRunner`1)
The command runner is where developers implement how commands are executed. It operates asynchronously to handle commands that might take a while to process. The framework routes each parsed command to its specific runner, helping to organize and manage the command execution logic within your application.

## [Events](xref:PerpetualIntelligence.Terminal.Events.IAsyncEventHandler)
Events play an important role in extending and customizing the behavior of the terminal to meet specific application requirements. Events are hooks that allow developers to inject custom logic and asynchronous operations at various stages of command routing.

- `BeforeCommandRouteAsync`: Called before the command routing process begins.
- `AfterCommandRouteAsync`: Called after the command routing process completes.
- `BeforeCommandRunAsync`: Called before a command starts execution.
- `AfterCommandRunAsync`: Called after a command finishes execution.
- `BeforeCommandCheckAsync`: Called before a command's integrity check.
- `AfterCommandCheckAsync`: Called after a command's integrity check completes.

## [Hosting](xref:PerpetualIntelligence.Terminal.Hosting)
The framework deploys dependency injection at its core to setup and run the terminal host. Developers can utilize the `TerminalHostedService` to configure services, customize terminal behavior, and ensure smooth execution throughout the terminal's lifecycle. For details refer to [configuration options](../configuration-options.md), and [services](../services.md).