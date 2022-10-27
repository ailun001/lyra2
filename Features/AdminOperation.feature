Feature: Admin manage Operation

login as admin can manage information and category

Background: homepage to order manage page with admin logged in 
	Given that I am in the home page
	And I login with admin
	And I move mouse hover on my avatar
	And I can see management background link
	And I select manage background
	And I goto operation page
	Then I am on the operation page

Scenario Outline: info management filter
	Given I am on the operation page
	When I can see Information management link
	And I select Information management 
	And I enter <filters> with <detial>
	And I click search button in Information management page
	Then I can see some orders
	And <order> order match result
	Examples: 
	| filters  | detial | order |
	| keywords | +      | 13     |
	| property | 头条     | 20     |
	| status   | 已发布    | 75     |

Scenario Outline:  info management filter with category
	Given I am on the operation page
	When I can see Information management link
	And I select Information management 
	And I click cayegory
	And I enter keyword <word>
	And I select match result <result>
	And I click search button in Information management page
	Then I can see some orders
	And <order> order match result
	Examples: 
	| word    | order | result |
	| EduSoho | 79    | 499    |
	
Scenario Outline: change article status
	Given I am on the operation page
	When I can see Information management link
	And I select Information management 
	And I change <id> article status to <status>
	Then I can see <id> article status change to <currentstatus>
	Examples: 
	| id | status | currentstatus |
	| 79 | 发布     | 已发布           |
	| 79 | 取消发布   | 未发布           |

Scenario Outline: add category
	Given I am on the operation page
	When I can see category management link
	And I select category management 
	And I select add category
	And I enter name <name>, code <code>, pre <pre>, title <title>, keyword <keyword>, desc <desc>, publish <publish>
	And  I save category
	Then I can see new category added <name>
	Examples: 
	| name  | code  | pre | title | keyword | desc  | publish |
	| Test_ | Test_ | 0   | Test_ | Test_   | Test_ | 1       |

Scenario Outline: edit category
	Given I am on the operation page
	When I can see category management link
	And I select category management 
	And I select edit <id>
	And I change name <name>, code <code>, pre <pre>, title <title>, keyword <keyword>, desc <desc>, publish <publish>
	And  I save category
	Then I can see category changed <id> <name>
	Examples: 
	| id  | name  | code  | pre | title | keyword | desc  | publish |
	| 823 | Test_ | Test_ | 0   | Test_ | Test_   | Test_ | 1       |