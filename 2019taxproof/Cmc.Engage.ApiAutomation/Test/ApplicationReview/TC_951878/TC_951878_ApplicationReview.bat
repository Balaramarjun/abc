newman run "%TestLocation%\%projectname%\Test\ApplicationReview\TC_951878\TC_951878_ApplicationReview.postman_collection.json" -d "%TestLocation%\%projectname%\TestData\ApplicationReview.csv" -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_951878\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json