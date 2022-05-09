Feature: StaffCalendar
	

@Regression
Scenario: Business Rule validation of Option set field Delivery Type and creation of User Location record
		#User should have Base+Shared+ Business Unit Admin
		##Create Campus
		Given I have logged in as a <Persona>
		And I navigate to main Area and SubArea Accounts
		And I switch the view to Active Campuses
		And I search <AccountName> in the grid
		And I open the first record in the grid
		When I select Account(Reach) Form
				And I select the sub tab Addresses of tab Related in the form	
		And I wait for 3000 specific time
		#And I have clicked New Address command in View
		  And I click New Address command in associated View
		  And I wait for 3000 specific time
		When I have set 2 to addresstypecode optionset field in the Form
		And I have set <MailType> to mshied_mailtype optionset field in the Form
		And I select matching Address to <Street 1> in the field search_field
		And I scrolldown to End of Customer Address Information section
		And I have set <TimeZone_India> to cmc_addresstimezone optionset field in the Form
		And I press Save in the form
		Then the Entity should be saved
		##Create In-person User Location for logged in user at the above created campus
		And I have navigated to the Area Reference Data and SubArea User Locations
		And I have clicked New command in View
		When I have set <UserName> to cmc_userid lookup item in the Form
		And I have set <DeliveryType> to cmc_deliverytype optionset field in the Form
		And I have set <AccountName> to cmc_accountid lookup item in the Form
		And I press Save in the form
		Then the Entity should be saved

Examples: 
| TestCaseID | Persona					 | AccountName    | AccountType | AddressType | MailType  | Country/Region | Street 1        | City      | State     | Zip    | TimeZone_India | UserName          | DeliveryType | Campus   |
|  1062784   | BusinessUnitAdministrator | Account-1062784 | Campus      | Primary     | 494280000 | 175490101      | 7284 West Palmetto Park Road | Bangalore | 175490089 | 560093 | 190            | anthologyd365automation | 175490000    | ALS      |

@Regression

Scenario: User should not be able to create more than one office hours with same Date,day and time range

		Given I have logged in as a <Persona>
		And I navigate to main Area and SubArea Office Hours
		And I have clicked New command in View
		When I wait for 2000 specific time    
	   #And I clear existing values in ownerid lookup field
		When I wait for 2000 specific time
		#When I have set <UserName> to ownerid lookup item in the Form
		#And I wait for 2000 specific time
		And I handle the dialog action button confirmButton only if available
		When I have set <UserLocation> to cmc_userlocationid lookup item in the Form
		When I wait for 2000 specific time
		And I handle the dialog action button confirmButton only if available
		And I wait for 2000 specific time
		And I have set <OfficeHoursType> to cmc_officehourstype optionset field in the Form
		When I wait for 2000 specific time
		And I have set <StartDate> to cmc_startdate date field in the Form
		And I wait for 2000 specific time
		And I have set <EndDate> to cmc_enddate date field in the Form
		And I wait for 2000 specific time
		Then I switch to WebResource_timePicker frame
		When I wait for 2000 specific time
		When I have set <StartTime> to Start Time in the kendo time field in 1 section
		And I wait for 2000 specific time
		When I have set <EndTime> to End Time in the kendo time field in 2 section
		And I wait for 2000 specific time
		And I select Monday under Day of Week section
		And I wait for 5000 specific time
		Then I switch back to default frame
		And I press Save in the form
		Then the Entity should be saved
		#Then I Select My Appointment Calendar webresource from Tools group


Examples: 
| TestCaseID | Persona                   | UserName                | UserLocation                                             | OfficeHoursType | StartDate  | EndDate    | StartTime | EndTime |
| 1057428    | BusinessUnitAdministrator | anthologyd365automation | Anthology D365 Automation - In-person - Account-1057428  | 175490000       | 01/04/2020 | 12/12/2020 | 10        | 11       |

@Regression
Scenario: Users should have ability to filter availability based on appointment type 

		Given I have logged in as a <Persona>
		And The handle live assist pop-up only if available
		##Click on My Appointment Sub Area unnder Tools group
		Then I Select My Appointments webresource from Tools group
		When I wait for 9000 specific time		
		
		##Switch the webdriver control to My Appointment Web resource content
		Then I switch to FullPageWebResource frame		
		Then I click on Book Appointment Button
		When I wait for 4000 specific time
		When I select value as Virtual in field deliverytypes
		And I wait for 2000 specific time
		And I select value as Interview in field appointmenttypes
		When I wait for 2000 specific time	
	    And I select anthologyd365automation in userIdSelect related optional field
		And I wait for 2000 specific time
		And I select UIAuto-Department-1057428 in departmentSelect related optional field
		And I wait for 2000 specific time
		And I select Show Availability Button under schedule appointment grid
		And I wait for 6000 specific time
		Then I click on available 10 PM slot
		Then I switch back to default frame
		And I wait for 2000 specific time
		And I have set CMC Mansa to regardingobjectid field in the lookup dialog
		And I wait for 4000 specific time
		When I press Save in QuickCreate
		Then the QuickCreate should be saved
		
		
Examples: 
| TestCaseID | Persona                   | Area   | SubArea      | SubGroup                | UserName | UserLocation | OfficeHoursType | StartDate | EndDate | StartTime | EndTime |
| 1063124    | BusinessUnitAdministrator | Reach | Office Hours | My Appointment Calendar | anthologyd365automation | engage | 175490000 | 01/04/2020 | 12/12/2020 | 10:00 | 11:00   |

@Regression
@Done
Scenario: The calendar should default to Day view with option to switch to Month and Week view 

		Given I have logged in as a <Persona>
		#And I have navigated to the Area <Area> and SubArea <SubArea>
		##Click on My Appointment Sub Area unnder Tools group
		And I have navigated to the Area Reference Data and SubArea User Locations
		And I navigate to main Area and SubArea Office Hours
		And I wait for 4000 specific time
		Then I Select My Appointments webresource from Tools group
		When I wait for 8000 specific time
	    And The handle live assist pop-up only if available
		##Switch the webdriver control to My Appointment Web resource content
		Then I switch to FullPageWebResource frame
		##Validate Day View
		And I wait for 5000 specific time
		Then I clcik on Month View of the Staff Calendar
		And I wait for 3000 specific time
		And I capture screenshot
		##Validate Month View
		Then I clcik on Week View of the Staff Calendar
		And I wait for 3000 specific time
		And I capture screenshot
		##Validate Week View
		Then I clcik on Day View of the Staff Calendar
		And I wait for 3000 specific time
		And I capture screenshot
		And I switch back to default frame
		And I wait for 1000 specific time
		
		
Examples: 
| TestCaseID | Persona                   | SubGroup | UserName | UserLocation | OfficeHoursType | StartDate | EndDate | StartTime | EndTime |
| 1059719    | BusinessUnitAdministrator | My Appointment Calendar | anthologyd365automation | engage | 175490000 | 01/04/2020 | 12/12/2020 | 10:00  | 11:00   |

#Scenario: Validate cancellation of Appointment from Staff Calendar without deleting the appointment
#
# 
#
#
#        Given I have logged in as a <Persona>       
#        ##Click on My Appointment Sub Area unnder Tools group
#        Then I Select My Appointments webresource from Tools group
#        When I wait for 7000 specific time              
#        Then I switch to FullPageWebResource frame        
#        When I wait for 7000 specific time    
#        Then I click on Book Appointment Button
#        When I wait for 4000 specific time
#       ## When I select value as Virtual in field deliverytypes
#        And I wait for 2000 specific time
#        #And I select engage automation in userIdSelect related optional field
#        And I wait for 2000 specific time
#       #And I select UIAuto-Department-1057428 in departmentSelect related optional field
#      # And I wait for 2000 specific time
#      #        And I select Account-1062784 in locationSelect related optional field
#        Then I click on Show Availability Button under schedule appointment grid
#        When I wait for 8000 specific time
#        #Then I click on Book Appointment - 30  minutes schedule  grid
#        #When I wait for 8000 specific time
#        Then I click on Title Cancel Appointment
#        #Then I cancel the appointment Title-12-Rohit sharma in the Staff Calendar
#        When I wait for 8000 specific time
#
# 
#
#                   
#Examples: 
#| TestCaseID | Persona                   | Area   | SubArea      | SubGroup                | UserName | UserLocation | OfficeHoursType | StartDate | EndDate | StartTime | EndTime |
#| 1063124    | BusinessUnitAdministrator | Engage | Office Hours | My Appointment Calendar | engage automation | engage | 175490000 | 01/04/2020 | 12/12/2020 | 10:00 | 11:00   |

@Regression
Scenario: Validate cancellation of Appointment from Staff Calendar without deleting the appointment
		
		Given I have logged in as a <Persona>
		And I navigate to main Area and SubArea <SubArea>
		And The handle live assist pop-up only if available
		Then I wait for 2000 specific time	
		Then I Select My Appointments webresource from Tools group
		When I wait for 7000 specific time		
		##Switch the webdriver control to My Appointment Web resource content
		Then I switch to FullPageWebResource frame	
		When I wait for 2000 specific time	
		Then I click on Book Appointment Button
		When I wait for 9000 specific time	
		And I select value as In-person in field deliverytypes
		When I wait for 2000 specific time	
		And I select value as Interview in field appointmenttypes
		When I wait for 2000 specific time
		And I select Show Availability Button under schedule appointment grid
		When I wait for 7000 specific time
        #Then I click on Book Appointment - 30  minutes schedule  grid
		#When I wait for 8000 specific time
		And I cancel TitleA- Appointment
		#Then I click on TitleA- Cancel Appointment		
		When I wait for 2000 specific time	
		Then I validate Required Message Reason : Required field must be filled in. notification in the dialog	
		When I wait for 1000 specific time
		Then I close cancel appointment pop-up
		When I wait for 1000 specific time
		And I cancel TitleA- Appointment
		When I wait for 2000 specific time 
		Then I select Marked as Block checkbox
		#Then Then I Click on Marked as Block
		When I wait for 1000 specific time
		Then I validate Required Message Reason : Required field must be filled in. notification in the dialog	
		When I wait for 1000 specific time
		Then I close cancel appointment pop-up
		When I wait for 4000 specific time
		And I cancel TitleA- Appointment		
		When I wait for 8000 specific time
		Then I provide the reason TestCancel-Appointment and click on Yes button
		When I wait for 8000 specific time
		Then I Verify Appointment with TitleA- should not avaialable
		When I wait for 8000 specific time
		And I cancel TitleB- Appointment
		#Then I click on TitleB- Cancel Appointment
		When I wait for 4000 specific time
		Then I select Marked as Block checkbox
		When I wait for 1000 specific time
		Then I provide the reason TestBlock-Appointment and click on Yes button
		When I wait for 4000 specific time
		Then I Verify Appointment with TitleB- should not avaialable
		When I wait for 4000 specific time
		

				   
Examples: 
| TestCaseID | Persona                   | Area   | SubArea      | SubGroup                | UserName | UserLocation | OfficeHoursType | StartDate | EndDate | StartTime | EndTime |
| 1017285    | BusinessUnitAdministrator | Engage | Office Hours | My Appointment Calendar | anthologyd365automation | engage | 175490000 | 1/18/2022 | 1/31/2022 | 09:00 | 16:00  |
