Feature: GoogleIntegration	

Scenario: 01 Manual Sync: Owner of the appt should be allowed to sync recurring appt created or cancelled manually
	Given I have logged in as a <StudentAdvisor>
	#Given I logged in as a <StudentAdvisor> in specific browser
	And I have navigated to the Area Settings and SubArea Configurations
	And I switch the view to Active Configurations
	And I open the first record in the grid
	And I select the tab Google Integration in the form
	And I have set External Only to cmc_googlesendeventnotifications optionset field in the Form
	And I press Save in the form
	And I wait for 3000 specific time
	And I navigate to main Area and SubArea Activities
	And I have clicked Appointment command in View
	And I have set test to requiredattendees lookup item in the Form
	And I wait for 5000 specific time
	And I have set test to optionalattendees lookup item in the Form
	And I wait for 5000 specific time
	And I have set Appointment-1067134 to subject text field uniquely in the Form
	And I wait for 2000 specific time
	And I have set Bangalore to location text field in the Form
	And I wait for 2000 specific time
	And I have set Invitation Pending to cmc_invitestatus optionset field in the Form
	And I wait for 2000 specific time
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 8000 specific time
    When I have clicked More commands for Appointment command in a View
	Then I have clicked Recurrence command in the View
	And I wait for 8000 specific time
	And I select Repeat field as Daily option in dialog
	And I wait for 5000 specific time
	And I click Set button in dialog
	And I wait for 5000 specific time
	Then I press Save in the form
	And the Entity should be saved
	And I wait for 5000 specific time
	And I navigate to main Area and SubArea Activities
	And I wait for 5000 specific time
	And I switch the view to Appointments: Failed to Sync
	And I wait for 2000 specific time
	When I search test in the grid
	And I wait for 2000 specific time
	And I select record no.0 in the grid
	And I wait for 2000 specific time
	And I have clicked Flow command in View
	And I wait for 5000 specific time
	And I select Flow flow in the flyout option
	And I wait for 2000 specific time
	And I select Sync with Google flow in the flow menu
	And I wait for 2000 specific time
	And I click the flow dialog action button Continue
	And I wait for 5000 specific time
	And I click the flow dialog action button Run Flow
	And I wait for 5000 specific time
	#And I have clicked Run Flow command in View
	#Then I switch to MicrosoftFlows_iframe frame
	#And I click Run Flow in Confirmation dialog

Examples:
| TestCase ID | StudentAdvisor |
| 1067134     | StudentAdvisor |

@Done
Scenario: 02 Manual Sync: Attachments in the calendar invite should remain unaffected after the manual sync by Owner
	#Given I logged in as a <StudentAdvisor> in specific browser

	Given I have logged in as a <StudentAdvisor>
	And I have navigated to the Area Settings and SubArea Configurations
	And I switch the view to Active Configurations
	And I open the first record in the grid
	And I select the tab Google Integration in the form
	And I have set External Only to cmc_googlesendeventnotifications optionset field in the Form
	And I press Save in the form
	And I wait for 3000 specific time
	And I navigate to main Area and SubArea Activities
	And I have clicked Appointment command in View
	And I have set Test123 to requiredattendees lookup item in the Form
	And I wait for 5000 specific time
	And I have set Test123 to optionalattendees lookup item in the Form
	And I wait for 5000 specific time
	And I have set Appointment-1065434 to subject text field uniquely in the Form
	And I wait for 2000 specific time
	And I have set Bangalore to location text field in the Form
	And I wait for 2000 specific time
	And I have set Invitation Pending to cmc_invitestatus optionset field in the Form
	And I wait for 2000 specific time
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 5000 specific time
    And I click available command New Attachment on <SubGridName> SubGrid
	And I wait for 5000 specific time
	And I click New Attachment SubGrid option on <SubGridName> in the available SubGrid
    When I wait for 5000 specific time
	And I browse Attachment.ics in a File section
	And I navigate to main Area and SubArea Activities
	And I wait for 5000 specific time
	And I switch the view to All Activities
	And I wait for 5000 specific time
	When I search Appointment-1065434 in the grid
	And I select record no.0 in the grid
	And I wait for 8000 specific time
    And I have clicked Flow command in View
	And I wait for 15000 specific time
    And I select Flow flow in the flyout option
	And I wait for 5000 specific time
	And I select Sync with Google flow in the flow menu
	And I wait for 1000 specific time
	And I click the flow dialog action button Continue
	And I wait for 5000 specific time
	And I click the flow dialog action button Run Flow
	And I wait for 5000 specific time

Examples:
| TestCase ID | StudentAdvisor | SubGridName |
| 1067934     | StudentAdvisor | Attachments |

Scenario: 03 Manual Sync: Admin user should be allowed to sync appts manually in bulk irrespective of the owner of appointment(Normal & recurring)
	#Given I logged in as a <StudentAdvisor> in specific browser
	Given I have logged in as a <StudentAdvisor>
	And I navigate to main Area and SubArea Activities
	And I wait for 5000 specific time
	And I switch the view to Appointments: Failed to Sync
	And I wait for 5000 specific time
	And I search test in the grid
	And I select record no.0 in the grid
	And I select record no.1 in the grid
	And I select record no.2 in the grid
	And I select record no.3 in the grid
	And I select record no.4 in the grid
	And I wait for 5000 specific time
	And I have clicked Flow command in View
	And I wait for 15000 specific time
	And I select Flow flow in the flyout option
	And I wait for 5000 specific time
	And I select Sync with Google flow in the flow menu
	#And I click Run Flow button in dialog
	And I wait for 1000 specific time
	And I click the flow dialog action button Continue
	And I wait for 5000 specific time
	And I click the flow dialog action button Run Flow
	And I wait for 5000 specific time

Examples:
| TestCase ID | StudentAdvisor |
| 1067935     | StudentAdvisor |