Feature: TestScore

@Apply
Scenario: 01 Create Test Score
Given I have logged in as a <StudentAdvisor> 
And I navigate to main Area and SubArea <SubArea>
And I have clicked New command in View
And I have set <LastName> to lastname text field uniquely in the Form
When I scroll in to view of INITIAL SOURCE section
Then I select Recommender options in mshied_contacttype_i multivalue optionset
When I press Save in the form
Then the Entity should be saved
And I wait for 2000 specific time
Given I select the tab Student Records in the form
#When I have clicked <subGridButton> command on <subGridName> SubGrid
And I click <subGridButton> command on <subGridName> SubGrid when available
 And I click More Commands button on <subGridName> SubGrid only if available
And I click <subGridButton> SubGrid option on More Commands SubGrid when available	
When I select SAT Form
Then I click Discard changes in Confirmation dialog
When I wait for 3000 specific time
#And I have set <TestDate> to mshied_testdate date field in the Form
When I have set date value <TestDate> to Test Date field in the Form
And I wait for 3000 specific time
And I set Official option to mshied_testsource PCF control field in General section
And I wait for 2000 specific time
And I scroll in to view of TEST COMPONENTS section
Then I verify below fields
| Type  | sectionLabel | FieldName                                  | FieldValue |
| Field | General      | Include in Score Calculations              | true       |
| Field | General      | Evidence-Based Reading and Writing Section |            |
| Field | General      | Math Section                               |            |
| Field | General      | SAT Essay - Analysis                       |            |
| Field | General      | SAT Essay - Reading                        |            |
| Field | General      | SAT Essay - Writing                        |            |
| Field | General      | Total Score                                |            |
| Field | General      | ACT Equivalent Score                       |            |

When I have set Bangalore to mshied_testlocation text field in the Form
And I have set 600 to mshied_satevidencebasedreadingandwritingsection numeric field in the Form
And I have set 700 to mshied_satmathsection numeric field in the Form
And I have set 6 to mshied_satessayanalysis numeric field in the Form
And I have set 6 to mshied_satessayreading numeric field in the Form
And I have set 6 to mshied_satessaywriting numeric field in the Form
And I have set 1100 to mshied_sattotalscore numeric field in the Form
When I press Save in the form
Then the Entity should be saved
And mshied_actequivalentscore field value should not be empty
And I click mshied_studentid locked lookup field in General section
Given I select the tab Student Records in the form
And I click <subGridButton> command on <subGridName> SubGrid when available
 And I click More Commands button on <subGridName> SubGrid only if available
And I click <subGridButton> SubGrid option on More Commands SubGrid when available	
When I select ACT Form
Then I click Discard changes in Confirmation dialog
When I wait for 2000 specific time
Then I verify below fields
| Type  | sectionLabel | FieldName                     | FieldValue |
| Field | General      | Contact                       |            |
| Field | General      | Test Date                     |            |
| Field | General      | Test Source                   |            |
| Field | General      | Test Location                 |            |
| Field | General      | Composite                     |            |
| Field | General      | SAT Equivalent Score          |            |
And I scroll in to view of TEST COMPONENTS section
Then I verify below fields
| Type  | sectionLabel | FieldName                     | FieldValue |
| Field | General      | Math                          |            |
| Field | General      | Science                       |            |
| Field | General      | Include in Score Calculations |            |
| Field | General      | English                       |            |
| Field | General      | Reading                       |            |
| Field | General      | Writing                       |            |
| Field | General      | STEM                          |            |
| Field | General      | ELA                           |            |  
And I verify in General section Locked SAT Equivalent Score field is locked
#When I have set <TestDate> to mshied_testdate date field in the Form
When I wait for 3000 specific time
When I have set date value <TestDate> to Test Date field in the Form
And I wait for 4000 specific time
And I set Self - Reported option to mshied_testsource PCF control field in General section
And I wait for 3000 specific time
And I have set Bangalore to mshied_testlocation text field in the Form
And I have set 32 to mshied_actmath numeric field in the Form
And I have set 32 to mshied_actscience numeric field in the Form
And I have set 32 to mshied_actenglish numeric field in the Form
And I have set 32 to mshied_actreading numeric field in the Form
And I have set 30 to mshied_actcomposite numeric field in the Form
When I press Save in the form
Then the Entity should be saved
And I wait for 2000 specific time
And cmc_satequivalentscore field value should not be empty

And I have clicked New command in View
And I select ACT Form
Then I click Discard changes in Confirmation dialog
When I wait for 3000 specific time
Then I verify below fields
| Type  | sectionLabel | FieldName                     | FieldValue |
| Field | General      | Contact                       |            |
| Field | General      | Test Date                     |            |
| Field | General      | Test Source                   |            |
| Field | General      | Test Location                 |            |
| Field | General      | Composite                     |            |
| Field | General      | SAT Equivalent Score          |            |
And I scroll in to view of TEST COMPONENTS section
Then I verify below fields
| Type  | sectionLabel | FieldName                     | FieldValue |
| Field | General      | Math                          |            |
| Field | General      | Science                       |            |
| Field | General      | Include in Score Calculations |            |
| Field | General      | English                       |            |
| Field | General      | Reading                       |            |
| Field | General      | Writing                       |            |
| Field | General      | STEM                          |            |
| Field | General      | ELA                           |            |  
And I verify in General section Locked SAT Equivalent Score field is locked
# IELTS form
When I select IELTS Form
Then I click Discard changes in Confirmation dialog
When I wait for 3000 specific time
And I verify below fields
| Type  | sectionLabel | FieldName          | FieldValue |
| Field | General      | Contact            |            |
| Field | General      | Test Date          |            |
| Field | General      | Test Source        |            |
| Field | General      | Test Location      |            |
| Field | General      | Overall Band Score |            |
| Field | General      | CEFR               |            |
And I scroll in to view of TEST COMPONENTS section
Then I verify below fields
| Type  | sectionLabel | FieldName                     | FieldValue |
| Field | General      | Listening          |            |
| Field | General      | Reading            |            |
| Field | General      | Writing            |            |
| Field | General      | Speaking Score     |            |
# GMAT
When I select GMAT Form
Then I click Discard changes in Confirmation dialog
When I wait for 3000 specific time
And I verify below fields
| Type  | sectionLabel | FieldName              | FieldValue |
| Field | General      | Contact                |            |
| Field | General      | Test Date              |            |
| Field | General      | Test Source            |            |
| Field | General      | Test Location          |            |
| Field | General      | Total                  |            |
And I scroll in to view of TEST COMPONENTS section
Then I verify below fields
| Type  | sectionLabel | FieldName                     | FieldValue |
| Field | General      | Analytical Writing     |            |
| Field | General      | Integrated Reasoning   |            |
| Field | General      | Quantitative Reasoning |            |
| Field | General      | Verbal Reasoning       |            |
# GRE
When I select GRE Form
Then I click Discard changes in Confirmation dialog
When I wait for 3000 specific time
And I verify below fields
| Type  | sectionLabel | FieldName              | FieldValue |
| Field | General      | Contact                |            |
| Field | General      | Test Date              |            |
| Field | General      | Test Source            |            |
| Field | General      | Test Location          |            |
| Field | General      | Total Score            |            |
And I scroll in to view of TEST COMPONENTS section
Then I verify below fields
| Type  | sectionLabel | FieldName                     | FieldValue |
| Field | General      | Analytical Reasoning   |            |
| Field | General      | Quantitative Reasoning |            |
| Field | General      | Verbal Reasoning       |            |

# TOEFL
When I select TOEFL Form
Then I click Discard changes in Confirmation dialog
When I wait for 3000 specific time
And I verify below fields
| Type  | sectionLabel | FieldName         | FieldValue |
| Field | General      | Contact           |            |
| Field | General      | Test Date         |            |
| Field | General      | Test Source       |            |
| Field | General      | Test Location     |            |
| Field | General      | Total Score       |            |
And I scroll in to view of TEST COMPONENTS section
Then I verify below fields
| Type  | sectionLabel | FieldName          | FieldValue |
| Field | General      | Listening Section |            |
| Field | General      | Reading Section   |            |
| Field | General      | Speaking Section  |            |
| Field | General      | Writing Section   |            |

# OLD SAT
#When I select OLD SAT Form
#Then I click Discard changes in Confirmation dialog
#When I wait for 3000 specific time
#And I verify below fields
#| Type  | sectionLabel | FieldName                | FieldValue |
#| Field | General      | Contact                  |            |
#| Field | General      | Test Date                |            |
#| Field | General      | Test Source              |            |
#| Field | General      | Test Location            |            |
#| Field | General      | New SAT Equivalent Score |            |
#| Field | General      | Total Composite Score    |            |
#| Field | General      | Critical Reading         |            |
#| Field | General      | Mathematics              |            |
#| Field | General      | Writing                  |            |
#| Field | General      | SAT Essay                |            |


Examples: 
| Test Case ID | StudentAdvisor | Area         | SubArea  | LastName  | subGridName | subGridButton  |TestDate  | TestSource |
| 803241       | StudentAdvisor | Constituents | Contacts | YashiTest | TEST SCORES | New Test Score |04/09/2020| 494280000  |