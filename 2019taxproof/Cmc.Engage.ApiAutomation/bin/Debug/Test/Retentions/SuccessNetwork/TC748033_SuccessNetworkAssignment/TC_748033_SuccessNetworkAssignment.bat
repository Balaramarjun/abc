newman run "%TestLocation%\%projectname%\Test\Retentions\SuccessNetwork\TC748033_SuccessNetworkAssignment\TC_748033_SuccessNetworkAssignment.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\SuccessNetwork.csv"  -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_748033\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
