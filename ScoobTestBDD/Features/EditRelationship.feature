Feature: EditRelationship

This feature tests the Edit Relationship page for editing a relationship 
and subsequent options around that page.

Background: 
	Given I cleanup the following data
		| Name             | Relationship | Appearance           | Gang |
		| EditRelationship | Uncle        | {"Test":"test_data"} | Fred |


Scenario: Verify the Gang options are available when editing new relationship
	Given I ensure the following relationship is created
		| Name             | Relationship | Appearance           | Gang |
		| EditRelationship | Uncle        | {"Test":"test_data"} | Fred |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	Then I can verify the Gang dropdown has the following option for Shaggy
	And I can verify the Gang dropdown has the following option for Scooby
	And I can verify the Gang dropdown has the following option for Velma
	And I can verify the Gang dropdown has the following option for Daphne
	And I can verify the Gang dropdown has the following option for Fred
	And I delete the EditRelationship relationship

Scenario: Verify the max length when editing a relationship for a Name is 60 characters and Relationship is 100 characters
	Given I ensure the following relationship is created
		| Name             | Relationship | Appearance           | Gang |
		| EditRelationship | Uncle        | {"Test":"test_data"} | Fred |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I enter a random sentence into the name field that is 75 characters long
	Then I can verify only 60 characters are allowed in the name field
	When I enter a random sentence into the relationship field that is 150 characters long
	Then I can verify only 100 characters are allowed in the relationship field
