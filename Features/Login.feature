Feature: User login 

user can login with valid username and password, remember the username and password, invalid input cannot login

Background: Enter the specified page
	Given that I am in the home page
	And I can select Login

	# login with valid username and password
Scenario: I enter valid username and password 
	Given that I enter valid username and password
	| name    | password |
	| test001 | Test1234 |
	And select Login
	Then the page jumped
	And I can see my avatar

	# login with valid username and password and select remember me
Scenario: I enter valid username and password and select remember me
	Given that I enter valid username and password
	| name    | password |
	| test001 | Test1234 |
	And select remember me
	* select Login
	Then the page jumped
	And I can see my avatar

	# login with invalid username and password
Scenario: I enter invalid username and password 
	Given that I enter invalid username and password
	| name | password |
	| abc  | abc      |
	And select Login
	Then error meaasge shows up