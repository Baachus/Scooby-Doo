Feature: EditRelationship

This feature tests the Edit Relationship page for editing a relationship 
and subsequent options around that page.

Background: 
	Given I cleanup the following data
		| Name                 | Relationship | Appearance           | Gang   |
		| AutomationTest       | Uncle        | {"Test":"test_data"} | Fred   |
		| AutomationTestEdited | Child        | {"Test":"test_data"} | Velma  |
		| EditRelationship     | Uncle        | {"Test":"test_data"} | Fred   |
		| MaxLength            | Uncle        | {"Test":"test_data"} | Velma  |
		| OverMax              | Uncle        | {"Test":"test_data"} | Daphne |
		| BackToList           | Mother       | {"Test":"test_data"} | Shaggy |
		

@Smoke_Test @retry(1)
Scenario: Edit the relationship, verify the details, and remove the new relationship
	Given I ensure the following relationship is created
		| Name           | Relationship | Appearance           | Gang |
		| AutomationTest | Uncle        | {"Test":"test_data"} | Fred |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I edit the relationship with the following details
		| Name                 | Relationship | Appearance                       | Gang  |
		| AutomationTestEdited | Child        | {"EditedTest":"Editedtest_data"} | Velma |
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the AutomationTestEdited relationship
	And I delete the AutomationTest relationship

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

@retry(2)
Scenario: Verify the max length when editing a relationship for a Name is 60 characters and Relationship is 100 characters
	Given I ensure the following relationship is created
		| Name      | Relationship | Appearance           | Gang |
		| MaxLength | Uncle        | {"Test":"test_data"} | Fred |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I enter a random sentence into the name field that is 60 characters long
	Then I can verify only 60 characters are allowed in the name field
	When I enter a random sentence into the relationship field that is 100 characters long
	Then I can verify only 100 characters are allowed in the relationship field
	And I delete the MaxLength relationship

@retry(2)
Scenario: Verify the Name is trimmed to 60 characters and Relationship is 100 characters when editing a relationship
	Given I ensure the following relationship is created
		| Name    | Relationship | Appearance           | Gang |
		| OverMax | Uncle        | {"Test":"test_data"} | Fred |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I enter a random sentence into the name field that is 61 characters long
	Then I can verify only 60 characters are allowed in the name field
	When I enter a random sentence into the relationship field that is 101 characters long
	Then I can verify only 100 characters are allowed in the relationship field
	And I delete the OverMax relationship

Scenario: Back to list does not save changes when editing
	Given I ensure the following relationship is created
		| Name       | Relationship | Appearance           | Gang   |
		| BackToList | Mother       | {"Test":"test_data"} | Shaggy |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I edit the relationship with the following details but do not save
		| Name             | Relationship | Appearance                       | Gang  |
		| EditedBackToList | Child        | {"EditedTest":"Editedtest_data"} | Velma |
	And I click the Back to List link
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the BackToList relationship
