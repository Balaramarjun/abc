newman run "%TestLocation%\%projectname%\Test\Lifecycles\Inbound\TC_1378625_SelectandAssociateParentContactandLifecycle\TC_1378625_SelectandAssociateParentContactandLifecycle.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\Inbound.csv" -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_1378625\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"