# [CliOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.CliOptions)
The pi-cli framework uses the options pattern to provide strongly typed access to groups of related settings. When configuration settings are isolated by scenario into separate classes, the host CLI terminal adheres to two crucial software engineering principles:

- [Interface Segregation Principle (ISP) or Encapsulation](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#encapsulation): Scenarios (classes) that depend on configuration settings depend only on the configuration settings that they use.
- [Separation of Concerns](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns): Settings for different parts of the app aren't dependent or coupled to one another.
Options also provide a mechanism to validate configuration data. For more information, see the Options validation section.

This article provides information on all the supported configuration options by the pi-cli framework.

## [CheckerOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.CheckerOptions)
The command and argument checker options.

> **Note:** The checker options are not filters. The command execution is blocked if any check fails.

### [AllowObsoleteArgument](xref:PerpetualIntelligence.Cli.Configuration.Options.CheckerOptions.AllowObsoleteArgument)
Determines whether the checker allows a command to run with an obsolete argument.

The obsolete argument value check is done at runtime only if a user or an application attempts to run the command and passes an obsolete argument value. This option has no effect if the command supports an obsolete argument, but the user did not give its value through the command string.

### [StrictArgumentValueType](xref:PerpetualIntelligence.Cli.Configuration.Options.CheckerOptions.StrictArgumentValueType)
Determines whether the checker checks an argument value type. If this option is enabled, the checker will try to map an argument value to its corresponding .NET value type. If the mapping fails, the command will not run.

Example:
```
    pi lic gen --lic-edition community --expiry 365 --nbf "26-Apr-2022 14:36:11" --test
```

In the code example above, let's assume the command `pi lic gen` defines 4 arguments:
- lic-edition (string)
- expiry (int)
- nbf (date and time)
- test (boolean)

If the strict argument value type check is enabled,  the checker will do an automatic type check and ensure that argument `lic-edition` is a string, `expiry` is an int, `nbf` is a valid date and time, and `test` is a bool. If any check fails, the command will not run.

> **Note:** If this option is not enabled, the checker will allow all the argument values as strings.

## [ExtractorOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions)
The command and argument extraction options.

### [ArgumentAlias](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentAlias)
Determines whether the extractor support extracting an argument by alias.

Example:
```
    options.Extractor.ArgumentAlias = true;
    dotnet build --configuration Release 
    dotnet build -c Release
```

Argument alias supports the apps that identify a command argument with an id and an alias string. For modern console apps, we recommend using just an argument identifier. We have optimized the core data model to work with argument id. An app should not identify the same argument with multiple strings. Using an alias will degrade the performance.

### [ArgumentAliasPrefix](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentAliasPrefix)
The argument alias prefix if [ArgumentAlias](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentAlias) is enabled. Defaults to `-`.

Example:
```
    dotnet build -c Release 

    options.Extractor.ArgumentAliasPrefix = ":";
    dotnet build :c Release 
```

> **Note:** The argument alias prefix must be a single Unicode character, and it cannot be `null` or whitespace.

### [ArgumentPrefix](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentPrefix)
The argument prefix. Defaults to `-`.

Example:
```
    dotnet build -configuration Release 

    options.Extractor.ArgumentPrefix = "--";
    dotnet build --configuration Release 
```

> **Note:** The argument prefix must be a single Unicode character, and it cannot be `null` or whitespace.

### [ArgumentValueSeparator](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentValueSeparator)
The argument value separator. Defaults to `=`.

Example:
```
    dotnet build -configuration=Release 

    options.Extractor.ArgumentValueSeparator = " ";
    dotnet build -configuration Release     

    options.Extractor.ArgumentValueSeparator = ":";
    dotnet build -configuration:Release     

    options.Extractor.ArgumentValueSeparator = ">";
    dotnet build -configuration>Release 
```

> **Note:** The argument value separator must be a single Unicode character, and it can be a single whitespace character.

### [ArgumentValueWithIn](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentValueWithIn)
An optional token within which to extract an argument value. Default to `null`.

Example:
```
    pi print -message=This is a string without quotes

    options.Extractor.ArgumentValueWithIn = "\"";
    pi print -message="This is a string within quotes"

    options.Extractor.ArgumentValueWithIn = "~";
    pi print -message=~This is a string within tilda~
```

> **Note:** The optional argument within token must be a single Unicode character. If set it cannot be `null` or whitespace.

### [CommandIdRegex](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.CommandIdRegex)
The Regex pattern for command identifier. Defaults to `^[A-Za-z0-9_-]*$`.

### [DefaultArgument](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.DefaultArgument)
Determines whether command supports default argument.

Example:
```
    dotnet restore -p ./projects/app1/app1.csproj

    options.Extractor.DefaultArgument = true;
    dotnet restore ./projects/app1/app1.csproj

```

In the code example above, let's assume the command `dotnet restore` has a default argument `p`. The command string's argument value `./projects/app1/app1.csproj` is automatically set to the default argument `p`.

### [DefaultArgumentValue](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.DefaultArgumentValue)
Determines whether argument support default value.

Example:
```
    dotnet build ./projects/app1/app1.csproj -c RELEASE

    options.Extractor.DefaultArgumentValue = true;
    dotnet build ./projects/app1/app1.csproj

```

In the code example above, let's assume the command `dotnet build` has defined a required configuration argument `c` with a default value `DEBUG`. Even though the command string did not specify any configuration value, the extractor will automatically set the `c` value to `DEBUG` during the command run.

### [Separator](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.Separator)
The command string separator. Defaults to a single whitespace ` `.

Example:
```
    pi gen guid --short
    dotnet publish --framework netcoreapp3.1 --runtime osx.10.11-x64
    डॉटनेट पब्लिश --कॉन्फिग रिलीज --सैंपल हिंदी

    options.Extractor.Separator = ":";
    options.Extractor.ArgumentValueSeparator = " ";
    dotnet:publish:--framework netcoreapp3.1:--runtime osx.10.11-x64
    pi:gen:guid:--short

```

> **Note:** The command string separator must be a single Unicode character, and it can be a whitespace character.

## [HandlerOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.HandlerOptions)

The handler options.

### [DataTypeHandler](xref:PerpetualIntelligence.Cli.Configuration.Options.HandlerOptions.DataTypeHandler)
The data type handler. Its value can be `null`, `default` or `custom`. The `default` and `custom` are reserved for future releases.

- `null` indicates no data type handler.
- :tipping_hand_person: `default` to be defined.
- :tipping_hand_person: `custom` to be defined.

> By default the value is set to `null`.

### [ErrorHandler](xref:PerpetualIntelligence.Cli.Configuration.Options.HandlerOptions.ErrorHandler)
The hosting and routing error handler. Its value can be `default` or `custom`. The command router receives an error or exception during the command routing, extraction, checker, or execution. On error, it forwards it to the @PerpetualIntelligence.Cli.Commands.Handlers.IErrorHandler or @PerpetualIntelligence.Cli.Commands.Handlers.IExceptionHandler.

- `default` handler prints the error information in the CLI terminal.
- `custom` handler allows application authors to define a custom error handler to process and publish the error according to their needs. E.g., app authors can publish the errors to a central log or on their cloud backend for audit purposes.

> By default the value is set to `default`.

### [LicenseHandler](xref:PerpetualIntelligence.Cli.Configuration.Options.HandlerOptions.LicenseHandler)
The license handler. Its value can be `online`, `offline`, or `byol`. The `offline` or `byol` are reserved for future releases.

- `online` handler checks your license key online. Your CLI terminal needs network access during startup.
- :soon: `offline` handler checks your license key offline. Your CLI terminal does not need network access during startup.
- :soon: `boyl` handler allows you to bring you own license certificate to check the license key. Your CLI terminal may need network access during startup.

> By default the value is set to `online`.

### [ServiceHandler](xref:PerpetualIntelligence.Cli.Configuration.Options.HandlerOptions.ServiceHandler)
The hosting and routing dependency injection services. Its value can be `default` or `custom`. The `custom` is reserved for future releases.

- `default` handler provides default DI service implementations for command router, extractor, checker and runner.
- :soon: `custom` handler allows application authors to define a custom DI services implementations.

> By default the value is set to `default`.

### [StoreHandler](xref:PerpetualIntelligence.Cli.Configuration.Options.HandlerOptions.StoreHandler)
The command and argument store handler. Its value can be `in-memory`, `json` or `custom`. The `json` or `custom` are reserved for future releases.

- `in-memory` handler provides in memory command and argument descriptions.
- :soon: `json` handler provides command and argument descriptions in a JSON file.
- :soon: `custom` handler allows application authors to provide command and argument descriptions from a custom store such as Entity framework or cloud databases REST API.

> By default the value is set to `in-memory`.

### [TextHandler](xref:PerpetualIntelligence.Cli.Configuration.Options.HandlerOptions.TextHandler)
The hosting and routing command string text handler. Its value can be `unicode` or `ascii`. The `ascii` is reserved for future releases.

- `unicode` handler supports Unicode command strings.
- :soon: `ascii` handler supports ASCII command strings.

> By default the value is set to `unicode`. Currently we only support `left-to-right` languages.

## [HttpOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.HttpOptions)
The HTTP configuration options.

### [HttpClientName](xref:PerpetualIntelligence.Cli.Configuration.Options.HttpOptions.HttpClientName)
The logical name to create and configure @"System.Net.Http.HttpClient" instance. The framework uses @"System.Net.Http.IHttpClientFactory" and the configured name to create an instance of @System.Net.Http.HttpClient.

## [LicensingOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.LicensingOptions)
The licensing configuration options. Please visit [licensing](licensing/intro.md) to generate license keys and access your identifiers.

> **Note:** You will require a valid community or commercial license and identifiers to set the licensing options. To use our test license for quick onboarding and evaluation, please refer to [this link](intro.md#demo-license).

### [AuthorizedApplicationId](xref:PerpetualIntelligence.Cli.Configuration.Options.LicensingOptions.AuthorizedApplicationId)
The authorized application id. This is also the `auth_apps` claim from your license key.

### [ConsumerTenantId](xref:PerpetualIntelligence.Cli.Configuration.Options.LicensingOptions.ConsumerTenantId)
The consumer tenant id.

### [KeySource](xref:PerpetualIntelligence.Cli.Configuration.Options.LicensingOptions.KeySource)
The license key source. Defaults to @PerpetualIntelligence.Protocols.Licensing.SaaSKeySources.JsonFile.

### [LicenseKey](xref:PerpetualIntelligence.Cli.Configuration.Options.LicensingOptions.LicenseKey)
The license key or the file path containing license key.

### [ProviderId](xref:PerpetualIntelligence.Cli.Configuration.Options.LicensingOptions.ProviderId)
The license SaaS provider id or the provider tenant id. Defaults to @PerpetualIntelligence.Protocols.Licensing.SaaSProviders.PerpetualIntelligence.

### [Subject](xref:PerpetualIntelligence.Cli.Configuration.Options.LicensingOptions.Subject)
The subject or a licensing context to check the license. Your subscription id or any other domain identifier usually establishes your licensing context.

## [LoggingOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.LoggingOptions)
The logging configuration options.

### [ObscureErrorArgumentString](xref:PerpetualIntelligence.Shared.Infrastructure.LoggingOptions.ObscureErrorArgumentString)
The string used to obscure error description arguments. The default value is `****`.

Example:
```
    // Obscure error args
    options.Logging.ObsureErrorArguments = true;
    options.Logging.ObscureErrorArgumentString = "####";
    [10:49:10 error] The license is not extracted or license is not valid. Please ensure you use the CLI hosted service. service=####

    options.Logging.ObsureErrorArguments = false;
    options.Logging.ObscureErrorArgumentString = "####";
    [10:49:10 error] The license is not extracted or license is not valid. Please ensure you use the CLI hosted service. service=PerpetualIntelligence.Cli.Integration.CliHostedService
```

### [ObsureErrorArguments](xref:PerpetualIntelligence.Shared.Infrastructure.LoggingOptions.ObsureErrorArguments)
Obscures the arguments in the error description to hide the sensitive data. The default value is `true`.

## [RouterOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.RouterOptions)

The command router options.

### [Timeout](xref:PerpetualIntelligence.Cli.Configuration.Options.RouterOptions.Timeout)
The command router timeout in milliseconds. The default value is `25` seconds. Use @System.Threading.Timeout.Infinite for infinite timeout.

> **Note:** A command route starts at a request to execute the command and ends when the command run is complete or at an error.

## [TerminalOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.TerminalOptions)

The terminal configuration options.

> Reserved for future.

## [AuthenticationOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.AuthenticationOptions)

:soon: The authentication configuration options. 

> Planned for next major release.

# References
- [Options pattern in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/options)
- [Architectural principles](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles)
