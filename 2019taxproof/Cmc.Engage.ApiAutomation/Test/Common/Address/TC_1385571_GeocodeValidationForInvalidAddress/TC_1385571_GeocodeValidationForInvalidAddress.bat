newman run "%TestLocation%\%projectname%\Test\Common\Address\TC_1385571_GeocodeValidationForInvalidAddress\TC_1385571_GeocodeValidationForInvalidAddress.postman_collection.json" -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1385571\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"