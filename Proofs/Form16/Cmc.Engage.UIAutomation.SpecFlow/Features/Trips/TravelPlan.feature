Feature: TravelPlan
#
#@Trips
#@Campus
#
#
#@Smoke
#@Regression					
#Scenario: TravelManagement.BPF should not move Back when Trip status is Submit for Approval at Reviewer End
#	Given I have logged in as a <Persona>
#	And I have navigated to the Area <Area> and SubArea <SubArea>
#	When I switch the view to Trips - Assigned to me for Review
#	And I search test 4 in the grid
#	And I open the first record in the grid
#	#Then The cmc_status field value should be equal to Submitted For Review
#	And I have clicked Reject command in View
#
#	And I have set <StartDate> to startdate text field uniquely in the Form
#	And I have set <EndDate> to enddate text field uniquely in the Form
#	When I press Save in the form 
#	Then the Entity should be saved
#	Given I click Ok in Confirmation dialog
#	
#	Examples:
#|TestCase ID|Persona            | Area  | SubArea | TripName | StartDate | EndDate |
#|815139     |SystemAdministrator| Engage| Trips   | Campus   | 01/01/2020 | 12/12/2020   |
#

@Smoke
@Regression					
Scenario: 01 Create a new Travel Plan(Trip) with Approval Process

   #Configuration for Approval
   Given I have logged in as a <Persona>
   And I have navigated to the Area Settings and SubArea Configurations
   And I open the first record in the grid
   And  I select the tab Trip in the form
   And I have set No to cmc_disabletripapproval optionset field in the Form
   And I press Save in the form

   #Trip1
   And I have navigated to the Area Reach and SubArea <SubArea>
   And I wait for 2000 specific time
   And I search <TripNamea> in the grid
   And I wait for 2000 specific time
   And I open the first record in the grid
   And I wait for 2000 specific time
   And I verify below fields
   | Type  | sectionLabel      | FieldName          | FieldValue                 |
   | Field | TRIP DETAILS      | Trip Name          |UIAuto-Testtrip-772573a     |
   | Field | TRIP DETAILS      | Trip Status        |Submitted For Review        |
   And I wait for 2000 specific time
   And I select Submitted For Review stage  in BPF
   And I wait for 2000 specific time
   And I enter the below data in the BPF
   | Type        | Stage                | FieldName                         | FieldValue  |
   | Field       | Submitted For Review |header_process_cmc_approvalcomment | Approved    | 
	And I wait for 2000 specific time
	And I select Reviewed stage  in BPF
	And I wait for 2000 specific time
    And I press Save in the form
    And I wait for 2000 specific time
	And I have clicked Approve command in View
	And I wait for 2000 specific time
	And I verify below fields
	| Type  | sectionLabel      | FieldName          | FieldValue              |
	| Field | TRIP DETAILS      | Trip Name          |UIAuto-Testtrip-772573a  | 
	| Field | TRIP DETAILS      | Trip Status        |Approved                 |
	And I wait for 4000 specific time
	And I have clicked Complete command in View
	And I wait for 2000 specific time
	And I handle dialog with button confirmButton
	And I wait for 2000 specific time
	And I verify below fields
	| Type  | sectionLabel      | FieldName          | FieldValue              |
	| Field | TRIP DETAILS      | Trip Name          |UIAuto-Testtrip-772573a  | 
	| Field | TRIP DETAILS      | Trip Status        |Completed                |
	And I wait for 4000 specific time


	#Trip2
	And I navigate to main Area and SubArea <SubArea>
	And I wait for 2000 specific time
	And I search <TripNameb> in the grid
	And I wait for 2000 specific time
	And I open the first record in the grid
	And I wait for 2000 specific time
	And I verify below fields
	| Type  | sectionLabel      | FieldName          | FieldValue                 |
	| Field | TRIP DETAILS      | Trip Status        |Submitted For Review        |
	| Field | TRIP DETAILS      | Trip Name          |UIAuto-Testtrip-772573b     |
	And I wait for 2000 specific time
	And I select Submitted For Review stage  in BPF
	And I wait for 2000 specific time
	And I enter the below data in the BPF
	| Type        | Stage                | FieldName                         | FieldValue |
    | Field       | Submitted For Review |header_process_cmc_approvalcomment | Rejected   | 
	And I wait for 2000 specific time
	And I select Reviewed stage  in BPF
	And I wait for 2000 specific time
    And I press Save in the form
	And I wait for 2000 specific time
	And I have clicked Reject command in View
	And I wait for 2000 specific time
	And I verify below fields
	| Type  | sectionLabel      | FieldName          | FieldValue              |
	| Field | TRIP DETAILS      | Trip Name          |UIAuto-Testtrip-772573b  | 
	| Field | TRIP DETAILS      | Trip Status        |Rejected                 |
	And I wait for 4000 specific time

	#Trip3
	And I navigate to main Area and SubArea <SubArea>
	And I wait for 2000 specific time
	And I search <TripNamec> in the grid
	And I wait for 2000 specific time
	And I open the first record in the grid
	And I wait for 2000 specific time
	And I verify below fields
	| Type  | sectionLabel      | FieldName          | FieldValue            |
	| Field | TRIP DETAILS      | Trip Name          |UIAuto-Testtrip-772573c|
	| Field | TRIP DETAILS      | Trip Status        |New                    |
	And I wait for 2000 specific time
	And I have clicked Copy command in View
	And I wait for 2000 specific time
	And I handle the dialog action button okButton only if available
	And I wait for 2000 specific time
	And I verify below fields
	| Type  | sectionLabel      | FieldName          | FieldValue                 |
	| Field | TRIP DETAILS      | Trip Name          |Copy UIAuto-Testtrip-772573c|
	| Field | TRIP DETAILS      | Trip Status        |New                         |
	And I wait for 4000 specific time

	#Create-Trip4 
	And I navigate to main Area and SubArea <SubArea>
	And I wait for 2000 specific time
	And I have clicked New command in View
	And I wait for 2000 specific time
	And I have set <TripNamed> to tripname text field uniquely in the Form
	And I wait for 2000 specific time
	And I have set next day to current date to cmc_startdate field in the Form
	And I wait for 2000 specific time
	And I have set  future date to cmc_enddate field in the Form
	And I wait for 2000 specific time
	And I verify in TRIP DETAILS section Reviewer field is present
	And I verify in TRIP DETAILS section Reviewed Date field is present
	And I verify in TRIP DETAILS section Reviewer Team field is present
	And I wait for 2000 specific time
	And I press Save in the form 
	And I wait for 2000 specific time
	And I handle the dialog action button okButton only if available
	And I wait for 2000 specific time
	Then the Entity should be saved
	And I wait for 2000 specific time
	And I verify Ribbon Button Approve is not present
	And I wait for 2000 specific time
	And I verify Ribbon Button Reject is not present
	And I wait for 2000 specific time
	And I have clicked Cancel command in View
	And I wait for 2000 specific time
	And I handle dialog with button confirmButton
	And I wait for 2000 specific time
	And I verify below fields
	| Type  | sectionLabel      | FieldName          | FieldValue       |
	| Field | TRIP DETAILS      | Trip Status        |Canceled          |
	And I wait for 4000 specific time
	
	
 Examples:
 | Test Case ID | Persona      | Area        | SubArea | TripNamea               | TripNameb               | TripNamec               | TripNamed        |
 | 772573       | TripReviewer | Recruitment | Trips   | UIAuto-Testtrip-772573a | UIAuto-Testtrip-772573b | UIAuto-Testtrip-772573c | Testtrip-772573d |

@Smoke
@Regression	
 Scenario: 02 Create a new Travel Plan(Trip) without Approval Process

   #Configuration for Approval
   Given I have logged in as a <Persona>
   And I have navigated to the Area Settings and SubArea Configurations
   And I open the first record in the grid
   And  I select the tab Trip in the form
   And I have set Yes to cmc_disabletripapproval optionset field in the Form
   And I press Save in the form

   #Create Trip
   And I have navigated to the Area Reach and SubArea <SubArea>
   And I have clicked New command in View
   And I have set <TripName> to tripname text field uniquely in the Form
   And I have set next day to current date to cmc_startdate field in the Form
   And I wait for 2000 specific time
   And I have set  future date to cmc_enddate field in the Form
   And I wait for 2000 specific time
   When I verify the Reviewer field is not present in the TRIP DETAILS section of the form
   When I verify the Reviewed Date field is not present in the TRIP DETAILS section of the form
   When I verify the Reviewer Team field is not present in the TRIP DETAILS section of the form
   And I wait for 2000 specific time
   And I press Save in the form 
   And I wait for 2000 specific time
   And I handle the dialog action button okButton only if available
   And I wait for 2000 specific time
   Then the Entity should be saved
   And I wait for 2000 specific time
   
Examples:
 | Test Case ID | Persona      | SubArea | TripName        |
 | 1399418      | TripReviewer | Trips   | Testtrip-1399418|



#@Smoke
#@Regression
#Scenario: 02 Create Trip Activity
#		Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#		When I search <TripName> in the grid
#		And I open the first record in the grid
#		Given I select the tab <TabName> in the form
#		And I have clicked New Trip Activity command in View
#		And I click new button for  <LookupName> lookup field	
#		And I have set <Subject> to subject text field in the Form
#		Given I press Save in QuickCreate
#		Then the QuickCreate should be saved
#		Given I have set <TripActivityType> to cmc_purpose optionset field in the Form
#		When I press Save in the form
#		Then the Entity should be saved
#		Given I click Ok in Confirmation dialog
#
#	Examples: 
#	| case               | Persona | Area        | SubArea | TripName | TabName         | LookupName              | Subject | TripActivityType |
#	| CreateTripActivity | AutomationUser | Recruitment | Trips   | Campus   | Trip Activities | cmc_linkedtoappointment | TestSub | 3        |
#
#@Regression
#Scenario: 03 Update Trip Activity
#	    Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#	    When I search <TripName> in the grid
#	 	And I open the first record in the grid
#		Given I select the tab <TabName> in the form
#		And I open the first record in the grid
#		And  I select the tab <TabName2> in the form
#		When I have clicked More Commands command on <SubGridName> SubGrid
#	    And I have clicked <subGridOption> SubGrid option on More Commands SubGrid
#	    Then I have set <lookupDialogValue> to lookupDialogContainer field in the lookup dialog
#		And I click true button in the lookup dialog
#		Given I select the tab <TabName3> in the form
#		When I have set <transportValue> to cmc_estdtransportation text field in the Form
#		And I press Save in the form 
#	    Then the Entity should be saved
#		Given I select the tab <TabName4> in the form
#		When I have set <Comments> to cmc_ratingcomments text field in the Form
#		And I press Save in the form
#	    Then the Entity should be saved
#
#	Examples: 
#	| case                 | Persona | Area        | SubArea | TripName | TabName         | TabName2           | SubGridName              | subGridOption     | lookupDialogValue | TabName3        | TabName4  | Comments | transportValue |
#	| Update Trip Activity | AutomationUser | Recruitment | Trips   | Campus   | Trip Activities | Staff & Volunteers | ADDITIONAL STAFF MEMBERS | Add Existing User | Rahul Sharma      | Expense Details | Post Trip | Test     |   35             |
#	
#	Scenario: 04 Trip Approval Process & Email Invite
#	Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#	      When I search <TripName> in the grid
#		And I open the first record in the grid  
#		Then I complete <Stage1> stage  in BPF
#		And  I select <Stage2> stage  in BPF
#	#	Given  I enter the below data in the BPF
#		   # | Type        | Stage | FieldName            | FieldValue              |
#		   # | BooleanItem |       | cmc_travelersdetails |                         |
#		   # | BooleanItem |       | cmc_tripactivitydetails |                      |
#		   # | BooleanItem |       | cmc_estimatedexpensedetails|                   |
#		#Then I complete <Stage2> stage  in BPF
#		#Given I have logged in as a <Persona2>
#		#Then I have navigated to the Area <Area> and SubArea <SubArea>
#	 #    When I search <TripName> in the grid
#		#And I open the first record in the grid  
#		#Then I select <Stage3> stage  in BPF
#		#Given I enter the below data in the BPF
#		#  | Type        | Stage               | FieldName                         | FieldValue |
#		#  | Field       | Submitted For Review      |header_process_cmc_approvalcomment | Test Comment|  
#  #      And  I select the tab <TabName> in the form
#  #      When I open the first record in the grid
#  #      And I have set <TripActivityStatus> to cmc_tripactivitystatus optionset field in the Form
#		#And I press Save in the form
#	 #   Then the Entity should be saved 
##Given I have logged in as a <Persona>
#		#And I have navigated to the Area <Area> and SubArea <SubArea>
#	 #     When I search <TripName> in the grid
#	#	And I open the first record in the grid  
#   # Given  I select the tab <TabName> in the form
#   # Then I open record no. <RecordNo> in the grid
#	#And I have clicked Send Email command in View
#  #  And I click Ok in Confirmation dialog
#
#
#
#	Examples: 
#	| case                  | Persona        | Area        | SubArea | TripName | Stage1      | Stage2                 | Persona2 | Stage3               | TabName         | TripActivityStatus | RecordNo |
#	| Trip Approval & Email | AutomationUser | Recruitment | Trips   | Campus   | Create Trip | Review Before Approval | Reviewer | Submitted For Review | Trip Activities | 175490003          |    1      |