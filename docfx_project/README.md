# Readme
This [DocFX](https://dotnet.github.io/docfx/) project powers the creation of the [documentation website](https://docs.perpetualintelligence.com) for our managed services, cross-platform frameworks, and developer tools.

# Audience
This documentation is intended for developers.

# Setting Up Locally
To set up DocFX on your local development machine, follow these steps. Please note that we only use stable releases of third-party tools, not pre-release or preview versions.

> **Prerequisite**: Make sure you have downloaded the source repositories before proceeding with the DocFX setup.

1. Visit [DocFX's official website](https://dotnet.github.io/docfx/).
2. Navigate to the [Download](https://github.com/dotnet/docfx/releases) page and select the latest stable release (e.g., Version 2.59.4).
3. Download the `docfx.zip` file and extract its contents to a designated folder, which will become your DocFX root directory.
4. Copy all scripts from the `../build/scripts` folder to your DocFX root directory.
5. Add your DocFX root directory to your system's `%PATH%` environment variable.
6. Download and install the latest stable release of [wkhtmltopdf](https://wkhtmltopdf.org/downloads.html).
7. Add the wkhtmltopdf executable's folder (e.g., `C:\Program Files\wkhtmltopdf\bin`) to your `%PATH%` environment variable.

You can now use DocFX commands within Visual Studio's Terminal to build (b), generate metadata (m), start a local server (s), or build and start (bs) the documentation website on your localhost.

> **Note**: These scripts assume that your documentation project resides within the ***docfx_project*** directory.

# CICD

The `../.github/workflows` directory contains actions for building and publishing the documentation.

> **Important**: Deploying the documentation is a ***manual*** process. We build the documentation site from both public and private GitHub repositories. Consequently, we cannot configure a CICD pipeline that accommodates all contributors.

The build and deployment processes include:
1. **build-test-publish**: This manually triggered pipeline builds the documentation and pushes the contents of the **_site** directory to the [gh-pages](https://github.com/perpetualintelligence/docs/tree/gh-pages) branch.
2. **Automated Pipeline**: GitHub's automated pipeline builds from the [gh-pages](https://github.com/perpetualintelligence/docs/tree/gh-pages) branch and deploys the static content to [docs.perpetualintelligence.com](https://docs.perpetualintelligence.com).

> Each build and deployment will trigger an approval process.

# Feedback
For any issues, suggestions, or feature requests, please submit them via our [GitHub issues page](https://github.com/perpetualintelligence/docs/issues).
