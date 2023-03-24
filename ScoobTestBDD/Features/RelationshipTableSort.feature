Feature: RelationshipTableSort

This feature verifies the Relationship pages and their ability to sort based upon
the column titles

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


