@Contactfeature
Feature: Contact

@Contact
Scenario: 01 Contact Form Verification
                Given I have logged in as a <Persona>
				And I navigate to main Area and SubArea <SubArea>
                And I switch the view to Active Contacts
				And I wait for 2000 specific time
                And I search UIAuto Contact-844969 in the grid
                And I open the first record in the grid
				And I wait for 2000 specific time
                And I select the tab Key Information in the form
				Then I click activity button Phone Call in INTERACTION OVERVIEW Timeline Section 
				And I switch back to default frame
				And I click Internal connections button in Connections section
                When I have set Mr to cmc_title optionset field in the Form
                And I have clicked More commands command on HOLD ASSIGNMENTS SubGrid
                And I verify in INITIAL SOURCE section Locked Originating Inbound Interest field is locked
                And I have clicked More Commands command on CONNECTIONS LIST SubGrid

                Given I select the tab Contact Overview in the form
                When I have set American to mshied_nationality optionset field in the Form
                And I have set Male to gendercode optionset field in the Form
				And I scroll in to view of CONTACT PREFERENCES section
                And I have set Any to preferredcontactmethodcode optionset field in the Form
                And I have clicked More Commands command on PRIVATE NOTES SubGrid
                And I have set test to nickname text field in the Form
                And I have clicked More Commands command on ADDRESS SubGrid

	Given I select the tab Inbound Interest & Lifecycle in the form
	When I verify in MARKETING section Locked Source email field is locked
	And I have clicked More Commands command on INBOUND INTERESTS SubGrid
	And I have clicked More Commands command on LIFECYCLES SubGrid
	And I wait for 2000 specific time
	Given I select the tab Student Records in the form
	When I wait for 2000 specific time
	#When I have set 20 to cmc_recentact text field in the Form
	And I have clicked More Commands command on TEST SCORES SubGrid
	And I verify in STUDENT LOGIN section Locked External Identifier field is locked
	And I have clicked More Commands command on AREA OF INTEREST SubGrid	
	And I have clicked More Commands command on EXTRA CURRICULAR PARTICIPANTS SubGrid
	And I have clicked More Commands command on PREVIOUS EDUCATION SubGrid
	And I scroll in to view of SCORES section
	And I verify in SCORES section Locked ACT Superscore field is locked
	And I scroll in to view of PREVIOUS EDUCATION section	
	Given I select the tab Student Progress in the form
	When I wait for 2000 specific time
	When I have clicked More Commands command on ENROLLMENT SubGrid
	And I have clicked More Commands command on SUCCESS NETWORK SubGrid
	And I have clicked More Commands command on ACADEMIC PROGRESS SubGrid
	And I have clicked More Commands command on CLASS SCHEDULE SubGrid
	Then I select Contact (Reach) Form
	
	Given I select the tab Student Success Profile in the form
	When I wait for 2000 specific time
	When I have clicked More Commands command on SUCCESS PLANS SubGrid
	And I have clicked More Commands command on TO DOs SubGrid
	And I have clicked More Commands command on POSITIVE ACKNOWLEDGEMENTS SubGrid
	And I have clicked More Commands command on FEEDBACK SubGrid
	Then I select Contact (Reach) Form
		
	Given I select the tab Events in the form
	When I wait for 2000 specific time
	When I have clicked More Commands command on REGISTERED EVENTS SubGrid
	And I have clicked More Commands command on REGISTERED SESSIONS SubGrid
	And I have clicked More Commands command on CHECKED-IN EVENTS SubGrid
	And I have clicked More Commands command on CHECKED-IN SESSIONS SubGrid

Examples: 
| Test Case ID | Persona        | Area         | SubArea  |
| 844969       | StudentAdvisor | Constituents | Contacts |

@Contact
Scenario: 02 Validate 'Contact Type' field 
	Given I have logged in as a <Persona>	
	And I navigate to main Area and SubArea <SubArea>
	And I wait for 2000 specific time
	And I have clicked New command in View
	And I have set <LastName> to lastname text field uniquely in the Form
	Then I press Save in the form
	And I click Ignore And Save button in dialog only if available
	And I wait for 1000 specific time
	And I scroll in to view of INITIAL SOURCE section
	And I wait for 1000 specific time
	Then I select <ContactType> options in mshied_contacttype_i multivalue optionset
	And I select <ContactType1> options in mshied_contacttype_i multivalue optionset 
	And I select <ContactType2> options in mshied_contacttype_i multivalue optionset 
	And I select <ContactType3> options in mshied_contacttype_i multivalue optionset 
	And I select <ContactType4> options in mshied_contacttype_i multivalue optionset 
	And I select <ContactType5> options in mshied_contacttype_i multivalue optionset 
	And I select <ContactType6> options in mshied_contacttype_i multivalue optionset
	When I wait for 2000 specific time
	Then I press Save in the form
	And the Entity should be saved
	When I wait for 3000 specific time
	And I scrolldown to End of INITIAL SOURCE section
	When I verify in INITIAL SOURCE section Locked Method field is locked
	And I verify in INITIAL SOURCE section Locked Category field is locked
	And I scroll in to view of INITIAL SOURCE section
	And I have set ALS to parentcustomerid lookup item in the Form
	Then I select Student options in mshied_contacttype_i multivalue optionset by removing existing selections
	And I press Save in the form
	And the Entity should be saved
	When I wait for 3000 specific time
	And I scrolldown to End of INITIAL SOURCE section
	When I verify in INITIAL SOURCE section Locked Method field is locked
	And I verify in INITIAL SOURCE section Locked Category field is locked
	And I select the tab Inbound Interest & Lifecycle in the form
	When I wait for 1000 specific time
	When I click available command New Inbound Interest on INBOUND INTERESTS SubGrid
	And I click New Inbound Interest SubGrid option on More Commands SubGrid when available
	
	When I wait for 10000 specific time
	#And I have clicked New Inbound Interest command on INBOUND INTERESTS SubGrid
	And I scrolldown to End of SOURCE section
	And I have set <Method> to cmc_sourcemethodid lookup item in the Form
	When I wait for 2000 specific time
	#And I scrolldown to End of SOURCE section
	#And I scroll to SOURCE section having Category field
	When I wait for 2000 specific time
	And I have set <Category> to cmc_sourcecategoryid lookup item in the Form
	When I wait for 2000 specific time
	Then I press Save in the form
	And the Entity should be saved
	When I wait for 3000 specific time
	And I verify below fields
	| Type  | sectionLabel | FieldName | FieldValue |
	| Field | GENERAL      | Primary   | true       |
	Then I click customerid locked lookup field in GENERAL section
	
	Then I switch to browser tab 2 if available

	Given I select the tab Inbound Interest & Lifecycle in the form
	When I click available command New Inbound Interest on INBOUND INTERESTS SubGrid
	And I click New Inbound Interest SubGrid option on More Commands SubGrid when available
	When I wait for 2000 specific time
	#And I scrolldown to End of SOURCE section
	
	And I scroll to SOURCE section having Method field
	And I have set <Method> to cmc_sourcemethodid lookup item in the Form
	When I wait for 2000 specific time
		
	And I scroll to SOURCE section having Category field
	And I have set <Category> to cmc_sourcecategoryid lookup item in the Form
		When I wait for 2000 specific time
	Then I press Save in the form
	And the Entity should be saved
	

Examples: 
| Test Case ID | Persona        | Area   | SubArea  | LastName | ContactType | ContactType1    | ContactType2                       | ContactType3 | ContactType4              | ContactType5     | ContactType6      | Method | Category    |
| 887114       | StudentAdvisor | Engage | Contacts | TestLast | HS Contact  | College Contact | Employer Contact(Inter/externship) | Parent       | Education Partner Contact | Referral Contact | Emergency Contact | Email  | Application |

@testcase03contact
Scenario: 03 Create connection and validate Connections Grid
    Given I have logged in as a <Persona>
    And I have navigated to the Area Engage and SubArea Contacts
	And I navigate to main Area and SubArea Contacts
	And I switch the view to Active Students
    And I search UIAuto Contact-846742-1 in the grid
    And I open the first record in the grid
    When I wait for 2000 specific time
	And I scroll in to view of CONNECTIONS LIST section
	 When I wait for 2000 specific time
	And I open Connection-GridList list item in CONNECTIONS LIST section only if available
    And I click first record in the grid in CONNECTIONS LIST section only if available 
	#And I click Connection-GridList locked lookup field in CONNECTIONS LIST section
    #And I open the first record in the grid in CONNECTIONS LIST section
    When I wait for 4000 specific time
    And I verify below fields
    | Type  | sectionLabel | FieldName    | FieldValue       |
    | Field | Connect To      | Name         |                  |
    | Field | Connect To      | As this role |                  |
    | Field | Description      | Description  |                  |
   When I wait for 2000 specific time
  Given I select the tab Details in the form
    When I wait for 1000 specific time
    And I verify below fields
    | Type  | sectionLabel | FieldName      | FieldValue |
    | Field | Connected From      | Connected from | AbhiTestD  |
    | Field | Connected From      | As this role   |            |
    And I navigate to main Area and SubArea Contacts
	And I switch the view to Active Students
    And I search UIAuto Contact-846742-1 in the grid
    And I open the first record in the grid
    And I have clicked New command in View
    When I have set <LastName> to lastname text field uniquely in the Form
	 And I scroll in to view of INITIAL SOURCE section
	 And I wait for 2000 specific time
    Then I select Student options in mshied_contacttype_i multivalue optionset by removing existing selections
 And I scrolldown to End of INITIAL SOURCE section
   When I have set Appointment to cmc_sourcemethodid lookup item in the Form
    And I wait for 2000 specific time
    And I have set Application to cmc_sourcecategoryid lookup item in the Form
    And I wait for 2000 specific time
    When I press Save in the form
    Then the Entity should be saved
    When I wait for 8000 specific time
    And I have clicked Connect command in View
	Then I switch to browser tab 2 if available
    When I have set UIAuto Contact-846742-2 to record2id lookup item in the Form
    When I wait for 2000 specific time
    And I have set Alumni to record2roleid lookup item in the Form
    When I wait for 2000 specific time
    When I press Save in the form
    Then the Entity should be saved

    And I navigate to main Area and SubArea Contacts
			Then I switch to browser tab 3 if available

	When I wait for 2000 specific time

	And I switch the view to Active Students
    When I search <LastName> in the grid
    And I open the first record in the grid
And I scroll in to view of CONNECTIONS LIST section
When I wait for 2000 specific time
And I open Connection-GridList list item in CONNECTIONS LIST section only if available
    And I click first record in the grid in CONNECTIONS LIST section only if available 
#And I click Connection-GridList locked lookup field in CONNECTIONS LIST section
When I wait for 4000 specific time
   # And I open the first record in the grid in CONNECTIONS LIST section
    And I verify below fields
    | Type  | sectionLabel | FieldName    | FieldValue              |
    | Field | Connect To      | Name         | UIAuto Contact-846742-2 |
    | Field | Connect To      | As this role | Alumni                  |
    #And I have navigated to the Area Engage and SubArea Contacts
    #When I search <LastName> in the grid
    #And I open the first record in the grid
    #And I have clicked All Connections SubGrid option on CONNECTIONS SubGrid
       # And I have clicked All Connections command on Connections SubGrid
       
    Examples: 
    | Test Case ID | Persona        |  LastName    |
    | 846742       | StudentAdvisor |  Contact-1-846742 |

Scenario: 04 Validate Contact Plugins
                Given I have logged in as a <Persona>
               And I navigate to main Area and SubArea Contacts
				And I switch the view to Active Students
                And I search UIAuto Contact-724258 in the grid
				When I wait for 4000 specific time
                And I open the first record in the grid
                And I verify below fields
                | Type  | sectionLabel		| FieldName    | FieldValue |
                | Field | CONTACT SUMMARY    | Contact Type | Student    |
                And I select the tab Student Progress in the form
				When I wait for 2000 specific time
				And I scroll in to view of SUCCESS NETWORK section
				And I open GridList list item in SUCCESS NETWORK section only if available
				 When I wait for 2000 specific time
               And I click first record in the grid in SUCCESS NETWORK section only if available 
               # And I click GridList locked lookup field in SUCCESS NETWORK section
                #And I open the first record in the grid in SUCCESS NETWORK section
                When I wait for 4000 specific time
                And I navigate to main Area and SubArea Contacts
				And I switch the view to Active Students
                And I search UIAuto Contact-724258 in the grid
				When I wait for 4000 specific time
                And I open the first record in the grid
				 And I scroll in to view of INITIAL SOURCE section
                Then I select Parent options in mshied_contacttype_i multivalue optionset by removing existing selections
                When I press Save in the form
                Then the Entity should be saved
				And  I wait for 3000 specific time
                And I click Ignore And Save button in dialog only if available
                And I select the tab Student Progress in the form
    And I click GridList locked lookup field in SUCCESS NETWORK section
                When I wait for 4000 specific time

                Examples: 
                | Test Case ID | Persona        | 
                | 724258       | StudentAdvisor | 


         

@mytag
@Regression
@pre-requisite
# Two contact should exist in Engage having association with Application Registraion and Application

Scenario: 05 Validation of merging contact when an application exist. Both contact created in Engage


 Given I have logged in as a <Persona>
 And I navigate to main Area and SubArea Contacts
 And I switch the view to Active Contacts
  And I search <searchTerm> in the grid
   When I wait for 2000 specific time

 Then I select record no. 0 in the grid
 Then I select record no. 1 in the grid
 When I wait for 2000 specific time
 And I have clicked Merge command in View
 When I wait for 7000 specific time 
Then I click OK button in dialog
And I wait for 5000 specific time

 Examples: 
| Test Case ID | Persona |searchTerm |
| 1046961      | Advisor |Contact-record-1046961|



	
@VerifyMostRecentPreviousEducation
#need to on the flow:- Contact - Set Most Recent Previous Education

Scenario:06 Ability to determine and maintain one Most recent previous Education record
	Given I have logged in as a <Persona>
	And I navigate to main Area and SubArea Contacts
	When I switch the view to All Contacts(Reach)
	And I wait for 2000 specific time
	And I search UIAuto Contact-1024950 in the grid
	And I open the first record in the grid
	And I wait for 3000 specific time
	Given I select the tab Student Records in the form
	When I wait for 2000 specific time
	And I click New Previous Education command on PREVIOUS EDUCATION SubGrid when available
	And I click More Commands button on PREVIOUS EDUCATION SubGrid only if available
	And I click New Previous Education SubGrid option on More Commands SubGrid when available
	#When I have clicked More Commands command on PREVIOUS EDUCATION SubGrid
	#And I have clicked New Previous Education SubGrid option on More Commands SubGrid
	And I wait for 3000 specific time
	And I have set Account-1024950 to mshied_schoolnameid field in the lookup dialog
		And I wait for 3000 specific time

	And I have set UIAuto-EduLevel-1024950-1 to mshied_educationlevelid field in the lookup dialog
	And I wait for 2000 specific time
	#And I have set 01/24/2012 to mshied_dateofenrollment date field in the Form
	When I have set date value 07/09/2012 to Date of Enrollment field in the Form
	And I have set 07/09/2012 to Date of Enrollment datetime field in the Form
		When I press Save in QuickCreate
	Then the QuickCreate should be saved
	When I wait for 2000 specific time
    And I click New Previous Education command on PREVIOUS EDUCATION SubGrid when available
	And I click More Commands button on PREVIOUS EDUCATION SubGrid only if available
	And I click New Previous Education SubGrid option on More Commands SubGrid when available
	#When I have clicked More Commands command on PREVIOUS EDUCATION SubGrid
	#And I have clicked New Previous Education SubGrid option on More Commands SubGrid
	And I wait for 3000 specific time
	And I have set Account-1024950 to mshied_schoolnameid field in the lookup dialog
	And I have set UIAuto-EduLevel-1024950-2 to mshied_educationlevelid field in the lookup dialog
	When I have set date value 04/12/2013 to Date of Enrollment field in the Form
	When I press Save in QuickCreate
	Then the QuickCreate should be saved
	
	When I wait for 2000 specific time
	And I click New Previous Education command on PREVIOUS EDUCATION SubGrid when available
	And I click More Commands button on PREVIOUS EDUCATION SubGrid only if available
	And I click New Previous Education SubGrid option on More Commands SubGrid when available
	#When I have clicked More Commands command on PREVIOUS EDUCATION SubGrid
	#And I have clicked New Previous Education SubGrid option on More Commands SubGrid
	And I wait for 3000 specific time
	And I have set Account-1024950 to mshied_schoolnameid field in the lookup dialog
	And I have set UIAuto-EduLevel-1024950-3 to mshied_educationlevelid field in the lookup dialog
	When I have set date value 04/12/2014 to Date of Enrollment field in the Form
	When I press Save in QuickCreate
	Then the QuickCreate should be saved
	
	When I wait for 2000 specific time
	And I click New Previous Education command on PREVIOUS EDUCATION SubGrid when available
	And I click More Commands button on PREVIOUS EDUCATION SubGrid only if available
	And I click New Previous Education SubGrid option on More Commands SubGrid when available
	#When I have clicked More Commands command on PREVIOUS EDUCATION SubGrid
	#And I have clicked New Previous Education SubGrid option on More Commands SubGrid
	And I wait for 3000 specific time
	And I have set Account-1024950 to mshied_schoolnameid field in the lookup dialog
	And I have set UIAuto-EduLevel-1024950-4 to mshied_educationlevelid field in the lookup dialog
	When I have set date value 04/12/2020 to Date of Enrollment field in the Form
	When I press Save in QuickCreate
	Then the QuickCreate should be saved
	When I wait for 2000 specific time
	
	And I navigate to main Area and SubArea Contacts
	And I switch the view to Active Students	
	When I wait for 2000 specific time
	When I search UIAuto Contact-1024950 in the grid
	And I open the first record in the grid
	Given I select the tab Student Records in the form
	And I click cmc_mostrecentpreviouseducationid locked lookup field in SCHOOL DETAILS section
	When I wait for 2000 specific time
	And I verify below fields
	 | Type  | sectionLabel | FieldName          | FieldValue |
	 | Field | EDUCATION      | Date of Enrollment | 04/12/2020 |
	#Negative Scenario
	
	When I wait for 2000 specific time
	And I navigate to main Area and SubArea Contacts
	And I switch the view to Active Students
	And I wait for 2000 specific time
	When I search UIAuto Contact-1024950 in the grid
	And I open the first record in the grid
	Given I select the tab Student Records in the form
	And I wait for 2000 specific time
	And I open the first record in the grid in PREVIOUS EDUCATION section
	And I have clicked Deactivate command in View
	And I click Deactivate button in dialog
	And I wait for 2000 specific time
	And I navigate to main Area and SubArea Contacts
	And I switch the view to Active Students
	When I search <LastName> in the grid
	And I open the first record in the grid
	Given I select the tab Student Records in the form
	
	When I wait for 2000 specific time
	And I open the first record in the grid in PREVIOUS EDUCATION section
	And I have clicked Deactivate command in View
	And I click Deactivate button in dialog

	When I wait for 2000 specific time
	And I navigate to main Area and SubArea Contacts
	And I switch the view to Active Students
	When I wait for 2000 specific time
	When I search UIAuto Contact-1024950 in the grid
	And I open the first record in the grid
	Given I select the tab Student Records in the form
	And I click cmc_mostrecentpreviouseducationid locked lookup field in SCHOOL DETAILS section
	And I verify below fields
	 | Type  | sectionLabel | FieldName          | FieldValue |
	 | Field | EDUCATION      | Date of Enrollment | 04/12/2013 |

	#Update Scenario
	And I navigate to main Area and SubArea Contacts
	And I switch the view to Active Students
	When I wait for 2000 specific time
	When I search UIAuto Contact-1024950 in the grid
	When I wait for 2000 specific time
	And I open the first record in the grid
	When I wait for 2000 specific time
	Given I select the tab Student Records in the form
	When I wait for 2000 specific time
	And I click New Previous Education command on PREVIOUS EDUCATION SubGrid when available
	And I click More Commands button on PREVIOUS EDUCATION SubGrid only if available
	And I click New Previous Education SubGrid option on More Commands SubGrid when available
	#When I have clicked More Commands command on PREVIOUS EDUCATION SubGrid	
	#And I have clicked New Previous Education SubGrid option on More Commands SubGrid
	And I wait for 3000 specific time
	And I have set Account-1024950 to mshied_schoolnameid field in the lookup dialog
	And I have set UIAuto-EduLevel-1024950-5 to mshied_educationlevelid field in the lookup dialog
	When I have set date value 04/12/2020 to Date of Enrollment field in the Form
	#And I have set 04/12/2020 to mshied_dateofenrollment datetime field in the Form
	When I press Save in QuickCreate
	Then the QuickCreate should be saved
	And I wait for 2000 specific time	
	And I navigate to main Area and SubArea Contacts
	And I switch the view to Active Students
	When I wait for 2000 specific time
	When I search UIAuto Contact-1024950 in the grid
		And I wait for 2000 specific time	

	And I open the first record in the grid
	Given I select the tab Student Records in the form
	And I click cmc_mostrecentpreviouseducationid locked lookup field in SCHOOL DETAILS section
	And I verify below fields
	 | Type  | sectionLabel | FieldName          | FieldValue |
	 | Field | EDUCATION      | Date of Enrollment | 04/12/2020 |
	
	

	
	Examples: 
	| Test Case ID | Persona        | Area   | SubArea  | LastName               |
	| 1024950      | StudentAdvisor | Engage | Contacts | UIAuto Contact-1024950 |