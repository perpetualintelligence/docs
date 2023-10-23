# Services (Dependency Injection)
`pi-cli` supports the dependency injection (DI) software design pattern, a technique for achieving Inversion of Control (IoC) between classes and their dependencies, along with [configuration options](options.md) and [logging](logging.md). A dependency is an object that another object depends on.

## Extension Methods
The following classes provide extension methods to register the host application's `pi-cli` DI services.

- @PerpetualIntelligence.Terminal.Extensions.IServiceCollectionExtensions
- @PerpetualIntelligence.Terminal.Integration.ICliBuilder
- @PerpetualIntelligence.Terminal.Configuration.Options.CliOptions

We have grouped the extension methods based on the feature they support.

## Core
Involves defining and registering the core CLI infrastructure and services.

### AddCli

Adds the core services to the DI service collection. @PerpetualIntelligence.Terminal.Extensions.IServiceCollectionExtensions provide extension methods that return a @PerpetualIntelligence.Terminal.Integration.ICliBuilder object which in turn provides extension methods to add `pi-cli` specific services to the host application.

```
public static ICliBuilder AddCli(this IServiceCollection services)
```
```
public static ICliBuilder AddCli(this IServiceCollection services, IConfiguration configuration)
```
```
public static ICliBuilder AddCli(this IServiceCollection services, Action<CliOptions> setupAction)
```

#### AddCliOptions

Adds the configuration options to the DI service collection.

```
public static ICliBuilder AddCliOptions(this ICliBuilder builder)
```

#### AddRouter<TRouter, THandler>

Adds the command router and handler to the DI service collection.

```
public static ICliBuilder AddRouter<TRouter, THandler>(this ICliBuilder builder)
    where TRouter : class, ICommandRouter where THandler : class, ICommandHandler
```

#### AddLicensing

Adds the license extractor and checker to the DI service collection.

```
public static ICliBuilder AddLicensing(this ICliBuilder builder)
```

> **Note**: Application authors should not explicitly use any core services above; instead, use `AddCli`.

## Extraction
Involves extracting commands and arguments from the command string.

### AddExtractor<TCommand, TArgument>

Adds the command and argument extractor to the DI service collection.

```
public static ICliBuilder AddExtractor<TCommand, TArgument>(this ICliBuilder builder)
    where TCommand : class, ICommandExtractor where TArgument : class, IArgumentExtractor
```

## Definition
Involves describing commands, arguments, checkers, and runners.

### AddDescriptor<TRunner, TChecker>

Adds a command descriptor, argument descriptors, command checker, and command runner to the DI service collection.

```
public static ICliBuilder AddDescriptor<TRunner, TChecker>(this ICliBuilder builder, CommandDescriptor commandDescriptor, bool isGroup = false, bool isRoot = false, bool isProtected = false)
    where TRunner : class, ICommandRunner where TChecker : class, ICommandChecker
```

## Behavior
Involves defining the default or custom behavior.

### AddArgumentChecker<TMapper, TChecker>

Adds an argument data type mapper and argument checker to the DI service collection.

```
public static ICliBuilder AddArgumentChecker<TMapper, TChecker>(this ICliBuilder builder)
    where TMapper : class, IArgumentDataTypeMapper where TChecker : class, IArgumentChecker
```

### AddErrorHandler<TError, TException>

Adds the error and exception handler to the DI service collection.

```
public static ICliBuilder AddArgumentChecker<TMapper, TChecker>(this ICliBuilder builder)
    where TError : class, IErrorHandler where TException : class, IExceptionHandler
```

### AddTextHandler<TTextHandler>

Adds the text handler to the DI service collection.

```
public static ICliBuilder AddTextHandler<TTextHandler>(this ICliBuilder builder) 
    where TTextHandler : class, ITextHandler    
```

## Store
Involves storing and retrieving the command descriptors.

### AddStoreHandler<TStore>

Adds the store handler to the DI service collection. 

```
public static ICliBuilder AddStoreHandler<TStore>(this ICliBuilder builder)
    where TStore : class, ICommandStoreHandler
```
