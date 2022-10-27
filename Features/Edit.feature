Feature: Edit user info

A short summary of the feature

Background: homepage to account setting page with user logged in 
	Given that I am in the home page
	And I already logged in
	And I move mouse hover on my avatar
	And I can see account seting link
	And  I select account setting 
	Then I am on the account setting page

Scenario: user can update info
	Given I am on the account setting page
	When I upload the info
	Then I can see success message

Scenario: error message for invalid input in setting page
	Given I am on the account setting page
	When I enter invalid info
	| name                | id | phone | title                      | profile | weibo | qq |
	| 1234567890123456789 | 1  | 14    | 12345678901234567890123456 | 1       | 1     | 1  |
	And I upload the info
	Then I can see error message in setting page
	| error   | message                      |
	| name    | 最多只能输入 18 个字符                |
	| id      | 请正确输入您的身份证号码                 |
	| phone   | 请输入正确的手机号                    |
	| title   | 最多只能输入 24 个字符                |
	| profile | 地址不正确，须以http://或者https://开头。 |
	| weibo   | 地址不正确，须以http://或者https://开头。 |
	| qq      | 请输入正确的QQ号                    |