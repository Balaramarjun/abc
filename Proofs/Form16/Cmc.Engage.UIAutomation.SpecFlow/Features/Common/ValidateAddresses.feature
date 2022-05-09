Feature: ValidateAddresses
	

@ValidateAddresses
Scenario: Validate default Addresses of Account and Contact
	Given I have logged in as a <Persona>
	And I navigate to main Area and SubArea Accounts
	When I switch the view to Active Campuses
	And I search <AccountName> in the grid
	And I wait for 2000 specific time
	And I open the first record in the grid
	When I select Account(Reach) Form
	And I select the sub tab Addresses of tab Related in the form
	And I switched the Systemview to All Addresses(Reach)
	And I open the first record in the grid
	And I navigate to main Area and SubArea Contacts
	And I wait for 3000 specific time
	When I switch the view to All Contacts(Reach)
	And I wait for 2000 specific time
	And I search <LastName> in the grid
	And I open the first record in the grid
	And I wait for 2000 specific time
	And I navigate to sub tab Course Histories of available tab Events in the form
	And I wait for 2000 specific time
	And I navigate to sub tab Addresses of available tab Events in the form
	And I wait for 2000 specific time
	And I switched the Systemview to All Addresses(Reach)
	And I wait for 2000 specific time
	And I open the first record in the grid
	And I have set Ship To to addresstypecode optionset field in the Form
	When I press Save in the form
	Then the Entity should be saved
	When I wait for 2000 specific time
	And I navigate to main Area and SubArea Accounts
	When I switch the view to Active Campuses
	And I search <AccountName> in the grid
	And I open the first record in the grid
	And I select the sub tab Addresses of tab Related in the form
	And I wait for 2000 specific time
	And I switched the Systemview to All Addresses(Reach)
	And I open the first record in the grid
	And I have set Ship To to addresstypecode optionset field in the Form
	When I press Save in the form
	Then the Entity should be saved
	And I navigate to main Area and SubArea Contacts
	And I wait for 2000 specific time
	When I switch the view to All Contacts(Reach)
	And I search <LastName> in the grid
	And I open the first record in the grid
	And I wait for 2000 specific time
	And I navigate to sub tab Course Histories of available tab Events in the form
	And I wait for 2000 specific time
	And I navigate to sub tab Addresses of available tab Events in the form
	And I wait for 2000 specific time
	#And I select the sub tab Addresses of tab Related in the form
	When I switched the Systemview to All Addresses(Reach)
	#And I have clicked New Address command in View
	  And I click New Address command in associated View
	And I have set Ship To to addresstypecode optionset field in the Form
	And I have set Primary to mshied_mailtype optionset field in the Form 
	When I press Save in the form
	Then the Entity should be saved
	When I wait for 2000 specific time
	And I navigate to main Area and SubArea Contacts
	When I switch the view to All Contacts(Reach)
	And I search <LastName> in the grid
	And I open the first record in the grid
	And I navigate to sub tab Course Histories of available tab Events in the form
	And I wait for 2000 specific time
	And I navigate to sub tab Addresses of available tab Events in the form
	And I wait for 2000 specific time
	When I switched the Systemview to All Addresses(Reach)
	And I open the first record in the grid
	And I verify below fields
	| Type  | sectionLabel | FieldName    | FieldValue |
	| Field | Customer Address Information      | Address Type | Ship To    |
	| Field | Customer Address Information      | Mail Type    | Primary    |
	
	Examples: 
	| Test Case ID | Persona                   | AccountName       | LastName              | 
	| 741403       | BusinessUnitAdministrator | Account-UI-741403 | UIAuto Contact-741403 | 

