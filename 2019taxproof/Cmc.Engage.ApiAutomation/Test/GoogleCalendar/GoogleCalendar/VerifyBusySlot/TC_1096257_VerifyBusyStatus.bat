newman run "%TestLocation%\%projectname%\Test\GoogleCalendar\GoogleCalendar\VerifyBusySlot\TC_1096257_VerifyBusyStatus.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\TC_1096257.csv"  -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1096257\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"