Feature: StudentGroup

@Common
@Smoke
Scenario: 01 Validate Marketing List or Student Group list form
# precondition: There should be 16 contacts must be available in this org and all these contact names must be paramenterizied in the below.
				                Given I have logged in as a <Persona>
                                And I have navigated to the Area Process Config and SubArea Marketing Lists
                                And I have clicked New marketing list command in View
                                And I have set <MrktValue> to listname text field uniquely in the Form
                                And I have set Contact to createdfromcode optionset field in the Form
                                When I wait for 3000 specific time
                                And I have set 04/03/2022  to cmc_expirationdate datetime field in the Form
                                When I wait for 3000 specific time
                                And I press Save in the form
                                Then the Entity should be saved
                                Given I select the tab Linked Entities in the form
                                #When I have clicked New DOM Master command on DOM Masters (Marketing List) SubGrid
                               And  I choose to click New DOM Master command in dommasters SubGrid out of multiple sections in Linked Entities div if available
                              #  And  I choose to click More Commands command in dommasters SubGrid out of multiple sections if available
                                #And  I click New DOM Master SubGrid option on More Commands SubGrid when available
                                And I have set Contact to cmc_runassignmentforentity optionset field in the Form
                                And I have set Record Owner to cmc_attributenametobeassigned optionset field in the Form
                                And I have set anthologyd365automation to cmc_fallbackuserid lookup item in the Form
                                And I have clicked Save & Close command in View
                                And I wait for 2000 specific time
                                And  I choose to click Add Existing Success Plan Assignment command in successplanassignments SubGrid out of multiple sections in Linked Entities div if available
                             #   And I click Add Existing Success Plan Assignment command on Success Plan Assignments SubGrid when available
	                            #And I click More Commands button on Success Plan Assignments SubGrid only if available
	                            #And I click Add Existing Success Plan Assignment SubGrid option on More Commands SubGrid when available	
                                #When I have clicked Add Existing Success Plan Assignment command on Success Plan Assignments SubGrid
                                When I wait for 2000 specific time
                                Then I have set UIAuto-SPA-898210 to lookupDialogContainer field in the lookup SearchBox
                                And I click true button in the lookup dialog
                                When I wait for 2000 specific time
                             #   And I click Add Existing Success Network Assignment command on Success Network Assignments SubGrid when available
	                            #And I click More Commands button on Success Network Assignments SubGrid only if available
	                            #And I click Add Existing Success Network Assignment SubGrid option on More Commands SubGrid when available	
                                #When I have clicked Add Existing Success Network Assignment command on Success Network Assignments SubGrid
                                  And  I choose to click Add Existing Success Network Assignment command in successnetworkassignments SubGrid out of multiple sections in Linked Entities div if available
                                When I wait for 2000 specific time
                                Then I have set DCRM DCRM Faculty/Instructor - UIAuto-Role-898210 to lookupDialogContainer field in the lookup SearchBox
                                And I click true button in the lookup dialog
                                When I wait for 4000 specific time
                                 And  I choose to click Add Existing Score Definition command in scoredefinitions SubGrid out of multiple sections in Linked Entities div if available
                               # When I have clicked Add Existing Score Definition command on Score Definitions SubGrid
                                When I wait for 2000 specific time
                                Then I have set UIAuto-SD-898210 to lookupDialogContainer field in the lookup SearchBox
                                And I click true button in the lookup dialog
                                Given I select the tab Members in the form
                                #When I have clicked Add command on Contacts SubGrid
                                   #And  I choose to click Add Existing Contact command in contactsUCI SubGrid out of multiple sections in Members div if available
                                   And I click Add command on Members SubGrid when available
                                   And I wait for 3000 specific time
                                Then I have set UIAuto Contact-898210-1 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
								Then I have set UIAuto Contact-898210-10 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-11 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-12 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-13 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-14 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-15 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-16 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
								And I click true button in the lookup dialog
								When I wait for 2000 specific time
								 #And  I choose to click Add Existing Contact command in contactsUCI SubGrid out of multiple sections in Members div if available
                                  And I click Add command on Members SubGrid when available
                                   And I wait for 3000 specific time
								Then I have set UIAuto Contact-898210-2 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-3 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-4 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-5 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-6 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-7 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-8 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
                                Then I have set UIAuto Contact-898210-9 to lookupDialogContainer field in the lookup SearchBox
								When I wait for 2000 specific time
								And I click true button in the lookup dialog
                                When I wait for 2000 specific time
                                # need to insert the validation step for pagination to validate each page will have 14 records.
Examples:
|TestCaseID|Persona        | MrktValue | ListTypeName | DateValue |
|898210    |StudentAdvisor | MCAGroup  | Static       | 05/14/2020 |