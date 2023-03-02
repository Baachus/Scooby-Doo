Feature: Relationship

This feature verifies the Relationship pages

Background: 
	Given I cleanup the following data
		| Name                    | Relationship | Appearance           | Gang   |
		| AutomationGuy           | Child        | {"Test":"test_data"} | Shaggy |
		| AutomationTest          | Uncle        | {"Test":"test_data"} | Fred   |
		| AutomationGuyBackToList | Child        | {"Test":"test_data"} | Shaggy |

@Smoke_Test @retry(1)
Scenario: Create a relationship, verify the details, and remove the new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	And I create a relationship with the following details
		| Name           | Relationship | Appearance           | Gang   |
		| AutomationGuy  | Child        | {"Test":"test_data"} | Shaggy |
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the AutomationGuy relationship

@Smoke_Test @retry(1)
Scenario: Edit the relationship, verify the details, and remove the new relationship
	Given I ensure the following relationship is created
		| Name           | Relationship | Appearance           | Gang |
		| AutomationTest | Uncle        | {"Test":"test_data"} | Fred |
	When I click the Relationship menu
	And I click the Edit link of the newly created relationship
	And I edit the relationship with the following details
		| Name           | Relationship | Appearance           | Gang  |
		| AutomationTest | Child        | {"Test":"test_data"} | Velma |
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the AutomationTest relationship

@retry(1)
Scenario: Verify Back to List works on every modify page, i.e. Edit, Details, and Delete
	Given I click the Relationship menu
	When I click the "Create New" link
	And I create a relationship with the following details
		| Name                    | Relationship | Appearance           | Gang   |
		| AutomationGuyBackToList | Child        | {"Test":"test_data"} | Shaggy |
	And I click the Details link of the newly created relationship
	And I click the Back to List link
	Then I verify I am on the Relationship page
	When I click the Edit link of the newly created relationship
	And I click the Back to List link
	Then I verify I am on the Relationship page
	When I click the Delete link of the newly created relationship
	And I click the Back to List link
	Then I verify I am on the Relationship page
	And I delete the AutomationGuyBackToList relationship
	When I click the "Create New" link
	And I click the Back to List link
	Then I verify I am on the Relationship page