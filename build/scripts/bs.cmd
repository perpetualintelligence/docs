REM Build doxfc_project and then start the docfx server on 8080 port, lauch the browser and serve the pages
call docfx docfx_project/docfx.json
start http://localhost:8080
call docfx serve docfx_project/_site
