Feature: Admin manage order

login as admin can manage order

Background: homepage to order manage page with admin logged in 
	Given that I am in the home page
	And I login with admin
	And I move mouse hover on my avatar
	And I can see management background link
	And I select manage background
	Then I am on the manage page

Scenario: defult search for course order
	Given I am on the manage page
	And I goto order manage page
	When I can see course order link
	And I select course order 
	And I click search button 
	Then I can see some orders

Scenario: defult search for class order
	Given I am on the manage page
	And I goto order manage page
	When I can see class order link
	And I select class order 
	And I click search button 
	Then I can see some orders

Scenario Outline: mutiple search for course order with different filters
	Given I am on the manage page
	And I goto order manage page
	When I can see course order link
	And I select course order 
	And I enter <filters> with <detial>
	And I click search button 
	Then I can see some orders
	Examples: 
	| filters       | detial           |
	| startDateTime | 2017.12.14 22:51 |
	| status        | 已付款              |
	| payment       | 支付宝              |
	| keywordType   | 课程名称             |

Scenario Outline: mutiple search for class order with different filters
	Given I am on the manage page
	And I goto order manage page
	When I can see class order link
	And I select class order 
	And I enter <filters> with <detial>
	And I click search button 
	Then I can see some orders
	Examples: 
	| filters       | detial           |
	| startDateTime | 2017.12.14 22:51 |
	| status        | 已付款              |
	| payment       | 支付宝              |
	| keywordType   | 课程名称             |