# Configuration Options
The terminal framework utilizes the options pattern, facilitating strongly typed access to groups of related settings. By isolating configuration settings into separate classes based on scenarios, the host CLI or terminal app upholds two fundamental software engineering principles:

- [Interface Segregation Principle (ISP) or Encapsulation](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#encapsulation): Classes dependent on configuration settings are only reliant on the settings they actually use, promoting clean and maintainable code.
- [Separation of Concerns](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns): Settings for different components of the application are isolated from each other, ensuring that changes in one area do not affect the others.

Furthermore, options offer a method for validating configuration data, ensuring that your application runs smoothly with correct and valid configurations.

## Configurability
### [Command Options](concepts/options.md)
Command options or simply options in `pi-cli` are specified directly in the command string as flags or key-value pairs, influencing the behavior of a specific command. They are defined within the command descriptor, parsed, and validated at runtime, allowing users to tailor the command's behavior to their specific needs. An example is `update-profile --username=johndoe --email=johndoe@example.com`, where `--username` and `--email` are command options providing values for the `update-profile` command.

### [Configuration Options](https://learn.microsoft.com/en-us/dotnet/core/extensions/options)
Configuration options, conversely, configure the overall application behavior and are a part of the [Options Design Pattern](https://docs.microsoft.com/en-us/dotnet/core/extensions/options) in .NET. They are generally set in configuration files like `appsettings.json` or through environment variables, and are loaded at startup, offering a structured way to manage settings across multiple commands or the entire application.


## [TerminalOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions)
This `TerminalOptions` outlines all the configuration options supported by the terminal framework, providing you with the information you need to effectively configure and optimize your application.


- [`Id`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Id): A unique identifier for the terminal instance.
- [`Driver`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Driver): Configuration options for the terminal's driver (reserved for future versions).
- [`Authentication`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Authentication): Configuration options for authentication (reserved for future versions).
- [`Checker`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Checker): Configuration options for command, argument and option validation.
- [`Extractor`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Extractor): Configuration options for extracting command arguments and options from the input string.
- [`Handler`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Handler): Configuration options for command handlers.
- [`Http`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Http): Configuration options related to HTTP interactions.
- [`Licensing`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Licensing): Configuration options for licensing.
- [`Router`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Router): Configuration options for the command router.
- [`Help`](xref:PerpetualIntelligence.Terminal.Configuration.Options.TerminalOptions.Help): Configuration options related to the help system.

## [CheckerOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.CheckerOptions)
The command, argument, and option checker configuration options. The checker options are not filters. The command execution is blocked if any check fails.

### [AllowObsolete](xref:PerpetualIntelligence.Terminal.Configuration.Options.CheckerOptions.AllowObsolete)
This setting determines the checker's behavior when a command is executed with obsolete arguments or options.

- **Runtime Check**: The obsolete check triggers at runtime, specifically when a user or an application runs a command with an obsolete argument or option.
- **Conditional Effect**: The setting is inactive if an obsolete argument is supported by the command but not provided in the command string at runtime.

### [StrictValueType](xref:PerpetualIntelligence.Terminal.Configuration.Options.CheckerOptions.StrictValueType)
This setting determines if the checker verifies the data type of argument or option value. When enabled, the checker attempts to match each value to its designated .NET data type, and if any mismatch occurs, it prevents the command from running.

**Example Command**:
```plaintext
pi lic gen --lic-edition community --expiry 365 --nbf "26-Apr-2022 14:36:11" --test
```

In the example above, the `pi lic gen` command includes four options:

- `lic-edition` (string)
- `expiry` (int)
- `nbf` (date and time)
- `test` (boolean)

With `StrictValueType` enabled, the checker conducts automatic type validation to ensure:

- `lic-edition` is a [System.String](xref:System.String)
- `expiry` is a [System.Int32](xref:System.Int32)
- `nbf` is a valid [System.DateTime](xref:System.DateTime)
- `test` is a [System.Boolean](xref:System.Boolean)

If any of these validations fail, the command will not execute.

> **Note:** Disabling this configuration option results in the checker interpreting all values as strings.

## [DriverOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.DriverOptions)
Reserved for future use, the `DriverOptions` provide configuration settings for operating the terminal as a native driver program.

### [Enabled](xref:PerpetualIntelligence.Terminal.Configuration.Options.DriverOptions.Enabled)
Determines if the terminal functions as a native driver program, allowing execution of commands directly from a native command prompt. This option is a nullable boolean (`bool?`).

### [Name](xref:PerpetualIntelligence.Terminal.Configuration.Options.DriverOptions.Name)
Specifies the name of the terminal driver program. This option is of type `string?`.

> **Note:** These configuration options are reserved for future development and enhancements of the terminal framework.

## [ExtractorOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.ExtractorOptions)
Configuration options for extracting command and argument strings.

### [OptionAliasPrefix](xref:PerpetualIntelligence.Terminal.Configuration.Options.ExtractorOptions.OptionAliasPrefix)
Specifies the prefix for option aliases, defaulting to `-`. It cannot be `null` or whitespace.

```csharp
// Example
options.Extractor.OptionAliasPrefix = "-";
dotnet build -c Release
```

In the example above, -c is recognized as an option alias.

### [OptionPrefix](xref:PerpetualIntelligence.Terminal.Configuration.Options.ExtractorOptions.OptionPrefix)
Defines the prefix for options, with a default of `--`. Like `OptionAliasPrefix`, it cannot be null or whitespace.

```csharp
// Example
options.Extractor.OptionPrefix = "--";
dotnet run --configuration Debug
```

In the example above, `--configuration` is recognized as an option.

### [OptionValueSeparator](xref:PerpetualIntelligence.Terminal.Configuration.Options.ExtractorOptions.OptionValueSeparator)
Sets the separator between an option and its value, defaulting to a space ` `. It must be a single Unicode character but can be whitespace.

```csharp
// Example
options.Extractor.OptionValueSeparator = " ";
dotnet run --framework netcoreapp3.1
```

In this case, the space between `--framework` and `netcoreapp3.1` is the option value separator.

### [ValueDelimiter](xref:PerpetualIntelligence.Terminal.Configuration.Options.ExtractorOptions.ValueDelimiter)
Specifies a delimiter for enclosing argument or option values, with a default of `"`.

```csharp
// Example
options.Extractor.ValueDelimiter = "\"";
dotnet run --project "My Project"
```

The quotes around My Project are the value delimiters..


### [Separator](xref:PerpetualIntelligence.Terminal.Configuration.Options.ExtractorOptions.Separator)
Determines the separator for the command string, defaulting to a single space ` `. It must be a single Unicode character and can be whitespace.

```csharp
// Example
options.Extractor.Separator = " ";
dotnet publish --runtime linux-x64
```

The spaces between the command and options are the separators.

### [ParseHierarchy](xref:PerpetualIntelligence.Terminal.Configuration.Options.ExtractorOptions.ParseHierarchy)
Indicates whether to parse the command hierarchy, which is optional and defaults to null. A command hierarchy includes the command route from root to executing command, through any nested groups.

```csharp
// Example
options.Extractor.ParseHierarchy = true;
dotnet publish --configuration Release --runtime linux-x64
```

In this example, if ParseHierarchy is enabled, the extractor will parse the entire command hierarchy.

> **Note**: Parsing the command hierarchy is generally not required for production use cases.

## [HandlerOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.HandlerOptions)

`HandlerOptions` offer a variety of settings to configure the behavior of different handlers in your application, allowing you to tailor their functionality to better suit your specific requirements and operational contexts.

### [LicenseHandler](xref:PerpetualIntelligence.Terminal.Configuration.Options.HandlerOptions.LicenseHandler)

The `LicenseHandler` property influences how the terminal handles license validation:

- `online-license`: Suitable for applications with reliable internet access. This setting enables real-time license key validation directly with the licensing server.

- `offline-license`: Designed for environments with limited or no internet access. With this setting, the license key is validated locally, allowing for operation in isolated environments. Periodic updates from a secure network are necessary to maintain license validity.

- `onpremise-license`: Specifically tailored for development and testing phases, particularly when debugging. In this mode, license verification occurs only when the terminal is running in a development environment and is attached to a debugger. It facilitates a smoother development process by simplifying license management. However, once the software is deployed to a production environment, especially in highly secured facilities with no internal internet access (like a high-tech factory), the license check is bypassed. 

> **Note**: It is crucial to note that continuing to run or deploy the terminal in an offline or on-premise production environment without a valid commercial subscription is a violation of the licensing terms.

### [ServiceHandler](xref:PerpetualIntelligence.Terminal.Configuration.Options.HandlerOptions.ServiceHandler)

The `ServiceHandler` property determines the strategy used for hosting and routing dependency injection services:

- `default`: Provides out-of-the-box service implementations for functionalities like command routing, extraction, and handling, facilitating a quick setup.

- `custom`: Reserved for future releases, this option will enable the use of custom service implementations, providing greater flexibility for advanced configurations.

### [StoreHandler](xref:PerpetualIntelligence.Terminal.Configuration.Options.HandlerOptions.StoreHandler)

The `StoreHandler` property configures how command and option descriptions are stored and accessed:

- `in-memory`: Stores descriptions directly in memory for quick access, requiring all descriptions to be loaded at startup.

- `json`: (Reserved for future releases) Allows for storing descriptions in a JSON file, offering a balance between performance and configurability.

- `custom`: Enables integration with custom storage solutions, such as databases or cloud services, for dynamic loading and updating of command descriptions.

These configuration options collectively enable extensive customization of the terminal's behavior, ensuring adaptability to a wide range of deployment scenarios and application needs.

## [HelpOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.HelpOptions)

`HelpOptions` configures the help functionality within a terminal application, allowing customization of how help information is presented and accessible to users.

### [Disabled](xref:PerpetualIntelligence.Terminal.Configuration.Options.HelpOptions.Disabled)

This property determines whether the global help functionality is active. When set to `true`, the help functionality is disabled across the application.

### [OptionId](xref:PerpetualIntelligence.Terminal.Configuration.Options.HelpOptions.OptionId)

`OptionId` provides a unique identifier for the help option, defaulting to `help`. It is crucial to ensure that this identifier is unique across all commands and options within the application.

### [OptionDescription](xref:PerpetualIntelligence.Terminal.Configuration.Options.HelpOptions.OptionDescription)

This property defines a description for the help option, with a default setting of "The command help". This description can be modified to better align with the application's context.

### [OptionAlias](xref:PerpetualIntelligence.Terminal.Configuration.Options.HelpOptions.OptionAlias)

`OptionAlias` sets a shorthand alias for the help option, defaulting to `h`. It is important to maintain the uniqueness of this alias across all options and commands to ensure clarity for the end-users.

## [HttpOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.HttpOptions)

`HttpOptions` is designed to configure HTTP-related settings within a terminal application.

### [HttpClientName](xref:PerpetualIntelligence.Terminal.Configuration.Options.HttpOptions.HttpClientName)

The `HttpClientName` property specifies the logical name used to create and configure an instance of `HttpClient`. Utilizing the `IHttpClientFactory.CreateClient(string)` method, the framework uses this configured name to instantiate `HttpClient`. Setting this property helps in associating a specific `HttpClient` configuration, promoting the use of named clients for various HTTP operations in the application.

## [LicensingOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.LicensingOptions)

`LicensingOptions` helps to configure licensing-related settings in your terminal application, ensuring that your usage complies with the licensing terms. For more details on generating license keys and accessing your identifiers, please visit [licensing](licensing/intro.md).

### [AuthorizedApplicationId](xref:PerpetualIntelligence.Terminal.Configuration.Options.LicensingOptions.AuthorizedApplicationId)

This is the authorized application ID, corresponding to the `auth_apps` claim in your license key.

### [ConsumerTenantId](xref:PerpetualIntelligence.Terminal.Configuration.Options.LicensingOptions.ConsumerTenantId)

This represents the license consumer tenant ID.

### [LicenseKeySource](xref:PerpetualIntelligence.Terminal.Configuration.Options.LicensingOptions.LicenseKeySource)

The source of the license key, defaulting to a JSON file. The value is configured to be one of the options provided by [LicenseSources](xref:PerpetualIntelligence.Shared.Licensing.LicenseSources).

### [LicenseKey](xref:PerpetualIntelligence.Terminal.Configuration.Options.LicensingOptions.LicenseKey)

The license key itself, or a path to the file containing the license key. If `LicenseKeySource` is set to [JsonFile](xref:PerpetualIntelligence.Shared.Licensing.LicenseSources.JsonFile), this option must be a valid file path.

### [Subject](xref:PerpetualIntelligence.Terminal.Configuration.Options.LicensingOptions.Subject)

The subject or licensing context for license checking. This is typically your subscription ID.

### [LicensePlan](xref:PerpetualIntelligence.Terminal.Configuration.Options.LicensingOptions.LicensePlan)

The license plan for the terminal, defaulting to the [Demo](xref:PerpetualIntelligence.Shared.Licensing.TerminalLicensePlans.Demo) plan. The value should be one of the options provided by [TerminalLicensePlans](xref:PerpetualIntelligence.Shared.Licensing.TerminalLicensePlans).

### [OnPremiseDeployment](xref:PerpetualIntelligence.Terminal.Configuration.Options.LicensingOptions.OnPremiseDeployment)

A flag indicating whether the terminal is deployed in a secured, offline environment. If set to `true`, the `ILicenseExtractor` will bypass the license checking. This option is crucial for hardware-centric or factory environments where software configurations are locked down. Ensure you have a valid active license plan to comply with licensing terms.

## [RouterOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.RouterOptions)

`RouterOptions` provides a range of settings that determine how command routing is handled within the terminal application.

### [Caret](xref:PerpetualIntelligence.Terminal.Configuration.Options.RouterOptions.Caret)

The `Caret` property allows you to set the terminal caret that is displayed in the console, helping users to identify where they can input their commands. The default caret is `>`.

### [Timeout](xref:PerpetualIntelligence.Terminal.Configuration.Options.RouterOptions.Timeout)

This property sets the timeout duration for command routing in milliseconds, with a default value of 25 seconds. Setting this to `Timeout.Infinite` will result in no timeout. A command route handles everything for a command: parsing it, making sure it's valid, and then running it.

### [MaxRemoteClients](xref:PerpetualIntelligence.Terminal.Configuration.Options.RouterOptions.MaxRemoteClients)

The `MaxRemoteClients` property defines the maximum number of active remote client connections that the router can accept, with a default value of 5. This is particularly useful for managing resource usage and ensuring optimal performance.

### [MaxMessageLength](xref:PerpetualIntelligence.Terminal.Configuration.Options.RouterOptions.MaxMessageLength)

This property specifies the maximum length of a single message, with a default limit of 1024 characters. It helps in managing the data flow and ensuring that the messages are within an acceptable size range.

### [MessageDelimiter](xref:PerpetualIntelligence.Terminal.Configuration.Options.RouterOptions.MessageDelimiter)

The `MessageDelimiter` is used to identify the end of a complete message, especially while streaming a long command string from a remote source, such as a network stream. The default delimiter is `$EOM$`.

These options collectively provide a comprehensive way to configure how commands are routed and handled within the terminal, offering flexibility and control to the developers.

## [AuthenticationOptions](xref:PerpetualIntelligence.Terminal.Configuration.Options.AuthenticationOptions)

> Planned for next major release.

# References
- [Options pattern in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/options)
- [Architectural principles](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles)
