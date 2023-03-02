Feature: CreateRelationship

This feature tests the Create New page for generating a new Relationship 
and subsequent options around that page.

Scenario: Verify Shaggy option is available when creating new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	Then I can verify the Gang dropdown has the following option for Shaggy
	
Scenario: Verify Scooby option is available when creating new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	Then I can verify the Gang dropdown has the following option for Scooby
	
Scenario: Verify Velma option is available when creating new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	Then I can verify the Gang dropdown has the following option for Velma
	
Scenario: Verify Daphne option is available when creating new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	Then I can verify the Gang dropdown has the following option for Daphne
	
Scenario: Verify Fred option is available when creating new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	Then I can verify the Gang dropdown has the following option for Fred