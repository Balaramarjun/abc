Feature: Lifecycle

@Smoke
@Regression 
Scenario:Lock the Initial Source section after Create of Lifecycle record.
Given I have logged in as a <Persona>
And I navigate to main Area and SubArea Lifecycles
When I have clicked New command in View
And I wait for 2000 specific time
And I have set <lifecycletype> to cmc_lifecycletype optionset field in the Form
And I have set <campus> to cmc_campusid lookup item in the Form
And I wait for 2000 specific time
And I have set <contact> to cmc_contactid lookup item in the Form
And I wait for 2000 specific time
And I scrolldown to End of INITIAL SOURCE section
And I wait for 2000 specific time
And I have set <areaofinterest> to cmc_areaofinterestid lookup item in the Form
And I wait for 2000 specific time
And I have set <sourcemethod> to cmc_sourcemethodid lookup item in the Form
And I wait for 2000 specific time
And I have set <sourcecategory> to cmc_sourcecategoryid lookup item in the Form
And I wait for 2000 specific time
And I press Save in the form
And I wait for 4000 specific time
And I scroll in to view of INITIAL SOURCE section
Then I verify below fields
| Type         | sectionLabel   | FieldName                           | FieldValue |
| Locked Field | INITIAL SOURCE | Locked Campus                       |            |
| Locked Field | INITIAL SOURCE | Locked Originating Inbound Interest |            |
| Locked Field | INITIAL SOURCE | Locked Date                         |            |
| Locked Field | INITIAL SOURCE | Locked Program                      |            |
| Locked Field | INITIAL SOURCE | Locked Source Program Level         |            |
And I scrolldown to End of INITIAL SOURCE section
Then I verify below fields
| Type         | sectionLabel   | FieldName                           | FieldValue |
| Locked Field | INITIAL SOURCE | Locked Campaign                     |            |
| Locked Field | INITIAL SOURCE | Locked Source Expected Start        |            |
| Locked Field | INITIAL SOURCE | Locked Method                       |            |
| Locked Field | INITIAL SOURCE | Locked Area of interest             |            |
| Locked Field | INITIAL SOURCE | Locked Category                     |            |
| Locked Field | INITIAL SOURCE | Locked Sub-Category                 |            |
| Locked Field | INITIAL SOURCE | Locked Campaign                     |            |
Then I capture screenshot

Examples: 
| TestCase ID | Persona                   | lifecycletype | campus | sourcemethod | sourcecategory | contact   |areaofinterest         |
| 756419      | BusinessUnitAdministrator | 175490001     | ALS    | Web Chat     | Application    | CMC Mansa | AreaofInterest-756419 |

@Smoke
@Regression 
@Done1
Scenario: To verify if the Campus field is made mandatory in the Lifecycle Form

#Create a contact 
Given I have logged in as a <Persona> 
And I navigate to main Area and SubArea Contacts
When I have clicked New command in View
And I have set <lastname> to lastname text field uniquely in the Form
And I scroll in to view of INITIAL SOURCE section
Then I select <contacttype> options in mshied_contacttype_i multivalue optionset
When I wait for 2000 specific time
And I scrolldown to End of INITIAL SOURCE section
Given I have set <sourcemethod> to cmc_sourcemethodid lookup item in the Form
And I have set <sourcecategory> to cmc_sourcecategoryid lookup item in the Form
And I press Save in the form
Given I select the tab <TabName> in the form  
# When I have clicked New Lifecycle command on <SubGridName> SubGrid
 When I scroll in to view of LIFECYCLES section
#And I find <subGridButton> command on <subGridName> SubGrid as per availability
And  I choose to click <subGridButton> command in Lifecyclyes SubGrid out of multiple sections in Inbound Interest & Lifecycle div if available
# And I click <subGridButton> command on <subGridName> SubGrid when available
# And I click More Commands button on <subGridName> SubGrid only if available
#And I click <subGridButton> SubGrid option on More Commands SubGrid when available
And I wait for 3000 specific time
And I press Save in the form
And I wait for 3000 specific time  
Then I validate You have 2 notifications. Select to view. notification/s in the form 
Then I capture screenshot
Given I have set <lifecycletype> to cmc_lifecycletype optionset field in the Form
And I wait for 3000 specific time
And I press Save in the form
Then I validate Campus : Required fields must be filled in. notification/s in the form 
And I press Save in the form
Given I have set <lifecycletype> to cmc_lifecycletype optionset field in the Form
And I have set <campus> to cmc_campusid lookup item in the Form
And I press Save in the form
Then the Entity should be saved
		  
Examples: 
| TestCase ID | Persona                   | lifecycletype |campus| sourcemethod | sourcecategory | contact   | lastname  | contacttype | TabName                      | SubGridName | subGridButton |
| 816875      | BusinessUnitAdministrator |175490001      | ALS  | Web Chat     | Application    | CMC Mansa | Test-Auto | Student     | Inbound Interest & Lifecycle | LIFECYCLES  | New Lifecycle |

