newman run "%TestLocation%\%projectname%\Test\ApplicationManagement\TC_845089_RecommendationAuto-complete\TC_845089_RecommendationAuto-complete.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\TC_845089_RecommendationAuto-complete.csv" -r  htmlextra  --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_845089\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
