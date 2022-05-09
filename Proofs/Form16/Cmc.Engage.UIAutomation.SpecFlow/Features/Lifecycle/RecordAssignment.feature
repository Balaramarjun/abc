Feature: RecordAssignment

@Smoke
@Regression 
Scenario: Validate the Assignment Group and Assignment Rule fields and forms creation including launching AQB window

#Create an Assignment Group 
Given I have logged in as a <Persona> 
And I have navigated to the Area Process Config and SubArea Assignment Groups
When I have clicked New command in View
And I have set <AssignmentGroupName> to cmc_name text field uniquely in the Form
And I wait for 2000 specific time
And  I have set Account view/Entity to cmc_baseentity Picker in Section section
When I wait for 2000 specific time
And  I have set Owner view/Entity to cmc_assigntofield Picker in Section section
#And I select Owner option in cmc_assigntofield field tree section
And I wait for 2000 specific time
Given I have set <FallBackUser> to cmc_fallbackuserid lookup item in the Form
And I wait for 1000 specific time
And I press Save in the form
Then the Entity should be saved
And I wait for 1000 specific time
And I handle dialog with button confirmButton
And I wait for 1000 specific time
And I select the tab Segment Criteria in the form
And I wait for 1000 specific time
And I have clicked Create/Edit Query button in Query section
And I wait for 8000 specific time
Then I switch to Advanced Find - Microsoft Dynamics 365 window 
And I wait for 6000 specific time   
And I click HideDetails in Query group of advanced find ribbon
 Then I switch to contentIFrame0 frame
 And I select sub filter option as Account Name from Fields option group in row 0
 And I switch back to default frame
Given I click Save in the Advanced Find Window 
And I close the Advanced Find Window
And I wait for 2000 specific time
Then I switch back to default frame
And I handle dialog with button okbutton
And I wait for 2000 specific time
And I press Save in the form
Then the Entity should be saved
And I wait for 1000 specific time
And I select the tab Assignment Rule in the form
And I click New Assignment Rule command in Assignment Rule SubGrid Division
And I wait for 3000 specific time
When I have set <AssignmentRuleName> to cmc_name text field uniquely in the Form
And I wait for 2000 specific time
And I have set <ExecutionOrder> to cmc_executionorder text field in the Form
And I wait for 2000 specific time
And I have set <AssignmentType> to cmc_assignmenttype optionset field in the Form
And I wait for 2000 specific time
When I have set <UserName> to cmc_usertoassignid lookup item in the Form
And I wait for 2000 specific time
And I press Save in the form
Then the Entity should be saved
And I wait for 2000 specific time
And I select the tab Query Condition in the form
And I wait for 2000 specific time
And I have clicked Use Existing View button in Query section
And I wait for 2000 specific time
And I set Active Campuses option to cmc_conditionview PCF control field in Query section
#And  I have set Accounts Being Followed view/Entity to cmc_conditionview Picker in Query section
And I have clicked Use Query button in Query section
And I press Save in the form
Then the Entity should be saved
And I wait for 2000 specific time
		  
Examples: 
| TestCase ID | Persona                   | AssignmentGroupName | FallBackUser      | AssignmentRuleName | ExecutionOrder | AssignmentType |UserName        |
| 1098366     | BusinessUnitAdministrator | TestAssignment      |  anthologyd365automation  | TestAssignment     | 1              | User           |anthologyd365automation|

