newman run "%TestLocation%\%projectname%\Test\GoogleCalendar\GoogleCalendar\GoogleCalendarErrorHandling\TC_1067347_GoogleCalendarErrorHandling.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\GoogleCalendarErrorHandling.csv"   -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1067347\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
