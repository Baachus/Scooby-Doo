Feature: HomePage

A short summary of the feature

@Smoke_Test
Scenario: Verify Header Links
	Given I am on the Welcome Page
	When I click the Privacy Link
	Then I am on the Privacy page
	When I click the Relationship Link
	Then I am on the Relationship page
	When I click the Home Link
	Then I am on the Home page
