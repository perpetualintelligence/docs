![in-progress](https://img.shields.io/badge/status-in--progress-yellow)

> **Note:** This is a ***preview*** release. It is also subject to design changes without any advance notice.

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

The obsolete argument value check is done at runtime if a user or an application attempts to run the command and passes an obsolete argument value. This option has no effect if the command has an obsolete argument, but the user did not give its value through command execution.

### [DataTypeHandler](xref:PerpetualIntelligence.Cli.Configuration.Options.CheckerOptions.DataTypeHandler)
Reserved for future.

### [StrictArgumentValueType](xref:PerpetualIntelligence.Cli.Configuration.Options.CheckerOptions.StrictArgumentValueType)
Determines whether the checker checks an argument value type. If this option is enabled, the checker will try to map an argument value to its corresponding .NET value type. If the mapping fails, the command will not run.

## [ExtractorOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions)
The command and argument checker options.

### [ArgumentAlias](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentAlias)
Determines whether the extractor support extracting an argument by alias.

```
    --configuration Release 
    -c Release
```

Argument alias supports the apps that identify a command argument with an id and an alias string. For modern console apps, we recommend using just an argument identifier. We have optimized the core data model to work with argument id. An app should not identify the same argument with multiple strings. Using an alias will degrade the performance.

### [ArgumentAliasPrefix](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentAliasPrefix)
The argument alias prefix if [ArgumentAlias](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentAlias) is enabled. Defaults to `-`.

```
    -c Release
```

> **Note:** The argument alias prefix cannot be `null` or whitespace.

### [ArgumentPrefix](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentPrefix)
The argument prefix. Defaults to `-`.

```
    -configuration Release
```

> **Note:** The argument prefix cannot be `null` or whitespace.

### [ArgumentValueSeparator](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentValueSeparator)
The argument value separator. Defaults to `=`.

```
    -configuration=Release
    -configuration Release
    -configuration:Release
    -configuration->Release
```

> **Note:** The argument value separator can be an whitespace ` `.

### [ArgumentValueWithIn](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.ArgumentValueWithIn)
An optional token within which to extract an argument value. Default to `null`.

```
    -message=This is a string without quotes

    options.Extractor.ArgumentValueWithIn = "\"";
    -message="This is a string within quotes"

    options.Extractor.ArgumentValueWithIn = "~";
    -message=~This is a string within tilda~
```

### [CommandIdRegex](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.CommandIdRegex)
The Regex pattern for command identifier. Defaults to `^[A-Za-z0-9_-]*$`.

### [DefaultArgument](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.DefaultArgument)
Determines whether command supports default argument.

```
    dotnet restore -p ./projects/app1/app1.csproj

    options.Extractor.DefaultArgument = true;
    dotnet restore ./projects/app1/app1.csproj

```

In the code example above, let's assume the command `dotnet restore` has a default argument `p`. The command string's argument value `./projects/app1/app1.csproj` is automatically set to the default argument `p`.

### [DefaultArgumentValue](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.DefaultArgumentValue)
Determines whether argument support default value.

```
    dotnet build ./projects/app1/app1.csproj -c RELEASE

    options.Extractor.DefaultArgumentValue = true;
    dotnet build ./projects/app1/app1.csproj

```

In the code example above, let's assume the command `dotnet build` has defined a required configuration argument `c` with a default value `DEBUG`. Even though the command string did not specify any configuration value, the extractor will automatically set the `c` value to `DEBUG` during the command run.

### [Separator](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions.Separator)
The command string separator. Defaults to a single whitespace ` `.

```
    pi gen guid --short
    dotnet publish --framework netcoreapp3.1 --runtime osx.10.11-x64
    डॉटनेट पब्लिश --कॉन्फिग रिलीज --सैंपल हिंदी

    options.Extractor.Separator = ":";
    pi:gen:guid:--short

```

## [HostingOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.HostingOptions)

## [HttpOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.HttpOptions)

## [LicensingOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.LicensingOptions)

## [LoggingOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.LoggingOptions)

## [AuthenticationOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.AuthenticationOptions)
Coming :soon:

# References
- [Options pattern in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/options)
- [Architectural principles](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles)
