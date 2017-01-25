cd Chromamboo
cd chromamboo-react
Call npm run build
echo deploying files to wwwroot
xcopy build ..\wwwroot /s /e /h /I