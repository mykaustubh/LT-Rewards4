Feature: Login
	Check if I can login as a user Rewards4Racing page

Scenario: Login as a member
	Given I navigate to <Homepage>
	And I click the Sign In link
	And I enter <Email> and <Password>
	And I click login
	Then I should see user logged in to the application
Examples: 
| Homepage                       | Email              | Password  |
| https://www.rewards4racing.com | example3@gmail.com | Rewards4! |