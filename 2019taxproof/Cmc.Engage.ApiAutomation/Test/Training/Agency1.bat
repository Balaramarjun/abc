if not defined TestLocation (set TestLocation=.) 
if not EXIST "%TestLocation%\..\..\..\..\..\Common\%ApiTestConfig%.postman_environment.json" (
@echo off
setlocal 
  setx ApiTestConfig "700001"
endlocal
@echo on
)

newman run "%TestLocation%\Agency1.postman_collection.json" -d "%TestLocation%\..\..\..\TestData\Agency.csv" -r  htmlextra  --reporter-htmlextra-title NewmanTests --reporter-htmlextra-export newmanReport/23456kj.html --reporter-htmlextra-logs --reporter-htmlextra-darkTheme -e "%TestLocation%\..\..\..\..\Common\%ApiTestConfig%.postman_environment.json"