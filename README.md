![Preview](https://img.shields.io/badge/release-preview-orange) 
[![build-test-publish](https://github.com/perpetualintelligence/docs/actions/workflows/build-test-publish.yml/badge.svg)](https://github.com/perpetualintelligence/docs/actions/workflows/build-test-publish.yml)
[![pages-build-deployment](https://github.com/perpetualintelligence/docs/actions/workflows/pages/pages-build-deployment/badge.svg)](https://github.com/perpetualintelligence/docs/actions/workflows/pages/pages-build-deployment)

> **Note:** This is a ***preview*** release, not ready for production usage. It is also subject to design changes without any advance notice.

## Introduction
This repository contains the conceptual documentation for Perpetual Intelligence L.L.C. managed services, frameworks, tools, and protocols. We build the [documentation site](https://docs.perpetualintelligence.com) using [docfx](https://dotnet.github.io/docfx/) from this repository.

We track the [issues and tasks](https://github.com/perpetualintelligence/docs/issues) here. We make our best effort to respond to issues in a timely fashion. You can read more about our procedures for classifying and resolving issues in our [Issues policy](https://terms.perpetualintelligence.com/articles/issues-policy.html) topic.

> We welcome contributions to help us improve and complete the docs.

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behavior in our community.
See the [Code of Conduct](https://terms.perpetualintelligence.com/articles/CODE_OF_CONDUCT.html).

## Environments
- [github-release](https://github.com/perpetualintelligence/docs/deployments/activity_log?environment=github-release): Tracks the publish of documentation assets to ***gh-pages*** branch
- [github-pages](https://github.com/perpetualintelligence/docs/deployments/activity_log?environment=github-pages): Tracks the deployment of documentation assets to [docs.perpetualintelligence.com](https://docs.perpetualintelligence.com)

## .github

### workflows
The workflows folder contains actions for generating and publishing documentation.

> The documentation delivery is ***manual***. We build the documentation site utilizing both public and private GitHub repositories. As a result, we cannot have the CD pipeline configured for all contributors.

The build and deployment include:
1. ***build-test-publish***: The manual triggered pipeline builds documentation and pushes the ***_site*** contents to the ***gh-pages*** branch.
2. ***Automated pipeline***: GitHub's automated pipeline builds the ***gh-branch*** and pushes the static content to GitHub pages.

> The build and deployment will trigger an approval.

## build

### /scripts
Put the script files in the same directory where you have extracted the docfx tools and libraries. Ensure that this directory is in the PATH environment variable.

You can now work with docfx within Visual Studio Terminal with handy commands to build(d), generate metadata(m), and start (s, ds) the documentation website on localhost.

> The scripts assume that your documentation project is within ***docfx_project*** directory.

## docfx_project
The [docfx](https://dotnet.github.io/docfx/) project builds our conceptual, class, and API documentation.
