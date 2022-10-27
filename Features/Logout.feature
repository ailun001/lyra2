Feature: User Logout

after login user can logout

Background: Enter the specified page and successful login
	Given that I am in the login page
	And that I enter valid username and password
	| name    | password |
	| test001 | Test1234 |
	And select Login




Scenario: I am on the home page with logon, I want logout
	Given I can see my avatra
	And I move mouse hover on my avatar
	When I can see logout link
	And I click the logout link
	Then I an on the login page
	

