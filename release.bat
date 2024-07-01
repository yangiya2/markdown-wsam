@setlocal
@set SCRIPT_DIR=%~dp0
cd %SCRIPT_DIR%
@set DIST_DIR=%SCRIPT_DIR%dist

@set PRJ_NAME=markdown-wsam

@echo.
@echo ************************************
dotnet publish -c Release
@echo ************************************
@echo.

cd %SCRIPT_DIR%
rmdir /S/Q %DIST_DIR%
mkdir %DIST_DIR%\%PRJ_NAME%

xcopy /S/F %SCRIPT_DIR%\bin\Release\net8.0\publish\wwwroot\*  %DIST_DIR%\%PRJ_NAME%\

cd %DIST_DIR%
@echo.
@echo *** tar -zcvf %PRJ_NAME%.tar.gz %PRJ_NAME% *********************************
tar -zcvf %PRJ_NAME%.tar.gz %PRJ_NAME%
@echo ************************************
@echo.

cd %SCRIPT_DIR%
@rem move %DIST_DIR%\%PRJ_NAME%.tar.gz .

@endlocal
