newman run "%TestLocation%\%projectname%\Test\Retentions\StudentAlert\TC_1222019_StudentAlert\TC_1222019_StudentAlert.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\StudentAlert.csv"  -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1222019\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
