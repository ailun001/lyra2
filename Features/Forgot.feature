Feature: Forgot password input

A short summary of the feature

Background: 
	Given I am on the login page
	And I select forgot password link
	Then I am on the reset password page

Scenario Outline:  user input invalid email
	Given I am on the reset password page
	When I can see email input box
	And I enter <email> in resetpage
	And I click reset password
	Then I can see <error> message <message> in reset page
	Examples: 
	| email      | error         | message      |
	| a@a.com    | emailNotExist | 该邮箱地址没有注册过帐号 |
	| 123@12.com | emailNotExist | 该邮箱地址没有注册过帐号 |

Scenario Outline:  user input invalid input
	Given I am on the reset password page
	When I can see email input box
	And I enter <email> in resetpage
	Then I can see <error> message <message> in reset page
	Examples: 
	| email | error   | message      |
	| aa    | invalid | 请输入有效的电子邮件地址 |
	| 123   | invalid | 请输入有效的电子邮件地址 |



