newman run "%TestLocation%\%projectname%\Test\Common\Contact\TC_802062_Gravatar\TC_802062_Gravatar.postman_collection.json"  -r htmlextra --reporters cli,junit,htmlextra --reporter-junit-export Results\TC_802062\junitReport.xml --reporter--reporter-htmlextra-export newmanReport/newmantests.html -e "%TestLocation%\Common\%ApiTestConfig%.postman_environment.json"
