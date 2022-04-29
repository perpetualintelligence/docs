# Readme
This is the [docfx](https://dotnet.github.io/docfx/) project to generate the documentation website for all our managed services, frameworks, tools, and protocols. 

# Environments
- [github-release](https://github.com/perpetualintelligence/docs/deployments/activity_log?environment=github-release): Tracks the publish of documentation assets to [gh-pages](https://github.com/perpetualintelligence/docs/tree/gh-pages) branch
- [github-pages](https://github.com/perpetualintelligence/docs/deployments/activity_log?environment=github-pages): Tracks the deployment of documentation assets to [docs.perpetualintelligence.com](https://docs.perpetualintelligence.com)

# Build (/build)

## workflows
The workflows folder contains actions for generating and publishing documentation.

> The documentation delivery is ***manual***. We build the documentation site utilizing both public and private GitHub repositories. As a result, we cannot have the CD pipeline configured for all contributors.

The build and deployment include:
1. *build-test-publish*: The manual triggered pipeline builds documentation and pushes the **_site** contents to the [gh-pages](https://github.com/perpetualintelligence/docs/tree/gh-pages) branch
2. *Automated pipeline*: GitHub's automated pipeline builds the [gh-pages](https://github.com/perpetualintelligence/docs/tree/gh-pages) branch and pushes the static content to [docs.perpetualintelligence.com](https://docs.perpetualintelligence.com).

> The build and deployment will trigger an approval.

## Scripts (/build/scripts)
Put the script files in the same directory where you have extracted the docfx tools and libraries. Ensure that this directory is in the PATH environment variable.

You can now work with docfx within Visual Studio Terminal with handy commands to build(b), generate metadata(m), and start (s, bs) the documentation website on localhost.

> The scripts assume that your documentation project is within ***docfx_project*** directory.
