# Configuration Options
The `OneImlx.Terminal` framework utilizes the options pattern, facilitating strongly typed access to groups of related settings. By isolating configuration settings into separate classes based on scenarios, the host CLI or terminal app upholds two fundamental software engineering principles:

- [Interface Segregation Principle (ISP) or Encapsulation](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#encapsulation): Classes dependent on configuration settings are only reliant on the settings they actually use, promoting clean and maintainable code.
- [Separation of Concerns](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns): Settings for different components of the application are isolated from each other, ensuring that changes in one area do not affect the others.

Furthermore, options offer a method for validating configuration data, ensuring that your application runs smoothly with correct and valid configurations.

## Configurability
The framework enhances flexibility through `Command Options` and `Configuration Options`, empowering developers to tailor applications to specific requirements.

### [Command Options](options.md)
`Command Options` are flags or key-value pairs within command strings that modify command behavior. Defined in the command descriptor and processed at runtime, these options allow for the customization of commands. For instance, `update profile --username=johndoe --email=johndoe@example.com` demonstrates how `--username` and `--email` define the `profile` command.

### [Configuration Options](https://learn.microsoft.com/en-us/dotnet/core/extensions/options)
`Configuration Options` set the application's overall behavior, as defined by the [Options Design Pattern](https://docs.microsoft.com/en-us/dotnet/core/extensions/options) in .NET. Typically specified in `appsettings.json` or via environment variables, these options are loaded at startup. This structure provides a systematic approach to managing application settings, enhancing control over multiple commands or the entire application's behavior.

## [TerminalOptions](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions)
This `TerminalOptions` outlines all the configuration options supported by the terminal framework, providing you with the information you need to effectively configure and optimize your application.

| Option           | Description                                                                      | Reserved for Future |
|------------------|----------------------------------------------------------------------------------|---------------------|
| [`Id`](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions.Id)             | A unique identifier for the terminal instance.                                   |                     |
| [`Authentication`](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions.Authentication) | Configuration options for authentication.                                        | Yes                 |
| [`Checker`](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions.Checker)        | Configuration options for command, argument, and option validation.              |                     |
| [`Driver`](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions.Driver)         | Configuration options for the terminal's driver.                                 | Yes                 |
| [`Help`](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions.Help)           | Configuration options related to the help system.                                |                     |
| [`Licensing`](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions.Licensing)      | Configuration options for licensing.                                             |                     |
| [`Parser`](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions.Parser)         | Configuration options for extracting command arguments and options from input.   |                     |
| [`Router`](xref:OneImlx.Terminal.Configuration.Options.TerminalOptions.Router)         | Configuration options for the command router.                                    |                     |

## [AuthenticationOptions](xref:OneImlx.Terminal.Configuration.Options.AuthenticationOptions)

> Planned for next major release.

## [CheckerOptions](xref:OneImlx.Terminal.Configuration.Options.CheckerOptions)
The command, argument, and option checker configuration options. The checker options are not filters. The command execution is blocked if any check fails.

### [AllowObsolete](xref:OneImlx.Terminal.Configuration.Options.CheckerOptions.AllowObsolete)
This setting determines the checker's behavior when a command is executed with obsolete arguments or options.

- **Runtime Check**: The obsolete check triggers at runtime, specifically when a user or an application runs a command with an obsolete argument or option.
- **Conditional Effect**: The setting is inactive if an obsolete argument is supported by the command but not provided in the command string at runtime.

### [StrictValueType](xref:OneImlx.Terminal.Configuration.Options.CheckerOptions.StrictValueType)
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

## [DriverOptions](xref:OneImlx.Terminal.Configuration.Options.DriverOptions)
Reserved for future use, the `DriverOptions` provide configuration settings for operating the terminal as a native driver program.

### [Enabled](xref:OneImlx.Terminal.Configuration.Options.DriverOptions.Enabled)
Determines if the terminal functions as a native driver program, allowing execution of commands directly from a native command prompt. This option is a nullable boolean (`bool?`).

### [Name](xref:OneImlx.Terminal.Configuration.Options.DriverOptions.Name)
Specifies the name of the terminal driver program. This option is of type `string?`.

> **Note:** These configuration options are reserved for future development and enhancements of the terminal framework.

## [HelpOptions](xref:OneImlx.Terminal.Configuration.Options.HelpOptions)

`HelpOptions` configures the help functionality within a terminal application, allowing customization of how help information is presented and accessible to users.

### [Disabled](xref:OneImlx.Terminal.Configuration.Options.HelpOptions.Disabled)

This property determines whether the global help functionality is active. When set to `true`, the help functionality is disabled across the application.

### [OptionId](xref:OneImlx.Terminal.Configuration.Options.HelpOptions.OptionId)

`OptionId` provides a unique identifier for the help option, defaulting to `help`. It is crucial to ensure that this identifier is unique across all commands and options within the application.

### [OptionDescription](xref:OneImlx.Terminal.Configuration.Options.HelpOptions.OptionDescription)

This property defines a description for the help option, with a default setting of "The command help". This description can be modified to better align with the application's context.

### [OptionAlias](xref:OneImlx.Terminal.Configuration.Options.HelpOptions.OptionAlias)

`OptionAlias` sets a shorthand alias for the help option, defaulting to `h`. It is important to maintain the uniqueness of this alias across all options and commands to ensure clarity for the end-users.

## [LicensingOptions](xref:OneImlx.Terminal.Configuration.Options.LicensingOptions)

`LicensingOptions` helps to configure licensing-related settings in your terminal application, ensuring that your usage complies with the licensing terms. For more details on generating license keys and accessing your identifiers, please visit [licensing](../licensing/intro.md).

### [LicenseFile](xref:OneImlx.Terminal.Configuration.Options.LicensingOptions.LicenseFile)

The path to the file containing the license key.

### [LicensePlan](xref:OneImlx.Terminal.Configuration.Options.LicensingOptions.LicensePlan)

The license plan for the terminal, defaulting to the [Demo](xref:OneImlx.Shared.Licensing.TerminalLicensePlans.Demo) plan. The value should be one of the options provided by [TerminalLicensePlans](xref:OneImlx.Shared.Licensing.TerminalLicensePlans).

### [Deployment](xref:OneImlx.Terminal.Configuration.Options.LicensingOptions.Deployment)

The deployment value indicating whether the terminal is deployed in a secured, offline environment. If set to `true`, the `ILicenseExtractor` will bypass the license checking. This option is crucial for hardware-centric or factory environments where software configurations are locked down. Ensure you have a valid active license plan to comply with licensing terms.

## [ParserOptions](xref:OneImlx.Terminal.Configuration.Options.ParserOptions)
Configuration options for parsing command and argument strings.

### [OptionAliasPrefix](xref:OneImlx.Terminal.Configuration.Options.ParserOptions.OptionAliasPrefix)
Specifies the prefix for option aliases, defaulting to `-`. It cannot be `null` or whitespace.

```csharp
// Example
options.Parser.OptionAliasPrefix = "-";
dotnet build -c Release
```

In the example above, -c is recognized as an option alias.

### [OptionPrefix](xref:OneImlx.Terminal.Configuration.Options.ParserOptions.OptionPrefix)
Defines the prefix for options, with a default of `--`. Like `OptionAliasPrefix`, it cannot be null or whitespace.

```csharp
// Example
options.Parser.OptionPrefix = "--";
dotnet run --configuration Debug
```

In the example above, `--configuration` is recognized as an option.

### [OptionValueSeparator](xref:OneImlx.Terminal.Configuration.Options.ParserOptions.OptionValueSeparator)
Sets the separator between an option and its value, defaulting to a space ` `. It must be a single Unicode character but can be whitespace.

```csharp
// Example
options.Parser.OptionValueSeparator = " ";
dotnet run --framework netcoreapp3.1
```

In this case, the space between `--framework` and `netcoreapp3.1` is the option value separator.

### [ValueDelimiter](xref:OneImlx.Terminal.Configuration.Options.ParserOptions.ValueDelimiter)
Specifies a delimiter for enclosing argument or option values, with a default of `"`.

```csharp
// Example
options.Parser.ValueDelimiter = "\"";
dotnet run --project "My Project"
```

The quotes around My Project are the value delimiters..


### [Separator](xref:OneImlx.Terminal.Configuration.Options.ParserOptions.Separator)
Determines the separator for the command string, defaulting to a single space ` `. It must be a single Unicode character and can be whitespace.

```csharp
// Example
options.Parser.Separator = " ";
dotnet publish --runtime linux-x64
```

The spaces between the command and options are the separators.

### [ParseHierarchy](xref:OneImlx.Terminal.Configuration.Options.ParserOptions.ParseHierarchy)
Indicates whether to parse the command hierarchy, which is optional and defaults to null. A command hierarchy includes the command route from root to executing command, through any nested groups.

```csharp
// Example
options.Parser.ParseHierarchy = true;
dotnet publish --configuration Release --runtime linux-x64
```

In this example, if ParseHierarchy is enabled, the parser will parse the entire command hierarchy.

> **Note**: Parsing the command hierarchy is generally not required for production use cases.

## [RouterOptions](xref:OneImlx.Terminal.Configuration.Options.RouterOptions)

`RouterOptions` provides a range of settings that determine how command routing is handled within the terminal application.

### [Caret](xref:OneImlx.Terminal.Configuration.Options.RouterOptions.Caret)

The `Caret` property allows you to set the terminal caret that is displayed in the console, helping users to identify where they can input their commands. The default caret is `>`.

### [Timeout](xref:OneImlx.Terminal.Configuration.Options.RouterOptions.Timeout)

This property sets the timeout duration for command routing in milliseconds, with a default value of 25 seconds. Setting this to `Timeout.Infinite` will result in no timeout. A command route handles everything for a command: parsing it, making sure it's valid, and then running it.

### [MaxRemoteClients](xref:OneImlx.Terminal.Configuration.Options.RouterOptions.MaxRemoteClients)

The `MaxRemoteClients` property defines the maximum number of active remote client connections that the router can accept, with a default value of 5. This is particularly useful for managing resource usage and ensuring optimal performance.

### [RemoteMessageMaxLength](xref:OneImlx.Terminal.Configuration.Options.RouterOptions.RemoteMessageMaxLength)

This property specifies the maximum length of a single message, with a default limit of 1024 characters. It helps in managing the data flow and ensuring that the messages are within an acceptable size range.

### [RemoteMessageDelimiter](xref:OneImlx.Terminal.Configuration.Options.RouterOptions.RemoteMessageDelimiter)

The `MessageDelimiter` is used to identify the end of a complete message, especially while streaming a long command string from a remote source, such as a network stream. The default delimiter is `$EOM$`.

These options collectively provide a comprehensive way to configure how commands are routed and handled within the terminal, offering flexibility and control to the developers.

# References
- [Options pattern in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/options)
- [Architectural principles](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles)
