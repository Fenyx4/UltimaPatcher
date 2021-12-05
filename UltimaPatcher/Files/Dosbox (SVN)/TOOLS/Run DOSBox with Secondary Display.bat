@echo off
setlocal enableextensions
cd /d "%~dp0"
cd ..
if not exist dosbox.exe goto done
chcp 437
color 07
title Run DOSBox with Secondary Display
:repeat
set me=
cls
echo Patch provided by ripsaw8080 (win32 pdcurses)
echo This feature requires software like Mah Jongg which supports secondary monitor
echo.
echo Choose one of the following color modes for your secondary display
echo.
echo    1. Green
echo    2. Amber
echo    3. White
echo.
set /p me=Select [1, 2, 3]?
if /I "%me%" == "1" start dosbox -display2 "green" && goto done
if /I "%me%" == "2" start dosbox -display2 "amber" && goto done
if /I "%me%" == "3" start dosbox -display2 "white" && goto done
goto repeat

:done
exit
