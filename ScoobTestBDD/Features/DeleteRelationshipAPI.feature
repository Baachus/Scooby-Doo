Feature: DeleteRelationshipAPI

This feature tests the Delete for generating a removing a Relationship 

Background: 
	Given I cleanup the following data
		| Name            | Relationship | Appearance                     | Gang  |
		| Delete_API      | Father       | {"Test":"Delete_API"}          | Fred  |
		| Delete_API_Name | Father       | {"Test":"Delete_API_Name"}     | Velma |
		| Delete_API_Name | Son          | {"Test":"Delete_API_Name_Son"} | Fred  |
		| Delete_API_Id   | Father       | {"Test":"Delete_API_Id"}       | Velma |
		| Delete_API_Id   | Son          | {"Test":"Delete_API_Id_Son"}   | Fred  |

@API
Scenario: Generate a relationship directly through the API and delete through the API
	Given I create a relationship with the following details through the API
		| Name       | Relationship | Appearance            | Gang |
		| Delete_API | Father       | {"Test":"Delete_API"} | Fred |
	When I delete the Delete_API relationship through the API
	And I click the Relationship menu
	Then I see all the relationship details are not present as expected

@API
Scenario: Generate two relationsips with the same name and delete with the name through the API
	Given I create multiple relationships with the following details through the API
		| Name            | Relationship | Appearance                     | Gang  |
		| Delete_API_Name | Father       | {"Test":"Delete_API_Name"}     | Velma |
		| Delete_API_Name | Son          | {"Test":"Delete_API_Name_Son"} | Fred  |
	When I delete the Delete_API_Name relationship through the API by name
	And I click the Relationship menu
	Then I can verify a record with the name Delete_API_Name exists on the table
	And I delete the Delete_API_Name relationship

@API
Scenario: Generate two relationsips with the same name and delete with the id through the API
	Given I create multiple relationships with the following details through the API
		| Name          | Relationship | Appearance                   | Gang  |
		| Delete_API_Id | Father       | {"Test":"Delete_API_Id"}     | Velma |
		| Delete_API_Id | Son          | {"Test":"Delete_API_Id_Son"} | Fred  |
	When I delete the Delete_API_Id relationship through the API
	And I click the Relationship menu
	Then I can verify a record with the name Delete_API_Id exists on the table
	And I delete the Delete_API_Id relationship