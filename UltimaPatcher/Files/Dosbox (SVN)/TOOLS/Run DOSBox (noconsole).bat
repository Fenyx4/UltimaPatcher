@echo off
setlocal enableextensions
cd /d "%~dp0"
cd ..
if exist dosbox.exe start dosbox -noconsole
