Feature: Common

@Common
@smoke
	Scenario: 01 Check Enrollment under contact and Lifecycle
	Given I have logged in as a <Persona>
	And I navigate to main Area and SubArea <SubArea> 
	When I wait for 3000 specific time
		And I search UIAuto-Enrollment-949989 in the grid
	And I open the first record in the grid
	When I wait for 3000 specific time
		And I verify below fields
	| Type  | sectionLabel | FieldName                                  | FieldValue |
	| Field | SUMMARY      | Enrollment Name							|	         |
	| Field | SUMMARY      | Enrollment Date							|            |
	| Field | SUMMARY      | Expected Start Date                        |            |
	| Field | SUMMARY      | Program									|            |
	| Field | SUMMARY      | Campus										|            |
	| Field | SUMMARY      | Student Status		                        |            |
	| Field | SUMMARY      | Owner		                                |            |
	| Field | SUMMARY      | Enrollment Number	                        |            |
	| Field | SUMMARY      | Enrollment Status	                        |            |
	| Field | SUMMARY      | Graduation Date	                        |            |
	And I scrolldown to End of SUMMARY section
	And I wait for 3000 specific time
	And I verify below fields
	| Type  | sectionLabel | FieldName                                  | FieldValue |
	| Field | SUMMARY      | External Source System                     |            |
	| Field | SUMMARY      | Last Day of Attendance                     |            |

    And I scroll in to view of DETAILS section
	And I verify below fields
	| Type  | sectionLabel | FieldName                                  | FieldValue |
	| Field | DETAILS      | Program Version Name                       |            |
	| Field | DETAILS      | Area of Study		                        |            |
	| Field | DETAILS      | Shift					                    |            |
	| Field | DETAILS      | Start Term				                    |            |
	| Field | DETAILS      | Hours Required			                    |            |
	| Field | DETAILS      | Credits Required		                    |            |
	| Field | DETAILS      | Hours Scheduled		                    |            |
	
	And I scrolldown to End of DETAILS section
	And I wait for 3000 specific time
	And I verify below fields
	| Type  | sectionLabel | FieldName                                  | FieldValue |
	| Field | DETAILS      | Credits Scheduled		                    |            |
	| Field | DETAILS      | Transfer Hours			                    |            |
	| Field | DETAILS      | Expected Credits per Term                  |            |
	| Field | DETAILS      | Enrollment Cumulative GPA                  |            |
	
	And I scrolldown to End of DETAILS section
	And I wait for 5000 specific time
	And I verify below fields
	| Type  | sectionLabel | FieldName                                  | FieldValue |
	| Field | DETAILS      | Credits Earned                             |            |
	| Field | DETAILS      | Credits Attempted                          |            |
	| Field | DETAILS      | Hours Earned                               |            |
	| Field | DETAILS      | Hours Attempted                            |            |

	And I scroll in to view of DETAILS section
	And I wait for 3000 specific time
	And I verify below fields
	| Type  | sectionLabel | FieldName                                  | FieldValue |
	| Field | DETAILS      | Student Overall GPA                        |            |
	
	And I verify below fields
	| Type  | sectionLabel | FieldName                                  | FieldValue |
	| Field | CONTACT      | Contact			                        |            |
	| Field | CONTACT      | Email				                        |            |
	| Field | CONTACT      | Mobile Phone		                        |            |
	| Field | CONTACT      | Phone Call Preference                      |            |
	| Field | CONTACT      | Email Preference	                        |            |
	| Field | CONTACT      | SMS Text Preference                        |            |
	| Field | CONTACT      | Address 1: Street 1                        |            |
	| Field | CONTACT      | Address 1: Street 2                        |            |
	| Field | CONTACT      | Address 1: Street 3                        |            |
	| Field | CONTACT      | Address 1: City                            |            |
	| Field | CONTACT      | Address 1: State                           |            |
	| Field | CONTACT      | Address 1: ZIP/Postal Code                 |            |
	| Field | CONTACT      | Address 1: Country/Region                  |            |

	And I verify below fields
	| Type  | sectionLabel | FieldName                                  | FieldValue |
	| Field | LIFECYCLE    | Lifecycle Name				                |            |
	| Field | LIFECYCLE    | Lifecycle Type                             |            |
	| Field | LIFECYCLE    | Source Method                              |            |
	| Field | LIFECYCLE    | Source Category                            |            |
	| Field | LIFECYCLE    | Campus                                     |            |
	| Field | LIFECYCLE    | Program                                    |            |
	| Field | LIFECYCLE    | Program Level                              |            |
	| Field | LIFECYCLE    | Expected Start Date                        |            |
	| Field | LIFECYCLE    | Status Reason                              |            |

	And I scroll in to view of CONTACT section
	When I click cmc_contactid locked lookup field in CONTACT section
	And I wait for 4000 specific time
	When I select Contact (Reach) Form 
	And I wait for 4000 specific time
	And I select the tab Student Progress in the form
	And I wait for 4000 specific time
	#When I have clicked new command on ENROLLMENT SubGrid
		#And I scroll in to view of ENROLLMENT section
	Then I open the first record in the grid in ENROLLMENT section
	#And I click GridList locked lookup field in ENROLLMENT section
	#And I have clicked More Commands command on ENROLLMENT SubGrid
	#And I have clicked  SubGrid option on More Commands SubGrid
	When I wait for 3000 specific time
	When I click cmc_opportunityid locked lookup field in LIFECYCLE section
	And I wait for 3000 specific time
	And I select the tab Enrollment in the form
	#When I have clicked new command in View
	Then I open the first record in the grid in ENROLLMENT section


Examples:
| Test Case ID | Persona		| Area | SubArea | EnrollmentName | Message |
|949989		   | StudentAdvisor | Engage | Enrollments | UIAuto-Enrollment-949989 |Read-only: You don't have access to edit this record.|


@Common02
@smoke
Scenario: 02 Verify on adding Course only related course options should be available to pick
	# Login with Business Unit Administrator
	# Data for 'Course Name', 'Academic Period' and 'Contact with type faculty (i.e. Abhinesh Vemula)' should come from Pre-req

	Given I have logged in as a BusinessUnitAdministrator
#	And I have navigated to the Area Reference Data and SubArea Courses
#	And I search UIAuto-Course-967176 in the grid
#	And I open the first record in the grid
#	And I select the tab Course Sections in the form
#
#    #Create Course section record
#	When I have clicked New Course Section command on Section SubGrid
#	And I wait for 4000 specific time
#	#And I have set <CourseDayTime> to mshied_coursedaytime text field in the QuickCreate
#	#And I have set UILocation to mshied_location text field in the QuickCreate
#	And I have set UIAuto-AcademicPer-967176 to mshied_academicperiodid field in the lookup dialog
#	And I click Save and Close action button in Quick Create pop-up
#	And I wait for 3000 specific time
#	#And I press Save in the form
#	#Then the Entity should be saved
#	#And I press Save in QuickCreate
#	#Then the QuickCreate should be saved
#	And I open the first record in the grid
#	And I wait for 3000 specific time
#	When I have set UICourseDay to mshied_coursedaytime text field uniquely in the Form
#	And I have set UILocation to mshied_location text field uniquely in the Form
#	And I press Save in the form
#	When I wait for 3000 specific time
#	Then the Entity should be saved
#	And I wait for 3000 specific time
#	And I select the tab Course Instructors in the form
#	When I wait for 3000 specific time
#    And I click New Course Instructor command in Course Instructors SubGrid Division
#    And I wait for 3000 specific time 
#	And I have set UIAuto Contact-967176 to cmc_instructorid field in the lookup dialog
#	And I wait for 3000 specific time
#	And I have set Advisor to cmc_roleid field in the lookup dialog
#	And I wait for 3000 specific time
#	And I click Save and Close action button in Quick Create pop-up
#	And I wait for 3000 specific time
#	And I click Ignore And Save button in dialog only if available
#	#And I press Save in QuickCreate
#	#Then the QuickCreate should be saved
#	When I wait for 3000 specific time
    And I navigate to main Area and SubArea <SubArea1>

	And I have clicked New command in View
	And I wait for 3000 specific time
	When I select Contact (Reach) Form 
	Then I click Discard Changes in Confirmation dialog
	And I wait for 3000 specific time
	Then I scrolldown to End of CONTACT SUMMARY section
	When I have set <LastName> to lastname text field uniquely in the Form
	 And I scroll in to view of INITIAL SOURCE section
	 And I wait for 3000 specific time
	And I select Recommender options in mshied_contacttype_i multivalue optionset
	When I press Save in the form
	Then the Entity should be saved
	When I wait for 3000 specific time
	And I select the tab Student Progress in the form
	When I wait for 3000 specific time
	And I click New Academic Period Detail command on ACADEMIC PROGRESS SubGrid when available
	And I click More Commands button on ACADEMIC PROGRESS SubGrid only if available
	When I wait for 3000 specific time
	And I click New Academic Period Detail SubGrid option on More Commands SubGrid when available	
	#And I have clicked More Commands command on ACADEMIC PROGRESS SubGrid
	When I wait for 3000 specific time
    #And I have clicked New Academic Period Detail SubGrid option on More Commands SubGrid
	When I wait for 3000 specific time
	And I have set UIAuto-AcademicPer-967176 to mshied_academicperiodid field in the lookup dialog
	When I wait for 3000 specific time
	And I press Save in QuickCreate
	Then the QuickCreate should be saved
	And I press Save in the form
	Then the Entity should be saved
	#And I have clicked Save & Close command in View
	#And I click Save and Close action button in Quick Create pop-up
	And I wait for 4000 specific time
		And I open the first record in the grid in ACADEMIC PROGRESS section
	When I wait for 3000 specific time
	And I select the tab Course Histories in the form
	#When I have clicked New Course History command on Course Histories (Academic Period Details) SubGrid
	  #And I click  New Course History command in Course Histories (Academic Period Details) SubGrid Division
	  And  I choose to click New Course History command in Course_Histories SubGrid out of multiple sections in Course Histories div if available
	And I have set UIAuto-Course-967176 to mshied_courseid field in the lookup dialog
	And I have set UIAuto-Course-967176 to mshied_coursesectionid field in the lookup dialog
	And I click Save and Close action button in Quick Create pop-up
	And I wait for 3000 specific time
	#And I press Save in the form
	#Then the Entity should be saved

Examples:
|TestCase ID | Persona                   | Area           | SubArea | Area1  | SubArea1 | LastName |
|967176       | BusinessUnitAdministrator | Reference Data | Courses | Engage | Contacts | UIcourse |


@smoke
Scenario: 03 Verify the functionality of Lifecycle Auto Create Connection flow
	
	Given I have logged in as a BusinessUnitAdministrator
	And I navigate to main Area and SubArea <SubArea>
	And I have clicked New command in View
	When I have set <LastName> to lastname text field uniquely in the Form
	And I scroll in to view of INITIAL SOURCE section
	And I select Student options in mshied_contacttype_i multivalue optionset
	And I scrolldown to End of INITIAL SOURCE section
	And I have set Web Chat to cmc_sourcemethodid lookup item in the Form
	And I wait for 3000 specific time
	And I have set Application to cmc_sourcecategoryid lookup item in the Form
	When I press Save in the form
	Then the Entity should be saved
	When I wait for 3000 specific time
	And I select the tab Inbound Interest & Lifecycle in the form
	When I wait for 3000 specific time
	When I have clicked New Lifecycle command on LIFECYCLES SubGrid
		When I wait for 3000 specific time
	And I have set <LifecycleType> to cmc_lifecycletype optionset field in the Form
	And I have set Account-974824 to cmc_campusid lookup item in the Form
	When I press Save in the form
	Then the Entity should be saved
	When I wait for 3000 specific time
	When I click cmc_contactid locked lookup field in CONTACT section
	And I wait for 3000 specific time
	And I select the tab Key Information in the form
	And I scrolldown to End of CONNECTIONS LIST section 
	And I wait for 8000 specific time	
	And I click first record in the grid in CONNECTIONS LIST section only if available
	And I wait for 3000 specific time
	
Examples:
| Test Case ID | Persona                   | Area   | AccountName | AccountType | StudentAdvisor | SubArea  | LastName   | LifecycleType |
| 974824       | BusinessUnitAdministrator | Engage | UICampus    | 494280000   | StudentAdvisor | Contacts | UIAutoLife | 175490001     |
 
 @smoke
Scenario: 04 Validate Campus NexusEngage App to be converted to Unfied UI
	Given I have logged in as a <StudentAdvisor>	
	And I have navigated to the Area <Area> and SubArea <SubArea>
	And I navigate to main Area and SubArea <SubArea1>
	And I navigate to main Area and SubArea <SubArea2>
	And I have navigated to the Area <Area3> and SubArea <SubArea3>
	And I have navigated to the Area <Area4> and SubArea <SubArea4>

Examples:
| Test Case ID | StudentAdvisor | Area         | SubArea  | Area1  | SubArea1 | Area2  | SubArea2   | Area3           | SubArea3 | Area4          | SubArea4         |
| 854441       | StudentAdvisor | Constituents | Contacts | Engage | Accounts | Engage | Activities | Case Management | Cases    | Reference Data | Academic Periods |

@Smoke
@Regression 
Scenario: 05 Sitemap UI check 
    Given I have logged in as a <Persona>
    And I have navigated to the Area Settings and SubArea Integration Logs
    And I have navigated to the Area Settings and SubArea Integration Mappings
    #Then I have navigated to the Area Training
	Then I navigate to the Area Training
    And I Select MyCampusInsight webresource from Resources group
    When I wait for 3000 specific time
    Then I switch back to main window
    Then I navigate to the Area Training
    And I Select Community webresource from Resources group
    When I wait for 3000 specific time
   

Examples: 
| Test Case ID | Persona             |
| 951139       | SystemAdministrator |


@Smoke
@Regression 
@EnrollmentAutoCreate
Scenario: 06Verify functionality of Enrollment Auto Create Connection flow TC		
#The "Enrollment Auto Create Connection" flow must be in active mode. 
#Pre-requisite data needs to be created for this

	Given I have logged in as a <Persona>
	And I navigate to main Area and SubArea Accounts
	And I have clicked New command in View
	When I select Account(Reach) Form
	And I have set TestAccount2 to name text field uniquely in the Form
	And I have set Campus to mshied_accounttype optionset field in the Form
	When I press Save in the form
	Then the Entity should be saved
	And I click Ignore and Save button in dialog only if available
	When I wait for 3000 specific time
	Given I have logged in as a <Perosna2>
	When I wait for 3000 specific time
	And I navigate to main Area and SubArea <SubArea>
	And I have clicked New command in View
    When I select Contact (Reach) Form
	Then I click Discard Changes in Confirmation dialog
	When I wait for 4000 specific time
    When I have set Test-PreReq to lastname text field uniquely in the Form
	  #And  I have set  to lastname text field uniquely in the Form
		And I scroll in to view of INITIAL SOURCE section
	When I wait for 3000 specific time
	Then I select Student options in mshied_contacttype_i multivalue optionset
	#And I scroll in to view of INITIAL SOURCE section
	And I scrolldown to End of INITIAL SOURCE section
	And I wait for 1000 specific time
	When I have set Appointment to cmc_sourcemethodid lookup item in the Form
	And I wait for 3000 specific time
	And I have set Application to cmc_sourcecategoryid lookup item in the Form
	And I wait for 3000 specific time
	When I press Save in the form
	Then the Entity should be saved	
	And I click Ignore and Save button in dialog only if available
	When I wait for 3000 specific time
	And I navigate to main Area and SubArea <SubArea>
	And I switch the view to Active Students
	When I search Test-PreReq in the grid
	And I open the first record in the grid
	When I wait for 3000 specific time
	Given I select the tab Inbound Interest & Lifecycle in the form
    When I have clicked New Lifecycle command on LIFECYCLES SubGrid
	And I have set Undergraduate Admissions to cmc_lifecycletype optionset field in the Form
	And I wait for 3000 specific time
	And I have set TestAccount2 to cmc_campusid lookup item in the Form
	When I press Save in the form
	Then the Entity should be saved
	#And I capture screenshot
	And I wait for 3000 specific time
	And I click cmc_contactid locked lookup field in CONTACT section
	And I wait for 3000 specific time
	#And I have navigated to the Area Engage and SubArea Contacts
	#And I switch the view to Active Students
	#When I search Test-PreReq in the grid
	#And I open the first record in the grid
	And I scroll in to view of CONNECTIONS LIST section
	And I wait for 3000 specific time
	#And I capture screenshot
	#And I have clicked More Commands command on CONNECTIONS LIST SubGrid
	#And I click Connection-GridList locked lookup field in CONNECTIONS LIST section
	And I open Connection-GridList list item in CONNECTIONS LIST section only if available
    And I click first record in the grid in CONNECTIONS LIST section only if available 
	And I wait for 3000 specific time
	#And I capture screenshot
	And I wait for 3000 specific time
	#Then record2roleid field value should not be empty
	When The lookup field record2roleid value should not be empty
	And I navigate to main Area and SubArea <SubArea>
	And I switch the view to Active Students
	When I search Test-PreReq in the grid
	And I open the first record in the grid
	Given I select the tab Inbound Interest & Lifecycle in the form
#When I scroll in to view of LIFECYCLES section
When I scrolldown to End of LIFECYCLES section
	When I open the first record in the grid in Lifecyclyes section
	And I wait for 3000 specific time
	Given I select the tab Enrollment in the form
	When I have clicked New Enrollment command on enrollments SubGrid
		And I have set TestAccount2 to cmc_campusid lookup item in the Form
	And I wait for 3000 specific time
    And I have set Test-PreReq to cmc_contactid lookup item in the Form
	And I wait for 3000 specific time
	And I have set Enrollment to cmc_name text field in the Form
	And I press Save in the form
	Then the Entity should be saved
	And I click cmc_contactid locked lookup field in CONTACT section
	#And I have navigated to the Area Engage and SubArea Contacts
	#And I switch the view to Active Students
	#When I search Test-PreReq in the grid
	#And I open the first record in the grid



Examples: 
| TestCase ID | Persona                   | Perosna2       | SubArea  |
| 977138      | BusinessUnitAdministrator | StudentAdvisor | Contacts |


@Common
@smoke
Scenario: 07 Course History Entity_Form And Field Validations
    Given I have logged in as a <StudentAdvisor>
    And I navigate to main Area and SubArea <SubArea>
  When I wait for 3000 specific time
	And I switch the view to Active Students
	  When I wait for 1000 specific time
    And I search UIAuto Contact-750901 in the grid
	When I wait for 3000 specific time
    And I open the first record in the grid
    When I wait for 3000 specific time
	And I navigate to sub tab Course Histories of available tab Events in the form
   # And I select the sub tab Course Histories of tab Related in the form    
    And I wait for 3000 specific time
  #  And I have clicked New Course History command in View
  And I click New Course History command in associated View
  And I wait for 1000 specific time
    And I verify below fields
        | Type  | sectionLabel       | FieldName               | FieldValue |
        | Field | COURSE INFORMATION | Student                 |            |
        | Field | COURSE INFORMATION | Academic Period Details |            |
        | Field | COURSE INFORMATION | Course                  |            |
        | Field | COURSE INFORMATION | Course Section          |            |
        | Field | COURSE INFORMATION | Registration Status     |            |
        | Field | GRADES             | Credits Attempted       |            |
        | Field | GRADES             | Credits Earned         |            |
        | Field | GRADES             | Letter Grade            |            |
        | Field | GRADES             | Grade Points            |            |
        | Field | GRADES             | Mid Term Letter Grade   |            |
        | Field | GRADES             | Mid Term Numeric Grade  |            |
        | Field | GRADES             | Continuing Education    |            |
        | Field | ATTENDANCE         | Last Date of Attendance |            |
        | Field | ATTENDANCE         | Minutes Absent          |            |
        | Field | ATTENDANCE         | Minutes Attended        |            |
    

Examples:
| Test Case ID | StudentAdvisor | Area   | SubArea  |
| 750901       | StudentAdvisor | Engage | Contacts |

@Common
@OccupationInsight
Scenario: 08 Configure Occupation Insight
	Given I have logged in as a <BusinessUnitAdministrator> 
	And I have navigated to the Area <Area> and SubArea Sync Error 
	When I wait for 7000 specific time
	And I have navigated to the Area <Area> and SubArea <SubArea>
    When I wait for 10000 specific time
	And I open the first record in the grid
	When I wait for 3000 specific time
	And I select the tab Occupation Insight in the form
	And I verify below fields
	| Type  | sectionLabel       | FieldName                  | FieldValue |
	| Field | Section | Occupation Insight URL     |            |
	| Field | Section | Occupation Insight API Key |            |
	
	Then The cmc_occupationinsighturl field value should be equal to https://sisoigraphapi-devpatch-910001.campusnexus.cloud/
    Then The cmc_occupationinsightapikey field value should be equal to DDAC2335-E996-452F-9889-C66923400A38
	
	And I have navigated to the Area <Area> and SubArea <SubArea1>
	And I have clicked New command in View
	When I have set Report to cmc_reporttype optionset field in the Form
	When I wait for 4000 specific time
	And I have set <ReportName> to cmc_selectreportinternal optionset field in the Form
	And I wait for 4000 specific time
	And I press Save in the form
	Then the Entity should be saved
	When I wait for 3000 specific time
	And I have navigated to the Area Reach and SubArea Dashboards	
	When I wait for 3000 specific time
	Then I Select <DashboardName> dashboard
	When I wait for 3000 specific time
    And I select <ReportName> report

Examples: 
| Test Case ID | BusinessUnitAdministrator | Area     | SubArea        | SubArea1                   | ReportName                                                 | DashboardName      |
| 969230       | BusinessUnitAdministrator | Settings | Configurations | Occupation Insight Reports | Occupation Insight - Program Explorer - by Program Version | Occupation Insight |

