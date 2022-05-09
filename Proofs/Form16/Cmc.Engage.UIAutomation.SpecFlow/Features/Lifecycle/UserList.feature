Feature: UserList
	
@UserList
Scenario:01 Validate User List form and fields
    Given I have logged in as a <BusinessUnitAdministrator>
    And I have navigated to the Area Process Config and SubArea User Lists
    When I have clicked New command in View
    And I verify in General section Name field is present
    And I verify in General section Owner field is present
    And I verify in General section List Type field is present
    And I verify in General section Purpose field is present
    And I verify in General section Description field is present
   # And I have set StaticUserList-1212311 to cmc_name text field uniquely in the Form
	And I have set SList-1212311 to cmc_name text field uniquely in the Form
    And I have set Static to cmc_listtype optionset field in the Form
    And I press Save in the form
    Given I click Ok in Confirmation dialog
    Then the Entity should be saved
    And I wait for 2000 specific time
    And I select the tab Members in the form  	
	And I wait for 2000 specific time
 #   And I click New User List Member command on Users SubGrid when available
	#And I click More Commands button on Users SubGrid only if available
	#And I click New User List Member SubGrid option on More Commands SubGrid when available	
	 And  I choose to click New User List command in Members SubGrid out of multiple sections in Members div if available
    And I wait for 2000 specific time
	And I have set Anthology Dev1 to cmc_userid field in the lookup dialog
    And I click Save and Close action button in Quick Create pop-up
	And I wait for 2000 specific time
    And I wait for 2000 specific time
    When I have clicked New command in View
    And I have set DynamicUserList-1212311 to cmc_name text field uniquely in the Form
    And I have set Dynamic to cmc_listtype optionset field in the Form
    And I press Save in the form
    Given I click Ok in Confirmation dialog
    Then the Entity should be saved
    And I wait for 2000 specific time
    And I select the tab Members in the form
    And I wait for 1000 specific time
    And I have clicked Create/Edit Query button in Query section
    And I wait for 1000 specific time
    Then I switch to Advanced Find - Microsoft Dynamics 365 window 
    And I wait for 6000 specific time   
    And I click HideDetails in Query group of advanced find ribbon
    Then I switch to contentIFrame0 frame
    And I select sub filter option as City from Fields option group in row 0
    And I enter Bangalore in Enter Text field
	#And I enter Bangalore in City field
    And I switch back to default frame
    Given I click Save in the Advanced Find Window 
    And I close the Advanced Find Window
    And I wait for 1000 specific time
    Then I switch back to default frame
    And I handle dialog with button okbutton
    And I wait for 2000 specific time
    And I press Save in the form
    Then the Entity should be saved
    And I wait for 1000 specific time    

    #create Assignment Group and Assignment rules
	And I have navigated to the Area Process Config and SubArea Assignment Groups
	And I wait for 2000 specific time
	When I have clicked New command in View
	And I wait for 2000 specific time
	And I have set <AssignmentGroupName> to cmc_name text field uniquely in the Form
	And I wait for 2000 specific time
	And I have set Contact view/Entity to cmc_baseentity Picker in Section section
	When I wait for 2000 specific time
	And  I have set Owner view/Entity to cmc_assigntofield Picker in Section section
	And I wait for 2000 specific time
	Given I have set <FallBackUser> to cmc_fallbackuserid lookup item in the Form
	And I wait for 1000 specific time
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 1000 specific time
	And I handle dialog with button confirmButton
	And I wait for 1000 specific time

	#Create Round Robin Assignment rule
	And I select the tab Assignment Rule in the form
	And I click New Assignment Rule command in Assignment Rule SubGrid Division
	And I wait for 3000 specific time
	When I have set UIAutoAR- 1212311-1 to cmc_name text field uniquely in the Form
	And I wait for 2000 specific time
	And I have set 1 to cmc_executionorder text field in the Form
	And I wait for 2000 specific time
	And I have set Round Robin to cmc_assignmenttype optionset field in the Form
	And I wait for 2000 specific time
	When I have set SList-1212311 to cmc_userlistid lookup item in the Form
	And I wait for 3000 specific time
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 2000 specific time
	When I click cmc_assignmentgroupid locked lookup field in Section section
	And I wait for 2000 specific time

	#Create weighted Round Robin Assignment rule
	And I select the tab Assignment Rule in the form
	And I click New Assignment Rule command in Assignment Rule SubGrid Division
	And I wait for 3000 specific time
	When I have set UIAutoAR- 1212311-2 to cmc_name text field uniquely in the Form
	And I wait for 2000 specific time
	And I have set 2 to cmc_executionorder text field in the Form
	And I wait for 2000 specific time
	And I have set Weighted Round Robin to cmc_assignmenttype optionset field in the Form
	And I wait for 2000 specific time
	When I have set SList-1212311 to cmc_userlistid lookup item in the Form
	And I wait for 2000 specific time
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 2000 specific time
	When I click cmc_assignmentgroupid locked lookup field in Section section
	And I wait for 2000 specific time

	#Create Load based Assignment rule
	And I select the tab Assignment Rule in the form
	And I click New Assignment Rule command in Assignment Rule SubGrid Division
	And I wait for 3000 specific time
	When I have set UIAutoAR- 1212311-3 to cmc_name text field uniquely in the Form
	And I wait for 2000 specific time
	And I have set 3 to cmc_executionorder text field in the Form
	And I wait for 2000 specific time
	And I have set Load-based Assignment to cmc_assignmenttype optionset field in the Form
	And I wait for 2000 specific time
	When I have set SList-1212311 to cmc_userlistid lookup item in the Form
	And I wait for 2000 specific time
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 2000 specific time
	And I have clicked Create/Edit Query button in Load Condition section
	And I wait for 4000 specific time
	Then I switch to Advanced Find - Microsoft Dynamics 365 window 
	And I wait for 6000 specific time   
	And I click HideDetails in Query group of advanced find ribbon
	Then I switch to contentIFrame0 frame
	And I select sub filter option as First Name from Fields option group in row 0
	And I switch back to default frame
	Given I click Save in the Advanced Find Window 
	And I close the Advanced Find Window
	And I wait for 1000 specific time
	Then I switch back to default frame
	And I handle dialog with button okbutton
	And I wait for 2000 specific time
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 2000 specific time
	And I scroll in to view of Load Condition section
	And I wait for 4000 specific time
	And I have clicked Use Existing View button in Load Condition section
	And I wait for 4000 specific time
	And I set All Contacts option to cmc_userconditionview PCF control field in Load Condition section
		And I wait for 2000 specific time
	And I have clicked Use Query button in Load Condition section
	And I wait for 2000 specific time
	And I press Save in the form
		And I wait for 2000 specific time
	Then the Entity should be saved
	And I wait for 2000 specific time
 

Examples: 
| TestCase ID | BusinessUnitAdministrator | AssignmentGroupName | FallBackUser      |
| 1212311     | BusinessUnitAdministrator | UIAutoAG- 1212311   | anthologyd365automation |