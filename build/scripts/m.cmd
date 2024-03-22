@ECHO OFF
SETLOCAL EnableDelayedExpansion

REM This script performs the following actions:
REM 1. Generates the DocFX project metadata.
REM 2. Checks if the generation was successful.
REM 3. Provides feedback to the user.

ECHO [INFO] Starting the DocFX metadata generation process...

REM Validate preconditions (e.g., existence of docfx_project directory)
IF NOT EXIST docfx_project (
    ECHO [ERROR] The 'docfx_project' directory does not exist. Please ensure you are running this script from the correct location. Exiting...
    EXIT /B 1
)

REM Generate the DocFX metadata
CALL docfx metadata docfx_project/docfx.json
IF !ERRORLEVEL! NEQ 0 (
    ECHO [ERROR] DocFX metadata generation failed. Exiting...
    EXIT /B 1
)

ECHO [INFO] DocFX metadata generation successful.
ECHO [INFO] You can find the generated metadata in the 'docfx_project/output_directory' (replace 'output_directory' with actual path).

REM The script has completed its execution
EXIT /B 0
