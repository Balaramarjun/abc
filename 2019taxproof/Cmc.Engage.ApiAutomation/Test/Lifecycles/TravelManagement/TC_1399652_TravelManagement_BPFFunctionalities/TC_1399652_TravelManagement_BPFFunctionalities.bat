newman run "%TestLocation%\%projectname%\Test\Lifecycles\TravelManagement\TC_1399652_TravelManagement_BPFFunctionalities\TC_1399652_TravelManagement_BPFFunctionalities.postman_collection.json" -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1399652\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"