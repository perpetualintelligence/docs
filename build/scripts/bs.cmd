@ECHO OFF
SETLOCAL

REM Build the DocFX project
ECHO [INFO] Building the DocFX project...
docfx docfx_project/docfx.json || (
    ECHO [ERROR] DocFX build failed. Exiting...
    EXIT /B 1
)

REM Check for successful build
IF NOT EXIST docfx_project\_site (
    ECHO [ERROR] Build failed. '_site' directory does not exist. Exiting...
    EXIT /B 1
)

ECHO [INFO] Build successful! Documentation generated in 'docfx_project/_site'.

REM Start the DocFX server
ECHO [INFO] Starting the DocFX server...
START "DocFX Server" /MIN cmd /C "docfx serve docfx_project/_site --port 8080 && ECHO [INFO] Server stopped. Press any key to exit... && PAUSE >NUL"

REM Open the documentation in the default browser
ECHO [INFO] Opening the documentation in the default web browser...
START http://localhost:8080

REM Inform the user
ECHO [INFO] The DocFX server is now running at 'http://localhost:8080'. Press CTRL+C in the 'DocFX Server' window to stop the server.
ECHO [INFO] You can access the documentation in your web browser. 

REM End
EXIT /B 0
