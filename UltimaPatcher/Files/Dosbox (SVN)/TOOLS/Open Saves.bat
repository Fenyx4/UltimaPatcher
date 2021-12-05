@echo off
title Open Saves
cls
setlocal enableextensions
cd /d "%~dp0"
cd ..
if not exist dosbox.exe goto done
dosbox -opensaves explorer.exe
goto done

:done
