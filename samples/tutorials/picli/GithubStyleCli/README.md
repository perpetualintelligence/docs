# Welcome
This sample tutorial shows how to build modern CLI terminals similar to [GitHub CLI](https://cli.github.com/).

The "terminal" framework handles the entire CLI infrastructure,  so your focus is on building modern CLI apps and services. For more details, see our [documentation](https://docs.perpetualintelligence.com/articles/terminal/intro.html).

The tutorial uses our [demo license](https://docs.perpetualintelligence.com/articles/onedemo/intro.html).
The code in `Program.cs` specifies the license key location. You can download the license key file in that location or set your path.
```
    // Download the license file in this location or specify your location
    options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json";
```

## Command Registry
The `CommandRegistry.cs` source file contains the `gh` CLI sample commands and arguments registration.

## Hosted Service
The `GhCliHostedService.cs` implement the sample hosted service to enable terminal lifecycle tracking and UX customization.

## Runners
The `Runners` folder defines the sample `gh` CLI command runners.

Example Run:
```
$ gh issue create --repo samplerepo --title demo title --body test body
Running sample create command.
Options
repo=samplerepo
title=demo title
body=test body
```
