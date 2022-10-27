Feature: upload user avatar

user can edit their info after their login

Background: homepage to account setting page with user logged in 
	Given that I am in the home page
	And I already logged in
	And I move mouse hover on my avatar
	And I can see account seting link
	And  I select account setting 
	Then I am on the account setting page

Scenario: change avatar
	Given I am on the account setting page
	And I can see avatar setting link
	And I select avatat setting
	When I upload a avatar 
	And  I click save
	Then button change to upload new avatar




	