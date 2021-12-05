@echo off
title Reset DOSBox configuration
setlocal enableextensions
cd /d "%~dp0"
cd ..
if not exist dosbox.exe goto done
if exist dosbox.conf goto current_dir
dosbox -resetconf
cls
echo Reset.
pause >nul
goto done

:current_dir
del dosbox.conf
if exist dosbox.conf goto done
dosbox -eraseconf >nul
start /wait /min dosbox -c "cls" -c "config -wcp dosbox.conf" -c "exit"
cls
echo Reset.
pause >nul
goto done

:done
