Feature: ApplicationRequirement

@ApplicationManagement
@Requirement
Scenario: 01 Create Requirement Definition

Given I have logged in as a <Persona> 
		And I have navigated to the Area Process Config and SubArea Requirement Definitions
		And I have clicked New command in View
		And I have set <RequirementName> to cmc_applicationrequirementdefinitionname text field uniquely in the Form
		#And I have set <ApplicationStatus> to cmc_applicationstatus optionset field in the Form
		When I press Save in the form
		Then the Entity should be saved
			
Examples: 
|TestCase ID|Persona         |RequirementName        |ApplicationStatus|
|839631     |ApplicationAdmin|Application Requirement|175490001        |

  
#@Smoke
#@Regression
#Scenario: 02 Create Requirement Definition Detail with Upload Requirement Type
#Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea> 
#		When I search <RequirementName> in the grid
#		And I open the first record in the grid
#		When I have clicked New Requirement Definition Detail command on <SubGridName> SubGrid
#		When I have set <RequirementTypeUpload> to cmc_requirementtype optionset field in the Form
#		And I have set <RequirementDefinitionDetailName> to cmc_name text field in the Form
#		And I have set <StatusOnSubmit> to cmc_statusonsubmit optionset field in the Form
#		When I press Save in the form
#		Then the Entity should be saved
#
#Examples: 
#| Persona | Area           | SubArea                 | RequirementName         | ApplicationStatus | SubGridName                        | RequirementTypeUpload | RequirementDefinitionDetailName | StatusOnSubmit |
#| AutomationUser | Process Config | Requirement Definitions | Application Requirement | 175490001         | REQUIREMENT DEFINITION DETAILS | 175490001       | RequirementDefinitionDetail - Upload    | 175490001     |
#
#@Smoke
#@Regression
#Scenario: 02 Create Requirement Definition Detail with General Requirement Type
#Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#		When I search <RequirementName> in the grid
#		And I open the first record in the grid
#		When I have clicked New Requirement Definition Detail command on <SubGridName> SubGrid
#		When I have set <RequirementTypeGeneral> to cmc_requirementtype optionset field in the Form
#		And I have set <RequirementDefinitionDetailName> to cmc_name text field in the Form
#		And I have set <StatusOnSubmit> to cmc_statusonsubmit optionset field in the Form
#		When I press Save in the form
#		Then the Entity should be saved
#
#Examples: 
#| Persona        | Area           | SubArea                 | RequirementName         | ApplicationStatus | SubGridName                   | RequirementTypeGeneral | RequirementDefinitionDetailName          | StatusOnSubmit |
#| AutomationUser | Process Config | Requirement Definitions | Application Requirement | 175490001         | REQUIREMENT DEFINITION DETAILS| 175490000              | RequirementDefinitionDetail - General    | 175490001      |
#
#@Smoke
#@Regression
#Scenario: 02 Create Requirement Definition Detail with TestScore Requirement Type
#Given I have logged in as a <Persona>
#		And I have navigated to the Area <Area> and SubArea <SubArea>
#		When I search <RequirementName> in the grid
#		And I open the first record in the grid
#		When I have clicked New Requirement Definition Detail command on <SubGridName> SubGrid
#		When I have set <RequirementTypeTestScore> to cmc_requirementtype optionset field in the Form
#		Then I verify below fields
#		  | Type  | sectionLabel | FieldName           | FieldValue |
#		  | Field | General      | Test Score Type     |            |
#		  | Field | General      | Test Source Type    |            |
#		
#		When I have set <DeadLine> to cmc_requirementdeadline text field in the Form
#		Then I update the <required> field in the form
#		When I have set <TestScoreType> to cmc_testscoretype lookup field in the Form
#		When I have set <TestSourceType> to cmc_testsourcetype optionset field in the Form
#		And I have set <StatusOnSubmit> to cmc_statusonsubmit optionset field in the Form
#		When I press Save in the form
#		Then the Entity should be saved
#
#Examples: 
#| Persona | Area           | SubArea                 | RequirementName         | ApplicationStatus | SubGridName                    | RequirementTypeTestScore| RequirementDefinitionDetailName          | StatusOnSubmit | DeadLine   | required                | TestScoreType | TestSourceType |
#| AutomationUser | Process Config | Requirement Definitions | Application Requirement | 175490001         | REQUIREMENT DEFINITION DETAILS | 175490003              | RequirementDefinitionDetail - Test Score | 175490001      | 01/01/2021 | cmc_requirementrequired | ACT           | 494280000      |


Scenario: 03 Create & Validate 'Recommendation Definition & Definition Details' forms
       #User should be logged in as Application Admin
	    Given I have logged in as a <Persona>		
	And I have navigated to the Area <Area> and SubArea <SubArea>
		And I have clicked New command in View
	    Then I verify below fields
		  | Type  | sectionLabel| FieldName                          | FieldValue |
		  | Field | General     | Recommendation Definition Name     |            |
		  | Field | General     | Recommendation Invitation Workflow |            |
		  | Field | General     | Recommendation Thank You Workflow  |            |
		  | Field | General     | Send on Behalf of Student          |            |
		When I have set <RecommendationDefinitionName> to cmc_applicationrecommendationdefinitionname text field uniquely in the Form
		And I have set <InvitationWorkFlow> to cmc_recommendationinvitationworkflow lookup item in the Form
		And I wait for 2000 specific time
		And I have set <ThankyouWorkflow> to cmc_recommendationthankyouworkflow lookup item in the Form
		And I wait for 2000 specific time
		And I press Save in the form
		Then the Entity should be saved
		When I wait for 2000 specific time
		And The handle live assist pop-up only if available
		When I have clicked <subGridButtonName> command on <subGridName> SubGrid
		And I verify in General section <FieldName> field is locked
		And  I have set <RecommendationType> to cmc_recommendationtype optionset field in the Form
		And I have set <NoOfRecommendations> to cmc_noofrecommendations numeric field in the Form
		And I press Save in the form 
		Then the Entity should be saved

Examples: 

|TestCaseID | Persona          | Area           | SubArea                    | FieldName                       | RecommendationDefinitionName | InvitationWorkFlow    | ThankyouWorkflow        | subGridButtonName                    | subGridName                       | RecommendationType | NoOfRecommendations |
|840842     | ApplicationAdmin | Process Config | Recommendation Definitions | Locked Recommendation Definition|Application Recommendation    | cmc_RecInviteWorkflow | Recommendation_Thankyou | New Recommendation Definition Detail | RECOMMENDATION DEFINITION DETAILS | 175490001          | 3                   |


Scenario: 04 Application Recommendation business logic/rules - Send & Resend Request
 #User should be logged in as Application Admin
 #Should have a Application registration and Application record in the system  
 #Should have Recommendation definition , make sure to select related work flows for
 #"Recommendation Invitation Workflow" & "Recommendation Thank you Workflow "  
	    Given I have logged in as a <ApplicationAdmin>
		And I navigate to main Area and SubArea <SubArea>
		When I search <Application> in the grid
		When I wait for 4000 specific time
		And I open the first record in the grid
		And I wait for 2000 specific time
		Given I select the tab Recommendations in the form
		When I wait for 2000 specific time
	    #When I have clicked Add New Recommendation command on RECOMMENDATIONS SubGrid
		And I click New Recommendation command on RECOMMENDATIONS SubGrid when available
		And I click More commands for Recommendation button on RECOMMENDATIONS SubGrid only if available
		And I click New Recommendation SubGrid option on More Commands SubGrid when available

		And  I have set <RecommendationType> to cmc_recommendationtype optionset field in the Form
	    
		When I wait for 10000 specific time
		And I have set <RecommendBy> to cmc_recommendedbyid lookup item in the Form
		And I press Save in the form
		Then the Entity should be saved
		When I wait for 3000 specific time
		Given I have clicked Send Request command in View
		#And I click Ok button in dialog
		When I wait for 2000 specific time
	And I handle the dialog action button okButton only if available
		When I wait for 2000 specific time
		#Then I click Ok in Confirmation dialog
		#And I have clicked Resend Request command in 
		#And I click Ok in Confirmation dialog	

Examples: 
| TestCaseID | ApplicationAdmin | Area   | SubArea      | Application           | RecommendationType | RecommendBy |
| 845653     | ApplicationAdmin | Reach | Applications | UIAuto Contact- 845653 |175490001         | CMC Mansa|


Scenario: 05 Upload document for Recommendation
  #User should be logged in as Application Admin
  #Should have an Application registration and application for a contact. 

		Given I have logged in as a <ApplicationAdmin>
		And I navigate to main Area and SubArea <SubArea>
		And I search <Application> in the grid
		When I wait for 2000 specific time
		And I open the first record in the grid
		When I wait for 2000 specific time
		And I select the tab Recommendations in the form
		And I click New Recommendation command on RECOMMENDATIONS SubGrid when available
		And I click More commands for Recommendation button on RECOMMENDATIONS SubGrid only if available
		And I click New Recommendation SubGrid option on More Commands SubGrid when available

		And  I have set <RecommendationType> to cmc_recommendationtype optionset field in the Form
	And I wait for 2000 specific time
	And I have set <RecommendBy> to cmc_recommendedbyid lookup item in the Form
	    When I press Save in the form 
		Then the Entity should be saved
		And I wait for 4000 specific time
		And I scroll in to view of ATTACHMENTS section
		And I wait for 4000 specific time
	    Then I browse <FilePath> File in ATTACHMENTS section
		And I scrolldown to End of ATTACHMENTS section
		And I click Add button in Note section
		When I press Save in the form 
		Then the Entity should be saved
		And I handle the dialog action button Ok only if available

Examples: 
| TestCaseID | ApplicationAdmin | Area   | SubArea      | Application            | RecommendationType | RecommendBy | FilePath                   |
| 846115     | ApplicationAdmin | Engage | Applications | UIAuto Contact-846115- | 175490001          | CMC Mansa   | SampleAcceptanceLetter.docx|

Scenario: 06 Upload document for Requirements
#User should be logged in as Application Admin
#Should have an Application registration and application for a contact

		Given I have logged in as a <ApplicationAdmin>
		And I navigate to main Area and SubArea <SubArea>
		And I search <Application> in the grid
		And I open the first record in the grid
		When I wait for 2000 specific time
		And I select the tab Requirements in the form
		When I wait for 2000 specific time
	    When I have clicked <subGridButtonName> command on <subGridName> SubGrid
		And I click <subGridButtonName> command on <subGridName> SubGrid when available
		And I click More commands for Requirements button on REQUIREMENTS SubGrid only if available
		And I click New Requirement SubGrid option on More Commands SubGrid when available


		When I wait for 2000 specific time
	    And I have set <RequirementName> to cmc_applicationrequirementname text field uniquely in the Form
	    And  I have set <RequirementType> to cmc_requirementtype optionset field in the Form
	    When I press Save in the form 
	    Then the Entity should be saved
		And I wait for 3000 specific time
		And I scroll in to view of ATTACHMENTS section
		And I wait for 1000 specific time
	    Then I browse <FilePath> File in ATTACHMENTS section
		And I scrolldown to End of ATTACHMENTS section
		And I wait for 1000 specific time
		And I click Add button in Note section		
		And I press Save in the form 
		Then the Entity should be saved


Examples: 
| TestCaseID | ApplicationAdmin | Area   | SubArea      | Application           | subGridButtonName | subGridName | RequirementName | RequirementType | RecommendBy |FilePath                               |
|846499      | ApplicationAdmin | Reach | Applications | UIAuto Contact-846499-| New Requirement   | REQUIREMENTS | Test Upload Req | 175490001     | CMC Mansa    |SampleAcceptanceLetter.docx|        


Scenario: 08 Verify mass decision is created only if records from the same App Defn Version are selected
        Given I have logged in as a <ApplicationAdmin>
		And I navigate to main Area and SubArea <SubArea>
		And I search <ApplicationName> in the grid
		And I select record no. 0 in the grid
		And I select record no. 1 in the grid
		And I select record no. 2  in the grid
		And I select record no. 3  in the grid
		And I select record no. 4  in the grid
		And I have clicked Create Decision command in View
		Then I wait for 5000 specific time 
		And I switch to <WindowName> window 
		And I switch to FullPageWebResource frame  
		   And I wait for 3000 specific time
	And I have set Admit to decisionStatusTemplates Kendo text field in dialog window
	    And I click Create button in the window 
		And I wait for 2000 specific time
		And I switch back to main window
		And I have clicked Create Decision command in View  
		Then I switch to <WindowName> window 
		When I wait for 1000 specific time
	    Then I switch to FullPageWebResource frame  
		And I have set Admit With Conditions to decisionStatusTemplates Kendo text field in dialog window
		When I wait for 1000 specific time
		Then I click Create button in the window
		And I wait for 2000 specific time
		And I switch back to main window	

Examples: 
| TestCaseID| ApplicationAdmin | Area   | SubArea      | ApplicationName         | WindowName           | 
| 1012488   | ApplicationAdmin | Reach | Applications | UIAuto Contact-1012488| CreateDecision.html - Dynamics 365 |

@Testcase09
Scenario: 09 Verify the decision should not be applied to application if existing decision is published.
        Given I have logged in as a <ApplicationAdmin>
		And I navigate to main Area and SubArea <SubArea>
		And I search <ApplicationName> in the grid
		And I select record no. 0 in the grid
		And I have clicked Create Decision command in View   
		Then I switch to <WindowName> window 
		When I wait for 4000 specific time
		Then I switch to FullPageWebResource frame 
		And I wait for 2000 specific time
		And I have set Admit to decisionStatusTemplates Kendo text field in dialog window
		When I wait for 2000 specific time
		Then I set Published in the dialog window drop down
		When I wait for 2000 specific time
	    Then I click Create button in the window  
		And I wait for 2000 specific time
		Then I switch back to main window
		And I wait for 2000 specific time
		When I open the first record in the grid
		And I select the sub tab Decisions of tab Related in the form
		And I open the first record in the grid
		When I wait for 2000 specific time
        And I verify below fields
        | Type | sectionLabel | FieldName  | FieldValue   |
        | Field | General | Decision Status| Admit        |
        | Field | General | Publish Status | Published    |
        When I wait for 2000 specific time
	    Given I navigate to main Area and SubArea <SubArea>
		And I search <ApplicationName> in the grid
		And I select record no. 0 in the grid
        And I have clicked Create Decision command in View   
	    Then I switch to <WindowName> window
		When I wait for 2000 specific time
		Then I switch to FullPageWebResource frame  
		And I have set Rejected to decisionStatusTemplates Kendo text field in dialog window
		When I wait for 2000 specific time
		Then I set Published in the dialog window drop down
		When I wait for 2000 specific time
		Then I click Create button in the window 
		And  I wait for 2000 specific time
		And I switch back to main window
		When I open the first record in the grid
		And I select the sub tab Decisions of tab Related in the form
	    And I search <Decision> in the grid
		Then I should not see any records listed
	

Examples: 
| TestCaseID| ApplicationAdmin | Area   | SubArea      | ApplicationName        | WindowName                                   |Decision|
| 1014038   | ApplicationAdmin | Reach | Applications | UIAuto Contact-1014038 | CreateDecision.html - Dynamics 365 | UIAuto Contact-1014038- - Rejected |

Scenario: 10 To validate the Discount Code functionality UI checks

		Given I have logged in as a <Advisor>
		And I navigate to main Area and SubArea <SubArea>
		And I have clicked New command in View
        When I select Application Fee Invoice Form
		And I wait for 2000 specific time
		#And I click Discard changes button in dialog only if available
   And I handle the dialog action button cancelButton only if available
		And I have set Invoice1-905176 to name text field in the Form
		And I wait for 2000 specific time
		Then I verify below fields
		  | Type  | sectionLabel | FieldName   | FieldValue |
		  | Field | INVOICE INFORMATION      | Name        |            |
		  | Field | INVOICE INFORMATION      | Application |            |
		  | Field | INVOICE INFORMATION      | Decision    |            |
		  | Field | INVOICE INFORMATION      | Customer    |            |
		  | Field | INVOICE INFORMATION      | Price List  |            |
		  | Field | INVOICE INFORMATION      | Due Date    |            |

		  And I scroll to Product Line Item Totals section having Detail Amount field
		  And I verify in Product Line Item Totals section Detail Amount field is locked
		  And I verify in Product Line Item Totals section Discount Code field is locked
		  And I verify in Product Line Item Totals section Invoice Discount Amount field is locked
		  And I verify in Product Line Item Totals section Total Amount field is locked
		  When I have set UIAuto Contact 905176 to cmc_applicationid lookup item in the Form
		  And I verify below fields
		  | Type  | sectionLabel | FieldName     | FieldValue |
		  | Field | Product Line Item Totals      | Discount Code |            |
		  And I wait for 2000 specific time
		  And I have set UIAuto DiscountCode1-905176 to cmc_discountcodeid lookup item in the Form
		  And I wait for 2000 specific time
		  And I verify in Product Line Item Totals section Discount Code Amount field is locked		  		  
		  And I press Save in the form
		  Then the Entity should be saved

		  When I have clicked New command in View
		  And I have set Invoice2-905176 to name text field in the Form
		  And I have set UIAuto Contact 905176 to cmc_applicationid lookup item in the Form
		  And I have set UIAuto DiscountCode2-905176 to cmc_discountcodeid lookup item in the Form
		  And I verify in Product Line Item Totals section Discount Code % field is locked
		  And I press Save in the form
		  Then the Entity should be saved		

Examples: 
| TestCaseID | Advisor | Area   | SubArea  |
| 905176     | Advisor | Reach | Invoices |


@Smoke
@Regression
Scenario: 15 Associating Multiple Program to One Application Type
        Given I have logged in as a <ApplicationAdmin>
		And I have navigated to the Area <Area> and SubArea <SubArea>
		And I wait for 2000 specific time
		And I have clicked New command in View
		When I have set <Application Type Name> to cmc_applicationtypename text field uniquely in the Form
		When I have set <ApplicationGroup> to cmc_applicationgroup optionset field in the Form
		When I press Save in the form
		Then the Entity should be saved
		
		#When I have clicked Add Existing Program command on <SubGridName> SubGrid
		And I click Add Existing Program command on <subGridName> SubGrid when available

		And I choose to click Add Existing Program command in applicationtypeprogram SubGrid out of multiple sections in Application Type div if available
		And I wait for 3000 specific time
		And I have set <lookupDialogValue1> to lookupDialogLookup field in the lookup SearchBox
		And I wait for 2000 specific time
		And I have set <lookupDialogValue2> to lookupDialogLookup field in the lookup SearchBox
		And I click true button in the lookup dialog
		And I wait for 5000 specific time
		And I select record no.0 in the grid
        And I select record no.1 in the grid
		
		
Examples: 
|TestCaseID| ApplicationAdmin | Area       | SubArea           | Application Type Name | ApplicationGroup | SubGridName | lookupDialogValue1| lookupDialogValue2 |
|895173| ApplicationAdmin | Process Config | Application Types | Gdt Appl              | 175490001 | GENERAL    | UIAuto-Program-895173-1 |UIAuto-Program-895173-2 |


@Smoke
@Regression
Scenario: 16 Verify Engage user able to Modify, Publish and Delete the decisions of other owner.
        Given I have logged in as a <ApplicationAdmin>
		And I navigate to main Area and SubArea <SubArea>
		And I search <Application> in the grid
		When I wait for 2000 specific time
		And I open the first record in the grid
		And I select the sub tab Decisions of tab Related in the form
		And I search <Decision> in the grid
		When I wait for 2000 specific time
		And I open the first record in the grid
		And I have clicked Delete command in View
		Then I verify <warningmessage> in Confirmation dialog
		And I handle dialog with button cancelButton
		#Then I capture screenshot

Examples:
| TestCaseID | ApplicationAdmin | Area   | SubArea	    | Application           | TabName   | Decision                | 
| 1018665    | ApplicationAdmin | Reach | Applications |UIAuto Contact-1018665 | Decisions | UIAuto-Decision-1018665 | 

@Smoke
@Regression
Scenario:Validate Empty records appear under Application requirements,if the Requirement definition record is not having any requirement definition detail records under it
#User should be logged in as Application Admin
#should have Requirement Definition
#should have Application Definition
#Should have an Application registration and application for a contact

        Given I have logged in as a <ApplicationAdmin>
		And I navigate to main Area and SubArea <SubArea>
		And I search <Application> in the grid
		When I wait for 2000 specific time
		And I open the first record in the grid
		Given I select the tab Requirements in the form
	
		Then I verify there are no records in the grid in REQUIREMENTS section

Examples:
| TestCaseID | ApplicationAdmin | Area   | SubArea      | Application |
| 847062     | ApplicationAdmin | Reach | Applications |  UIAuto Contact-846115- |



@ToValidateDate
Scenario: 17 To validate 'Start and End dates' in 'Application Definition version detail' and 'Cutoff date' in 'Application Period Program' forms
                Given I have logged in as a <Persona>
                And I have navigated to the Area Process Config and SubArea Application Definition Versions
                When I wait for 2000 specific time
                And I search UIAuto-ADV-904484 in the grid
				When I wait for 2000 specific time
                And I open the first record in the grid
                When I wait for 2000 specific time
                And I select the sub tab Application Definition Version Details of tab Related in the form
                When I wait for 3000 specific time
   # And I have clicked New Application Definition Version Detail command in View
                And I click New Application Definition Version Detail command in associated View
                When I wait for 3000 specific time
                And I have set UIAuto-ApplicationPeriod-904484 to cmc_applicationperiod lookup item in the Form
                When I wait for 3000 specific time
                #provide the dates only in MM/dd/yyyy format
                When I have set 04/20/2019 to cmc_startdate datetime field in the Form
                When I wait for 3000 specific time
                When I have set 04/01/2019 to cmc_enddate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                When I have set 04/20/2019 to cmc_enddate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                When I have set 04/01/2019 to cmc_startdate datetime field in the Form
                When I wait for 3000 specific time
                When I have set 04/20/2019 to cmc_enddate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                When I wait for 2000 specific time
                
                And I select the sub tab Application Period Programs of tab Related in the form
				When I wait for 2000 specific time

                And I open the first record in the grid
                #When I have set Program 1 to cmc_programid lookup field in the Form
                #And I have set  to cmc_aplicationldefversdetailid lookup field in the Form
                When I wait for 3000 specific time
                When I have set 04/20/2019 to cmc_cutoffdate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                
                When I wait for 3000 specific time
                When I have set 03/31/2019 to cmc_cutoffdate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                When I wait for 3000 specific time
                When I have set 03/31/2019 to cmc_cutoffdate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                When I wait for 3000 specific time
                When I have set 04/21/2019 to cmc_cutoffdate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                When I wait for 3000 specific time
                When I have set 04/15/2019 to cmc_cutoffdate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                And I have navigated to the Area Process Config and SubArea Application Definition Versions
                When I search UIAuto-ADV-904484 in the grid 
                And I open the first record in the grid
				When I wait for 3000 specific time

                And I select the sub tab Application Definition Version Details of tab Related in the form
                When I wait for 2000 specific time
				And I open the first record in the grid
                When I wait for 3000 specific time
                When I have set 03/01/2019 to cmc_startdate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                When I have set 04/11/2019 to cmc_startdate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                When I have set 04/20/2019 to cmc_enddate datetime field in the Form
                When I press Save in the form
                Then the Entity should be saved
                #And I have clicked New Application Definition Version Detail command in View
                #And I have clicked New Application Definition Version Detail command on Application Definition Version Details Form SubGrid
                #Then the result should be 120 on the screen
Examples: 
| Test Case ID | Persona        | 
| 904484       | StudentAdvisor | 


  
Scenario: 18 Verify Engage user able to Create, Modify, Publish and Delete the decisions without any error.
    Given I have logged in as a <Persona>
   And I navigate to main Area and SubArea <SubArea>
    And I search UIAuto Contact-1017531 in the grid
	When I wait for 2000 specific time
    And I open the first record in the grid
	And I wait for 2000 specific time
    And I select the sub tab Decisions of tab Related in the form
   # And I have clicked New Decision command in View
   And I click New Decision command in associated View
   And I wait for 1000 specific time
    And I have set Decision1 to cmc_decisionname text field in the Form
    And I have set Admit to cmc_decisionstatus optionset field in the Form
    When I press Save in the form
    Then the Entity should be saved
     Given I navigate to main Area and SubArea <SubArea>
    And I search UIAuto Contact-1017531 in the grid
	When I wait for 2000 specific time
    And I open the first record in the grid
    Given I select the sub tab Decisions of tab Related in the form
	When I wait for 2000 specific time
    And I open the first record in the grid
    And I have set Decisionupdate1 to cmc_decisionname text field in the Form
    #Then I click on Not Published field
	Then I select option Published in cmc_publishstatus field
    When I press Save in the form
    Then the Entity should be saved
	And I navigate to main Area and SubArea Applications
    When I search UIAuto Contact-1017531 in the grid
    And I open the first record in the grid
    Given I select the sub tab Decisions of tab Related in the form
	When I wait for 2000 specific time
    And I open the first record in the grid
    And I have clicked Delete command in View
   # And I click Delete in Confirmation dialog	
	And I handle dialog with button confirmButton
	And I wait for 2000 specific time
   
   
    Examples:
    | Test Case ID | Persona          | SubArea      |
    | 1017531      | ApplicationAdmin | Applications |




#@Requirement
Scenario: 19 Verify mass decision should be created to application if new decision is different from existing.
Given I have logged in as a <ApplicationAdmin>
       And I navigate to main Area and SubArea Applications
        And I search <ApplicationName> in the grid
        And I select record no. 0 in the grid
        And I select record no. 1 in the grid
        And I select record no. 2  in the grid
        And I select record no. 3  in the grid
        And I select record no. 4  in the grid
        And I have clicked Create Decision command in View   
		And I wait for 4000 specific time
        Then I switch to <WindowName> window 
		And I wait for 3000 specific time
        And I switch to FullPageWebResource frame 
		And I wait for 5000 specific time
        And I have set <DecisionStatus> to decisionStatusTemplates Kendo text field in dialog window
		And I wait for 2000 specific time
		Then I have clear text in dpDecisionPublishDate Kendo text field in dialog window
		And I wait for 2000 specific time
        And I click Create button in the window  
        And I switch back to main window
        When I wait for 8000 specific time
        And I open the first record in the grid
		When I wait for 8000 specific time
        And I click Advanced Find global command
        When I wait for 6000 specific time
        Then I switch to contentIFrame0 frame
        When I wait for 6000 specific time
        And I select slctPrimaryEntity dropdown filter value as Applications
    When I wait for 2000 specific time
    And I select sub filter option as Application Name from Fields option group in row 0
    And I wait for 3000 specific time
    #And I select filter option as Contains Data for Equals field
    And I enter UIAuto Contact-1012496- in Enter Text field
    And I select sub filter option as Decisions (Application) from Related option group in row 0
    And I wait for 3000 specific time
    And I select sub filter option as Decision Name from Fields option group in row 1
    And I wait for 3000 specific time
    #And I select filter option as Contains Data for Equals field
    And I wait for 3000 specific time
    And I enter <DecisionName> in Enter Text field
    And I wait for 3000 specific time
	Then I switch back to default frame
    And I click Results in Show group of advanced find ribbon
    And I wait for 3000 specific time
	Then I verify UIAuto Contact-1012496-  in advanced find results
	And I close the Advanced Find Window
	#And I open the first record in the grid
	#And I verify Contact-1012496- in advanced find results
        
Examples: 
| TestCaseID | ApplicationAdmin | ApplicationName        | WindowName                                   | DecisionName                                    | DecisionStatus        |
| 1012496    | ApplicationAdmin | UIAuto Contact-1012496 | CreateDecision.html - Dynamics 365 | UIAuto Contact-1012496- - Admit                 | Admit                 |
#| 1012496    | ApplicationAdmin | UIAuto Contact-1012496 | CreateDecision.html - Microsoft Dynamics 365 | UIAuto Contact-1012496- - Admit with Conditions | Admit with Conditions |  


#
#
Scenario: 20 UI- To validate the Application Management UI Updates- Part2

Given I have logged in as a <Persona>
And I have navigated to the Area Process Config and SubArea Queries
When I wait for 4000 specific time
 And I navigate to main Area and SubArea Application Registrations
And I wait for 4000 specific time
And I open the first record in the grid
And I wait for 2000 specific time
And I have clicked More Commands command on APPLICATIONS SubGrid
When I wait for 2000 specific time
And I have navigated to the Area Process Config and SubArea Queries
And I have clicked New command in View
When I wait for 2000 specific time
And I have set <QueryName> to cmc_queryname text field uniquely in the Form
And  I have set <BaseEntity> view/Entity to cmc_baseentity Picker in General section
#Given I have set <BaseEntity> to Entity in Entity Picker in the Form
When I press Save in the form
Then the Entity should be saved
When I wait for 2000 specific time
And I select the tab Query Condition in the form
And I select the tab Query in the form
And I have clicked More Commands command on Query Conditions SubGrid
And I wait for 2000 specific time
And I have clicked More Commands command on Query Condition Groups SubGrid

Examples:
| Test Case ID | Persona          | QueryName      | BaseEntity |
| 915628       | ApplicationAdmin | Query-1-915628 | Contact    |



#Scenario: 21 UI Check- Validate complete 'Query' UI checks including launching 'Advanced Query builder' functionality
#Given I have logged in as a <Persona>
#And I have navigated to the Area Process Config and SubArea Queries
#And I have clicked New command in View
#And I have set <QueryName> to cmc_queryname text field uniquely in the Form
#And I have set <BaseEntity> to Entity in Entity Picker in the Form
#When I press Save in the form
#Then the Entity should be saved
#When I wait for 2000 specific time
#And I select the tab Query Condition in the form
#And I have clicked Create/Edit Query command on Query SubGrid
#Then I switch to contentIFrame0 frame
#When I wait for 6000 specific time
#And I click Details in Query group of advanced find ribbon
#
#
#Examples:
#| Test Case ID | Persona          | QueryName       | BaseEntity |
#| 1015579      | ApplicationAdmin | Query-1-1015579 | Contact    |


Scenario: 22 Filter the Application Period based on the Program
Given I have logged in as a <Persona>
And I navigate to main Area and SubArea Applications
    And I have clicked New command in View
	And I have set UIAuto-ADV-899056 - UIAuto Contact- 899056 to cmc_applicationregistration lookup item in the Form
	And I wait for 2000 specific time
	And I have set UIAuto-Program-899056-2 to cmc_programid lookup item in the Form
	And I wait for 2000 specific time	
	And I have set UIAuto-ApplicationPeriodSpring22-899056 to cmc_applicationperiodid lookup item in the Form
	And I wait for 3000 specific time
	Then I clear existing values in cmc_applicationperiodid lookup field
	And I wait for 3000 specific time
	Given I Verify lookup Value UIAuto-ApplicationPeriodSpring21-899056 is not available in cmc_applicationperiodid lookup item in the Form
	And I wait for 2000 specific time
	Then I clear existing values in cmc_applicationperiodid lookup field
	When I have set UIAuto-ApplicationPeriodSpring22-899056 to cmc_applicationperiodid lookup item in the Form
	And I wait for 2000 specific time
	And I press Save in the form
	Then the Entity should be saved 

Examples:
| Test Case ID | Persona          | 
| 899056       | ApplicationAdmin |

Scenario: 23 Validate 'Application Requirement' Form functionality
	#login as Application Admin role
	#Application record should be available from Pre-req data 
	
	Given I have logged in as a <Persona>
	And I navigate to main Area and SubArea Applications
    And I search UIAuto Contact- 843875-UIAuto-Program-843875 in the grid
	When I wait for 2000 specific time
	And I open the first record in the grid
	And I wait for 2000 specific time
	And I select the tab Requirements in the form
	And I wait for 2000 specific time
	#When I have clicked New Requirement command on REQUIREMENTS SubGrid
	And I click New Requirement command on REQUIREMENTS SubGrid when available
	And I click More commands for Requirement button on REQUIREMENTS SubGrid only if available
	And I click New Requirement SubGrid option on More Commands SubGrid when available


	And I wait for 2000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName				 | FieldValue |
	| Field | General      | Requirement Name        |            |
	| Field | General      | Application             |            |
	| Field | General      | Requirement Type        |            |
	| Field | General      | Description             |            |
	| Field | General      | Deadline Date/Time      |            |
	| Field | General      | Required                |            |
	| Field | General      | Requirement Status      |            |
	| Field | General      | Received Date           |            |
	And I scrolldown to End of General section
		And I wait for 1000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName				 | FieldValue |
	| Field | General      | Source of Record        |            |
	| Field | General      | Owner                   |            |
	And I wait for 2000 specific time
	
	# Unofficial Transcript
	When  I have set Unofficial Transcript to cmc_requirementtype optionset field in the Form
	And I verify in General section Previous Education field is present
	And I wait for 2000 specific time
	When  I have set General to cmc_requirementtype optionset field in the Form
	And I verify the Previous Education field is not present in the General section of the form
	
	# Official Transcript
	When  I have set Official Transcript to cmc_requirementtype optionset field in the Form
	And I verify in General section Previous Education field is present
	And I wait for 2000 specific time
	When  I have set General to cmc_requirementtype optionset field in the Form
	And I verify the Previous Education field is not present in the General section of the form

	# Recommendation
	When  I have set Recommendation to cmc_requirementtype optionset field in the Form
	And I verify in General section Recommendation field is present
	And I wait for 2000 specific time
	When  I have set General to cmc_requirementtype optionset field in the Form
	And I verify the Recommendation field is not present in the General section of the form

	# Upload


	When  I have set Upload to cmc_requirementtype optionset field in the Form
	And I wait for 2000 specific time
	And I verify the Recommendation field is not present in the General section of the form
	And I verify the Previous Education field is not present in the General section of the form
	And I verify the Test Score field is not present in the General section of the form

	# General
	When  I have set General to cmc_requirementtype optionset field in the Form
	And I wait for 2000 specific time
	And I verify the Recommendation field is not present in the General section of the form
	And I verify the Previous Education field is not present in the General section of the form
	And I verify the Test Score field is not present in the General section of the form
	
	# Test Score
	When  I have set Test Score to cmc_requirementtype optionset field in the Form
	And I wait for 2000 specific time
	And I verify in General section Test Score field is present
	And I wait for 2000 specific time
	When  I have set General to cmc_requirementtype optionset field in the Form
	And I wait for 2000 specific time
	And I verify the Test Score field is not present in the General section of the form
	And I wait for 2000 specific time
	When  I have set Test Score to cmc_requirementtype optionset field in the Form
	And I have set SAT to cmc_testscoreid field in the lookup dialog
	And I press Save in the form
	And I wait for 7000 specific time
	And I verify in General section Application field is locked
	When I click cmc_applicationid locked lookup field in General section
	And I select the tab Requirements in the form
	And I wait for 2000 specific time
	When I have clicked New Requirement command on REQUIREMENTS SubGrid
	When  I have set Recommendation to cmc_requirementtype optionset field in the Form
	And I have set UIAuto Recommender- 843875 - Pending to cmc_recommendationid field in the lookup dialog
	And I press Save in the form


Examples:
| Test Case ID | Persona          | 
| 843875       | ApplicationAdmin |


Scenario: 24 Validate complete 'Query' UI checks including launching 'Advanced Query builder' functionality
	#login as Application Admin role
	
	Given I have logged in as a <Persona>
	And I have navigated to the Area Process Config and SubArea Queries
	When I wait for 2000 specific time
	And I have clicked New command in View
	When I wait for 1000 specific time
	And I have set <QueryName> to cmc_queryname text field uniquely in the Form
	And  I have set <BaseEntity> view/Entity to cmc_baseentity Picker in General section
	When I press Save in the form
	Then the Entity should be saved
	When I wait for 2000 specific time
	And I select the tab Query Condition in the form
	And I wait for 2000 specific time
	And I click Create/Edit Query button in the page
	And I wait for 3000 specific time
	Then I switch to Advanced Find - Microsoft Dynamics 365 window
	And I click HideDetails in Query group of advanced find ribbon
	And I wait for 3000 specific time
	Then I switch to contentIFrame0 frame
	And I select sub filter option as Application Name from Fields option group in row 0
	And I switch back to default frame
	And I wait for 8000 specific time
	Given I click Save in the Advanced Find Window 
	And I close the Advanced Find Window
	And I wait for 1000 specific time
	Then I switch back to default frame
	And I wait for 2000 specific time
    #And  I close window pop-up
    #Given I click Done button in dialog
	#Given I click okButtonText in Confirmation dialog
	Then I switch to browser tab 1 if available
    Then I handle dialog with button okButton
	#And I handle dialog with button D
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 3000 specific time
	And I click Use Existing View button in the page
	#Given  I click Use Existing View in View Picker
	And I wait for 5000 specific time
	#And I have set Active Applications view/Entity to cmc_baseentity Picker in QUERY section
	#Given I select view Active Applications in View Picker
	Given I select Active Applications view in View Picker in Query section
	And I wait for 1000 specific time
	And I click Use Query button in the page
	#And I click Use Query in View Picker
	And I wait for 2000 specific time
	When I press Save in the form
	And I wait for 2000 specific time
	#Then cmc_conditionxml field value should not be empty
	#And The optionset value cmc_conditionxml should not be empty
	And I have navigated to the Area Process Config and SubArea Queries
	When I wait for 4000 specific time
	And I have navigated to the Area Process Config and SubArea Requirement Definitions
	When I wait for 2000 specific time
	And I have clicked New command in View
	And I have set UIAuto requirement to cmc_applicationrequirementdefinitionname text field uniquely in the Form
	When I press Save in the form
	Then the Entity should be saved
	When I wait for 3000 specific time
	
	#When I have clicked New Requirement Definition Detail command on REQUIREMENT DEFINITION DETAILS SubGrid
	And I click New Requirement Definition Detail command on APPLICATION REQUIREMENT DEFINITION DETAILS SubGrid when available
	And I click More commands for Requirement Definition Detail button on APPLICATION REQUIREMENT DEFINITION DETAILS SubGrid only if available
	And I click New Requirement Definition Detail SubGrid option on More Commands SubGrid when available

	
	When I have set General to cmc_requirementtype optionset field in the Form
	And I have set UIAutoRDD to cmc_name text field uniquely in the Form
	And I scrolldown to End of General section
	#Then I update the cmc_conditional field with input as Yes in the form
    And I select option Yes in cmc_conditional field
	And I wait for 2000 specific time
	Given I have set <QueryName> to cmc_queryid lookup item in the Form
	And I wait for 2000 specific time
	When I press Save in the form
	Then the Entity should be saved


Examples:
| Test Case ID | Persona          | QueryName               | BaseEntity  |
| 1015579      | ApplicationAdmin | UIAuto-QueryApplication | Application |


Scenario: 25 Validate on selecting Payment Gateway option its related cofiguration fields appear
	#login as System Admin role
	Given I have logged in as a <Persona>
	And I have navigated to the Area Settings and SubArea Payment Gateway Configurations
	When I wait for 2000 specific time
	And I have clicked New command in View
	When I wait for 1000 specific time
	And  I have set PayPal to cmc_paymentgateway optionset field in the Form
	And I wait for 2000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName				 | FieldValue |
	| Field | General      | Username                |            |
	| Field | General      | Password                |            |
	
	#And I scrolldown to End of PayPal  section
	And I scroll in to view of PayPal section
	And I wait for 2000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName				 | FieldValue |
	| Field | PayPal      | Payment Url             |            |
	| Field | PayPal      | Hosted Url              |            |
	| Field | PayPal      | Vendor                  |            |

	When I wait for 1000 specific time
	And  I have set Cashnet to cmc_paymentgateway optionset field in the Form
	Then I verify below fields
	| Type  | sectionLabel | FieldName							   | FieldValue |
	| Field | General      | Username                              |            |
	| Field | General      | Password							   |            |
	And I scrolldown to End of Cashnet section
	And I wait for 1000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName							   | FieldValue |
	| Field | Cashnet      | URL							       |            |
	| Field | Cashnet      | Item Code							   |            |
	| Field | Cashnet      | Encryption Key						   |            |
	| Field | Cashnet      | Digest Parameter                      |            |
	| Field | Cashnet      | Authentication Method (Digest)        |            |

	When I wait for 1000 specific time
	And  I have set Touchnet to cmc_paymentgateway optionset field in the Form
	And I wait for 2000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName							   | FieldValue |
	| Field | General      | Username                              |            |
	| Field | General      | Password							   |            |
	And I scrolldown to End of Touchnet section
	And I wait for 1000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName							   | FieldValue |
	| Field | Touchnet      | Site ID						       |            |
	| Field | Touchnet      | uPay URL							   |            |
	| Field | Touchnet      | Webservice URL					   |            |

	When I wait for 1000 specific time
	And  I have set AuthorizeNet to cmc_paymentgateway optionset field in the Form
	And I wait for 2000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName							   | FieldValue |
	| Field | General      | API LoginID                           |            |
	| Field | General      | API TransactionKey 				   |            |
	And I scrolldown to End of AuthorizeNet section
	And I wait for 1000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName							   | FieldValue |
	| Field | AuthorizeNet | API Endpoint   				       |            |
	| Field | AuthorizeNet | Form Post Url						   |            |
	| Field | AuthorizeNet | Webhook Endpoint URL				   |            |

	When I wait for 1000 specific time
	And  I have set ACI Funding Portal to cmc_paymentgateway optionset field in the Form
	Then I verify below fields
	| Type  | sectionLabel | FieldName							   | FieldValue |
	| Field | General      | Username                              |            |
	| Field | General      | Password							   |            |
	And I scrolldown to End of ACI section
	And I wait for 1000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName							   | FieldValue |
	| Field | ACI        | Business ID							   |            |
	| Field | ACI        | Make Payment URL						   |            |
	| Field | ACI        | Add Funding URL					       |            |

	When I wait for 1000 specific time
	And  I have set Nelnet to cmc_paymentgateway optionset field in the Form
	Then I verify below fields
	| Type  | sectionLabel | FieldName							   | FieldValue |
	| Field | General      | Username                              |            |
	| Field | General      | Password							   |            |
	And I scrolldown to End of Nelnet section
	And I wait for 1000 specific time
	Then I verify below fields
	| Type  | sectionLabel | FieldName							       | FieldValue |
	| Field | Nelnet     | Access Token URL							   |            |
	| Field | Nelnet     | Client ID							       |            |
	| Field | Nelnet     | Client Secret						       |            |
	| Field | Nelnet     | Tenant ID							       |            |
	| Field | Nelnet     | Checkout Profile ID						   |            |
	| Field | Nelnet     | Payment Profile ID					       |            |
	| Field | Nelnet     | Checkout URL						           |            |

Examples:
| Test Case ID | Persona             | 
| 917118       | SystemAdministrator | 

Scenario: 26 Verify the Assignment of Bulk decision to an application including both Publish date & publish status values are blank.
Given I have logged in as a <ApplicationAdmin>
And I navigate to main Area and SubArea <SubArea>
And I search <ApplicationName> in the grid
And I select record no. 0 in the grid
And I have clicked Create Decision command in View
Then I switch to <WindowName> window
When I wait for 4000 specific time
Then I switch to FullPageWebResource frame
And I wait for 2000 specific time
And I have set Admit to decisionStatusTemplates Kendo text field in dialog window
Then I have clear text in dpDecisionPublishDate Kendo text field in dialog window
When I wait for 5000 specific time
Then I click Create button in the window
And I wait for 2000 specific time
Then I switch back to main window
And I wait for 5000 specific time
When I open the first record in the grid
And I select the sub tab Decisions of tab Related in the form
And I open the first record in the grid
When I wait for 2000 specific time
And I verify below fields
| Type | sectionLabel | FieldName  | FieldValue|
| Field | General | Decision Status| Admit     |
| Field | General | Publish Status |           |
| Field | General | Publish Date   |           |
When I wait for 2000 specific time

Examples:
| TestCaseID | ApplicationAdmin | Area  | SubArea      | ApplicationName        |WindowName                          |
| 1380791    | ApplicationAdmin | Reach | Applications | UIAuto Contact-1380791 | CreateDecision.html - Dynamics 365 |


Scenario: 27 Verify the Assignment of Bulk decision to an application including when Publish date is set & publish status is blank and viceversa.
Given I have logged in as a <ApplicationAdmin>
And I navigate to main Area and SubArea <SubArea>
And I search <ApplicationName> in the grid
And I select record no. 0 in the grid
And I have clicked Create Decision command in View
Then I switch to <WindowName> window
When I wait for 2000 specific time
Then I switch to FullPageWebResource frame
And I wait for 2000 specific time
And I have set Admit to decisionStatusTemplates Kendo text field in dialog window
Then I have clear text in dpDecisionPublishDate Kendo text field in dialog window
And I wait for 2000 specific time
Then I set Published in the dialog window drop down
When I wait for 5000 specific time
Then I click Create button in the window
And I wait for 2000 specific time
And I handle the dialog action button okButton only if available
And I wait for 2000 specific time
Then I switch back to main window
And I wait for 5000 specific time
And I navigate to main Area and SubArea <SubArea>
And I wait for 2000 specific time
When I search <ApplicationName> in the grid
And I select record no. 0 in the grid
And I have clicked Create Decision command in View
Then I switch to <WindowName> window
When I wait for 4000 specific time
Then I switch to FullPageWebResource frame
And I wait for 2000 specific time
And I have set Admit to decisionStatusTemplates Kendo text field in dialog window
And I wait for 2000 specific time
Then I click Create button in the window
And I wait for 2000 specific time
And I handle the dialog action button okButton only if available

Examples:
| TestCaseID | ApplicationAdmin | Area  | SubArea      | ApplicationName        | WindowName                         |
| 1380861    | ApplicationAdmin | Reach | Applications | UIAuto Contact-1380861 | CreateDecision.html - Dynamics 365 |

Scenario: 28 Verify the Assignment of Bulk decision to an application including both Publish date & publish status values are present.

Given I have logged in as a <ApplicationAdmin>
And I navigate to main Area and SubArea <SubArea>
And I search <ApplicationName> in the grid
And I select record no. 0 in the grid
And I have clicked Create Decision command in View
Then I switch to <WindowName> window
When I wait for 4000 specific time
Then I switch to FullPageWebResource frame
And I wait for 2000 specific time
And I have set Admit to decisionStatusTemplates Kendo text field in dialog window
And I wait for 2000 specific time
Then I set Not Published in the dialog window drop down
When I wait for 5000 specific time
Then I click Create button in the window
And I wait for 2000 specific time
Then I switch back to main window
And I wait for 5000 specific time
When I open the first record in the grid
And I select the sub tab Decisions of tab Related in the form
And I open the first record in the grid
When I wait for 2000 specific time
And I verify below fields
| Type | sectionLabel | FieldName  | FieldValue   |
| Field | General | Decision Status| Admit        |
| Field | General | Publish Status | Not Published|
When I wait for 2000 specific time

Examples:
| TestCaseID | ApplicationAdmin | Area  | SubArea      | ApplicationName        |WindowName                          |
| 1380809    | ApplicationAdmin | Reach | Applications | UIAuto Contact-1380809 | CreateDecision.html - Dynamics 365 |

