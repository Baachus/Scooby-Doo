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
