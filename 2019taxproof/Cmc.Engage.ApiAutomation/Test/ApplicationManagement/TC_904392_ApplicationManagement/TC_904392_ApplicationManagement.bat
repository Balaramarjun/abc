newman run "%TestLocation%\%projectname%\Test\ApplicationManagement\TC_904392_ApplicationManagement\TC_904392_ApplicationManagement.postman_collection.json" -r  htmlextra  --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_904392\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"