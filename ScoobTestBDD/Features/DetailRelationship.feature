Feature: DetailRelationship

This feature tests the Detail page for viewing a Relationship 
and subsequent options around that page.

Background: 
	Given I cleanup the following data
		| Name          | Relationship | Appearance               | Gang   |
		| Detail        | Child        | {"Test":"Detail"}        | Shaggy |
		| Detail_Edit   | Child        | {"Test":"Detail_Edit"}   | Shaggy |
		| Detail_Edited | Grandmother  | {"Test":"Detail_Edited"} | Velma  |

@Smoke_Test
Scenario: Create a relationship, verify the details on the details page, and remove the new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	And I create a relationship with the following details
		| Name   | Relationship | Appearance        | Gang   |
		| Detail | Child        | {"Test":"Detail"} | Shaggy |
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected on the details page
	And I delete the Detail relationship

Scenario: Create a relationship, verify the details on the details page, edit from the details page and remove the new relationship
	Given I click the Relationship menu
	When I click the "Create New" link
	And I create a relationship with the following details
		| Name        | Relationship | Appearance             | Gang   |
		| Detail_Edit | Child        | {"Test":"Detail_Edit"} | Shaggy |
	And I click the Details link of the newly created relationship
	And I click the Edit link on the detail page
	And I edit the relationship with the following details
		| Name          | Relationship | Appearance               | Gang  |
		| Detail_Edited | Grandmother  | {"Test":"Detail_Edited"} | Velma |
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected on the details page
	And I delete the Detail_Edit relationship
	And I delete the Detail_Edited relationship