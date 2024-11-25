@setlocal
@set SCRIPT_DIR=%~dp0
cd %SCRIPT_DIR%
@set DIST_DIR=%SCRIPT_DIR%dist

@set PRJ_NAME=markdown-wsam

@echo.
@echo ************************************
rmdir /S/Q %DIST_DIR%
dotnet publish -c Release markdown-wsam.sln -o %DIST_DIR%\markdown-wsam
@echo ************************************
@echo.

cd %DIST_DIR%
@echo.
@echo *** tar -zcvf %PRJ_NAME%.tar.gz %PRJ_NAME% *********************************
tar -zcvf %PRJ_NAME%.tar.gz %PRJ_NAME%
@echo ************************************
@echo.

cd %SCRIPT_DIR%
@rem move %DIST_DIR%\%PRJ_NAME%.tar.gz .

@endlocal
