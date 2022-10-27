Feature: Register error info

user register with invalid input error message should shows up

Scenario Outline:  error message for user invalid input in register page
	Given I am on the register page
	When I enter email with <email>, username with <name>, password with <pass>, verification with <ver>
	And I click register
	Then I can see <error> error message <message>
	And verification error message
	Examples: 	
	| email   | name | pass  | ver  | error | message                |
	| a       | aaaa | aaaaa | aaaa | email | 请输入有效的电子邮件地址           |
	| a@a.com | -    | aaaaa | aaaa | name  | 字符长度必须大于等于4，一个中文字算2个字符 |
	| a@a.com | aaaa | a     | aaaa | pass  | 最少需要输入 5 个字符           |
	| a       | -    | a     | aaaa | all   | all                    |


