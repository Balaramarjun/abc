newman run "%TestLocation%\%projectname%\Test\Retentions\ScoringModel\ScoringModelContact\TC_968910_ScoringModelContact.postman_collection.json"  -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_968910\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"