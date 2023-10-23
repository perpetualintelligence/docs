# Welcome
This sample tutorial shows how to build modern CLI terminals similar to [dotnet CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/).

The "terminal" framework handles the entire CLI infrastructure,  so your focus is on building modern CLI apps and services. For more details, see our [documentation](https://docs.perpetualintelligence.com/articles/picli/intro.html).

The tutorial uses our [demo license](https://docs.perpetualintelligence.com/articles/onedemo/intro.html).
The code in `Program.cs` specifies the license key location. You can download the license key file in that location or set your path.
```
    // Download the license file in this location or specify your location
    options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json";
```

## Command Registry
The `CommandRegistry.cs` source file contains the `dotnet` CLI sample commands and arguments registration.

## Hosted Service
The `DotNetCliHostedService.cs` implement the sample hosted service to enable terminal lifecycle tracking and UX customization.

## Runners
The `Runners` folder defines the sample `dotnet` CLI command runners.

Example Run:
```
$ dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a
Running sample push command.
Printing arguments...
root: foo.nupkg
api-key: 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a
```
