newman run "%TestLocation%\%projectname%\Test\Lifecycles\TravelManagement\TC_775764\TC_775764.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\Travelmgmt.csv" -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_775764\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
