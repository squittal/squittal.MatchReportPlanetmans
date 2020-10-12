@echo off

echo Starting squittal.MatchReportPlanetmans app...
call :StartDotnetApp
if %ERRORLEVEL% NEQ 0 (
    echo Failed to start the app. Exiting...
    pause
    exit
)
pause

:StartDotnetApp
cd "%~dp0"
dotnet run --verbosity m --project "..\squittal.MatchReportPlanetmans\squittal.MatchReportPlanetmans.csproj"
exit /B