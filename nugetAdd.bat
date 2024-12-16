@setlocal
@set SCRIPT_DIR=%~dp0
cd %SCRIPT_DIR%

dotnet add markdown-wsam.csproj package Markdig
dotnet add markdown-wsam.csproj package Microsoft.Extensions.Logging

@endlocal
