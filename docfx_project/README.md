# Readme
This [docfx](https://dotnet.github.io/docfx/) project generates the [documentation website](https://docs.perpetualintelligence.com) for our managed services, cross-platform frameworks, and developer tools. 

# Local Machine

Follow the steps below to setup the docfx on your local development machine. We do not use pre-release or preview versions for third-party tools.

> Note: As a prerequisite, you must download the source repos before the docfx setup.

1. Go to [docfx](https://dotnet.github.io/docfx/).
2. Click on [Download](https://github.com/dotnet/docfx/releases) and get the latest released installer (e.g. Version 2.59.4).
3. Save the docfx.zip file, extract it to a folder (this is your docfx root location).
4. Copy all scripts from `../build/scripts` folder to your root location.
5. Add the root location to your `%PATH%` environment variable.
6. Download and install the latest released [wkhtmltopdf](https://wkhtmltopdf.org/downloads.html) installer.
7. Add the executable folder (e.g. `C:\Program Files\wkhtmltopdf\bin`) to `%PATH%` environment variable.

You can now work with docfx within Visual Studio Terminal with commands to build (b), generate metadata (m), start (s), build and start (bs) the documentation website on localhost.

> The scripts assume that your documentation project is within ***docfx_project*** directory.

# CICD

The `../.github/workflows` folder contains actions for generating and publishing documentation.

> Note: The documentation deployment is ***manual***. We build the documentation site from both public and private GitHub repositories. As a result, we cannot have the CICD pipeline configured for all contributors.

The build and deployment include:
1. *build-test-publish*: The manual triggered pipeline builds documentation and pushes the **_site** contents to the [gh-pages](https://github.com/perpetualintelligence/docs/tree/gh-pages) branch
2. *Automated pipeline*: GitHub's automated pipeline builds the [gh-pages](https://github.com/perpetualintelligence/docs/tree/gh-pages) branch and pushes the static content to [docs.perpetualintelligence.com](https://docs.perpetualintelligence.com).

> The build and deployment will trigger an approval.

# Contact
Submit issues and feature requests on [Github](https://github.com/perpetualintelligence/docs/issues).
