@echo off
setlocal enableextensions
cd /d "%~dp0"
cd ..
REM SET SDL_VIDEODRIVER=WINDIB
SET SDL_VIDEODRIVER=DIRECTX
if exist dosbox.exe start dosbox
