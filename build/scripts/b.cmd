@ECHO OFF
SETLOCAL EnableDelayedExpansion

REM This script performs the following actions:
REM 1. Builds the DocFX project documentation.
REM 2. Checks if the build was successful.
REM 3. Provides feedback to the user.

ECHO [INFO] Starting the DocFX build process...

REM Build the DocFX project
CALL docfx docfx_project/docfx.json
IF !ERRORLEVEL! NEQ 0 (
    ECHO [ERROR] DocFX build failed. Exiting...
    EXIT /B 1
)

REM Check if the build was successful by verifying the existence of the '_site' folder
IF NOT EXIST docfx_project\_site (
    ECHO [ERROR] Build failed. The '_site' directory does not exist. Exiting...
    EXIT /B 1
)

ECHO [INFO] DocFX build successful! Documentation generated in 'docfx_project/_site'.
ECHO [INFO] You can find the generated documentation in the 'docfx_project/_site' directory.

REM The script has completed its execution
EXIT /B 0
