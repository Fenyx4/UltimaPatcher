@echo off
if "%OS%" == not "Windows_NT" goto done
setlocal enableextensions
cd /d "%~dp0"
if not exist ..\DOSBox.exe goto done
cd ..
title DOSBox configuration
echo DOSBox configuration
echo.
echo This is the configuration file for DOSBox SVN-Daum.
echo Lines starting with a # are comment lines and are ignored by DOSBox.
echo They are used to (briefly) document the effect of each option.
echo.
if exist dosbox.conf goto conf_here
DOSBox.exe -editconf notepad.exe -editconf %SystemRoot%\system32\notepad.exe -editconf %WINDIR%\notepad.exe
pause >nul
goto done

:conf_here
if exist "%WINDIR%\notepad.exe" goto open_conf
if exist "%SystemRoot%\system32\notepad.exe" goto open_conf
echo Couldn't find notepad.exe in your system.
pause >nul
goto done

:open_conf
if exist "%WINDIR%\notepad.exe" "%WINDIR%\notepad.exe" dosbox.conf && goto done
if exist "%SystemRoot%\system32\notepad.exe" "%SystemRoot%\system32\notepad.exe" dosbox.conf && goto done
goto done

:done
