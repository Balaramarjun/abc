newman run "%TestLocation%\%projectname%\Test\Applications\TestScore\TC_805552_SATSuperscore\TC_805552_SATSuperscore.postman_collection.json"  -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_805552\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
