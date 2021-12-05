@echo off
title Open Screenshots / Recordings
cls
setlocal enableextensions
cd /d "%~dp0"
cd ..
if not exist dosbox.exe goto done
dosbox -opencaptures explorer.exe
goto done

:done
