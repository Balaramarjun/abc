Feature: SuccessPlan

@SuccessPlan
Scenario: 01 Check the SuccessPlan assignment through Web resource pop-up 
			
		Given I have logged in as a <StudentAdvisor> 

		##Create successplan Template
		And I have navigated to the Area Process Config and SubArea Success Plan Templates
		And I wait for 2000 specific time
        And I have clicked New command in View
		And I press Save in the form
		Then I validate <SPTNotification> notification/s in the form
		When I have set UIAutoSPT-737999 to cmc_successplantemplatename text field uniquely in the Form
		And I wait for 2000 specific time			
		And I press Save in the form
		And I wait for 1000 specific time
		Then the Entity should be saved

		##Create SuccessPlanTodo Template
		And I have navigated to the Area Process Config and SubArea Success Plan To Do Templates
		And I wait for 2000 specific time
		And I have clicked New command in View
		And I press Save in the form
		Then I validate <SPTDTNotification> notification/s in the form
		When I have set UIAutoSPTDT-737999-1a to cmc_successplantodotemplatename text field uniquely in the Form
		And I have set UIAutoSPT-737999 to cmc_successplantemplateid lookup item in the Form
		And I have set Static to cmc_duedatecalculationtype optionset field in the Form
		And I set future date time value to Due Date-Static field in the Form
		And I press Save in the form
		And I wait for 2000 specific time
		And I have navigated to the Area Process Config and SubArea Success Plan To Do Templates
		And I wait for 2000 specific time
		And I have clicked New command in View
		And I press Save in the form
		Then I validate <SPTDTNotification> notification/s in the form
		When I have set UIAutoSPTDT-737999-1b to cmc_successplantodotemplatename text field uniquely in the Form
		And I have set UIAutoSPT-737999 to cmc_successplantemplateid lookup item in the Form
		And I have set Calculated to cmc_duedatecalculationtype optionset field in the Form
		And I have set 3 to cmc_duedatenumberofdays text field in the Form
		And I have set Before to cmc_duedatedaysdirection optionset field in the Form
		And I have set Assignment Date to cmc_duedatecalculationfield optionset field in the Form
		And I wait for 2000 specific time
		And I press Save in the form
		And I wait for 2000 specific time

		##Assign successplan through web resource
		And I navigate to main Area and SubArea Contacts
		And I wait for 2000 specific time
		And The handle live assist pop-up only if available
		And I search UIAuto Contact-737999 in the grid
		And I wait for 4000 specific time	
		And I select record no. 0 in the grid
		And I wait for 4000 specific time
		And I have clicked Assign Success Plan command in View
		And I wait for 2000 specific time
		Then I switch to FullPageWebResource frame
	    And I wait for 2000 specific time
		Then I set UIAutoSPT-737999 to successPlanTemplates field in dialog dialog
	    And I wait for 2000 specific time
	    And I click Cancel button in the window
		And I wait for 4000 specific time
		Then I switch back to default frame
		And I have clicked Assign Success Plan command in View
		And I wait for 2000 specific time
		Then I switch to FullPageWebResource frame
	    And I wait for 2000 specific time
		And I set UIAutoSPT-737999 to successPlanTemplates field in dialog dialog
	    And I wait for 2000 specific time
	    And I click Assign button in the window
		And I wait for 2000 specific time
	    And I switch back to default frame
	    And I switch to active element
	    And I handle dialog with button okButton
	    And I wait for 3000 specific time

		# Assign successplan template again to same contact record
		And I wait for 4000 specific time
		And I have clicked Assign Success Plan command in View
		And I wait for 2000 specific time
		Then I switch to FullPageWebResource frame
	    And I wait for 2000 specific time
		And I set UIAutoSPT-737999 to successPlanTemplates field in dialog dialog
	    And I wait for 2000 specific time
	    And I click Assign button in the window
		And I wait for 2000 specific time
	    And I switch back to default frame
	    And I switch to active element
	    And I handle dialog with button okButton

		# Assign successplan template to both contacts having academic period
		And I wait for 2000 specific time
		And I select record no. 2 in the grid
		And I wait for 4000 specific time
		And I have clicked Assign Success Plan command in View
		And I wait for 2000 specific time
		Then I switch to FullPageWebResource frame
	    And I wait for 2000 specific time
		And I set UIAutoSPT-737999 to successPlanTemplates field in dialog dialog
	    And I wait for 2000 specific time
	    And I click Assign button in the window
		And I wait for 2000 specific time
	    And I switch back to default frame
	    And I switch to active element
	    And I handle dialog with button okButton

		# Assign successplan template to both contacts having academic period and one not having academic period
		And I wait for 2000 specific time
		And I select record no. 1 in the grid
		And I select record no. 2 in the grid
		And I select record no. 3 in the grid
		And I wait for 4000 specific time
		And I have clicked Assign Success Plan command in View
		And I wait for 2000 specific time
		Then I switch to FullPageWebResource frame
	    And I wait for 2000 specific time
		And I set UIAutoSPT-737999 to successPlanTemplates field in dialog dialog
	    And I wait for 2000 specific time
	    And I click Assign button in the window
		And I wait for 2000 specific time
	    And I switch back to default frame
	    And I switch to active element
	    And I handle dialog with button okButton

		#Create SuccessPlan directly from the sitemap
		And I navigate to main Area and SubArea Success Plans
		And I wait for 3000 specific time
		And I have clicked New command in View
		And I press Save in the form
		Then I validate <SPNotification> notification/s in the form
		When I have set UIAutoSP-737999 to cmc_successplanname text field uniquely in the Form
		And I have set UIAuto Contact-737999 to cmc_assignedtoid lookup item in the Form
		And I wait for 2000 specific time
		And I press Save in the form
		And I wait for 1000 specific time
		Then the Entity should be saved
		#When I click New To Do button on Success Plan TO DOs SubGrid only if available
		#And I wait for 2000 specific time
		#And I have set Todo1quickcreate to cmc_todoname text field in the Form
		##And I have set Todo1quickcreate to cmc_todoname text field in the QuickCreate
		## step for setting value to date field
		#And I set future date time value to Due Date field in the Form
		##And I have set (.*) to (.*) datetime field in the Form
		#And I click Save and Close action button in Quick Create pop-up
		#And I wait for 2000 specific time

		##Deativate the parent Successplan record with status reason  as 'canceled'
		And I wait for 2000 specific time
		And I have clicked Update Status command in View
		And I click Deactivate button in dialog
		
		## Create successplanAssignment from sitemap
		And I have navigated to the Area Process Config and SubArea Success Plan Assignments
		And I wait for 3000 specific time
		And I have clicked New command in View
		And I press Save in the form
		Then I validate <SPANotification> notification/s in the form
		When I have set UIAutoSPA-737999 to cmc_successplanassignmentname text field uniquely in the Form
		And I have set UIAutoSPT-737999 to cmc_successplantemplateid lookup item in the Form
		And I wait for 2000 specific time
		And I press Save in the form
		And I wait for 1000 specific time
		Then the Entity should be saved

Examples: 
| Test Case ID | StudentAdvisor | SPTNotification                                                 | SPTDTNotification                         | StaticDate | SPNotification                            | SPANotification                           |
| 737999       | StudentAdvisor | Success Plan Template Name : Required fields must be filled in. | You have 3 notifications. Select to view. | 02/05/2021 | You have 2 notifications. Select to view. | You have 2 notifications. Select to view. |



Scenario: UI: Validate fields and form of Student Alert and Case related to Student Alert
	Given I have logged in as a <StudentAdvisor>
	And I navigate to main Area and SubArea Student Alerts
	And I have clicked New command in View
	And I verify below fields
	| Type  | sectionLabel                                                                                                          | FieldName               | FieldValue |
	| Field | Alert Information                                                                                                     | Alert Name              |            |
	| Field | Alert Information                                                                                                     | Alert Reason            |            |
	| Field | Alert Information                                                                                                     | Alert Reason Details    |            |
	| Field | Alert Information                                                                                                     | Alert Description       |            |
	| Field | Alert Information                                                                                                     | Anonymous               |            |
	| Field | Alert Information                                                                                                     | Associated Case         |            |
	| Field | Alert Information                                                                                                     | Alert Source            |            |
	| Field | Student                                                                                                               | Student                 |            |
	| Field | Student                                                                                                               | Student First Name      |            |
	
	When I scroll in to view of Student section
		And I verify below fields
	| Type  | sectionLabel                                                                                                          | FieldName               | FieldValue |
	| Field | Student                                                                                                               | Student Last Name       |            |
	| Field | Student                                                                                                               | Student Email           |            |
	| Field | Student                                                                                                               | Student Phone Number    |            |
	| Field | Student                                                                                                               | Course                  |            |
	| Field | Student                                                                                                               | Instructor              |            |
	| Field | Student                                                                                                               | Course Section          |            |
	When I scroll in to view of Submitter section
		And I verify below fields
	| Type  | sectionLabel                                                                                                          | FieldName               | FieldValue |
	| Field | Submitter                                                                                                             | Alert Submitter         |            |
	| Field | Submitter                                                                                                             | Submitter First Name    |            |
	| Field | Submitter                                                                                                             | Submitter Last Name     |            |
	| Field | Submitter                                                                                                             | Submitter Email         |            |
	| Field | Submitter                                                                                                             | Submitter Phone Number  |            |
	| Field | Submitter                                                                                                             | Relationship to Student |            |
	When I scroll in to view of Reviewer section
		And I verify below fields
	| Type  | sectionLabel                                                                                                          | FieldName               | FieldValue |
	| Field | Reviewer                                                                                                              | Reviewed By             |            |
	| Field | Reviewer                                                                                                              | Reviewed On             |            |
	| Field | Reviewer                                                                                                              | Review State            |            |
	| Field | Reviewer                                                                                                              | Visible to Student      |            |
Then I scroll in to view of Student Alert State section
And I wait for 2000 specific time	
	And I verify below fields
	| Type  | sectionLabel                                                                                                          | FieldName               | FieldValue |
	| Field | Student Alert State                                                                                                   | Owner                   |            |
	| Field | Student Alert State                                                                                                   | Status                  |            |
	| Field | Student Alert State                                                                                                   | Created By              |            |
	| Field | Student Alert State                                                                                                   | Created On              |            |
	| Field | Student Alert State                                                                                                   | Status Reason           |            |
	| Field | Student Alert to Case - To create a case for this alert: 1) Save the alert record 2) Update this field to Yes 3) Save | Create Case             |            |
	And I have navigated to the Area Case Management and SubArea Cases
	And I have clicked New Case command in View
	When I select Case - Student Alert Form	
	And I wait for 1000 specific time
	And I scroll in to view of CASE DETAILS section
	And I verify below fields
	| Type  | sectionLabel       | FieldName            | FieldValue |
	| Field | CASE DETAILS       | Case Title           |            |
	| Field | CASE DETAILS       | ID                   |            |
	| Field | CASE DETAILS       | Submitted For        |            |
	| Field | CASE DETAILS       | Origin of Case       |            |
	| Field | CASE DETAILS       | Case: Student Facing |            |
	| Field | Student Alert Info | Student Alert        |            |
		


Examples:
| Test Case ID | StudentAdvisor |
| 1118460      | StudentAdvisor |