# Welcome
This sample tutorial shows how to build modern CLI terminals with custom format.

The "pi-cli" framework handles the entire CLI infrastructure,  so your focus is on building modern CLI apps and services. For more details, see our [documentation](https://docs.perpetualintelligence.com/articles/pi-cli/intro.html).

The tutorial uses our [demo license](https://docs.perpetualintelligence.com/articles/pi-demo/intro.html).
The code in `Program.cs` specifies the license key location. You can download the license key file in that location or set your path.
```
    // Download the license file in this location or specify your location
    options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json";
```

## Command Registry
The `CommandRegistry.cs` source file contains the CLI sample commands and arguments registration.

## Hosted Service
The `CustomCliHostedService.cs` implement the sample hosted service to enable terminal lifecycle tracking and UX customization.

## Runners
The `Runners` folder defines the sample `custom` CLI command runners.

Example Run:
```
>_ custom
Running custom command.
>_ custom test -arg1 -arg2="test value" -arg4=369
Running test command.
Printing arguments...
arg1: True
arg2: test value
arg4: 369
>_ custom test random
Running sample random command.
Random number:
0.09281167311086658
>_ custom test guid
Running guid command.
Guid:
37c7bb54-dc34-45f1-991f-0c02afaacefc
>_
```
