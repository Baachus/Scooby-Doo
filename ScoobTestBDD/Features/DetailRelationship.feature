Feature: DetailRelationship

This feature tests the Detail page for viewing a Relationship 
and subsequent options around that page.

Background: 
	Given I cleanup the following data
		| Name               | Relationship | Appearance           | Gang   |
		| AutomationGuy      | Child        | {"Test":"test_data"} | Shaggy |

@Smoke_Test @retry(1)
Scenario: Create a relationship, verify the details on the details page, and remove the new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	And I create a relationship with the following details
		| Name           | Relationship | Appearance           | Gang   |
		| AutomationGuy  | Child        | {"Test":"test_data"} | Shaggy |
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the AutomationGuy relationship