newman run "%TestLocation%\%projectname%\Test\ApplicationManagement\TC_1094960_AppFeeInvoiceGeneration\TC_1094960_AppFeeInvoiceGeneration.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\AppFee InvoiceGeneration.csv" -r  htmlextra  --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1094960\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
