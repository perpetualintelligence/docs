## .github/workflow
The workflow folder contains actions for generating and publishing documentation for all the Perpetual Intelligence's managed services, framework and tools.

> The documentation delivery is ***manual***. We build the documentation site utilizing both public and private GitHub repositories. As a result, we cannot have the CD pipeline configured for all contributors.

The build and deploy include:
1. ***build-and-publish-cross***: The manual triggered pipeline builds documentation and pushes the ***_site*** contents to the ***gh-pages*** branch.
2. ***Automated pipeline***: The GitHub's automated pipeline builds the ***gh-branch*** and pushes the static content to GitHub pages.

> The manual release requires approval.

## build

## /config
The build config files.

## /scripts
Put the script files in the same directory where you have extracted the docfx tools and libraries. Ensure that this directory is in the PATH environment variable.

You can now work with docfx within Visual Studio Terminal with handy commands to build(d), generate metadata(m), and start (s, ds) the documentation website on localhost.

> The scripts assume that your documentation project is within ***docfx_project*** directory.
