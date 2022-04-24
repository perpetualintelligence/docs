![in-progress](https://img.shields.io/badge/status-in--progress-yellow)

> **Note:** This is a ***preview*** release. It is also subject to design changes without any advance notice.

# [CliOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.CliOptions)
The pi-cli framework uses the options pattern to provide strongly typed access to groups of related settings. When configuration settings are isolated by scenario into separate classes, the host CLI terminal adheres to two crucial software engineering principles:

- [Interface Segregation Principle (ISP) or Encapsulation](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#encapsulation): Scenarios (classes) that depend on configuration settings depend only on the configuration settings that they use.
- [Separation of Concerns](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns): Settings for different parts of the app aren't dependent or coupled to one another.
Options also provide a mechanism to validate configuration data. For more information, see the Options validation section.

This article provides information on all the supported configuration options by the pi-cli framework.

## [AuthenticationOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.AuthenticationOptions)

## [CheckerOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.CheckerOptions)

## [ExtractorOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.ExtractorOptions)

## [HostingOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.HostingOptions)

## [HttpOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.HttpOptions)

## [LicensingOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.LicensingOptions)

## [LoggingOptions](xref:PerpetualIntelligence.Cli.Configuration.Options.LoggingOptions)

# References
- [Options pattern in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/options)
- [Architectural principles](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles)
