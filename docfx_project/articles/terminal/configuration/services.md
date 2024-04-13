# Services (Dependency Injection)
`OneImlx.Terminal` supports the dependency injection (DI) software design pattern, a technique for achieving Inversion of Control (IoC) between classes and their dependencies. This framework allows for easy integration with [configuration options](options.md) and [logging](logging.md) to create robust, maintainable, and scalable terminal applications.

## Extension Methods
To facilitate the integration of `OneImlx.Terminal` services into a host application's dependency injection container, the following classes offer extension methods:

- [IServiceCollectionExtensions](xref:OneImlx.Terminal.Extensions.IServiceCollectionExtensions): Offers extension methods to register and configure `OneImlx.Terminal` services within the host application's dependency injection container.
- [IHostExtensions](xref:OneImlx.Terminal.Extensions.IHostExtensions): Provides an extension method to run the terminal routing, enabling the execution of commands within the terminal application.
- [ITerminalBuilderExtensions](xref:OneImlx.Terminal.Extensions.ITerminalBuilderExtensions): Enhances the terminal builder with additional configuration and customization options.
- [ICommandBuilderExtensions](xref:OneImlx.Terminal.Extensions.ICommandBuilderExtensions): Provides extension methods to aid in the configuration and creation of commands in the terminal application.
- [IOptionBuilderExtensions](xref:OneImlx.Terminal.Extensions.IOptionBuilderExtensions): Offers methods for defining and configuring command options, ensuring their proper integration and validation.
- [TerminalOptions](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions): Represents the configurable options for the `OneImlx.Terminal` terminal application, allowing for customization of its behavior.

## Hosted Service
You need to register a @OneImlx.Terminal.Hosting.TerminalHostedService using standard .NET extension method [`AddHostedService`](xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions.AddHostedService`1). This will enable you to define and customize terminal startup and lifetime behavior.

```csharp
collection.AddHostedService<TestAppHostedService>();
```

## HTTP Client
If you are using an online license then you will need to register the HttpClient service in your application. This service is used to communicate with the our licensing server to validate the license. 

```csharp
collection.AddHttpClient("demo-http");
```

The `demo-http` is the name of the HTTP client instance. You can use any name you like. The HTTP client registration is required only if you are using an online license.

## Integrate Framework
Integrating the `OneImlx.Terminal` framework into a .NET application is straightforward with two standard methods designed for most use cases. These methods facilitate the registration of terminal services within your application's Dependency Injection (DI) service collection. For advanced scenarios, the framework also allows for more granular control by using individual services. 

### AddTerminalDefault
The [`AddTerminalDefault`](xref:OneImlx.Terminal.Extensions.IServiceCollectionExtensions.AddTerminalDefault```3) method adds essential terminal functionalities to your application, such as command handling, text processing, and help provider. It registers the foundational terminal services in your project, allowing customization through setup actions.

```csharp
ITerminalBuilder terminalBuilder = collection.AddTerminalDefault<TerminalInMemoryCommandStore, TerminalUnicodeTextHandler, TerminalHelpLoggerProvider>(new TerminalUnicodeTextHandler(),
    options =>
    {
        options.Id = TerminalIdentifiers.TestApplicationId;
        options.Licensing.LicenseFile = "C:\\this\\perpetualintelligence\\tools\\lic\\oneimlx-terminal-demo-test.json";
        options.Router.Caret = "> ";
    }
);
```

### AddTerminalConsole
The [`AddTerminalConsole`](xref:OneImlx.Terminal.Extensions.IServiceCollectionExtensions.AddTerminalConsole````4) method extends `AddTerminalDefault` by adding console-specific functionalities. This method integrates additional services tailored for console applications, building on the foundational terminal services.

```csharp
ITerminalBuilder terminalBuilder = collection.AddTerminalConsole<TerminalInMemoryCommandStore, TerminalUnicodeTextHandler, TerminalHelpConsoleProvider, TerminalSystemConsole>(new TerminalUnicodeTextHandler(),
    options =>
    {
        options.Id = TerminalIdentifiers.TestApplicationId;
        options.Licensing.LicenseFile = "C:\\this\\perpetualintelligence\\tools\\lic\\oneimlx-terminal-demo-test.json";
        options.Router.Caret = "> ";
    }
);
```

### Advanced Use Cases
For more detailed control and customization, developers can use specific services from the OneImlx.Terminal framework. This option supports creating tailored terminal experiences for unique application needs, offering flexibility for intricate setups.

## Add Descriptors
The [`ITerminalBuilder`](xref:OneImlx.Terminal.Extensions.ITerminalBuilderExtensions) extensions offer both explicit and declarative syntaxes for registering command, argument and option descriptors within the service collection.

When deciding between explicit and declarative syntax for command registration, consider both usability and performance implications. Explicit syntax is more efficient as it avoids reflection, unlike declarative syntax, which may be more resource-intensive due to its use of reflection. However, for applications with intricate command hierarchies, the straightforward usability of declarative syntax could be appealing despite potential performance costs. Given that command registration is a startup activity, the performance impact primarily affects initial load time, not runtime. Developers should assess these factors based on their application's specific needs and performance requirements.

### Explicit Syntax
The explicit syntax method for command registration in the framework is a direct and controlled approach to integrating command functionalities into your .NET application. This method primarily revolves around the use of hosting builders, which are sophisticated tools provided by the framework to manually define and register command descriptors with the service collection.

```csharp
private static void RegisterCommands(ITerminalBuilder terminalBuilder)
{
    terminalBuilder.DefineCommand<TestChecker, TestRunner>("test", "Test command", "Test Description", Commands.CommandType.Root, Commands.CommandFlags.None)
                        .DefineArgument(1, "arg1", nameof(String), "The first argument", Commands.ArgumentFlags.None)
                            .Add()
                        .DefineArgument(2, "arg2", nameof(Int32), "The second argument", Commands.ArgumentFlags.None)
                            .Add()
                        .DefineOption("version", nameof(String), "The version option", Commands.OptionFlags.None, "v")
                            .Add()
                    .Add();
}
```


>Note: In the explicit syntax for command registration, the `Add()` method is necessary for finalizing and registering commands, arguments or options. It commits an element definition and adds the command descriptor to the service collection.

### Declarative Syntax
Alternatively, descriptors can also be defined directly on command runners using [declarative attributes](xref:OneImlx.Terminal.Commands.Declarative).

```csharp
[CommandDescriptor("test", "Test App", "Test application description.", Commands.CommandType.Root, Commands.CommandFlags.None)]
[OptionDescriptor("version", nameof(String), "Test version description", Commands.OptionFlags.None, "v")]
[CommandChecker(typeof(CommandChecker))]
public class TestRunner : CommandRunner<CommandRunnerResult>, IDeclarativeRunner
    {
        ...
    }
}
```

The framework automatically discovers and registers these command descriptors through the `AddDeclarative...` extension methods.

```csharp
// Add all the commands in the assembly using declarative syntax.
terminalBuilder.AddDeclarativeAssembly<TestRunner>();
```

> Note: For declarative syntax it is necessrary to implement @OneImlx.Terminal.Commands.IDeclarativeRunner interface in the command runner class.

## Complete Integration Example
Below is an example showing the `AddTerminalConsole` method in action, configuring the terminal framework for a console application with an online demo license.

```csharp
 private static void ConfigureOneImlxTerminal(IServiceCollection collection)
{
    // Configure the hosted service
    collection.AddHostedService<TestAppHostedService>();

    // We are using online license so configure HTTP
    collection.AddHttpClient("demo-http");

    // NOTE:
    // Specify your demo or commercial license file.
    // Specify your application id.
    ITerminalBuilder terminalBuilder = collection.AddTerminalConsole<TerminalInMemoryCommandStore, TerminalUnicodeTextHandler, TerminalHelpConsoleProvider, TerminalSystemConsole>(new TerminalUnicodeTextHandler(),
        options =>
        {
            options.Id = TerminalIdentifiers.TestApplicationId;
            options.Licensing.LicenseFile = "C:\\this\\perpetualintelligence\\tools\\lic\\oneimlx-terminal-demo-test.json";
            options.Router.Caret = "> ";
        }
    );

    // Add commands using declarative syntax.
    terminalBuilder.AddDeclarativeAssembly<TestRunner>();
}
```
