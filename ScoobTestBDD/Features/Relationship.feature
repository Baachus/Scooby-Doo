Feature: Relationship

This feature verifies the Relationship pages

Background: 
	Given I cleanup the following data
		| Name              | Relationship | Appearance                   | Gang   |
		| RelationshipTable | Child        | {"Test":"RelationshipTable"} | Shaggy |

Scenario: Verify Back to List works on every modify page, i.e. Edit, Details, and Delete
	Given I click the Relationship menu
	When I click the "Create New" link
	And I create a relationship with the following details
		| Name              | Relationship | Appearance                   | Gang   |
		| RelationshipTable | Child        | {"Test":"RelationshipTable"} | Shaggy |
	And I click the Details link of the newly created relationship
	And I click the Back to List link
	Then I verify I am on the Relationship page
	When I click the Edit link of the newly created relationship
	And I click the Back to List link
	Then I verify I am on the Relationship page
	When I click the Delete link of the newly created relationship
	And I click the Back to List link
	Then I verify I am on the Relationship page
	And I delete the RelationshipTable relationship
	When I click the "Create New" link
	And I click the Back to List link
	Then I verify I am on the Relationship page

Scenario: Verify the default sorting order of the records on the Relationship Table
	Given I click the Relationship menu
	Then all records are sorted by ID in ascending order

Scenario: Verify Sorting by ID works as intended on the Relationship Table
	Given I click the Relationship menu
	Then all records are sorted by ID in ascending order
	When I click the ID sort
	Then all records are sorted by ID in descending order
	When I click the ID sort
	Then all records are sorted by ID in ascending order

Scenario: Verify Sorting by Name works as intended on the Relationship Table
	Given I click the Relationship menu
	When I click the Name sort
	Then all records are sorted by Name in ascending order
	When I click the Name sort
	Then all records are sorted by Name in descending order


Scenario: Verify Sorting by Gang works as intended on the Relationship Table
	Given I click the Relationship menu
	When I click the Gang sort
	Then all records are sorted by Gang in ascending order
	When I click the Gang sort
	Then all records are sorted by Gang in descending order
	
Scenario: Verify Sorting by Relationship works as intended on the Relationship Table
	Given I click the Relationship menu
	When I click the Relationship sort
	Then all records are sorted by Relationship in ascending order
	When I click the Relationship sort
	Then all records are sorted by Relationship in descending order
