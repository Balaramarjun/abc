newman run "%TestLocation%\%projectname%\Test\ApplicationManagement\TC_846543_InvoicePopulate\TC_846543_InvoicePopulate.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\Invoice Populate.csv" -r  htmlextra  --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_846543\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json" 