@echo off
setm
IF ERRORLEVEL 1 GOTO ABORTED2
GOTO END
:ABORTED2
echo Midi Music Driver configuration was not completed.
GOTO FINI
:END
echo Sound Configuration Complete!
copy u4.asc u4.bat
echo type 'u4' to play Ultima 4 with sound
echo thank you for using Aradindae Dragon's U4 music patch v2.0
:FINI
