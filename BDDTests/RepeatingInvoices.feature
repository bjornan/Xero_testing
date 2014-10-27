Feature: RepeatingInvoices
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add new repeating invoices
	Given I have created a new repeating invoice
	And I have entered all required parameters
	When I press save
	Then the result should be an repeating invoice with correct data
