# Welcome
This sample tutorial shows how to build modern CLI terminals similar to [Stripe CLI](https://stripe.com/docs/stripe-cli).

The "pi-cli" framework handles the entire CLI infrastructure,  so your focus is on building modern CLI apps and services. For more details, see our [documentation](https://docs.perpetualintelligence.com/articles/pi-cli/intro.html).

The tutorial uses our [demo license](https://docs.perpetualintelligence.com/articles/pi-demo/intro.html).
The code in `Program.cs` specifies the license key location. You can download the license key file in that location or set your path.
```
    // Download the license file in this location or specify your location
    options.Licensing.LicenseKey = "D:\\lic\\demo_lic.json";
```

## Command Registry
The `CommandRegistry.cs` source file contains the `Stripe` CLI sample commands and arguments registration.

## Hosted Service
The `StripeCliHostedService.cs` implement the sample hosted service to enable terminal lifecycle tracking and UX customization.

## Runners
The `Runners` folder defines the sample `Stripe` CLI command runners.

Example Run:
```
$ stripe
Running sample stripe command.
The SAMPLE Stripe CLI tutorial
$ stripe login
Running sample login command.
$ stripe login --interactive
Running sample login command.
Printing arguments...
interactive: True
$ stripe login --api-key sample_asdasdasdjasdajskd
Running sample login command.
Printing arguments...
api-key: sample_asdasdasdjasdajskd
```
