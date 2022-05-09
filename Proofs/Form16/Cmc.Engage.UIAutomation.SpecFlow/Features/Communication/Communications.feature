Feature: Communications

@Regression
Scenario: 01 To validate if Engage User is able to cancel the appointment from Appointment Form
	Given I have logged in as a <Persona>
	And I have navigated to the Area Engage and SubArea Activities
	And I have clicked <EntityName> command in View
	And I have set <SubjectName> to subject text field uniquely in the Form
	And I have set <FieldName> to cmc_cancelreason text field uniquely in the Form
	And I press Save in the form
	Then the Entity should be saved
	And I click Ignore And Save button in dialog only if available
	When I wait for 4000 specific time
	And I have clicked More commands for Appointment command in a View
	And I have clicked Close Appointment command in a View	
	#And I have clicked  command in View
	When I wait for 4000 specific time
	And I select state_id field as Canceled option in the dialog
	And I click Close Appointment button in dialog	
	

Examples:
| TestCase ID | Persona        | EntityName  | SubjectName        | FieldName                                                                                        | 
| 1065300     | StudentAdvisor | Appointment | UIAutomationCancel | Cancelling this appointment because having another priority appointment planned in the same slot |