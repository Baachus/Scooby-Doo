Feature: DeleteRelationship

This feature tests the Delete page for deleting a Relationship 
and subsequent options around that page.

Background: 
	Given I cleanup the following data
		| Name   | Relationship | Appearance        | Gang |
		| Delete | Father       | {"Test":"Delete"} | Fred |

Scenario: Verify the Delete page has the correct data displayed
	Given I click the Relationship menu
	When I click the "Create New" link
	And I create a relationship with the following details
		| Name   | Relationship | Appearance        | Gang |
		| Delete | Father       | {"Test":"Delete"} | Fred |
	And I click the Delete link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the Delete relationship