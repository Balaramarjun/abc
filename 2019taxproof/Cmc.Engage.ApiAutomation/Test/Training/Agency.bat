if not defined TestLocation (set TestLocation=.) 
if not EXIST "%TestLocation%\..\..\..\..\..\Common\%ApiTestConfig%.postman_environment.json" (
@echo off
setlocal 
  setx ApiTestConfig "700001"
endlocal
@echo on
)

newman run "%TestLocation%\TC_1012504_AssigningBulkDecisionsToApplications.postman_collection.json" -d "%TestLocation%\..\..\..\TestData\AssigningBulkDecisionsToApplications.csv" -r  htmlextra  --reporter-htmlextra-title NewmanTests --reporter-htmlextra-export newmanReport/newmantests.html --reporter-htmlextra-logs --reporter-htmlextra-darkTheme -e "%TestLocation%\..\..\..\..\Common\%ApiTestConfig%.postman_environment.json"