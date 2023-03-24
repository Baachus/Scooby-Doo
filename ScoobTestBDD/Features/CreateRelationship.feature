Feature: CreateRelationship

This feature tests the Create New page for generating a new Relationship 
and subsequent options around that page.

Background: 
	Given I cleanup the following data
		| Name          | Relationship | Appearance                | Gang   |
		| CreationTable | Child        | {"Test":"Creation_Table"} | Shaggy |

@Smoke_Test @retry(1)
Scenario: Create a relationship, verify the details in the relationship table, and remove the new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	And I create a relationship with the following details
		| Name          | Relationship | Appearance                | Gang   |
		| CreationTable | Child        | {"Test":"Creation_Table"} | Shaggy |
	Then I see the new relationship on the relationship table
	And I delete the CreationTable relationship

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

Scenario: Verify max characters allowed to enter in Name is 60
	Given I click the Relationship menu
	When I click the "Create New" link
	And I enter random characters into the Name field that is 60 characters long on the edit page
	Then I can verify only 60 characters are allowed in the Name field on the edit page

Scenario: Verify max characters allowed to enter in Relationship is 100
	Given I click the Relationship menu
	When I click the "Create New" link
	And I enter random characters into the Relationship field that is 100 characters long on the edit page
	Then I can verify only 100 characters are allowed in the Relationship field on the edit page

Scenario: Verify Name is trimmed to 60 characters when creating a new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	And I enter random characters into the Name field that is 61 characters long on the edit page
	Then I can verify only 60 characters are allowed in the Name field on the edit page

Scenario: Verify relationship is trimmed to 100 characters when creating a new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	And I enter random characters into the Relationship field that is 101 characters long on the edit page
	Then I can verify only 100 characters are allowed in the Relationship field on the edit page