This folder contains the CI/CD pipelines for generating and publishing documentation to GitHub pages.

> The documentation delivery is manual. We build the documentation site utilizing both public and private GitHub repositories. As a result, we cannot have the CD pipeline configured for all contributors.

The build pipeline ***build-and-stage.yml*** builds the docfx_projects from public and private repos and stages the generated documentation to the ***private*** directory. The manual triggered 
release pipeline ***stage-github-release.yml*** downloads the documentation from the ***private*** directory and creates a GitHub release. Finally, the GitHub workflow action will start, download 
the new release and publish the documentation pages to the ***gh-action** branch.

To summarize, the build and deploy includes:
1. ***build-and-stage.yml*** builds the docfx_projects and publishes the build artifacts (automated CI)
2. ***stage-github-release.yml*** stages the build artifact as a GitHub release (manual CD)
3. ***release-push-gh-branch*** downloads the release and pushes it to ***gh-action** branch (automated Deploy)
4. GitHub ***bot*** builds the static doc and deploys it to GitHub pages (automated Deploy)