Feature: ScoringModel

@ScoringModel
Scenario: 01 Validate Scoring Factor and Score Definition form and fields including launching Advanced Query builder  

		Given I have logged in as a <StudentAdvisor> 

		##Creating 1st Scoring Factor Record with AQB Query 

        And I have navigated to the Area <Area> and SubArea <SubArea>
        And I have clicked New command in View
		And I press Save in the form
		And I wait for 2000 specific time
		Then I validate <FactorNotification> notification/s in the form
		When I have set <ScoringFactorName1> to cmc_scoringfactorname text field uniquely in the Form
		And I wait for 2000 specific time
		And I press Save in the form
		And I wait for 2000 specific time
		Then I validate You have 2 notifications. Select to view. notification/s in the form
		And  I have set Contact view/Entity to cmc_baseentity Picker in GENERAL section
		And I wait for 2000 specific time
		And I press Save in the form
		And I wait for 2000 specific time
		Then I validate Points : Required fields must be filled in. notification/s in the form
		And I wait for 2000 specific time
		When I have set 30 to cmc_points text field in the Form
		And I wait for 1000 specific time
		And I have set <Description> to cmc_description text field uniquely in the Form
		And I wait for 1000 specific time
		And I press Save in the form
		And I wait for 1000 specific time
		And I handle dialog with button confirmButton
		And I wait for 1000 specific time
		Then the Entity should be saved
		And I wait for 1000 specific time
		And I select the tab Query Condition in the form
		And I wait for 1000 specific time
		Given I click Edit Query in View Picker which opens the Advanced Find Window
		And I wait for 3000 specific time
		And I click HideDetails in Query group of advanced find ribbon
		Then I switch to contentIFrame0 frame
		And I select sub filter option as First Name from Fields option group in row 0
		And I switch back to default frame
		Given I click Save in the Advanced Find Window 
		And I close the Advanced Find Window
		And I wait for 1000 specific time
		Then I switch back to default frame
		And I wait for 2000 specific time
		And I press Save in the form
		Then the Entity should be saved
		And I wait for 3000 specific time

		##Creating 2nd Scoring Factor Record with Use Existing view query 

        Given I have navigated to the Area <Area> and SubArea <SubArea>
        And I have clicked New command in View
		And I have set <ScoringFactorName2> to cmc_scoringfactorname text field uniquely in the Form
		And I wait for 2000 specific time
		And  I have set Contact view/Entity to cmc_baseentity Picker in GENERAL section
		And I wait for 2000 specific time
		And I have set 40 to cmc_points text field in the Form
		And I wait for 100 specific time
		And I have set <Description> to cmc_description text field uniquely in the Form
		And I wait for 1000 specific time
		And I press Save in the form
		And I wait for 1000 specific time
		And I handle dialog with button confirmButton
		And I wait for 1000 specific time
		Then the Entity should be saved
		And I wait for 1000 specific time
		And I select the tab Query Condition in the form
		And I wait for 1000 specific time
		Given I click Use Existing View in View Picker
		And I wait for 1000 specific time
		And I select view All Contacts in View Picker
		And I wait for 1000 specific time
		And I click Use Query in View Picker
		And I wait for 2000 specific time
		When I press Save in the form
		Then the Entity should be saved
		And I wait for 2000 specific time
		#Then cmc_conditionxml field value should not be empty
		#Then The optionset value cmc_conditionxml should not be empty
		##creating Score Definition and associate marketing list and Scoring factor to it

		Given I have navigated to the Area <Area> and SubArea <SubArea1>
        And I have clicked New command in View
		And I press Save in the form
		Then I validate <Notification> notification/s in the form
		Given I have set <ScoreDefinitionName> to cmc_scoredefinitionname text field uniquely in the Form
		And I wait for 3000 specific time
		And  I have set Contact view/Entity to cmc_baseentity Picker in GENERAL section
		And I wait for 2000 specific time
		And  I have set ACT Best view/Entity to cmc_targetattributename Picker in GENERAL section
		And I wait for 2000 specific time
		And I press Save in the form
		And I wait for 1000 specific time
		And I handle dialog with button confirmButton
		And I wait for 1000 specific time
		Then the Entity should be saved
		And I wait for 1000 specific time

		And I wait for 2000 specific time
		Given I click More Commands button on MARKETING LIST SubGrid only if available
		And I wait for 2000 specific time
		And I click Add Existing Marketing List SubGrid option on More Commands SubGrid when available
		And I wait for 3000 specific time
		And I have set Static ScoringModel-970369 to lookupDialogLookup field in the lookup SearchBox
		And I click true button in the lookup dialog
		And I wait for 2000 specific time
		And I click More Commands button on SCORING FACTORS SubGrid only if available
		And I wait for 2000 specific time
		And I click Add Existing Scoring Factor SubGrid option on More Commands SubGrid when available
		And I wait for 2000 specific time
		And I have set <ScoringFactorName1> to lookupDialogLookup field in the lookup SearchBox
		And I wait for 2000 specific time
		When I have set <ScoringFactorName2> to lookupDialogLookup field in the lookup SearchBox
		And I click true button in the lookup dialog
		And I wait for 2000 specific time
		#Then I update the cmc_recalculaterecords field with input as Yes in the form
		Then I select option Yes in cmc_recalculaterecords field
		Given I have set 3 to cmc_recalculationinterval text field in the Form
		And I press Save in the form
		And I wait for 2000 specific time

Examples: 
| Test Case ID | StudentAdvisor | Area           | SubArea         | ScoringFactorName1 | ScoringFactorName2 | Description                | SubArea1          | Notification                              | FactorNotification                        | ScoreDefinitionName |
| 970369       | StudentAdvisor | Process Config | Scoring Factors | UIAutoSF-970369-1a | UIAutoSF-970369-1b | Scoring Factor for Contact | Score Definitions | You have 2 notifications. Select to view. | You have 3 notifications. Select to view. | UIAutoSD-970369     |
