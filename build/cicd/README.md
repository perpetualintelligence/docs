This folder contains the CI/CD pipelines for generating and publishing documentation GitHub pages.

The build pipeline ***azure_build_pipeline.yml*** builds the docfx_projects and pushes the generated documentation to the ***private*** staging artifacts directory.

The release pipeline ***azure_release_pipeline.yml*** downloads from the ***private*** staging artifacts directory and creates a pull request for the /docs folder. The repo admin will merge the pull request to push the docs to the GitHub pages.

> We build the documentation site utilizing both public and private GitHub repositories. As a result, we cannot have the CD pipeline configured. Documentation delivery is manual.
