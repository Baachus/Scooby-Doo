Feature: CreateRelationshipAPI

This feature tests the API for generating a new Relationship 

Background: 
	Given I cleanup the following data
		| Name         | Relationship | Appearance              | Gang |
		| Creation_API | Father       | {"Test":"Creation_API"} | Fred |

@API
Scenario: Generate a relationship directly through the API
	Given I create a relationship with the following details through the API
		| Name         | Relationship | Appearance              | Gang |
		| Creation_API | Father       | {"Test":"Creation_API"} | Fred |
	And I click the Relationship menu
	When I click the Details link of the newly created relationship
	Then I see all the relationship details are created as expected
	And I delete the Creation_API relationship