@echo off
title 
setlocal enableextensions
cd /d "%~dp0"
SET MANHTM="..\DOCS\SVN-specific manuals\index.html"
if not exist %MANHTM% goto done
explorer %MANHTM%
goto done

:done
SET MANHTM=
