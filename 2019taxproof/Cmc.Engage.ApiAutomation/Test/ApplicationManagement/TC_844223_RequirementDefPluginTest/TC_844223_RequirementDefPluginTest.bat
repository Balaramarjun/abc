newman run "%TestLocation%\%projectname%\Test\ApplicationManagement\TC_844223_RequirementDefPluginTest\TC_844223_RequirementDefPluginTest.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\Requirement Def Plugin Test.csv" -r  htmlextra  --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_844223\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json" 