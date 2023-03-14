Feature: DeleteRelationshipAPI

This feature tests the Delete for generating a removing a Relationship 

Background: 
	Given I cleanup the following data
		| Name       | Relationship | Appearance            | Gang |
		| Delete_API | Father       | {"Test":"Delete_API"} | Fred |

@API
Scenario: Generate a relationship directly through the API
	Given I create a relationship with the following details through the API
		| Name       | Relationship | Appearance            | Gang |
		| Delete_API | Father       | {"Test":"Delete_API"} | Fred |
	When I delete the Delete_API relationship through the API
	And I click the Relationship menu
	Then I see all the relationship details are not present as expected