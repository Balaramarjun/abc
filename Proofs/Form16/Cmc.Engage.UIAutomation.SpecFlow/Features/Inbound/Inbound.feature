Feature: Inbound

@Smoke
@Regression 
Scenario: Validate if the Contact lookup field is form level mandatory in Inbound Interest and qualify Inbound Interest
Given I have logged in as a <Persona>
And I navigate to main Area and SubArea Inbound Interests
And I have clicked New command in View
And I wait for 2000 specific time
When I select Inbound Interest (Reach) Form
And I wait for 2000 specific time
And I handle the dialog action button cancelButton only if available
And I wait for 2000 specific time
And I have set <Type> to cmc_type optionset field in the Form
When I wait for 2000 specific time
And I have set <Areaofinterest> to cmc_areaofinterestid lookup item in the Form
When I wait for 2000 specific time
Given I have set <sourcemethod> to cmc_sourcemethodid lookup item in the Form
When I wait for 2000 specific time
And I have set <sourcecategory> to cmc_sourcecategoryid lookup item in the Form
And I wait for 2000 specific time
When I have set <Comments> to cmc_comments text field in the Form
And I wait for 2000 specific time
And I press Save in the form
And I wait for 2000 specific time
Then I validate <Message1> notification/s in the form
And I wait for 2000 specific time
Given I have set <contact> to customerid lookup item in the Form
And I wait for 2000 specific time
And I press Save in the form
Then the Entity should be saved
When I wait for 3000 specific time
And I have clicked Qualify command in View
When I wait for 3000 specific time
And I verify below fields
| Type  | sectionLabel   | FieldName      | FieldValue          |
| Field | INITIAL SOURCE | Method         |Web Chat             |
| Field | INITIAL SOURCE | Category       |Application          |
| Field | INITIAL SOURCE |Area of interest|AreaofInterest-759377|
And I wait for 4000 specific time
Examples:
| TestCase ID | Persona | sourcemethod | sourcecategory |contact        | Areaofinterest       | Type                | Comments  | Message1                                     |
| 759377      | Advisor | Email        | Application    |Contact-759377 | AreaofInterest-759377| Graduate Admissions | thank you | Contact : Required fields must be filled in. |

@Smoke
@Regression
@pre-requisite 
@Done
#Trip Activity type Appointment and event should exist 
Scenario: Validate Lookup field 'Link to Trip Activity'
 
Given I have logged in as a <Persona> 
And I navigate to main Area and SubArea Inbound Interests
When I have clicked New command in View
When I select Inbound Interest (Reach) Form
And I handle the dialog action button cancelButton only if available
And I wait for 2000 specific time
And I scrolldown to End of SOURCE section
When I have clicked New command in View
Given I have set Event Attendee to cmc_sourcemethodid lookup item in the Form
Given I have set UIAuto-event10-858651 - UIAuto-trip10-858651 to cmc_linktotripactivity lookup item in the Form
Given I have set Application to cmc_sourcecategoryid lookup item in the Form
When I wait for 3000 specific time
And I have set <Type> to cmc_type optionset field in the Form
When I wait for 2000 specific time
When I have set <Comments> to cmc_comments text field in the Form
When I wait for 2000 specific time
And I press Save in the form
Then I validate <Message1> notification/s in the form
And I wait for 2000 specific time
Given I have set UIAuto Contact-858651 to customerid lookup item in the Form
And I wait for 2000 specific time
And I press Save in the form
Then the Entity should be saved
When I wait for 3000 specific time
When I have clicked New command in View
And I scrolldown to End of SOURCE section
Given I have set UIAuto Contact-858651 to customerid lookup item in the Form
Then I scroll to SOURCE section having Category field
Given I have set Appointment to cmc_sourcemethodid lookup item in the Form
Given I have set UIAuto-appointment10-858651 - UIAuto-trip10-858651 to cmc_linktotripactivity lookup item in the Form
Given I have set Application to cmc_sourcecategoryid lookup item in the Form
And I press Save in the form
Then the Entity should be saved

When I wait for 3000 specific time
When I have clicked New command in View
Given I have set UIAuto Contact-858651 to customerid lookup item in the Form
When I wait for 1000 specific time
And I scroll to SOURCE section having Category field
#And I scrolldown to End of SOURCE section Method

Given I have set Trip to cmc_sourcemethodid lookup item in the Form
Given I have set UIAuto-event10-858651 - UIAuto-trip10-858651 to cmc_linktotripactivity lookup item in the Form
Given I have set Application to cmc_sourcecategoryid lookup item in the Form
And I press Save in the form
Then the Entity should be saved
When I wait for 2000 specific time

When I wait for 3000 specific time
And I have clicked New command in View
Given I have set UIAuto Contact-858651 to customerid lookup item in the Form
#When I scrolldown to End of SOURCE section
When I scroll to SOURCE section having Category field
And  I have set Trip to cmc_sourcemethodid lookup item in the Form
And  I have set UIAuto-appointment10-858651 - UIAuto-trip10-858651 to cmc_linktotripactivity lookup item in the Form
And I have set Application to cmc_sourcecategoryid lookup item in the Form
And I press Save in the form
Then the Entity should be saved

Examples: 
| TestCase ID | Persona | sourcemethod | sourcecategory | contact   | lastname    | contacttype | TabName                      | SubGridName       | Areaofinterest | Type                | Comments  | Message1									 |                              
| 858651      | Advisor | Web Chat     | Application    | TestCon01 | testcon0532 | Student     | Inbound Interest & Lifecycle | INBOUND INTERESTS | Testdata       | Graduate Admissions | thank you | Contact : Required fields must be filled in. |

@Smoke
@Regression 
Scenario:  Inbound Interest should not create for Contacts if Contact type is not set as 'Student' 
 
Given I have logged in as a <Persona> 
And I navigate to main Area and SubArea Contacts
And I switch the view to Active Contacts
And I have clicked New command in View
When I select Contact (Reach) Form
When I wait for 3000 specific time
Then I click Discard changes in Confirmation dialog
 When I wait for 3000 specific time
And I have set zxcv12b11 to lastname text field uniquely in the Form
When I wait for 3000 specific time
Then I scroll in to view of INITIAL SOURCE section
Then I select Donor options in mshied_contacttype_i multivalue optionset
Then I select Alumni options in mshied_contacttype_i multivalue optionset
Then I select Faculty options in mshied_contacttype_i multivalue optionset
Then I select Recommender options in mshied_contacttype_i multivalue optionset
And I scrolldown to End of INITIAL SOURCE section
Given I have set <Method> to cmc_sourcemethodid lookup item in the Form
Given I have set <Category> to cmc_sourcecategoryid lookup item in the Form
And I press Save in the form
When I wait for 3000 specific time
Given I select the tab Inbound Interest & Lifecycle in the form
Then I verify there are no records in the grid in INBOUND INTERESTS section	


Examples: 
| TestCase ID | Persona | Method | Category    |
| 1050747      | Advisor | Email | Application |



Scenario:Inbound Interest creation should happen for Contacts where Contact type is 'Student' and 'Owner'
	Given I have logged in as a <Persona>
	And I navigate to main Area and SubArea Contacts
	And I have clicked New command in View
    When I select Contact (Reach) Form
	Then I click Discard Changes in Confirmation dialog
	And I wait for 3000 specific time
	Then I scroll in to view of CONTACT SUMMARY section
	When I have set <LastName> to lastname text field in the Form
	Then I scroll in to view of INITIAL SOURCE section
	Then I select Student options in mshied_contacttype_i multivalue optionset by removing existing selections
And I scrolldown to End of INITIAL SOURCE section
	When I have set <Method> to cmc_sourcemethodid lookup item in the Form
	And I wait for 3000 specific time
	And I have set <Category> to cmc_sourcecategoryid lookup item in the Form
	When I press Save in the form
	Then the Entity should be saved
	And I click Ignore And Save button in dialog only if available
	When I wait for 3000 specific time
	Then I click Advanced Find global command
	When I wait for 2000 specific time
	Then I switch to contentIFrame0 frame
	When I wait for 6000 specific time
	And I select slctPrimaryEntity dropdown filter value as Contacts
	When I wait for 2000 specific time
	And I select sub filter option as Owner from Fields option group in row 0
	And I wait for 3000 specific time
	And I select sub filter option as Inbound Interests (Contact) from Related option group in row 0
	And I wait for 3000 specific time
	And I select sub filter option as Owner from Fields option group in row 1
	And I wait for 2000 specific time
	Then I switch back to default frame
	And I click Results in Show group of advanced find ribbon
	And I wait for 5000 specific time
	Then I verify <LastName> in advanced find results
	And I wait for 5000 specific time

	
	Examples: 
| Test Case ID | Persona                   | LastName       | ContactType | Method      | Category    |
| 851063       | BusinessUnitAdministrator | Contact-851063 | 494280011   | Appointment | Application |

Scenario:verification of Fields in Capture Inbound Interest (Reach) form
Given I have logged in as a <Persona>
And I navigate to main Area and SubArea Inbound Interests
And I wait for 2000 specific time
And I have clicked New command in View
And I wait for 2000 specific time
When I select Capture Inbound Interest (Reach) Form
And I wait for 2000 specific time
And I handle the dialog action button cancelButton only if available
And I wait for 2000 specific time
And I have set <Firstname> to firstname text field uniquely in the Form
And I have set <LastName> to lastname text field uniquely in the Form
And I have set <Email> to emailaddress1 text field in the Form
And I have set <Mobile> to mobilephone text field in the Form
And I have set <Street1> to address1_line1 text field in the Form
And I have set <Street2> to address1_line2 text field in the Form
And I have set <Street3> to address1_line3 text field in the Form
And I have set <City> to address1_city text field in the Form
And I have set <State> to address1_stateorprovince text field in the Form
And I have set <ZIP> to address1_postalcode text field in the Form
And I have set <Country> to address1_country text field in the Form
And I have set <County> to address1_county text field in the Form
And I wait for 2000 specific time
And I scrolldown to End of SOURCE section
And I have set <Type> to cmc_type optionset field in the Form
And I wait for 2000 specific time
And I have set <Areaofinterest> to cmc_areaofinterestid lookup item in the Form
And I wait for 2000 specific time
And I have set <sourcemethod> to cmc_sourcemethodid lookup item in the Form
And I wait for 2000 specific time
And I have set <sourcecategory> to cmc_sourcecategoryid lookup item in the Form
And I wait for 2000 specific time
And I verify in CONTACT PREFERENCES section Sms Text field is present
And I wait for 2000 specific time
And I press Save in the form
Then the Entity should be saved
And I wait for 2000 specific time
Examples: 
| TestCase ID | Persona       | Method | Category    | Firstname | LastName  | Email          | Mobile   | City       | Street1   | Street2     | Street3     | State      | ZIP    | Country | County    | Type                | Areaofinterest       |sourcemethod  | sourcecategory |
| 1377578     | StudentAdvisor| Email  | Application | Firstname | Lastname  | Email@test.com |8976645363| Benagaluru | CVR nagar | Test Street | Demo Street | Karanataka | 560001 | India   | Bengaluru | Graduate Admissions | AreaofInterest-759377| Web Chat     | Application    |

