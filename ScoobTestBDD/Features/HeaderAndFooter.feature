Feature: Header and Footer

This feature file verifies the welcome page along with the header links that 
are present on each page.

@Smoke_Test
Scenario: Header links bring the user to the correct pages.
	When I click the Relationship menu
	Then I verify I am on the Relationship page
	When I click the Privacy menu
	Then I verify I am on the Privacy page
	When I click the Home menu
	Then I verify I am on the Home page
	When I click the ScoobWebApp menu
	Then I verify I am on the Home page

Scenario: ScoobWebApp links bring the user to the home page from any page.
	Given I click the Relationship menu
	When I click the ScoobWebApp menu
	Then I verify I am on the Home page
	Given I click the Privacy menu
	When I click the ScoobWebApp menu
	Then I verify I am on the Home page
	Given I click the Home menu
	When I click the ScoobWebApp menu
	Then I verify I am on the Home page

Scenario: Relationship links bring the user to the home page from any page.
	Given I click the Home menu
	When I click the Relationship menu
	Then I verify I am on the Relationship page
	Given I click the Privacy menu
	When I click the Relationship menu
	Then I verify I am on the Relationship page
	Given I click the Relationship menu
	When I click the Relationship menu
	Then I verify I am on the Relationship page

Scenario: Privacy links bring the user to the home page from any page.
	Given I click the Home menu
	When I click the Privacy menu
	Then I verify I am on the Privacy page
	Given I click the Relationship menu
	When I click the Privacy menu
	Then I verify I am on the Privacy page
	Given I click the Privacy menu
	When I click the Privacy menu
	Then I verify I am on the Privacy page

Scenario: Home links bring the user to the home page from any page.
	Given I click the Home menu
	When I click the Home menu
	Then I verify I am on the Home page
	Given I click the Privacy menu
	When I click the Home menu
	Then I verify I am on the Home page
	Given I click the Relationship menu
	When I click the Home menu
	Then I verify I am on the Home page

Scenario: Privacy footer links bring the user to the home page from any page.
	Given I click the Home menu
	When I click the Privacy menu in the footer
	Then I verify I am on the Privacy page
	Given I click the Relationship menu
	When I click the Privacy menu in the footer
	Then I verify I am on the Privacy page
	Given I click the Privacy menu
	When I click the Privacy menu in the footer
	Then I verify I am on the Privacy page