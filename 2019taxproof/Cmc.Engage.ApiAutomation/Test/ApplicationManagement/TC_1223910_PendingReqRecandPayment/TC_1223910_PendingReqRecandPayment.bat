newman run "%TestLocation%\%projectname%\Test\ApplicationManagement\TC_1223910_PendingReqRecandPayment\TC_1223910_PendingReqRecandPayment.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\TC_1223910_PendingReqRecandPayment.csv" -r  htmlextra  --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1223910\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"