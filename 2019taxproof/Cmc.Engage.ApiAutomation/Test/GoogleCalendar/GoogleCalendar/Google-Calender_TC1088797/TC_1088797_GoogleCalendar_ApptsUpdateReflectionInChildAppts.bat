newman run "%TestLocation%\%projectname%\Test\GoogleCalendar\GoogleCalendar\Google-Calender_TC1088797\TC_1088797_GoogleCalendar_ApptsUpdateReflectionInChildAppts.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\ApptsUpdateReflectionInChildAppts.csv"   -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1088797\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"