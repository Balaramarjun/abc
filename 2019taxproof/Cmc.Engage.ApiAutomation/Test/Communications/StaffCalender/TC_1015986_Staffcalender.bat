newman run "%TestLocation%\%projectname%\Test\Communications\StaffCalender\TC_1015986_Staffcalender.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\StaffCalender.csv" -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1015986\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
