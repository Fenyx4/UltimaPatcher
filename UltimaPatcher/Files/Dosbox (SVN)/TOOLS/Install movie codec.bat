@echo off
if "%OS%" == not "Windows_NT" goto quick_install_win9x
set win64=no
if exist %systemroot%\syswow64 set win64=yes
chcp 437
cls
if not exist "%SYSTEMROOT%\system32\cacls.exe" goto home
rem ----------------- obtain admin start -----------------
:obtain_admin
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"
if '%errorlevel%' NEQ '0' goto UACPrompt
goto gotAdmin

:UACPrompt
echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
set params = %*:"=""
echo UAC.ShellExecute "%~s0", "%params%", "", "runas", 1 >> "%temp%\getadmin.vbs"
"%temp%\getadmin.vbs" && exit /B

:gotAdmin
if exist "%temp%\getadmin.vbs" ( del "%temp%\getadmin.vbs" )
pushd "%CD%" && CD /D "%~dp0"
rem ----------------- obtain admin end -----------------

:home
title Install/Uninstall ZMBV movie codec
set errornum=0
setlocal enableextensions
cd /d "%~dp0"
:ready
if not exist %SystemRoot%\system32\rundll32.exe set errornum=1 && goto error
if not exist .\zmbv\zmbv.dll set errornum=2 && goto error
if not exist .\zmbv\zmbv.inf set errornum=3 && goto error
if not exist .\zmbv\zmbv64.dll set errornum=4 && goto error
if not exist .\zmbv\zmbv64.inf set errornum=5 && goto error
if /I "%1" == "/u" goto uninstall_confirm
if exist %SystemRoot%\inf\zmbv.inf goto already_installed
if exist %SystemRoot%\inf\zmbv64.inf goto already_installed
:install_confirm
set me=
cls
set /p me=Do you want to install ZMBV codec [Y/N]?
if /I "%me%" == "y" goto install
if /I "%me%" == "n" goto done
goto install_confirm
:install
echo.
%SystemRoot%\system32\rundll32.exe setupapi,InstallHinfSection DefaultInstall 128 .\zmbv\zmbv.inf
if "%win64%" == "yes" %SystemRoot%\system32\rundll32.exe setupapi,InstallHinfSection DefaultInstall 128 .\zmbv\zmbv64.inf
if exist %SystemRoot%\inf\zmbv.inf (echo Zip Motion Block Video codec installation is complete.) ELSE (echo Failed to install.)
pause >nul
goto done

:uninstall_confirm
set me=
cls
echo Are you sure to uninstall ZMBV codec [Y/N]?
if /I "%me%" == "y" goto uninstall
if /I "%me%" == "n" goto done
:uninstall
echo.
%SystemRoot%\system32\rundll32.exe setupapi,InstallHinfSection DefaultunInstall 128 .\zmbv\zmbv.inf
%SystemRoot%\system32\rundll32.exe setupapi,InstallHinfSection DefaultunInstall 128 .\zmbv\zmbv64.inf
if not exist %SystemRoot%\inf\zmbv.inf (echo Zip Motion Block Video codec uninstallation is complete.) ELSE (echo Failed to uninstall.)
pause >nul
goto done

:already_installed
set me=
cls
echo Already installed. Select one of the following options.
set /p me=Reinstall: R, Uninstall: U, Quit: Q   [R/U/Q]?
if /I "%me%" == "r" goto install
if /I "%me%" == "u" goto uninstall
if /I "%me%" == "q" goto done
goto already_installed

:error
if %errornum% == 0 goto done
echo Error!
if %errornum% == 1 echo Couldn't find rundll32.exe in your systemroot.
if %errornum% == 2 echo Couldn't find zmbv.dll in \zmbv.
if %errornum% == 3 echo Couldn't find zmbv.inf in \zmbv.
if %errornum% == 4 echo Couldn't find zmbv64.dll in \zmbv.
if %errornum% == 5 echo Couldn't find zmbv64.inf in \zmbv.
pause >nul
goto done

:quick_install_win9x
if not exist .\zmbv\zmbv.dll set errornum=2 && goto error
if not exist .\zmbv\zmbv.inf set errornum=3 && goto error
rundll setupx.dll,InstallHinfSection DefaultInstall 128 $INSTDIR\Video Codec\zmbv.inf
goto done

:done
set errornum=
set me=
set win64=
