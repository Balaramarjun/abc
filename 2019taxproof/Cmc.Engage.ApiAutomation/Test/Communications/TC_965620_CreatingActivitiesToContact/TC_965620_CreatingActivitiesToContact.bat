newman run "%TestLocation%\%projectname%\Test\Communications\TC_965620_CreatingActivitiesToContact\TC_965620_CreatingActivitiesToContact.postman_collection.json"  -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_965620\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
