Feature: Practice1

#Scenario: Update existing contact
 #   Given I have logged in as a <Persona>
 #   And I have navigated to the Area Reach and SubArea Contacts
 #   And I have clicked New command in View
  #  When I have set Bajaj to lastname text field in the Form
 #   And I select Alumni options in mshied_contacttype_i multivalue optionset
 #   # When I have set 178-TestSoucreMethod385 to cmc_sourcemethodid lookup item in the Form
 #   #When I have set 130-TestSoucreCategor-y634 to cmc_sourcecategoryid lookup item in the Form
 #   And I press Save in the form
 #   Then the Entity should be saved
 #  And I wait for 5000 specific time
 #  	Then I open specific record  from the grid
# Examples:
#| TestCase ID | Persona | 
#| 766162       | Faculty |

  
#@UserList

#Scenario:01 Validate User List form and fields
#    
#
#Given I navigate to Registration URL as <TPCUser>
#And I wait for 3000 specific time
# And I click Page button 
# And I verify title of the page is NewRegistration
# Then I verify multiple fields
#		  | Type  |FieldName                            | FieldValue    |
#		  | Field |cmc_applicationdefinitionversionname | TT Version    |
#		  | Field |cmc_contactid                        | Rohit Sharma1 |
#	And I click Next button in the page  
#    
#
#
# Examples: 
#| TestCase ID | TPCUser| FallBackUser |
#| 1212311     | TPCUser |engage automation |

#Scenario:01 Validate User List form and fields
#        Given I have logged in as a <BusinessUnitAdministrator>
#    And I have navigated to the Area Process Config and SubArea Assignment Groups
#    And I search UIAutoAG- 1212311kw0j in the grid
#    And I open the first record in the grid
#    And I select the tab Assignment Rule in the form
#    And I click New Assignment Rule command in Assignment Rule SubGrid Division
#    And I wait for 3000 specific time
#    When I have set UIAutoAR- 1212311-3 to cmc_name text field uniquely in the Form
#    And I wait for 2000 specific time
#    And I have set 3 to cmc_executionorder text field in the Form
#    And I wait for 2000 specific time
#    And I have set Load-based Assignment to cmc_assignmenttype optionset field in the Form
#    And I wait for 2000 specific time
#    When I have set StaticUserList-1212311 to cmc_userlistid lookup item in the Form
#    And I wait for 2000 specific time
#    And I press Save in the form
#    Then the Entity should be saved
#    And I wait for 2000 specific time
#    And I have clicked Create/Edit Query button in Load Condition section
#    And I wait for 4000 specific time
#    Then I switch to Advanced Find - Microsoft Dynamics 365 window 
#    And I wait for 6000 specific time   
#    And I click HideDetails in Query group of advanced find ribbon
#    Then I switch to contentIFrame0 frame
#    And I select sub filter option as First Name from Fields option group in row 0
#    And I switch back to default frame
#    Given I click Save in the Advanced Find Window 
#    And I close the Advanced Find Window
#    And I wait for 1000 specific time
#    Then I switch back to default frame
#    And I handle dialog with button okbutton
#    And I wait for 2000 specific time
#    And I press Save in the form
#    Then the Entity should be saved
#    And I wait for 2000 specific time
#    And I scroll in to view of Load Condition section
#    And I wait for 2000 specific time
#    And I have clicked Use Existing View button in Load Condition section
#    And I wait for 2000 specific time
#    And I set All Contacts option to cmc_userconditionview PCF control field in Load Condition section
#    And I have clicked Use Query button in Load Condition section
#    And I press Save in the form
#    Then the Entity should be saved
#    And I wait for 2000 specific time
#
#Examples: 
#| TestCase ID | BusinessUnitAdministrator | AssignmentGroupName | FallBackUser      |
#| 1212311     | BusinessUnitAdministrator | UIAutoAG- 1212311   | engage automation |
#Scenario: 24 Validate complete 'Query' UI checks including launching 'Advanced Query builder' functionality
#    #login as Application Admin role
#    #Application record should be available from Pre-req data 
#    
#    Given I have logged in as a <Persona>
#    And I have navigated to the Area Process Config and SubArea Queries
#    When I wait for 4000 specific time
#    And I have clicked New command in View
#    When I wait for 2000 specific time
#    And I have set <QueryName> to cmc_queryname text field uniquely in the Form
#    Given I have set <BaseEntity> to Entity in Entity Picker in the Form
#    When I press Save in the form
#    Then the Entity should be saved
#    #And I search test for ui in the grid
#    #And I open the first record in the grid
#    When I wait for 2000 specific time
#    And I select the tab Query Condition in the form
#    And I wait for 2000 specific time   
#    #Then I switch to WebResource_viewPicker frame
#    #And I wait for 2000 specific time
#    ##And I click on Create/Edit Query Button
#    ##And I click Create/Edit Query button in the window
#    #And I have clicked Create/Edit Query button in Query section
#    #And I wait for 3000 specific time
#    #Then I switch to Advanced Find - Microsoft Dynamics 365 window 
#    #And I wait for 6000 specific time   
#    #And I click HideDetails in Query group of advanced find ribbon
#    #Then I switch to contentIFrame0 frame
#    Given I click Edit Query in View Picker which opens the Advanced Find Window
#    And I wait for 3000 specific time
#    And I click HideDetails in Query group of advanced find ribbon
#    Then I switch to contentIFrame0 frame
#    And I select sub filter option as Application Name from Fields option group in row 0
#    And I switch back to default frame
#    Given I click Save in the Advanced Find Window 
#    And I close the Advanced Find Window
#    And I wait for 1000 specific time
#    Then I switch back to default frame
#    And I wait for 2000 specific time
#    And I press Save in the form
#    Then the Entity should be saved
#    And I wait for 3000 specific time
#    Given  I click Use Existing View in View Picker
#    And I wait for 1000 specific time
#    And I select view Active Applications in View Picker
#    And I wait for 1000 specific time
#    And I click Use Query in View Picker
#    And I wait for 2000 specific time
#    When I press Save in the form
#    And I wait for 2000 specific time
#    Then cmc_conditionxml field value should not be empty
#    And I have navigated to the Area Process Config and SubArea Queries
#    When I wait for 4000 specific time
#    And I have navigated to the Area Process Config and SubArea Requirement Definitions
#    And I have clicked New command in View
#    And I have set UIAuto requirement to cmc_applicationrequirementdefinitionname text field uniquely in the Form
#    When I press Save in the form
#    Then the Entity should be saved
#    When I wait for 3000 specific time
#    When I have clicked New Requirement Definition Detail command on REQUIREMENT DEFINITION DETAILS SubGrid
#    When I have set General to cmc_requirementtype optionset field in the Form
#    And I have set UIAutoRDD to cmc_name text field uniquely in the Form
#    And I have set Yes to Conditional optionset field in the Form
#    And I have set <QueryName> to cmc_queryid lookup item in the Form
#    And I wait for 2000 specific time
#    When I press Save in the form
#    Then the Entity should be saved
#
#Examples:
#| Test Case ID | Persona          | QueryName               | BaseEntity  |
#| 1015579      | ApplicationAdmin | UIAuto-QueryApplication | Application |




#@Common
#@smoke
#Scenario: 09 Navigate to Global Command
#Given I have logged in as a <Persona>
#When I wait for 2000 specific time
#Then I click Advanced Find global command
#When I wait for 2000 specific time
#Then I switch to contentIFrame0 frame
#When I wait for 6000 specific time
#And I select slctPrimaryEntity dropdown filter value as Accounts
#When I wait for 2000 specific time
#Then I switch back to default frame
#And I click Results in Show group of advanced find ribbon
#And I wait for 2000 specific time
##And I verify {{name}}361416612 in advanced find results
#And I wait for 2000 specific time
##And I select sub filter option as Engage Account ID from Fields option group
#And I wait for 2000 specific time
#And I wait for 2000 specific time
#And I select filter option as Contains Data for Equals field
##And I select sub filter option as Created On from Fields option group
##And I enter 03/17/2020 in Choose Date field
##And I select advFindE dropdown filter value as Created On
# 
# Examples: 
#| Persona | 
#| Advisor |

#Scenario:Create a connection and validate Connections Grid, Connection list and Visualization of Internal and All connections in the Contact Form
#    Given I have logged in as a <Persona>
#    And I have navigated to the Area <Area> and SubArea <SubArea>
#    And I search AbhiTestD in the grid
#    And I open the first record in the grid
#	When I wait for 1000 specific time
#	And I click Connection-GridList locked lookup field in CONNECTIONS LIST section
#    #And I open the first record in the grid in CONNECTIONS LIST section
#	When I wait for 2000 specific time
#    And I verify below fields
#    | Type  | sectionLabel | FieldName    | FieldValue       |
#    | Field | General      | Name         |                  |
#    | Field | General      | As this role |                  |
#    | Field | General      | Description  |                  |
#
#
#    Given I select the tab Details in the form
#	When I wait for 1000 specific time
#    And I verify below fields
#    | Type  | sectionLabel | FieldName      | FieldValue |
#    | Field | General      | Connected from | AbhiTestD  |
#    | Field | General      | As this role   |            |
#    And I have navigated to the Area <Area> and SubArea <SubArea>
#    And I search AbhiTestD in the grid
#    And I open the first record in the grid
#    And I have clicked New command in View
#    When I have set <LastName> to lastname text field in the Form
#    Then I select Student options in mshied_contacttype_i multivalue optionset by removing existing selections
#    When I have set Appointment to cmc_sourcemethodid lookup field in the Form
#    And I have set Application to cmc_sourcecategoryid lookup field in the Form
#    When I press Save in the form
#    Then the Entity should be saved
#    And I have clicked Connect command in View
#    When I have set 123 to record2id lookup field in the Form
#    And I have set Alumni to record2roleid lookup field in the Form
#    When I press Save in the form
#    Then the Entity should be saved
#    And I have navigated to the Area <Area> and SubArea <SubArea>
#    When I search <LastName> in the grid
#    And I open the first record in the grid
#    And I open the first record in the grid in CONNECTIONS LIST section
#    And I verify below fields
#    | Type  | sectionLabel | FieldName    | FieldValue |
#    | Field | General      | Name         | 123        |
#    | Field | General      | As this role | Alumni     |
#    And I have navigated to the Area <Area> and SubArea <SubArea>
#    When I search <LastName> in the grid
#    And I open the first record in the grid
#	And I have clicked All Connections SubGrid option on CONNECTIONS SubGrid
#       # And I have clicked All Connections command on Connections SubGrid
#       
#    Examples: 
#    | Test Case ID | Persona        | Area   | SubArea  | LastName    |
#    | 846742       | StudentAdvisor | Engage | Contacts | AbhiTest123 |
#
#@Dashboard
#Scenario: Navigate to MyCampusInsight Webresource
#    Given I have logged in as a <Persona>
#    Then I Select Occupation Insight dashboard
#    When I wait for 3000 specific time  
#    And I select <ReportName> report
#
# Examples:
#    | Test Case ID | Persona        | ReportName   |
#    |              | StudentAdvisor | Occupation Insight - Occupation Dashboard - National |

#

#Scenario: 01 Filter the Application Period based on the Program
#    Given I have logged in as a <Persona>
   # And I have navigated to the Area <Area> and SubArea <SubArea>
   # And I have clicked New command in View
   # And I have set AbhiTest123 to cmc_applicationdefinitionversionname text field in the Form
   # And I have set DemoApplicationType to cmc_applicationtype lookup field in the Form
   # And I have set 102{{cmc_applicationdefinitionname}} to cmc_applicationdefinitionid lookup field in the Form
   # And I have set Undergraduate Admissions to cmc_lifecycletype optionset field in the Form
   # When I press Save in the form
   # Then the Entity should be saved
   # And I select the sub tab Application Definition Version Details of tab Related in the form
   # When I wait for 3000 specific time
   # And I have clicked New Application Definition Version Detail command in View
   # When I wait for 3000 specific time
   # And I have set Spring2021 to cmc_applicationperiod lookup field in the Form
   # When I wait for 3000 specific time
   # #provide the dates only in MM/dd/yyyy format
   ## When I have set 04/20/2020 to cmc_startdate datetime field in the Form
   # When I wait for 3000 specific time
   ## When I have set 04/22/2020 to cmc_enddate datetime field in the Form
   # When I press Save in the form
   # Then the Entity should be saved
 
  #And I have navigated to the Area <Area> and SubArea <SubArea>
  #  When I search AbhiTest123 in the grid
  #  And I open the first record in the grid
  #  And I select the sub tab Application Definition Version Details of tab Related in the form
  #  When I wait for 3000 specific time
  #  And I have clicked New Application Definition Version Detail command in View
  #  When I wait for 3000 specific time
  #  And I have set Spring2022 to cmc_applicationperiod lookup field in the Form
  #  When I wait for 3000 specific time
  #  #provide the dates only in MM/dd/yyyy format
  # # When I have set 05/20/2020 to cmc_startdate datetime field in the Form
  #  When I wait for 3000 specific time
  ##  When I have set 06/22/2020 to cmc_enddate datetime field in the Form
  #  When I press Save in the form
  #  Then the Entity should be saved
 #   Given I have navigated to the Area <NewArea> and SubArea <NewSubArea>
 #   And I have clicked New command in View
 #   And I have set ADV12 to cmc_applicationdefinitionversionid lookup field in the Form
 #   And I have set BalaAPI126 lastname239 to cmc_contactid lookup field in the Form
 #   And I have set Started to cmc_applicationstatus optionset field in the Form
 #   When I press Save in the form
 #   Then the Entity should be saved
	#When I wait for 2000 specific time
 #   When I have clicked New Application command on APPLICATIONS SubGrid
	#When I wait for 3000 specific time
 #   And I have set **86709** to cmc_programid lookup field in the Form
 #   And I have set 311AT-Fall2018 278 to cmc_applicationperiodid lookup field in the Form
 #   When I press Save in the form
 #   Then the Entity should be saved
 #   When I wait for 2000 specific time
	#And I clear existing values in cmc_programid lookup field
	#When I wait for 2000 specific time
	#When The lookup cmc_applicationperiodid field value should be equal to <AcademicPeriod>
 #   Given I have navigated to the Area <Area> and SubArea <SubArea>
 #   And I search AbhiTest123 in the grid
 #   And I open the first record in the grid
 #   And I select the sub tab Application Definition Version Details of tab Related in the form
 #   And I open the first record in the grid
 #   #And I have clicked {subGridOption} SubGrid option on Application Period Programs SubGrid
 #   And I have clicked Animation - Master command on Application Period Programs SubGrid
 #   And I have clicked Deactivate command in View

    #Examples: 
    #| Test Case ID | Persona        | Area           | SubArea                         | NewArea | NewSubArea                | AcademicPeriod     |
    #| 899056       | StudentAdvisor | Process Config | Application Definition Versions | Engage  | Application Registrations | 311AT-Fall2018 278 |

#	@VerifyMostRecentPreviousEducation
#Scenario: 05 Ability to determine and maintain one Most recent previous Education record
#    Given I have logged in as a <Persona>
#    And I have navigated to the Area <Area> and SubArea <SubArea>
#	And I search AbhiTestDemo2 in the grid
#	And I open the first record in the grid
#	When I wait for 2000 specific time
#    #And I have clicked New command in View
    #When I select Contact(Engage) Form
    #Then I click Discard Changes in Confirmation dialog
    #When I have set <LastName> to lastname text field in the Form
    #Then I select Student options in mshied_contacttype_i multivalue optionset by removing existing selections
    #When I have set Appointment to cmc_sourcemethodid lookup field in the Form
    #And I have set Application to cmc_sourcecategoryid lookup field in the Form
    #When I press Save in the form
    #Then the Entity should be saved
 #   Given I select the tab Student Records in the form
 #   When I have clicked More Commands command on PREVIOUS EDUCATION SubGrid
 #   And I have clicked New Previous Education SubGrid option on More Commands SubGrid
 #   And I wait for 3000 specific time
	##And I have set 50 to mshied_classsize text field in the QuickCreate
	#And I have set 50 to mshied_classsize text field in the Form
	#And I wait for 1000 specific time
	#And I have set Fabrikam, Inc to mshied_schoolnameid field in the lookup dialog
	##Given I click new button for mshied_schoolnameid lookup field
	#When I wait for 1000 specific time
 #   #And I have set (.*) to (.*) field in the lookup SearchBox
 #   When I have set ​Fabrikam, Inc to mshied_schoolnameid lookup item in the Form
	#And I wait for 1000 specific time
 #   And I have set Associate of Arts to mshied_educationlevelid lookup field in the Form
 #   And I have set 01/24/2012 to mshied_dateofenrollment datetime field in the Form
 #   When I press Save in QuickCreate
 #   Then the QuickCreate should be saved
 #  
 #   Examples:
 #   | Test Case ID | Persona        | Area   | SubArea  | LastName       |
 #   | 1024950      | StudentAdvisor | Engage | Contacts | AbhiTestDemo2 |
#Scenario: 12 Try selecting command in App def 
#	Given I have logged in as a <Persona>
#	And I have navigated to the Area Process Config and SubArea Application Definition Versions
#	And I open the first record in the grid
#	When I wait for 5000 specific time
#	And I select the sub tab Application Definition Version Details of tab Related in the form
#	When I wait for 7000 specific time
#	And I have clicked New Application Definition Version Detail command in View
#    When I wait for 2000 specific time
#	
#Examples: 
#| TestCase | Persona         | Area         | SubArea  | Window Name | ExpireDate | subGridName |subGridButton  | TestDate |
#| 803241   | ApplicationAdmin  | Process Config | Marketing Lists |ActivateMarketingList.html - Microsoft Dynamics 365      | 2020/1/26   | TEST SCORES  |New Test Score |03/12/2020 |
#

#Scenario: 07 Account : Form update design
#				Given I have logged in as a <Persona>
#				And I have navigated to the Area <Area> and SubArea <SubArea>
#				And I open the first record in the grid
#				Then I verify below fields
#				| Type  | sectionLabel             | FieldName          | FieldValue |
#				| Field | Account Information      | Account Name       |               |
#				| Field | Account Information      | Account Type       |               |
#				| Field | Account Information      | External Identifier|               |
#				| Field | Account Information      | Code               |               |
#				| Field | Account Information      | Website            |               |
#				| Field | Account Information      | SMS Number         |               |
#				| Field | Account Information      | Parent Account     |               |
#				| Field | Account Information      | Industry           |               |
#				| Field | Account Information      | # of Students      |               |
#				| Field | Account Information      | # of Contacts      |               |
#
#
#				| Field | Correspondence Details   | Main Phone             |               |
#				| Field | Correspondence Details   | Alternate Phone Number |               |
#				| Field | Correspondence Details   | Primary Email Address  |               |
#				| Field | Correspondence Details   | Alternate Email Address|               |
#				| Field | Correspondence Details   | Fax                    |               |
#				| Field | Correspondence Details   | Address 1: Street 1    |               |
#				| Field | Correspondence Details   | Address 1: Street 2    |               |
#				| Field | Correspondence Details   | Address 1: Street 3    |               |
#				| Field | Correspondence Details   | Address 1: City        |               |
#				| Field | Correspondence Details   | Address 1: State/Province |               |
#				| Field | Correspondence Details   | Address 1: ZIP/Postal Code|               |
#				| Field | Correspondence Details   | Address 1: Country/Region |               |
#
# 
#
#				| Field | Contact Prefrences       | Contact Method               |               |
#				| Field | Contact Prefrences       | Follow Email                 |               |
#				| Field | Contact Prefrences       | Phone                        |               |
#				| Field | Contact Prefrences       | Mail                         |               |
#				| Field | Contact Prefrences       | Bulk Email                   |               |
#				| Field | Contact Prefrences       | Email                        |               |
#				| Field | Contact Prefrences       | Fax                          |               |
#
# 
#
#				And I select the tab Account Details in the form
#				And I verify below fields
#				| Type  | sectionLabel                          | FieldName                | FieldValue  |
#				| Field | Account Description & Additional Info | Description              |               |
#				| Field | Account Description & Additional Info | Academic/Fiscal Year End |               |
#				| Field | Account Description & Additional Info       | DOM Status                   |               |
#        
#				#| Field | Addresses                                |                              |               |
#				#| Field | Child Accounts                           |                              |               |
#
#Examples:
#| Test Case ID | Persona        | Area   | SubArea  | subGridButtonName                            |
#| 849563       | StudentAdvisor | Engage | Accounts | Create a new activity, note, or custom item. |  

#Scenario: 01 Create a Trip
#	Given I have logged in as a <Persona>
#	And I have navigated to the Area Recruitment and SubArea <SubArea>
#   And I open the first record in the grid
#   When I wait for 2000 specific time
#   Then The cmc_engagetripid field value should be equal to TR-01010-X7V1
#  # Then The cmc_engagetripid GUID value should be equal to TR-01010-X7V1
#
##Then The TR-01010-X7V1 GUID value should be equal to existing
#
##Then The TR-01010-X7V1 GUID value should be equal to param
#	#When I have clicked New command in View
#	#And I have set <Tripname> to cmc_tripname text field uniquely in the Form
#	#And I have set <StartDate> to cmc_startdate text field in the Form
#	#And I have set <EndDate> to cmc_enddate text field in the Form
#	#Then I press Save in the form
#	#And the Entity should be saved
#	#And I validate <Message1> notification/s in the form
#	#And I validate <Message2> notification/s in the form
#Examples: 
#| Persona        | SubArea | Tripname | StartDate  | EndDate    | Message1                                        | Message2                                      |
#| AutomationUser | Trips   | Campus   | 03/03/2019 | 03/03/2020 | Trip Name : Required fields must be filled in. | End Date : Required fields must be filled in. |
#
#Scenario: 02 Try selecting form in Contacts Module 
#	Given I have logged in as a <Persona>
#	And I have navigated to the Area Engage and SubArea Contacts
#	And I have clicked New command in View
#	#And I search contact in the grid
#	#And I open the first record in the grid
#	#And I select the tab Contact Overview in the form
#	#Then I select Donor options in mshied_contacttype_i multivalue optionset by removing existing selections
#	When I wait for 3000 specific time
#	And I have set TestName to lastname text field uniquely in the Form
#	#And I have clicked Create a new activity, note, or custom item. command on SOCIAL PANE SubGrid
#    #And I select Email Activity flyout option in the Subgrid
#	#And I verify Email flyout option exists in the Subgrid
#	#And I have set fieldValue to nickname text field uniquely in the Form
#	And I select Recommender options in mshied_contacttype_i multivalue optionset
#	#Then I select Alumni options in mshied_contacttype_i multivalue optionset by removing existing selections
#	And I select Alumni options in mshied_contacttype_i multivalue optionset
#	And I wait for 4000 specific time
#	And I press Save in the form
#	Then the Entity should be saved
#
#Examples: 
#
#| Persona        | 
#| StudentAdvisor | 

#Scenario: 02 Try selecting form in Contacts Module 
#
#    Given I have logged in as a <Persona>
#	And I have navigated to the Area Engage and SubArea Enrollments
#	And I search SPContact144 CMI in the grid
#	And I open the first record in the grid
#	And I click cmc_contactid locked lookup field in CONTACT section
#	#And I click  
#	#I click cmc_contactid locked lookup field in CONTACT section
#	#Given I select the tab Contact Overview in the form
#	And I click Connection-GridList locked lookup field in CONNECTIONS LIST section
#	When I have set test to record2roleid lookup field in the Form
#	
#
#Examples: 
#
#| Persona        | 
#| AutomationUser | 

	
	#When I click cmc_programid locked lookup field SPContact114 CMI record in SUMMARY section
	#When I click locked field cmc_contactid in CONTACT section
    #And  I wait for 3000 specific time
	#And I search PRG in the grid	
	##Then I select <FormName> Form
	##	
 #   And I select the 0 specific record in the grid in {sectionLabel} section
	#And I have clicked Create a new activity, note, or custom item. command on SOCIAL PANE SubGrid
	#And I select Email Activity flyout option in the Subgrid
	#And I have clicked Insert Template command in View
	#And I have set email to emailtemplates_id field in the lookup dialog
	#And I click Select button in dialog
	#Then The subject field value should be equal to Kudo
	##And I have set test to emailtemplates_id lookup field in the Form
	##When I press Save in the form
	##Then the Entity should be saved



#Scenario: 03 Create Test Score
#Given I have logged in as a <Persona> 
#And I have navigated to the Area Reference Data and SubArea Course Section
#And I search contact in the grid
#And I open the first record in the grid
##And I have clicked New command in View
##And I have set <LastName> to lastname text field uniquely in the Form
##And I have set <Recommender> to mshied_contacttype optionset field in the Form
##When I press Save in the form
##Then the Entity should be saved
##Then I select Contact(Engage) Form
##When I wait for 3000 specific time
##And I select the sub tab Related - Sales of tab Events in the form
#When I wait for 3000 specific time
#And I select the sub tab Course Histories of tab Events in the form
##And I select the tab Related - Sales in the form
#When I wait for 3000 specific time
##And I select the tab Course Histories in the form
##When I wait for 3000 specific time
##I select the sub tab Course Histories of tab {tabName} in the form
##Given I select the tab Course Histories Related - Sales in the form
##Then I open the first record in the grid
##When I have clicked <subGridButton> command on <subGridName> SubGrid
##When I have clicked <subGridOption> SubGrid option on <SubGridName> SubGrid in TEST SCORES section
##Then I select SAT Form
##When I have set <TestDate> to mshied_testdate date field in the Form
#
#
#
#Examples: 
#| TestCase | Persona         | Area         | SubArea  | LastName | Recommender | subGridName |subGridButton  | TestDate |
#| 803241   | AutomationUser | Constituents | Contacts  | Test      | 494280012   | TEST SCORES  |New Test Score |03/12/2020 |
# 
# Scenario: 04 Try selecting command in Marketing List 
#	Given I have logged in as a <Persona>
#	And I have navigated to the Area <Area> and SubArea <SubArea>
#	#And I search DOMList522 in the grid
#	And I open the first record in the grid
#	When I wait for 2000 specific time
#	And I have clicked Manage Members command in View
#	
#Then I navigate to quick create Add using Advanced find 
#	When I wait for 4000 specific time
#	When I click Add row option in Rule Conditions section of Manage Members window	
#	And I wait for 2000 specific time
#	And I set First Name and Anil in row 1 of Manage Members window
#	And I wait for 2000 specific time
#	And I click Find button in dialog
#	And I wait for 2000 specific time
#	And I click Use Query button in dialog
#	And I wait for 2000 specific time
#	When I switch the view to Inactive Student Groups
#	And I select record no. 0 in the grid
#	#And I select the tab Linked Entities in the form
#	And I have clicked Activate command in View
#	#Then I click Deactivate button in dialog
#	Then I switch to <Window Name> window
#	When I wait for 2000 specific time
#	Then I switch to FullPageWebResource frame
#	When I wait for 2000 specific time
#	Then I have set day as 4 to activateListInput_dateview Kendo date field in dialog window
#	##And I have set 26 to activateListInput_dateview Kendo date field in dialog window
#	When I wait for 2000 specific time
#	Then I click Activate button in the window
#	When I wait for 3000 specific time
#	Then I switch back to main window
#	And I select record no.0 in the grid	
#	When I have clicked New DOM Master command on DOM Masters (Marketing List) SubGrid
#	And I have clicked Create a new activity, note, or custom item. command on SOCIAL PANE SubGrid
#	And I select Email Activity flyout option in the Subgrid
#	When I press Save in the form
#	Then the Entity should be saved
#	And I click Deactivate button in dialog
#
#Examples: 
#| TestCase | Persona         | Area         | SubArea  | Window Name | ExpireDate | subGridName |subGridButton  | TestDate |
#| 803241   | StudentAdvisor  | Process Config | Marketing Lists |ActivateMarketingList.html - Microsoft Dynamics 365      | 2020/1/26   | TEST SCORES  |New Test Score |03/12/2020 |
# 
# Scenario: 05 Try selecting form in Contacts Module 
#	Given I have logged in as a <Persona>
#	And I have navigated to the Area Constituents and SubArea Contacts
#	And I search contact in the grid
#	And I open the first record in the grid
#	And I select the tab Student Records in the form
#	When I have clicked More Commands command on ACADEMIC PROGRESS SubGrid
#    And I have clicked New Academic Period Detail SubGrid option on More Commands SubGrid
#	And I have set Academic to mshied_academicperiodid field in the lookup dialog
#	And I press Save in QuickCreate
#	Then the QuickCreate should be saved
#
#Examples: 
#
#| Persona        | FormName |
#| AutomationUser |Contact(Engage)|
#
# Scenario: 06 Enrollments module 
#	Given I have logged in as a <Persona>
#	And I have navigated to the Area Engage and SubArea Enrollments
#	#And I search contact in the grid
#	And I open the first record in the grid
#	Then I validate <Message> notification/s in the form
#	#And I select the tab Student Records in the form
#	#When I have clicked More Commands command on ACADEMIC PROGRESS SubGrid
# #   And I have clicked New Academic Period Detail SubGrid option on More Commands SubGrid
#	#And I have set Academic to mshied_academicperiodid field in the lookup dialog
#	#And I press Save in QuickCreate
#	#Then the QuickCreate should be saved
#
#
#Examples: 
#
#| Persona        | Message |
#| StudentAdvisor |Read-only: You don't have access to edit this record.|
#
#Scenario: 07 Associating Multiple Program to One Application Type
#        Given I have logged in as a <Persona>
#		And I have navigated to the Area Process Config and SubArea Application Types
#		And I open the first record in the grid
#		When I wait for 2000 specific time
#		And I have clicked Add Existing Program command in View
#		And I wait for 3000 specific time
#	And I have set prog in science to lookupDialogContainer field in the lookup SearchBox
#
#
#Examples: 
#
#| Persona        | Message |
#| AutomationUser |Read-only: You don't have access to edit this record.|
#
#Scenario: 08 Merge Duplicate Contact
#Given I have logged in as a <Persona>
# And I have navigated to the Area <Area> and SubArea <SubArea>
# And I switch the view to Active Contacts
#  And I search AAbhij in the grid
# And I select record no. 0 in the grid
# And I select record no. 1 in the grid
# And I have clicked Merge command in View
# When I wait for 3000 specific time
#Then I switch to InlineDialog_Iframe frame
# When I wait for 2000 specific time
#Then I click OK button in dialog
#When I wait for 2000 specific time
#And 

#When I wait for 2000 specific time
#
#
# Examples: 
#| Persona | Area         | SubArea  | searchTerm |
#| AutomationUser | Constituents | Contacts | AAbhij |
#

#Scenario: 10 Test Case 963215: UI- Adding query Condition record from the Grid in the Query
#Given I have logged in as a <Persona> 
# And I have navigated to the Area Process Config and SubArea (Preview)-Assignment Groups
#    And I search Test from UIAuto in the grid
#    And I open the first record in the grid
#    Then I select the tab Segment Criteria in the form
#    And I wait for 2000 specific time
#    And I have clicked Use Existing View button in Query section
#    And I have clicked  button in  section
#    When I wait for 2000 specific time
#    Given I have set Active Students view to Existing View Picker in Query section
#   # Given I have set Active Students view to Use Existing View Picker
#    And I press Save in the form
#    When I wait for 2000 specific time
#    Then the Entity should be saved
#    Then I have clicked Create/Edit Query button in Query section
#   Then I switch to Advanced Find - Microsoft Dynamics 365 window 
#    When I wait for 6000 specific time   
#    And I click HideDetails in Query group of advanced find ribbon
#      Then I switch to contentIFrame0 frame
#    And I select sub filter option as Contact from Fields option group in row 0
#    And I switch back to default frame
#    Given I click Save in the Advanced Find Window
#
#
# Examples: 
#| Persona | 
#| Advisor |

#Scenario: 11 Validate empty records appear under Application requirements
#        
#		Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#		And I search <Application> in the grid
#		And I open the first record in the grid
#		And I open the first record in the grid
#		And I select the tab Requirements in the form
#		And I open the first record in the grid
#	    When I have clicked <subGridButtonName> command on <subGridName> SubGrid
#		And I have set <RequirementName> to cmc_applicationrequirementname text field in the Form
#		And  I have set <RequirementType> to cmc_requirementtype optionset field in the Form
#	    When I press Save in the form 
#		Then the Entity should be saved
#	    Then I browse <FilePath> File in ATTACHMENTS section
#		And I click Add button in Note section	
#		#And  I close window pop-up
#	    When I have set test desc to cmc_description text field in the Form
#		And I press Save in the form 
#		Then the Entity should be saved
#		#And I click locked field cmc_applicationid in General section
#		Given I select the tab Requirements in the form
#		And I open the first record in the grid
#		Then I open specific record <RequirementName> from the grid
#
#Examples: 
#
#| Persona | Area           | SubArea                   | Application                    | subGridButtonName | subGridName  | RequirementName |RequirementType  | RecommendBy | FilePath|
#| AutomationUser | Process Config | Requirement Definitions   | Regression Requirement | New Requirement   | REQUIREMENTS | Test Upload Req | 175490001     | Mansa Bajaj |  C:\\Users\\Mansas\\File Uploads\\dummy word.docx|        
#
#Scenario: 12 Try selecting command in Marketing List 
#	Given I have logged in as a <Persona>
#	And I have navigated to the Area <Area> and SubArea <SubArea>
#	And I switch the view to Active Dynamic Student Groups
#	And I open the first record in the grid
#	And I have clicked Manage Members command in View
#    And I select the tab Linked Entities in the form
#	When I select the 0 specific record in the grid in successnetworkassignments section
#	And I wait for 3000 specific time
#	
#
#Examples: 
#| TestCase | Persona         | Area         | SubArea  | Window Name | ExpireDate | subGridName |subGridButton  | TestDate |
#| 803241   | AutomationUser  | Process Config | Marketing Lists |ActivateMarketingList.html - Microsoft Dynamics 365      | 2020/1/26   | TEST SCORES  |New Test Score |03/12/2020 |
#
#
#Scenario: 13 verify lookup field
#Given I have logged in as a <Persona> 
#And I have navigated to the Area Constituents and SubArea <subArea>
#When I have clicked New command in View
## And I have set <lastname> to lastname text field uniquely in the Form
#And I have set <lastname> to lastname text field in the Form
#Then I select <contacttype> options in mshied_contacttype_i multivalue optionset
#Given I have set <sourcemethod> to cmc_sourcemethodid lookup field in the Form
#And I have set <sourcecategory> to cmc_sourcecategoryid lookup field in the Form
#When I wait for 3000 specific time
#And I press Save in the form
#When I wait for 3000 specific time
#Given I select the tab <TabName> in the form  
#Then I have clicked More Commands command on <SubGridName> SubGrid
#And I have clicked New Inbound Interest SubGrid option on More Commands SubGrid
#Given I have set Web Chat  to cmc_sourcemethodid lookup field in the Form
# And I have set Internet to cmc_sourcecategoryid lookup field in the Form
#And I press Save in the form
#Then the Entity should be saved
#Given The lookup customerid field value should be equal to Orange
##Given The customerid lookup field value should be equal to Orange
#
#       
#          
#Examples: 
#| Persona  | subArea  | lifecycletype | campus              | sourcemethod | sourcecategory | contact   | lastname       | contacttype | TabName                      | SubGridName        | subGridButton |
#| AutomationUser  | Contacts | 175490001     | CampusNexus College | Web Chat     | Application    | TestCon01 | Orange      | Student     | Inbound Interest & Lifecycle | INBOUND INTERESTS  | New Lifecycle |


#   
#@Practice
#Scenario: Navigate to MyCampusInsight Webresource
#    Given I have logged in as a <Persona>
#	Then I navigate to the Area <Arearepro
#    Then I Select MyCampusInsight webresource from Resources group
#	When I wait for 2000 specific time
#   
#    Examples:
#    | Test Case ID | Persona        | Area   | 
#    |       | StudentAdvisor		| Training |
#
#@InboundInterest
#@Requirement
#Scenario: 01 Create Inbound Interest with Student Contact Type
#    Given I have logged in as a <Persona>
#   # And I have navigated to the Area <Area> and SubArea <SubArea>
#    #And I have clicked New command in View
#    #When I select Contact(Engage) Form
#    #Then I click Discard Changes in Confirmation dialog
#    #When I have set <LastName> to lastname text field uniquely in the Form
#    #Then I select Student options in mshied_contacttype_i multivalue optionset by removing existing selections
#    #When I have set <Method> to cmc_sourcemethodid lookup field in the Form
#    #And I have set <Category> to cmc_sourcecategoryid lookup field in the Form
#    #When I press Save in the form
#    #Then the Entity should be saved
#	Then I click Advanced Find global command
#	When I wait for 2000 specific time
#	Then I switch to contentIFrame0 frame
#	When I wait for 6000 specific time
#	And I select slctPrimaryEntity dropdown filter value as Contacts
#	When I wait for 2000 specific time
#	And I select sub filter option as Owner from Fields option group in row 0
#		And I wait for 3000 specific time
#	And I select sub filter option as Inbound Interests (Contact) from Related option group in row 0
#		#And I select filter option as Inbound Interests (Contact) for Select field
#	And I wait for 3000 specific time
#	And I select sub filter option as Owner from Fields option group in row 1
#	#And I click Results in Show group of advanced find ribbon
#	#And I wait for 2000 specific time
#	#And I verify {{name}}361416612 in advanced find results
#	And I wait for 2000 specific time
#	#And I select sub filter option as Engage Account ID from Fields option group
#	And I wait for 2000 specific time
#	#And I wait for 2000 specific time
#	#And I select filter option as Contains Data for Equals field
#	#
#	#And I enter 03/17/2020 in Choose Date field
#	#And I select advFindE dropdown filter value as Created On
# #   Given I select the tab Inbound Interest & Lifecycle in the form
# #   When I have clicked More Commands command on <subGridName> SubGrid
# #   And I have clicked <subGridOption> SubGrid option on <subGridButtonName> SubGrid
# #   And I open the first record in the grid in INBOUND INTERESTS section
# #   And I switch the view to INBOUND INTERESTS
# #   Then I open specific record <LastName> from the grid
#
#    Examples: 
#| Persona                   | Area         | SubArea  | LastName        | ContactType | Method      | Category    | subGridButtonName | subGridName       | subGridOption | Owner |
#| BusinessUnitAdministrator | Constituents | Contacts | TestLastNameNew | 494280011   | Appointment | Application | More Commands     | INBOUND INTERESTS | Refresh       |       |

#@Requirement
#Scenario: 01 Advanced Find
#
#Given I have logged in as a <ApplicationAdmin>
#        And I have navigated to the Area <Area> and SubArea <SubArea>
#        And I search <ApplicationName> in the grid
#        And I select record no. 0 in the grid
#        And I select record no. 1 in the grid
#        And I select record no. 2  in the grid
#        And I select record no. 3  in the grid
#        And I select record no. 4  in the grid
#        And I have clicked Create Decision command in View   
#        Then I switch to <WindowName> window 
#        And I switch to FullPageWebResource frame 
#        And I have set Admit to decisionStatusTemplates Kendo text field in dialog window
#        And I click Create button in the window  
#        And I switch back to main window
#        When I wait for 6000 specific time
#        And I open the first record in the grid
#        Then I click Advanced Find global command
#        When I wait for 6000 specific time
#        Then I switch to contentIFrame0 frame
#        When I wait for 6000 specific time
#        And I select slctPrimaryEntity dropdown filter value as Applications
#    When I wait for 2000 specific time
#    #And I select sub filter option as Application Name from Fields option group in row 0
#    And I wait for 3000 specific time
#    #And I select filter option as Contains Data for Equals field
#    And I enter <ApplicationName> in Enter Text field
#    And I select sub filter option as Decisions (Application) from Related option group in row 0
#    And I wait for 3000 specific time
#    And I select sub filter option as Decision Name from Fields option group in row 1
#    And I wait for 3000 specific time
#    And I select filter option as Contains Data for Equals field
#    And I wait for 3000 specific time
#    And I enter <ApplicationName> in Enter Text field
#    And I wait for 3000 specific time
#    And I click Results in Show group of advanced find ribbon
#    And I wait for 3000 specific time
#        
#Examples: 
#| TestCaseID | ApplicationAdmin | Area   | SubArea      | ApplicationName | WindowName                                   |
#| 1012496    | ApplicationAdmin | Engage | Applications | Contact-1012496 | CreateDecision.html - Microsoft Dynamics 365 |
#
#
#@Requirement
#Scenario: Success Plan
#
#Given I have logged in as a <Persona>
##And I have navigated to the Area Process Config and SubArea Success Plan Templates
##And I search <SuccessPlanTemplate> in the grid
##When I wait for 2000 specific time
##And I open the first record in the grid
##And I select the sub tab Success Plans of tab Related in the form
###And I select the tab Student Success Profile in the form
###And I have clicked New Success Plan command on Success Plan SubGrid
##And I have clicked New Success Plan command in View
##And I have set <Contact1> to cmc_assignedtoid lookup field in the Form
##And I have clicked Save & Close command in View
#And I have navigated to the Area Engage and SubArea Contacts
#And I search Contact1 in the grid
#When I wait for 2000 specific time
#And I open the first record in the grid
#And I wait for 2000 specific time
#And I select the tab Student Success Profile in the form
#And I click to_do_subgrid-GridList locked lookup field in TO DOs section
##And I open the first record in the grid in TO DOs section
#When I wait for 2000 specific time
#And I have clicked Deactivate command in View
#And I have set Complete to status_id optionset field in the Form
#When I wait for 2000 specific time
#
#
#Examples:
#| Test Case ID | Persona        | Contact1         | SuccessPlanTemplate       |
#| 723127       | StudentAdvisor | Contact-1-723127 | SuccessPlanTemplate723127 |
#
#
#@Requirement
#Scenario: Success Plan 3
#Given I have logged in as a <Persona>
#And I have navigated to the Area Process Config and SubArea Success Plan Templates
#And I have clicked New command in View
#When I have set <SuccessPlanTemplate3> to cmc_successplantemplatename text field uniquely in the Form
#When I press Save in the form
#Then the Entity should be saved
#When I wait for 3000 specific time
#And I have clicked More Commands command on Section SubGrid
#And I wait for 1000 specific time
#And I have clicked New Success Plan To Do Template SubGrid option on More Commands SubGrid
#And I wait for 2000 specific time
#And I have set <SuccessPlanToDo3> to cmc_successplantodotemplatename text field uniquely in the Form
#And I have set Calculated to cmc_duedatecalculationtype optionset field in the Form
#And I have set 0 to cmc_duedatenumberofdays text field in the Form
#And I have set Before to cmc_duedatedaysdirection optionset field in the Form
#And I have set Start of Academic Period to cmc_duedatecalculationfield optionset field in the Form
#When I press Save in the form
#And I have clicked Save & Close command in View
#And I have clicked Copy command in View
#And I switch to current window
#When I have set SuccessPlan to cmc_successplantemplatename text field uniquely in the Form
#
#Examples:
#| Test Case ID | Persona        | Contact1         | SuccessPlanTemplate       | Contact2         | SuccessPlanName    | ToDoName   | SuccessPlanTemplate2     | SuccessPlanToDo | SuccessPlanTemplate3     | SuccessPlanToDo |
#| 723127       | StudentAdvisor | Contact-1-723127 | SuccessPlanTemplate723127 | Contact-2-723127 | SuccessPlan-723127 | ToDo723127 | SuccessTemplate-2-723127 | SuccessToDo     | SuccessTemplate-3-723127 | SuccessToDo3    |
#
#Scenario: 06 Validate the functionality of "Lifecycle - Auto Update Connections" flow
#    Given I have logged in as a <StudentAdvisor>    
    #And I have navigated to the Area <Area> and SubArea <SubArea2>
    #And I have clicked New command in View
    #When I have set <AccountName> to name text field uniquely in the Form
    #And I have set Campus to mshied_accounttype optionset field in the Form
    #Then I press Save in the form
    #And I click Ignore And Save button in dialog only if available
    #And the Entity should be saved
    #And I have navigated to the Area <Area> and SubArea <SubArea>
    #And I have clicked New command in View
    #When I have set Contact C1 to lastname text field in the Form
    #Then I select Student options in mshied_contacttype_i multivalue optionset by removing existing selections
    #And I have set Email to cmc_sourcemethodid field in the lookup dialog
    #And I have set Application to cmc_sourcecategoryid field in the lookup dialog
    #Then I press Save in the form
    #And I click Ignore And Save button in dialog only if available
    #And the Entity should be saved
    #Then I select the tab Inbound Interest & Lifecycle in the form
    #And I have clicked New Lifecycle command on LIFECYCLES SubGrid
    #When I wait for 3000 specific time
    #And I have set Undergraduate Admissions to cmc_lifecycletype optionset field in the Form
    #And I have set <AccountName> to cmc_campusid lookup item in the Form
    #Then I press Save in the form
    #And the Entity should be saved
    #And I click cmc_contactid locked lookup field in contact_section section
    #Summary, CONTACT, contact_section
    #And I have navigated to the Area <Area> and SubArea <SubArea>
    #When I search Contact C1 in the grid
    #And I open the first record in the grid
    #And I wait for 3000 specific time
    #And I scroll in to view of INITIAL SOURCE section
    #And I have clicked More Commands command on CONNECTIONS LIST SubGrid
    #When I wait for 2000 specific time
    #And I have clicked See associated records SubGrid option on More Commands SubGrid
    ##And I have clicked Export Connections SubGrid option on More Commands SubGrid
    ##And I select See associated records flyout option in the Subgrid
    #When I wait for 2000 specific time
    #And I open the first record in the grid

#Examples:
#| Test Case ID | StudentAdvisor | Area   | SubArea  | SubArea2 | AccountName |
#| 977759       | StudentAdvisor | Engage | Contacts | Accounts | Account A1  |

#Scenario: 07 Base Entity
#    Given I have logged in as a <StudentAdvisor>    
#    And I have navigated to the Area <Area> and SubArea <SubArea>
#  And I have clicked New command in View
#  And I have set Account Entity to cmc_baseentity Entity Picker in the Form
#  And I have set Owner Entity to cmc_assigntofield Entity Picker in the Form
#  When I wait for 2000 specific time
#
#Examples:
#| StudentAdvisor | Area           | SubArea          | SubArea2 | AccountName |
#| StudentAdvisor | Process Config | Assignment Groups| Accounts | Account A1  |

#   Scenario: 03 New Campus Survey View
#   
#    Given I have logged in as a <Faculty>
#   # Creating new course section
#    And I have navigated to the Area <Area1> and SubArea <SubArea3>
#    And I search test in the grid
#    And I open the first record in the grid
#    #And I open record no. 2 in the grid
#    #And I have clicked New command in View
#    #When I have set <Instructor> to cmc_staffid lookup item in the Form
#    #And I wait for 1000 specific time
#    #And I have set <CourseName> to mshied_courseid lookup item in the Form
#    #And I have set <AcademicPeriodName> to mshied_academicperiodid lookup item in the Form
#    #When I press Save in the form
#    #Then the Entity should be saved
#    And I select the tab Course Instructors in the form
#    When I wait for 3000 specific time
#  # And  I click New Course Instructor css command on Course Instructors SubGrid
#   And I click New Course Instructor command in Course Instructors SubGrid Division
#   # When I have clicked New Course Instructor command on Course Instructors SubGrid
#   # And I click New Course Instructor button on Section SubGrid only if available
#   And I wait for 3000 specific time
# Examples:
#| Test Case ID | Faculty | Area1          | SubArea1 | SubArea2         | SubArea3       | CourseName  | Code | AcademicPeriodName | Instructor        | Area    | SubArea       | FormName             | SurveyName    | StartDate | EndDate   | CourseSection                   | TemplateName            | DesignerForm           |
#| 766162       | Faculty | Reference Data | Courses  | Academic Periods | Course Section | Mathematics | 0123 | Summer 2021        | engage automation | Surveys | Campus Survey | Information(Succeed) | YashiTemplate | 5/31/2020 | 7/30/2020 | engage automation - Mathematics | Talisma Campus Survey02 | Feedback Form(Succeed) |
#
#  Scenario: 04 New lifecycle 
#   
#    Given I have logged in as a <Faculty>
#    #Creating new course section
#    And I have navigated to the Area Engage and SubArea Lifecycles
#    And I search 391 in the grid
#    And I open the first record in the grid
#    #And I open record no. 2 in the grid
#    #And I have clicked New command in View
#    #When I have se <Instructor> to cmc_staffid lookup item in the Form
#    #And I wait for 1000 specific time
#    #And I have set <CourseName> to mshied_courseid lookup item in the Form
#    #And I have set <AcademicPeriodName> to mshied_academicperiodid lookup item in the Form
#    #When I press Save in the form
#    #Then the Entity should be saved
#    And I select the tab Inbound Interest in the form
#    When I wait for 3000 specific time
#   # When I have clicked New Inbound Interest command on Inbound Interest SubGrid
#       And I click New Inbound Interest command in Inbound Interest SubGrid Division
#   # And I click New Course Instructor button on Section SubGrid only if available
#    And I wait for 3000 specific time
# Examples:
#| Test Case ID | Faculty | Area1          | SubArea1 | SubArea2         | SubArea3       | CourseName  | Code | AcademicPeriodName | Instructor        | Area    | SubArea       | FormName             | SurveyName    | StartDate | EndDate   | CourseSection                   | TemplateName            | DesignerForm           |
#| 766162       | Faculty | Reference Data | Courses  | Academic Periods | Course Section | Mathematics | 0123 | Summer 2021        | engage automation | Surveys | Campus Survey | Information(Succeed) | YashiTemplate | 5/31/2020 | 7/30/2020 | engage automation - Mathematics | Talisma Campus Survey02 | Feedback Form(Succeed) |
#

#@CampusSurvey
#Scenario: 01 Create Campus Survey template including questions
#                Given I have logged in as a <BusinessUnitAdministrator> 
#                And I have navigated to the Area <Area> and SubArea <SubArea>
#                Given I search test in the grid
#                And I open the first record in the grid
#                Then I select Designer(Succeed) Form
#                When I wait for 2000 specific time
#                Given I select Text Field question and provide Textvalue to question field and provide  to option field in the form
#                When I wait for 4000 specific time
#                Then I click on Add Question Button in the questions section in the form
#                Given I select Check Box question and provide CheckBoxvalue to question field and provide CheckBoxOptionValue to option field in the form
#              Then I switch back to default frame
#                When I press Save in the form
#                Then the Entity should be saved
#
#         
#Examples: 
#| Test Case ID | BusinessUnitAdministrator | Area    | SubArea                | FormName                        | TemplateName  | StartDate  | DueDate    | dueDatelessThanstartdate | Message1                                                  |
#| 757900       | BusinessUnitAdministrator | Surveys | Campus Survey Template | Campus Survey Template(Succeed) | YashiTemplate | 05/31/2020 | 06/10/2020 | 05/29/2020               | Due Date Static : Due Date cannot be less than Start Date |
#
#
#
