Feature: Join

As a user I can join the membership for Rewards4Racing

@ignore
Scenario: Join as new user
	Given I click the join link
	And I enter name, email and password
		| Name     | Email              | Password  |
		| Example2 | example2@gmail.com | Rewards4! |
	And I click join now
	Then I should see user has joined successfully