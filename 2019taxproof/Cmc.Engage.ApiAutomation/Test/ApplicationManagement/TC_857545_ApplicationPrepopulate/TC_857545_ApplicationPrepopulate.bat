newman run "%TestLocation%\%projectname%\Test\ApplicationManagement\TC_857545_ApplicationPrepopulate\TC_857545_ApplicationPrepopulate.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\Application Prepopulate.csv" -r  htmlextra  --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_857545\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"