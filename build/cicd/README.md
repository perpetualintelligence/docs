This folder contains the CI/CD pipelines for generating and publishing documentation to GitHub pages.

> The documentation delivery is manual. We build the documentation site utilizing both public and private GitHub repositories. As a result, we cannot have the CD pipeline configured for all contributors.

The build pipeline ***build-and-stage.yml*** builds the docfx_projects from public and private repos and stages the generated documentation to the ***private*** staging artifacts directory.

The manual triggered release pipeline ***stage-github-release.yml*** downloads the documentation from the ***private*** staging artifacts and creates a GitHub release. 

Finally, the GitHub workflow action will trigger, download the new release and publish the documentation pages to the ***gh-action** branch.