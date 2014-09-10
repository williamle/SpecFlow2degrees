Feature: Login
	In order to manage my 2degrees account
	As a 2degrees subscriber
	I need to login my 2degrees account 

@Login
Scenario: Login at your 2degrees
	Given I am on Your2degrees login page
	And I have my login credentials as below
	| Your Mobile Number | Password |
	| 0220406949		 | abc123	|
	When I enter my login details
	And I click on 'Log in to Your 2degrees Account' button
	Then I should see my product type
	And I should see my mobile number
	And I should see the summary of my balances as below
	| NZ Data | Standard Minutes | Standard Text   |
	| 921MB   | 429              | Unlimited Text* |