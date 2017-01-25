@echo off

IF [%1]==[] goto undefined
SET buildconfig=%1

goto start
:undefined
SET buildconfig=debug
echo.
echo no build configuration specified, using 'debug' as a default.
:start
echo Preparing chromamboo-react for %buildconfig%
cd Chromamboo
cd chromamboo-react
Call npm run build
echo deploying files to the '%buildconfig%' binaries
xcopy build ..\bin\%buildconfig%\wwwroot  /s /e /h /I /Y
cd..
cd..