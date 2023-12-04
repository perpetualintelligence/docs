# Services (Dependency Injection)
`OneImlx.Terminal` supports the dependency injection (DI) software design pattern, a technique for achieving Inversion of Control (IoC) between classes and their dependencies, along with [configuration options](configurationoptions.md) and [logging](logging.md). A dependency is an object that another object depends on.

## Extension Methods
The following classes provide extension methods to register the host application's `OneImlx.Terminal` DI services.

- [IServiceCollectionExtensions](xref:OneImlx.Terminal.Extensions.IServiceCollectionExtensions): Offers extension methods to register and configure `OneImlx.Terminal` services within the host application's dependency injection container.
- [IHostExtensions](xref:OneImlx.Terminal.Extensions.IHostExtensions): Provides an extension method to run the terminal routing, enabling the execution of commands within the terminal application.
- [ITerminalBuilderExtensions](xref:OneImlx.Terminal.Extensions.ITerminalBuilderExtensions): Enhances the terminal builder with additional configuration and customization options.
- [ICommandBuilderExtensions](xref:OneImlx.Terminal.Extensions.ICommandBuilderExtensions): Provides extension methods to aid in the configuration and creation of commands in the terminal application.
- [IOptionBuilderExtensions](xref:OneImlx.Terminal.Extensions.IOptionBuilderExtensions): Offers methods for defining and configuring command options, ensuring their proper integration and validation.
- [TerminalOptions](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions): Represents the configurable options for the `OneImlx.Terminal` terminal application, allowing for customization of its behavior.

## [IServiceCollectionExtensions](xref:OneImlx.Terminal.Extensions.IServiceCollectionExtensions)
This section provides guidance on integrating the `OneImlx.Terminal` terminal framework into your .NET application using the available extension methods.

### AddTerminal
`AddTerminal` integrates `OneImlx.Terminal` into your application, configuring necessary services and setting up command store and text handling functionalities.

```csharp
services.AddTerminal<ICommandStore, ITextHandler>();
```
- ICommandStore: A store to lookup a [CommandDescriptor](xref:OneImlx.Terminal.Commands.CommandDescriptor).
- ITextHandler: An abstraction to handle all textual operations.

#### Setup with Configuration Options
This variant allows for direct configuration of `TerminalOptions` within your setup.

```csharp
services.AddTerminal<ICommandStore, ITextHandler>(options =>
{
    // Configure options here
});
```

#### Setup with IConfiguration Binding
This variant enables binding `TerminalOptions` to a configuration section, allowing for configuration via app settings or other configuration providers.
    
```csharp
services.AddTerminal<ICommandStore, ITextHandler>(Configuration.GetSection("Terminal"));
```

### Default Services
`OneImlx.Terminal` offers methods to add default services commonly required for terminal applications.

#### AddTerminalDefault
Adds terminal services along with default implementations for command handling, argument checking, option checking, and help providing.

```csharp
public static ITerminalBuilder AddTerminalDefault<TStore, TText, THelp>(this IServiceCollection services, Action<TerminalOptions> setupAction)
            where TStore : class, ICommandStore
            where TText : class, ITextHandler
            where THelp : class, IHelpProvider
{
    if (services == null)
    {
        throw new ArgumentNullException(nameof(services));
    }

    if (setupAction == null)
    {
        throw new ArgumentNullException(nameof(setupAction));
    }

    return services.AddTerminal<TStore, TText>(setupAction)
                   .AddCommandRouter<CommandRouter, CommandHandler>()
                   .AddCommandExtractor<CommandExtractor, CommandRouteParser>()
                   .AddOptionChecker<DataTypeMapper<Option>, OptionChecker>()
                   .AddArgumentChecker<DataTypeMapper<Argument>, ArgumentChecker>()
                   .AddExceptionHandler<ExceptionHandler>()
                   .AddHelpProvider<THelp>();
}
```

#### AddTerminalConsole
Designed specifically for console applications, this method configures terminal services and additional console-specific services.

```csharp
public static ITerminalBuilder AddTerminalConsole<TStore, TText, THelp, TConsole>(this IServiceCollection services, Action<TerminalOptions> setupAction)
    where TStore : class, ICommandStore
    where TText : class, ITextHandler
    where THelp : class, IHelpProvider
    where TConsole : class, ITerminalConsole
{
    if (services == null)
    {
        throw new ArgumentNullException(nameof(services));
    }

    if (setupAction == null)
    {
        throw new ArgumentNullException(nameof(setupAction));
    }

    return services.AddTerminalDefault<TStore, TText, THelp>(setupAction)
                   .AddRouting<TerminalConsoleRouting, TerminalConsoleRoutingContext>()
                   .AddConsole<TConsole>();
}
```

### Further Configuration
The `AddTerminal` methods return an instance of ITerminalBuilder, providing additional extension methods for more advanced configuration and service registration.

```
public static ICliBuilder AddCliOptions(this ICliBuilder builder)
```

## [IHostExtensions](xref:OneImlx.Terminal.Extensions.IHostExtensions)
`IHostExtensions` provides methods to run the terminal framework within the host application's runtime.

### RunTerminalRoutingAsync

`RunTerminalRoutingAsync` is an extension method for `IHost`, designed to asynchronously execute terminal routing.

```csharp
await host.RunTerminalRoutingAsync<TRouting, TContext>(context);
```
> **Note**: `RunTerminalRoutingAsync` blocks the calling thread until a cancellation request.

## [ITerminalBuilderExtensions](xref:OneImlx.Terminal.Extensions.ITerminalBuilderExtensions)
`ITerminalBuilderExtensions` provides methods to customize the terminal framework execution services for commands.

### AddOptionChecker
This extension method is used to add option checking functionality to the terminal builder. It registers a custom option mapper and a custom option checker to the services collection.

```csharp
public static ITerminalBuilder AddOptionChecker<TMapper, TChecker>(this ITerminalBuilder builder) 
    where TMapper : class, IDataTypeMapper<Option> 
    where TChecker : class, IOptionChecker
{
    builder.Services.AddTransient<IDataTypeMapper<Option>, TMapper>();
    builder.Services.AddTransient<IOptionChecker, TChecker>();
    return builder;
}
```

### AddArgumentChecker
This method enhances the terminal builder by introducing argument checking capabilities. It does so by adding a specific argument mapper and argument checker to the service collection.

```csharp
public static ITerminalBuilder AddArgumentChecker<TMapper, TChecker>(this ITerminalBuilder builder) 
    where TMapper : class, IDataTypeMapper<Argument> 
    where TChecker : class, IArgumentChecker
{
    builder.Services.AddTransient<IDataTypeMapper<Argument>, TMapper>();
    builder.Services.AddTransient<IArgumentChecker, TChecker>();
    return builder;
}
```

### AddEventHandler
Adds an asynchronous event handler to the terminal builder's services.

```csharp
public static ITerminalBuilder AddEventHandler<TEventHandler>(this ITerminalBuilder builder) 
    where TEventHandler : class, IAsyncEventHandler
{
    builder.Services.AddSingleton<IAsyncEventHandler, TEventHandler>();
    return builder;
}
```

### AddConfigurationOptions
This extension method configures the terminal options and adds them to the service collection. It also registers a configuration options checker.

```csharp
public static ITerminalBuilder AddConfigurationOptions(this ITerminalBuilder builder)
{
    builder.Services.AddOptions();
    builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<TerminalOptions>>().Value);
    builder.Services.AddSingleton<IConfigurationOptionsChecker, ConfigurationOptionsChecker>();
    return builder;
}
```

### AddStartContext
Adds a start context to the terminal builder, allowing for the configuration of the terminal's startup behavior.

```csharp
public static ITerminalBuilder AddStartContext(this ITerminalBuilder builder, TerminalStartContext terminalStartContext)
{
    builder.Services.AddSingleton(terminalStartContext);
    return builder;
}
```

### AddHelpProvider
Registers a custom help provider to the terminal builder.

```csharp
public static ITerminalBuilder AddHelpProvider<THelpProvider>(this ITerminalBuilder builder) 
    where THelpProvider : class, IHelpProvider
{
    builder.Services.AddSingleton<IHelpProvider, THelpProvider>();
    return builder;
}
```

### AddDeclarativeAssembly
Scans an assembly for declarative targets and adds them to the terminal builder.

```csharp
public static ITerminalBuilder AddDeclarativeAssembly(this ITerminalBuilder builder, Type assemblyType)
{
    IEnumerable<Type> declarativeTypes = assemblyType.Assembly.GetTypes()
        .Where(e => typeof(IDeclarativeTarget).IsAssignableFrom(e));

    foreach (Type type in declarativeTypes)
    {
        AddDeclarativeTarget(builder, type);
    }

    return builder;
}
```

### AddDeclarativeAssembly
A generic version of AddDeclarativeAssembly, allowing for type-safe assembly scanning.

```csharp
public static ITerminalBuilder AddDeclarativeAssembly<TType>(this ITerminalBuilder builder)
{
    return AddDeclarativeAssembly(builder, typeof(TType));
}
```

### AddExceptionHandler
Registers a custom exception handler to the terminal builder.

```csharp
public static ITerminalBuilder AddExceptionHandler<THandler>(this ITerminalBuilder builder) 
    where THandler : class, IExceptionHandler
{
    builder.Services.AddTransient<IExceptionHandler, THandler>();
    return builder;
}
```

### AddCommandParser
Registers command extraction and parsing capabilities to the terminal builder.

```csharp
public static ITerminalBuilder AddCommandExtractor<TCommand, TParser>(this ITerminalBuilder builder) 
    where TCommand : class, ICommandExtractor 
    where TParser : class, ICommandRouteParser
{
    builder.Services.AddTransient<ICommandExtractor, TCommand>();
    builder.Services.AddTransient<ICommandRouteParser, TParser>();
    return builder;
}
```

### AddLicensing
Registeres licensing services into the terminal builder.

```csharp
public static ITerminalBuilder AddLicensing(this ITerminalBuilder builder)
{
    builder.Services.AddSingleton<ILicenseDebugger, LicenseDebugger>();
    builder.Services.AddSingleton<ILicenseExtractor, LicenseExtractor>();
    builder.Services.AddSingleton<ILicenseChecker, LicenseChecker>();
    return builder;
}
```

### AddRouter
Registeres licensing services into the terminal builder.

```csharp
public static ITerminalBuilder AddLicensing(this ITerminalBuilder builder)
{
    builder.Services.AddSingleton<ILicenseDebugger, LicenseDebugger>();
    builder.Services.AddSingleton<ILicenseExtractor, LicenseExtractor>();
    builder.Services.AddSingleton<ILicenseChecker, LicenseChecker>();
    return builder;
}
```

### AddRouter
Registeres licensing services into the terminal builder.

```csharp
public static ITerminalBuilder AddLicensing(this ITerminalBuilder builder)
{
    builder.Services.AddSingleton<ILicenseDebugger, LicenseDebugger>();
    builder.Services.AddSingleton<ILicenseExtractor, LicenseExtractor>();
    builder.Services.AddSingleton<ILicenseChecker, LicenseChecker>();
    return builder;
}
```
