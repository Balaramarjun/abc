# Specflow Guidelines

## Feature Files

- One Feature file for each module  
    Additional sub-folders can be created, where the modules can be subdivided

    ```folder
    Features
        |---Retention
            |--ScoringFactor.feature
            |--SuccessPlan.feature
        |---Trips
            |--TravelPlan.feature
    ```

- Feature must have a one-line description

## Scenario

- Keep each Scenario independent  
    Data created in one scenario cannot be assumed to be available in another scenario
- Scenario must have a description  
    Following format can be used to define the scenario

    ```feature
    Scenario: As [concrete user]
    I want [take a concrete action]
    for [result or benefit]
    ```

- Scenario steps must follow the Given-When-Then format

    ```feature
    Given I meet a precondition
    When I execute an action
    Then I observe this result
    ```

    Then should correspond to the acceptance criteria  
    Multiple statements of Given/When/Then should be having the “And” keyword prefixed instead of the Given/When/Then [Refer Sample](#sample-feature-file)

- Scenario steps should be well indented
  - Scenario fist line should not be indented  
  - New lines in scenario should be indented by 1 tab  
  - Given/When/Then steps should be indented by 1 tab  
  - “And” statements should be indented by an extra tab  
    [Refer Sample](#sample-feature-file)

- Step Tables can be used when repetitive data needs to be specified  
    Table data should be indented by an extra tab and end with a new line to improve readability
    [Refer Sample](#sample-feature-file)

- Steps with table data should end with a colon “:”
- “Examples” must be used to specify data in the Scenario  
    Instead of hard coding within the Given/When/Then statements, Example keyword can be used to specify data  
    The Examples line must be indented by a tab  
    The table data can also refer the data from the Examples
    [Refer Sample](#sample-feature-file)

- Multiple examples can be specified to test with multiple data  
    The first column “case” must be provided to give appropriate test name [Refer Sample](#sample-feature-file)

- Use comments to describe any specific behavior  
    Comments can be added by prefixing the line with #.

### Sample Feature file

```feature
@Account
Feature: Account Management

@Smoke
@Regression
Scenario: As Advisor
    I want to create College
    for mantaining Education history

	Given I have logged in as a <Persona>
		And I have navigated to the Area <Area> and SubArea <SubArea>
		And I have clicked New command in View
		And I have set <AccountName> to name text field in the Form
		And I have set <AccountType> to mshied_accounttype optionset field in the Form
	When I press Save in the form
	Then the Entity should be saved

	Examples:
	| case           | Persona | Area         | SubArea  | AccountName | AccountType |
	| Create Account | Advisor | Constituents | Accounts | ALS         | College     |
```

## Categorizing Test Cases

- Use Tags to categorize your tests  
    Tags can be provided at the feature level as well as the Scenario level  Tags specified at the Feature Level are applied for all the Scenarios  Additional Tags can be given at the Scenario Level
- Tag at Feature Level with respective **Module Name**
- Tag at Scenario Level with **Regression**  
    As we would be targeting all regression test cases initially, mark all the scenarios with the tag @Regression

## Step Bindings 

- Step Bindings should define declaratively what is being achieved rather than the individual UI actions as much as possible  
    Example:  
    Instead of writing as

    ```feature
    Given I am on the homepage
    When I click on the "Login" button
    And I fill in the "Email" field with "me@example.com"
    And I fill in the "Password" field with "secret"
    And I click on "Submit"
    Then I should see "Welcome to the app, John Doe"
    ```

    It should be written as

    ```feature
    Given I am on the homepage
    When I log in
    Then I should see a login notification
    ```

- Step bindings should be reusable