@echo off
:Start
set /p name= Enter program name: 
echo.
С:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe "%name%.cs"
echo.
goto Start