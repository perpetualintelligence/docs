@ECHO OFF
SETLOCAL EnableDelayedExpansion

REM This script performs the following actions:
REM 1. Starts the DocFX server to serve previously built documentation from the 'docfx_project/_site' directory.
REM 2. Opens the default web browser to the home page of the served documentation.
REM 3. Provides feedback to the user and ensures proper execution order.

ECHO [INFO] Attempting to start the DocFX server...

REM Check if the '_site' directory exists
IF NOT EXIST docfx_project\_site (
    ECHO [ERROR] The 'docfx_project/_site' directory does not exist. Please ensure that the documentation has been built. Exiting...
    EXIT /B 1
)

REM Start the DocFX server to serve the generated documentation
ECHO [INFO] Starting the DocFX server to serve the documentation on port 8080...
START "DocFX Server" cmd /C "docfx serve docfx_project/_site --port 8080"

REM Give the server some time to start before opening the browser
TIMEOUT /NOBREAK /T 5 >NUL

REM Open the default web browser to the DocFX project's home page
ECHO [INFO] Opening the documentation in the default web browser...
START http://localhost:8080

ECHO [INFO] The DocFX server is now running and serving the documentation at 'http://localhost:8080'.
ECHO [INFO] You can access the documentation in your web browser. Press CTRL+C in the 'DocFX Server' window to stop the server when you are done.

REM The script has completed its execution
EXIT /B 0
