newman run "%TestLocation%\%projectname%\Test\Communications\TC_762862_LastActivityDateRollup\TC_762862_LastActivityDateRollup.postman_collection.json"  -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_762862\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"