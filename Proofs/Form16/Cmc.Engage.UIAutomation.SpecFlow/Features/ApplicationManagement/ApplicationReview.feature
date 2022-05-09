Feature: ApplicationReview

@ApplicationManagement
@ReviewBundle
@Regression

#Scenario: Application Review-Validate Popup if reviewer not associated
#		Given I have logged in as a <Coordinator>
#		And I switch to Application Review App
#		#Then I navigate to the Area <Area>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#		And I have clicked New command in View
#	     #provide the dates only in MM/dd/yyyy format
#		When I have set <BundleName> to cmc_bundlename text field uniquely in the Form
#		When I wait for 1000 specific time
#		And I have set <CutoffDate> to cmc_cutoffdate date field in the Form
#		When I wait for 1000 specific time
#		And I have set <DueDate> to cmc_duedate date field in the Form
#		When I press Save in the form
#		Then the Entity should be saved
#		When I select the tab <TabName> in the form
#		And I have clicked Activate command in View
#		And I wait for 2000 specific time
#		#Then I switch to active element
#		And I click Activate button in dialog
#		#Then I click Ok in Confirmation dialog
#		And I wait for 2000 specific time
#		#Then I capture screenshot
#			
#Examples: 
#| TestCase ID | Coordinator      | Area     | SubArea | BundleName | CutoffDate | DueDate | TabName | SubGridName | UserName |
#|  951878     | ApplicationAdmin | Reviewer | Review Bundles | ReviewBundleUIAutomation | 04/08/2021 | 05/08/2021 | Reviewers | All Users   | Rahul Sharma |

@Regression
Scenario: Verify that Reviewers able to see application review details in Review Summary screen
		Given I have logged in as a <Coordinator>
		And I switch to Application Review App
		And I have navigated to the Area <Area> and SubArea <SubArea>
		When I search <BundleName> in the grid
		And I open the first record in the grid
		When I select the tab <TabName> in the form
		#And I wait for 5000 specific time
		#Then I verify below <ReviewsbyBundle> <ReviewMethod> in Review tab in ApplicationReview 
		#Then I verify below fields

		  #| Type  | sectionLabel | FieldName                          | FieldValue |
		 # | Field | General      | Reviews by Bundle				  |            |
		  #| Field | General      | Review Method					  |            |
		#Then I capture screenshot
			
Examples: 
| TestCase ID | Coordinator      | BundleName              | Area     | SubArea             | TabName | SubGridName | UserName     | ReviewsbyBundle | ReviewMethod |
| 954345      | ApplicationAdmin | UIAuto Contact- 954345- | Reviewer | Application Reviews | Reviews | All Users   | Rahul Sharma | Reviews by Bundle | Review Method |

@ReviewBundle
@Regression
@Done
Scenario: A custom warning message should appear before deletion
		Given I have logged in as a <Coordinator>
		And I switch to Application Review App
		And I have navigated to the Area <Area> and SubArea <SubArea>
		When I search <BundleName> in the grid
		And I open the first record in the grid
		And I have clicked Delete command in View
		Then I verify <warningmessage> in Confirmation dialog
		And I handle dialog with button cancelButton
		#Then I capture screenshot
			
Examples: 
| TestCase ID | Coordinator      | Area     | SubArea        | BundleName     | TabName | warningmessage |
|1047024      | ApplicationAdmin | Reviewer | Review Bundles | Bundle-1047024 | Reviews | Do you want to delete this Review Bundle? You can't undo this action. |

@ApplicationManagement
@ReviewBundle
Scenario: 04 Validate flow to generate pdf when application is assigned to a Review Bundle
# Need to change app to 'AppReview' before running
# All App Review flows should be enabled before running the script

		Given I have logged in as a <Reviewer>
		And I switch to Application Review App
		And I have navigated to the Area <Area> and SubArea <SubArea>
		And I search <ReviewRecord> in the grid
		And I open the first record in the grid
		Then I select <FormName> Form
		#And I capture screenshot
		
			
Examples: 
| TestCase ID | Reviewer         | Area     | SubArea             | FormName             | ReviewRecord            |
| 1050231     | ApplicationAdmin | Reviewer | Application Reviews | Review Form with PDF | UIAuto Contact- 954345- |
