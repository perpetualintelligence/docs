# Roadmap

The following is our roadmap for planned features and future requests.

:point_left: In progress

:soon: Future planned

:tipping_hand_person: Future not-planned

:raising_hand: Help wanted

## General
* [x] Publish the terminal SaaS solution on Microsoft SaaS Marketplace
* [x] Publish the -preview docs at https://docs.perpetualintelligence.com/
* [ ] Provide terminal native pricing options and purchase experience :soon:
* [x] Provide terminal consumer fulfillment portal for Microsoft SaaS purchases at https://consumer.perpetualintelligence.com/
* [ ] Provide terminal consumer fulfillment portal for AWS SaaS purchases :tipping_hand_person:
* [ ] Provide terminal consumer fulfillment portal for Google Cloud SaaS purchases :tipping_hand_person:
* [x] Provide licensing and redistribution terms
    * [x] https://terms.perpetualintelligence.com/articles/licensing.html
    * [x] https://terms.perpetualintelligence.com/articles/redistribution.html

* [ ] Clarify the community edition and have common FAQs :soon:

## terminal
* [x] Publish -preview packages for terminal on Nuget
* [x] Finalize the pricing
    * [x] Make perpetualintelligence/terminal public under licensig terms
* [x] Finalyse configuration options :point_left:
* [x] Enumerate restricted characters for command extractions and command string
* [x] Reserve REGEX patterns for command and argument extraction
* [ ] Support JSON and Custom command and argument stores :tipping_hand_person:
* [ ] Support custom DI servies :tipping_hand_person:
* [ ] Custom Handler
    * [ ] Data type custom handlers :point_left:
    * [X] Unicode command and argument handlers
    * [ ] Custom Error handlers :point_left:
    * [ ] Text handler for `right-to-left` languages :raising_hand:
* [x] Create test license server for quick on-boarding, [Github Issue](https://github.com/perpetualintelligence/picli/issues/15) :soon: 
* [ ] Unitest all critical scenarios :point_left:
* [ ] Integration test for E2E workflow :point_left:
* [ ] Publish [samples](../samples.md) for CLI terminals
    * [x] Github CLI
    * [x] .NET CLI
    * [x] Stripe CLI
    * [x] Custom format CLI :soon:
    * [ ] Non english CLI terminals (e.g. Japanese, Spanish, German, Hindi, Marathi, Chinese) :soon:
* [ ] Support CLI Authentication as a separate Nuget package
    * [ ] MSAL :soon:
    * [ ] Identity Server :raising_hand:
    * [ ] OAuth 2.0 and Open ID Connect :tipping_hand_person:
* [ ] Branding portal for custom CLI solutions :tipping_hand_person:
* [ ] Track redistribution :tipping_hand_person:

## protocols
* [ ] Publish the -preview docs at https://docs.perpetualintelligence.com/

