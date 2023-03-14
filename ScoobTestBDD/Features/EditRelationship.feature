Feature: EditRelationship

This feature tests the Edit Relationship page for editing a relationship 
and subsequent options around that page.

Background: 
	Given I cleanup the following data
		| Name            | Relationship | Appearance                 | Gang   |
		| Edit            | Uncle        | {"Test":"Edit"}            | Fred   |
		| Edited          | Child        | {"Test":"Edited"}          | Velma  |
		| Edit_Gang       | Uncle        | {"Test":"Edit_Gang"}       | Fred   |
		| Edit_MaxLength  | Uncle        | {"Test":"Edit_MaxLength"}  | Velma  |
		| Edit_OverMax    | Uncle        | {"Test":"Edit_OverMax"}    | Daphne |
		| Edit_BackToList | Mother       | {"Test":"Edit_BackToList"} | Shaggy |
		

@Smoke_Test @retry(1)
Scenario: Edit the relationship, verify the details, and remove the new relationship
	Given I ensure the following relationship is created
		| Name | Relationship | Appearance      | Gang |
		| Edit | Uncle        | {"Test":"Edit"} | Fred |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I edit the relationship with the following details
		| Name   | Relationship | Appearance        | Gang  |
		| Edited | Child        | {"Test":"Edited"} | Velma |
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the Edit relationship
	And I delete the Edited relationship

Scenario: Verify the Gang options are available when editing new relationship
	Given I ensure the following relationship is created
		| Name      | Relationship | Appearance           | Gang |
		| Edit_Gang | Uncle        | {"Test":"Edit_Gang"} | Fred |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	Then I can verify the Gang dropdown has the following option for Shaggy
	And I can verify the Gang dropdown has the following option for Scooby
	And I can verify the Gang dropdown has the following option for Velma
	And I can verify the Gang dropdown has the following option for Daphne
	And I can verify the Gang dropdown has the following option for Fred
	And I delete the Edit_Gang relationship

@retry(2)
Scenario: Verify the max length when editing a relationship for a Name is 60 characters and Relationship is 100 characters
	Given I ensure the following relationship is created
		| Name           | Relationship | Appearance                | Gang  |
		| Edit_MaxLength | Uncle        | {"Test":"Edit_MaxLength"} | Velma |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I enter a random sentence into the name field that is 60 characters long
	Then I can verify only 60 characters are allowed in the name field
	When I enter a random sentence into the relationship field that is 100 characters long
	Then I can verify only 100 characters are allowed in the relationship field
	And I delete the Edit_MaxLength relationship

@retry(2)
Scenario: Verify the Name is trimmed to 60 characters and Relationship is 100 characters when editing a relationship
	Given I ensure the following relationship is created
		| Name         | Relationship | Appearance              | Gang   |
		| Edit_OverMax | Uncle        | {"Test":"Edit_OverMax"} | Daphne |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I enter a random sentence into the name field that is 61 characters long
	Then I can verify only 60 characters are allowed in the name field
	When I enter a random sentence into the relationship field that is 101 characters long
	Then I can verify only 100 characters are allowed in the relationship field
	And I delete the Edit_OverMax relationship

Scenario: Back to list does not save changes when editing
	Given I ensure the following relationship is created
		| Name            | Relationship | Appearance                 | Gang   |
		| Edit_BackToList | Mother       | {"Test":"Edit_BackToList"} | Shaggy |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I edit the relationship with the following details but do not save
		| Name                   | Relationship | Appearance                              | Gang  |
		| Edit_BackToList_Edited | Child        | {"EditedTest":"Edit_BackToList_Edited"} | Velma |
	And I click the Back to List link
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the Edit_BackToList relationship
	And I delete the Edit_BackToList_Edited relationship
