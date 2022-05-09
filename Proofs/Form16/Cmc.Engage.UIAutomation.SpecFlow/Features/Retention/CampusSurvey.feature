Feature: CampusSurvey

@CampusSurvey
Scenario: 01 Create Campus Survey template including questions
                Given I have logged in as a <BusinessUnitAdministrator> 
                And I have navigated to the Area <Area> and SubArea <SubArea>
                And I have clicked New command in View
	            Then I select <FormName> Form
	            When I have set <TemplateName> to cmc_staffsurveytemplatename text field uniquely in the Form
	            Given I select the tab Start Date in the form
	            When I have set Static to cmc_startdatecalculationtype optionset field in the Form
	           	            And I wait for 2000 specific time
			  # And I have set <StartDate> to cmc_staticstartdate date field in the Form
			  And  I enter date time value <StartDate> to Start Date Static field in the Form
			  And I wait for 2000 specific time
	            Given I select the tab Due Date in the form
	            When I have set Static to cmc_duedatecalculationtype optionset field in the Form
				 And I wait for 2000 specific time
	            #And I have set <dueDatelessThanstartdate> to cmc_staticduedate date field in the Form
	     And  I enter date time value <dueDatelessThanstartdate> to Due Date Static field in the Form
			   And I wait for 2000 specific time
	            When I press Save in the form
	            And I wait for 2000 specific time
	            Then I validate <Message1> notification/s in the form
	            When I wait for 2000 specific time
				And  I enter date time value <DueDate> to Due Date Static field in the Form
	           # And I have set <DueDate> to cmc_staticduedate date field in the Form
	          
	            When I press Save in the form
	            Then the Entity should be saved
				 When I wait for 4000 specific time
                Then I select Designer(Succeed) Form
                When I wait for 2000 specific time
                Given I select Text Field question and provide StudentName to question field and provide  to option field in the form
                When I wait for 4000 specific time
                Then I click on Add Question Button in the questions section in the form
                Given I select Check Box question and provide Student Education to question field and provide Grade1 to option field in the form
                When I wait for 4000 specific time
                Then I click on Add Question Button in the questions section in the form
                Given I select Dropdown question and provide Courses to question field and provide English to option field in the form
                When I wait for 4000 specific time
                Then I click on Add Question Button in the questions section in the form
                Given I select Radio Button question and provide Gender to question field and provide Male to option field in the form
                When I wait for 4000 specific time
                Then I switch back to default frame
                And I press Save in the form
				Then the Entity should be saved
				And I wait for 2000 specific time

                
Examples: 
| Test Case ID | BusinessUnitAdministrator | Area    | SubArea                | FormName                        | TemplateName           | StartDate  | DueDate    | dueDatelessThanstartdate | Message1                                                  |
| 757900       | BusinessUnitAdministrator | Surveys | Campus Survey Template | Campus Survey Template(Succeed) | UICampusSurveyTemplate | 05/31/2020 | 06/10/2020 | 05/29/2020               | Due Date Static : Due Date cannot be less than Start Date |

 
Scenario: 02 Validate Campus Survey Assignment
	
     	Given I have logged in as a <BusinessUnitAdministrator> 
		# Create pre-req 'campus survey template' record	
		And I wait for 2000 specific time
		When I have navigated to the Area Surveys and SubArea Campus Survey Template
		And I wait for 2000 specific time
		And I have clicked New command in View
		And I select Campus Survey Template(Succeed) Form
		And I have set test to cmc_staffsurveytemplatename text field uniquely in the Form
		And I select the tab Start Date in the form
		And I have set Static to cmc_startdatecalculationtype optionset field in the Form
		And I set future date time value to Start Date Static field in the Form
		#And I have set next day to current date to cmc_staticstartdate field in the Form
		And I select the tab Due Date in the form 
		And I wait for 2000 specific time
		And I have set Static to cmc_duedatecalculationtype optionset field in the Form
		And I wait for 1000 specific time
		#And I have set next day to current date to cmc_staticduedate field in the Form
				And I set future date time value to Due Date Static field in the Form
		And I wait for 1000 specific time
		And I press Save in the form
		Then the Entity should be saved
		And I wait for 4000 specific time

	##Assign Campus Survey Template to Course section with 'All instructors'
	   When I have navigated to the Area Reference Data and SubArea Course Section
	   And I wait for 5000 specific time
	   And I search UIAuto-Course-766162 - 766162-1 - 766162-1 in the grid
	   And I wait for 2000 specific time
	   And I open the first record in the grid
	   And I have clicked Assign Campus Survey command in View
	   And I wait for 3000 specific time
	   Then I switch to FullPageWebResource frame
	   And I wait for 2000 specific time
	   And I set test to StaffCourseTemplates field in assignStaffCoursedialog dialog
	   And I wait for 2000 specific time
	   And I click Assign button in the window
	   And I wait for 2000 specific time
	   And I switch back to default frame
	   And I switch to active element
	   And I handle dialog with button okButton
	   And I wait for 3000 specific time
	   And I press Save in the form
	   Then the Entity should be saved
And I wait for 4000 specific time
	#Assign Campus Survey Template to Course section with 'role related instructors'
		When I have navigated to the Area Reference Data and SubArea Course Section
		And I search UIAuto-Course-766162 - 766162-2 - 766162-2 in the grid
		And I open the first record in the grid
		And I wait for 2000 specific time
		And I have clicked Assign Campus Survey command in View
	    And I wait for 2000 specific time
		Then I switch to FullPageWebResource frame
		And I wait for 2000 specific time
	    And I set test to StaffCourseTemplates field in assignStaffCoursedialog dialog
		And I wait for 2000 specific time
		And I select instructorsByRole radio button in the dialog window 
		And I wait for 2000 specific time
		And I set Primary Advisor to k-input k-readonly field in assignStaffCoursedialog dialog
		And I wait for 2000 specific time
		And I set Static CampusSurvey-766162 to studentGroup field in assignStaffCoursedialog dialog
		And I wait for 2000 specific time
		And I click Assign button in the window
		And I switch back to default frame
		And I switch to active element
		And I handle dialog with button okButton
		And I wait for 2000 specific time
		And I press Save in the form
		Then the Entity should be saved
		And I wait for 3000 specific time
		And I select the tab Related in the form
		And I select the tab Course Instructors in the form
		And I wait for 2000 specific time
		And I select the sub tab Campus Surveys of tab Related in the form
		And I wait for 2000 specific time
		And I open the first record in the grid
		And I wait for 1000 specific time
		And I select Information(Succeed) Form
		And I verify in General section Locked Campus Survey Name field is locked
		And I verify in General section Locked Course Section field is locked
		And I verify in General section Locked Main Instructor field is locked
		And I verify in General section Locked Campus Survey Template field is locked
		And I verify in General section Locked Start Date field is locked
		And I verify in General section Locked Due Date field is locked
		And I verify in General section Locked Student Group field is locked

	
Examples: 
| Test Case ID | BusinessUnitAdministrator | 
| 766162       | BusinessUnitAdministrator | 