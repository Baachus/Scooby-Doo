Feature: UpdateRelationshipAPI

This feature tests the API for updating a new Relationship 

Background: 
	Given I cleanup the following data
		| Name              | Relationship | Appearance                   | Gang   |
		| Update_API        | Son          | {"Test":"Update_API"}        | Velma  |
		| Update_API_Edited | Daughter     | {"Test":"Update_API_Edited"} | Scooby |


@API
Scenario: Generate a relationship and update it directly through the API
	Given I create a relationship with the following details through the API
		| Name       | Relationship | Appearance            | Gang  |
		| Update_API | Son          | {"Test":"Update_API"} | Velma |
	When I update a relationship with the following details through the API
		| Name              | Relationship | Appearance                   | Gang   |
		| Update_API_Edited | Daughter     | {"Test":"Update_API_Edited"} | Scooby |
	And I click the Relationship menu
	And I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the Update_API relationship
	And I delete the Update_API_Edited relationship