Feature: DataIntegration
	
@Regression
Scenario: 01 Validate 'Integration Mappings' new forms and fields changes
	
	##'Field Mapping' form and fields check
	Given I have logged in as a <Persona>
	And I have navigated to the Area <Area> and SubArea <SubArea> 
	And I wait for 3000 specific time
	When I have clicked New command in View
	And I select Field Mapping Form
	Then I verify below fields
	| Type  | sectionLabel | FieldName                              | FieldValue |
	| Field | Field Details      | Name								|	         |
	| Field | Field Details      | Template Type					|            |
	| Field | Field Details      | Mapping Type                     |            |
	| Field | Field Details      | Entity Name						|            |
	| Field | Field Details      | Internal Field Name				|            |
	| Field | Field Details      | External Field Name		        |            |
	| Field | Field Details      | Data Transformation Type		    |            |
	| Field | Field Details      | Parameters	                    |            |
	| Field | Field Details      | Record Type	                    |            |
	| Field | Field Details      | Field Value Start Position	    |            |
	| Field | Field Details      | Field Value Length	            |            |
	| Field | Additional Details      | Dataset Name	            |            |
	| Field | Additional Details      | Parent Lookup Field	        |            |
	| Field | Additional Details      | Overwrite with Blank	    |     NO     |
	| Field | Additional Details      | Reset Multi Select Value	|     NO     |
	And I wait for 1000 specific time
	When I press Save in the form
	And I wait for 2000 specific time
	Then I validate Name : Required fields must be filled in. notification/s in the form
	And I wait for 1000 specific time
	When I have set <MappingName> to cmc_name text field uniquely in the Form
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 1000 specific time
	
	##'Data Mapping' form and fields check
	Given I have clicked New command in View
	When I select Data Mapping Form
	Then I verify below fields
	| Type  | sectionLabel | FieldName                              | FieldValue |
	| Field | Dataset Details      | Name							|	         |
	| Field | Dataset Details      | Mapping Type					|            |
	| Field | Dataset Details      | Dataset Name                   |            |
	| Field | Dataset Details      | External Option Value			|            |
	| Field | Dataset Details      | Internal Option Value			|            |
	| Field | Dataset Details      | External Option Display Name	|            |
	| Field | Dataset Details      | Internal Option Display Name	|            |
	And I wait for 1000 specific time
	When I press Save in the form
	And I wait for 2000 specific time
	Then I validate Name : Required fields must be filled in. notification/s in the form
	And I wait for 1000 specific time
	When I have set <MappingName> to cmc_name text field uniquely in the Form
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 1000 specific time
	
	##'Export' form and fields check
	Given I have clicked New command in View
	When I select Export Form
	Then I verify below fields
	| Type  | sectionLabel | FieldName                              | FieldValue |
	| Field | Export Details      | Name							|	         |
	| Field | Export Details      | Entity Name						|            |
	| Field | Export Details      | Template Type                   |            |
	| Field | Export Details      | Mapping Type					|            |
	| Field | Export Details      | External Field Name				|            |
	| Field | Export Details      | Internal Field Name				|            |
	| Field | Export Details      | Data Transformation Type		|            |
	| Field | Export Details      | Parameters						|            |
	| Field | Export Details      | Record Type						|            |
	And I wait for 1000 specific time
	When I press Save in the form
	And I wait for 2000 specific time
	Then I validate Name : Required fields must be filled in. notification/s in the form
	And I wait for 1000 specific time
	When I have set <MappingName> to cmc_name text field uniquely in the Form
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 1000 specific time
	
	##'Export Entity' form and fields check
	Given I have clicked New command in View
	When I select Export Entity Form
	Then I verify below fields
	| Type  | sectionLabel | FieldName                              		| FieldValue |
	| Field | Export Entity Details      | Name								|	         |
	| Field | Export Entity Details      | Entity Name						|            |
	| Field | Export Entity Details      | Parent Entity (Export)           |            |
	| Field | Export Entity Details      | Template Type					|            |
	| Field | Export Entity Details      | Record Type						|            |
	| Field | Export Entity Details      | Primary Key Column Name (Export)	|            |
	| Field | Export Entity Details      | Parent Integration Mapping     	|            |
	| Field | Additional Details      | Relationship Field Name (Export)	|            |
	| Field | Additional Details      | Query (Export)						|            |
	| Field | Additional Details      | Is Many Sided (Export)				|     No     |
	| Field | Additional Details      | Add To Parent Entity (Export)		|     No     |
	| Field | Additional Details      | Root Entity (Export)				|     No     |
	And I wait for 1000 specific time
	When I press Save in the form
	And I wait for 2000 specific time
	Then I validate Name : Required fields must be filled in. notification/s in the form
	And I wait for 1000 specific time
	When I have set <MappingName> to cmc_name text field uniquely in the Form
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 1000 specific time
	
	##'Export File Names' form and fields check
	Given I have clicked New command in View
	When I select Export File Names Form
	Then I verify below fields
	| Type  | sectionLabel | FieldName                              		| FieldValue |
	| Field | Export File Details      | Name								|	         |
	| Field | Export File Details      | Template Type						|            |
	| Field | Export File Details      | Root Entity (Export)           	|     No     |
	| Field | Export File Details      | File Name (Export)					|            |
	| Field | Export File Details      | File Type (Export)					|            |
	
	And I wait for 1000 specific time
	When I press Save in the form
	And I wait for 2000 specific time
	Then I validate Name : Required fields must be filled in. notification/s in the form
	And I wait for 1000 specific time
	When I have set <MappingName> to cmc_name text field uniquely in the Form
	And I press Save in the form
	Then the Entity should be saved
	And I wait for 1000 specific time
	

Examples:
| Test Case ID | Persona		      | Area 	   | SubArea              | MappingName  |
|	1388820	   | SystemAdministrator  | Settings   | Integration Mappings | UIAutonewform|