Feature: RelationshipTableSearch

This feature verifies the Relationship pages and their ability to search

Background: 
	Given I cleanup the following data
		| Name                | Relationship | Appearance                     | Gang   |
		| Search              | Father       | {"Test":"Search"}              | Scooby |
		| Search_Gang         | Father       | {"Test":"Search_Gang"}         | Fred   |
		| Search_Relationship | Special      | {"Test":"Search_Relationship"} | Velma  |

Scenario:  Verify the search feature works on the Name field
	Given I create a relationship with the following details through the API
		| Name   | Relationship | Appearance        | Gang   |
		| Search | Father       | {"Test":"Search"} | Scooby |
	When I click the Relationship menu
	And I search for Search on the relationship page
	Then I can verify a record with the name Search exists on the table
	And I delete the Search relationship

Scenario:  Verify the search feature works on the Gang field
	Given I create a relationship with the following details through the API
		| Name        | Relationship | Appearance             | Gang |
		| Search_Gang | Father       | {"Test":"Search_Gang"} | Fred |
	When I click the Relationship menu
	And I search for Fred on the relationship page
	Then I can verify a record with the name Search_Gang exists on the table
	And I delete the Search_Gang relationship

Scenario:  Verify the search feature works on the Relationship field
	Given I create a relationship with the following details through the API
		| Name                | Relationship | Appearance                     | Gang  |
		| Search_Relationship | Special      | {"Test":"Search_Relationship"} | Velma |
	When I click the Relationship menu
	And I search for Special on the relationship page
	Then I can verify a record with the name Search_Relationship exists on the table
	And I delete the Search_Relationship relationship
	