newman run "%TestLocation%\%projectname%\Test\Retentions\CampusSurvey\CreateCampusSurveyAndResponse\TC_764851_CampusSurvey.postman_collection.json"  -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_764851\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"