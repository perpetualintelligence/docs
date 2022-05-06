# Welcome
This sample tutorial shows how to build modern CLI terminals similar to [GitHub CLI](https://cli.github.com/).

The "pi-cli" framework handles the entire CLI infrastructure for the .NET ecosystem,  so your focus is on building modern CLI apps and services and not the infrastructure. For more details, see our [documentation](https://docs.perpetualintelligence.com/articles/pi-cli/intro.html).

The tutorial uses our [demo license](https://docs.perpetualintelligence.com/articles/pi-demo/intro.html).
The code in `Program.cs` specifies the license key location. You can download the license key file in that location or specify your own path.
```
    // Download the license file in this location or specify your location
    options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json";
```

# Runners

All the sample command runners are defined in `Runners` folder.

Example Run:
```
    $ gh issue create --repo samplerepo --title demo title --body test body
    Running sample create command.
    Options
    repo=samplerepo
    title=demo title
    body=test body
```
