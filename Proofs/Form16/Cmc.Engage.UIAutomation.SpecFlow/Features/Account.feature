@Account
@Campus

Feature: Account

@Smoke
@Regression
#Scenario: 01 Create Account
#	Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#		And I have clicked New command in View
#		And I have set <AccountName> to name text field in the Form
#		And I have set <AccountType> to mshied_accounttype optionset field in the Form
#	When I press Save in the form
#	Then the Entity should be saved
#
#	Examples:
#	| case           | Persona | Area         | SubArea  | AccountName | AccountType |
#	| Create Account | Advisor | Constituents | Accounts | ALS         | College     |
#
#@Regression
#Scenario: 02 Edit Account
#	Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#	When I search <AccountName> in the grid
#		And I open the first record in the grid
#		And I have set <AccountType> to mshied_accounttype optionset field in the Form
#		And I press Save in the form
#	Then the Entity should be saved
#
#	Examples: 
#	| case         | Persona | Area         | SubArea  | AccountType | AccountName |
#	| Edit Account | Advisor | Constituents | Accounts | Campus      | ALS         |

#@Regression
#Scenario: 03 Delete Account
#	Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#	When I search <AccountName> in the grid
#		And I open the first record in the grid
#		And I press Delete in the form
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#		And I search <AccountName> in the grid
#	Then I should not see any records listed
#
#	Examples: 
#	| case           | Persona | Area         | SubArea  | AccountName |
#	| Delete Account | Advisor | Constituents | Accounts | ALS         |

#@Regression
#Scenario: 04 Create Account
#	Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#		And I have clicked New command in View
#		And I enter the below data in the Form
#			| Type      | FieldName          | FieldValue    |
#			| string    | name               | <AccountName> |
#			| optionset | mshied_accounttype | <AccountType> |
#			| string    | websiteurl         | <WebSiteUrl>  |
#			| string    | cmc_accountcode    | <AccCode>     |
#	When I press Save in the form
#	Then the Entity should be saved
#
#	Examples:
#	| case                       | Persona  | Area         | SubArea  | AccountName | AccountType | WebSiteUrl        | AccCode |
#	| Create Account as Advisor  | Advisor  | Constituents | Accounts | ALD         | College     | www.ald123.aa.edu | ALD     |
#	| Create Account as Reviewer | Reviewer | Constituents | Accounts | ALC         | College     | www.alc123.aa.edu | ALC     |
#

Scenario: 05 Account form locks when Account Type is Campus
	Given I have logged in as a <BusinessUnitAdministrator> 
		And I navigate to main Area and SubArea <SubArea>
		And I have clicked New command in View
		And I have set <AccountName> to name text field uniquely in the Form
		And I have set <AccountType> to mshied_accounttype optionset field in the Form
		And I press Save in the form
	Then the Entity should be saved
	When I have set <AccountTypeCampus> to mshied_accounttype optionset field in the Form
		#And I verify in <Section> section Locked Account Type field is locked
		#And I verify in <Section> section Locked Account Name field is locked
		And I verify in <Section> section Locked External Identifier field is locked
		#And I verify in <Section> section Locked Code field is locked
		#And I verify in <Section> section Locked Website field is locked
		#And I verify in <Section> section Locked SMS Number field is locked
		#And I verify in <Section> section Locked Parent Account field is locked
		#And I verify in <Section> section Locked Industry field is locked
		#And I verify in <Section> section Locked Main Phone field is locked
		#And I verify in <Section> section Locked Primary Email Address field is locked
		#And I verify in <Section> section Locked Fax field is locked
		And I press Save in the form
		#And I verify in <Section> section Locked Account Type field is locked
		#And I verify in <Section> section Locked Account Name field is locked
		#And I verify in <Section> section Locked External Identifier field is locked
		#And I verify in <Section> section Locked Code field is locked
		#And I verify in <Section> section Locked Website field is locked
		#And I verify in <Section> section Locked SMS Number field is locked
		#And I verify in <Section> section Locked Parent Account field is locked
		#And I verify in <Section> section Locked Industry field is locked
		#And I verify in <Section> section Locked Main Phone field is locked
		#And I verify in <Section> section Locked Primary Email Address field is locked
		#And I verify in <Section> section Locked Fax field is locked

		And I have clicked New command in View
		#And I have set <AccountName> to name text field uniquely in the Form
	#When I have set <AccountTypeCampus> to mshied_accounttype optionset field in the Form
	#	And I verify in <Section> section Locked Account Type field is locked
		#And I verify in <Section> section Locked Account Name field is locked
		And I verify in <Section> section Locked External Identifier field is locked
	#	And I verify in <Section> section Locked Code field is locked
	#	And I verify in <Section> section Locked Website field is locked
		#And I verify in <Section> section Locked SMS Number field is locked
		#And I verify in <Section> section Locked Parent Account field is locked
		#And I verify in <Section> section Locked Industry field is locked
		#And I verify in <Section> section Locked Main Phone field is locked
		#And I verify in <Section> section Locked Primary Email Address field is locked
		#And I verify in <Section> section Locked Fax field is locked
		#And I press Save in the form
	Then the Entity should be saved
		#And I verify in <Section> section Locked Account Type field is locked
		#And I verify in <Section> section Locked Account Name field is locked
		And I verify in <Section> section Locked External Identifier field is locked
		#And I verify in <Section> section Locked Code field is locked
		#And I verify in <Section> section Locked Website field is locked
		#And I verify in <Section> section Locked SMS Number field is locked
		#And I verify in <Section> section Locked Parent Account field is locked
		#And I verify in <Section> section Locked Industry field is locked
		#And I verify in <Section> section Locked Main Phone field is locked
		#And I verify in <Section> section Locked Primary Email Address field is locked
		#And I verify in <Section> section Locked Fax field is locked


	Examples: 
	| Test Case ID | BusinessUnitAdministrator | Area         | SubArea  | AccountName  | AccountType | AccountTypeCampus | Section         |
	| 773806       | BusinessUnitAdministrator | Constituents | Accounts | YashiAccount | High School | Campus            | Account Information |

Scenario: 06 Customer Address should copy to  Account's Native address when Mail Type Field is set to Primary
	Given I have logged in as a <BusinessUnitAdministrator> 
		And I navigate to main Area and SubArea <SubArea>
		And I switch the view to Active High Schools	
		And I wait for 2000 specific time
		And I search Account-840929 in the grid
				When I wait for 4000 specific time

		And I open the first record in the grid	
		When I wait for 3000 specific time
        And I select Account(Reach - New) Form
		When I wait for 2000 specific time
		And I select the sub tab Addresses of tab Related in the form		
		And I wait for 3000 specific time
		#And I have clicked New Address command in View
		And I click New Address command in associated View
		And I wait for 1000 specific time
		And I select Information(Reach - New) Form
	When I have set 2 to addresstypecode optionset field in the Form
		And I have set Primary to mshied_mailtype optionset field in the Form
		#And I set United States of America option to cmc_countryregion PCF control field in Customer Address Information section
		#And I have set <Country> to cmc_country optionset field in the Form
		#And I wait for 1500 specific time
		#And I have set <Street 1> to line1 text field in the Form
		And I select matching Address to <Street 1> in the field search_field
#And I have set <City> to city text field in the Form
		#And I have set <State> to cmc_stateprovince optionset field in the Form
		#And I set FL option to cmc_state PCF control field in Customer Address Information section
		#And I have set <Zip Code> to postalcode text field in the Form
		And I have clicked Save & Close command in View
		#And I have clicked Save command in View
		And I wait for 2000 specific time
		#And I have clicked Go back command in View
		And I select the tab Account Summary in the form
		And I select Account(Reach) Form
		And I wait for 1500 specific time
		And I scroll to Correspondence Details section having Address 1: Street 1 field
		#And I scroll in to view of Correspondence Details section
				And I wait for 5000 specific time

				#And The field 7284 West Palmetto value should be same as address1_line1 in section Correspondence Details

		And The field address1_composite_compositionLinkControl_address1_line1 value should be same as <Street 1> in section Correspondence Details
	#Then The address1_composite_compositionLinkControl_address1_line1 field value should be equal to <Street 1>
	And The field address1_composite_compositionLinkControl_address1_city value should be same as <City> in section Correspondence Details
		And The field address1_composite_compositionLinkControl_address1_postalcode value should be same as <Zip Code> in section Correspondence Details
		And The field address1_composite_compositionLinkControl_address1_country value should be same as <Country> in section Correspondence Details
		#Then The address1_composite_compositionLinkControl_address1_city field value should be equal to <City>
		#And The address1_composite_compositionLinkControl_address1_postalcode field value should be equal to <Zip Code>
		#And The address1_composite_compositionLinkControl_address1_country field value should be equal to <Country>
		#And I capture screenshot
	
	

	Examples: 
	| Test Case ID | BusinessUnitAdministrator | Area         | SubArea  |  Country                  | Street 1                | City       | State   | Zip Code |
	| 840929       | BusinessUnitAdministrator | Constituents | Accounts |  United States of America | 7284 West Palmetto Park Road | Boca Raton | Florida | 33433    |


Scenario: 07 Account_Form update design
                Given I have logged in as a <Persona>
                And I navigate to main Area and SubArea <SubArea>
				When I wait for 2000 specific time
                And I open the first record in the grid
				When I wait for 1000 specific time
				And I select the tab Account Summary in the form
                Then I verify below fields
                | Type  | sectionLabel             | FieldName          | FieldValue |
                | Field | Account Information      | Account Name       |               |
                | Field | Account Information      | Account Type       |               |
                | Field | Account Information      | External Identifier|               |
                | Field | Account Information      | Code               |               |
                | Field | Account Information      | Website            |               |
                | Field | Account Information      | SMS Number         |               |
                | Field | Account Information      | Parent Account     |               |
                | Field | Account Information      | Industry           |               |
                | Field | Account Information      | # of Students      |               |
                | Field | Account Information      | # of Contacts      |               |
				And I scroll in to view of Correspondence Details section
				And I wait for 1000 specific time
				And I verify below fields
				| Type  | sectionLabel             | FieldName          | FieldValue |
                | Field | Correspondence Details   | Main Phone             |               |
                | Field | Correspondence Details   | Alternate Phone Number |               |
                | Field | Correspondence Details   | Primary Email Address  |               |
                | Field | Correspondence Details   | Alternate Email Address|               |
                | Field | Correspondence Details   | Fax                    |               |
                | Field | Correspondence Details   | Address 1: Street 1    |               |
                | Field | Correspondence Details   | Address 1: Street 2    |               |
                | Field | Correspondence Details   | Address 1: Street 3    |               |
                | Field | Correspondence Details   | Address 1: City        |               |
				And I scrolldown to End of Correspondence Details section
				And I wait for 1000 specific time
				And I verify below fields
				| Type  | sectionLabel             | FieldName          | FieldValue |
                | Field | Correspondence Details   | Address 1: State/Province |               |
                | Field | Correspondence Details   | Address 1: ZIP/Postal Code|               |
                | Field | Correspondence Details   | Address 1: Country/Region |               |

				And I scroll in to view of Contact Prefrences section
				And I wait for 3000 specific time
				And I verify below fields
				| Type  | sectionLabel             | FieldName          | FieldValue |
                | Field | Contact Prefrences       | Contact Method               |               |
                | Field | Contact Prefrences       | Follow Email                 |               |
                | Field | Contact Prefrences       | Phone                        |               |
                | Field | Contact Prefrences       | Mail                         |               |
                | Field | Contact Prefrences       | Bulk Email                   |               |
                | Field | Contact Prefrences       | Email                        |               |
                | Field | Contact Prefrences       | Fax                          |               |

                And I select the tab Account Details in the form
                And I verify below fields
                | Type  | sectionLabel                           | FieldName                | FieldValue  |
                | Field | Account Description & Additional Info  | Description              |               |
                | Field | Account Description & Additional Info  | Academic/Fiscal Year End |               |
                | Field | Account Description & Additional Info       | DOM Status                   |               |
        
                #| Field | Addresses                                |                              |               |
                #| Field | Child Accounts                           |                              |               |

 

Examples:
| Test Case ID | Persona        | Area   | SubArea  | subGridButtonName                            |
| 849563       | StudentAdvisor | Engage | Accounts | Create a new activity, note, or custom item. |



Scenario: 08 validate Account  form lookupfields ,Option set and text fields
#User should have Business Unit Administrator Role
#Default data (Contacts) should exists
                Given I have logged in as a <Persona>
				And I navigate to main Area and SubArea Accounts
    #            And I have clicked New command in View
    #            When I select Account(Engage) Form
    ##When I have set TestAccount to name text field in the Form
    #            And I have set Account to name text field uniquely in the Form
    #            When I press Save in the form
    #            Then the Entity should be saved
                And I have clicked New command in View
                When I select Account(Reach) Form
    #When I have set TestAccountAbhi1 to name text field in the Form
                And I have set TestAccountAbhi to name text field uniquely in the Form
                And I have set Account-837527 to parentaccountid lookup item in the Form
                When I have set High School to mshied_accounttype optionset field in the Form
                And I have set Brokers to industrycode optionset field in the Form
                And I have set Test to cmc_accountcode text field uniquely in the Form
				And I scroll in to view of Correspondence Details section
				And I wait for 1000 specific time
                And I have set 123546 to telephone1 text field in the Form
                And I capture screenshot
                Given I select the tab Account Details in the form
                #And I have set TestDescription to description text field in the Form
                And I have set TestDescription to description text field uniquely in the Form
                When I press Save in the form
                Then the Entity should be saved
                And I wait for 2000 specific time
                                
                Examples: 
| Test Case ID | Persona                   | LastName       | Method      | Category    |
| 837527       | BusinessUnitAdministrator | Contact-837527 | Appointment | Application |
          
