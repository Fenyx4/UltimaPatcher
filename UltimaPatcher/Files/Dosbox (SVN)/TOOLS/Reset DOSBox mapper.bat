@echo off
title Reset DOSBox mapper
cls
setlocal enableextensions
cd /d "%~dp0"
cd ..
if exist dosbox.conf goto warning
if not exist dosbox.exe goto done
dosbox -resetmapper
echo Reset.
pause >nul
goto done

:warning
cls
echo Warning: dosbox.conf exists in current working directory.
echo Keymapping might not be properly reset.
echo Please reset configuration as well and delete the dosbox.conf.
pause >nul
goto done

:done
