Feature: Activities

@Activities
@smoke
@Done
Scenario: 01 Check Accept and Decline Appointments show hide rules
	Given I have logged in as a <Persona>
	And I have navigated to the Area Engage and SubArea Activities
	And I have clicked <EntityName> command in View
	And I have set UIAuto Contact-761164 to requiredattendees lookup field in the Form
	And I have set <SubjectName> to subject text field uniquely in the Form
	And I press Save in the form
	Then the Entity should be saved
	And I click Ignore And Save button in dialog only if available
	When I wait for 8000 specific time
	When I have clicked Accept command in View
	And The optionset cmc_invitestatus value should be equal to Accepted
    #Then I verify in Dccepted section <FieldName> field is present
	When I wait for 8000 specific time
	And I navigate to main Area and SubArea Contacts
	And I wait for 2000 specific time
	And I have navigated to the Area Engage and SubArea Activities
	And I have clicked <EntityName> command in View
	And I wait for 2000 specific time
		And I have set UIAuto Contact-761164 to requiredattendees lookup field in the Form
			And I wait for 2000 specific time
	When I have set <SubjectName> to subject text field uniquely in the Form
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 8000 specific time
	And I click Ignore And Save button in dialog only if available
		 And I wait for 2000 specific time
	 When I have clicked Decline command in View
	 And I wait for 2000 specific time
    #Then I verify in Declined section <FieldName> field is present
	And The optionset cmc_invitestatus value should be equal to Declined
   And I wait for 3000 specific time
#validation for failure to be included 
#need to handle a business error pop-up
Examples:
|TestCase ID|Persona       |EntityName |SubjectName|FieldName     |Description          | Description1          | 
|761164     |StudentAdvisor|Appointment|UIAutomation|Invite Status|Accept the invitation| Decline the invitation| 


@Smoke
@Regression
Scenario: 02 Validate Positive Acknowledgement Email Template
	Given I have logged in as a <Persona>
	And I navigate to main Area and SubArea Contacts
	   And I wait for 2000 specific time
	And I switch the view to Active Students
	And I search UIAuto Contact-760760 in the grid
	And The handle live assist pop-up only if available
	And I wait for 2000 specific time
	And I open the first record in the grid
	And I wait for 2000 specific time
	When I select Contact(Reach) Form	
	And I select the tab Contact Overview in the form	
    And I click <subGridButtonName> button on SOCIAL PANE SubGrid only if available	
	And I wait for 3000 specific time
	And I select Email Activity flyout option in the Subgrid
	And I wait for 3000 specific time
	And I have clicked Insert Template command in View
	And I wait for 2000 specific time
	Given I search Email Contact with Positive Acknowledgment in the emailtemplatescontrolid lookup SearchBox
	When I wait for 2000 specific time
	And I click Apply template button in dialog
	When I wait for 2000 specific time
	When I press Save in the form
	Then the Entity should be saved
	And I wait for 3000 specific time
	And The subject field value should be equal to Kudos!
	

Examples:
| TestCase ID|Persona       | ContactName | subGridButtonName        | TemplateName                             |
| 760760     |StudentAdvisor| contact     | Create a timeline record.|Email Contact with Positive Acknowledgment|

# UIAuto Contact-760760

#@Regression
#Scenario: 03 Validate Contact Activities view in timeline Grid
#	Given I have logged in as a <Persona>
#	And I have navigated to the Area <Area> and SubArea <SubArea>
#	And I search <ContactName> in the grid
#	And I open the first record in the grid
#		
#	# Validate Email Activity on Timeline
#	
#
#
#Examples:
#| Test Case ID | Persona | Area | SubArea | ContactName | subGridButtonName | EmailSubjectName |
#|   765025     |StudentAdvisor | Engage | Contacts | ActivitiesCheck | Create a new activity, note, or custom item. | EmailUI          |