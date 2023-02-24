using AutoFixture.Xunit2;
using FluentAssertions;
using ScoobTestProject.Model;
using ScoobTestProject.Pages;

namespace ScoobTestProject.Tests;

public class RelationshipTest
{
    private readonly IHomePage homePage;
    private readonly IRelationshipPage relationshipPage;

    public RelationshipTest(IHomePage homePage, IRelationshipPage relationshipPage)
    {
        this.homePage = homePage;
        this.relationshipPage = relationshipPage;
    }

    /// <summary>
    /// This test generates a new relationship for the scooby gang then verifies it is 
    /// successfully created and all details on the details page match.  It then deletes
    /// this new relationship to keep the list clean.
    /// </summary>
    /// <param name="relationship">This is a dynamically generated relationship all
    /// details are auto-populated from AutoData through Autofac</param>
    [Theory, AutoData]
    public void CreateNewRelationshipAndVerifyDetails(ScoobRelation relationship)
    {
        //Relationship creation
        homePage.CreateRelationship();
        relationshipPage.EnterRelationshipDetails(relationship);

        //Assertions on newly created relationship
        homePage.PerformClickOnSpecialValue(relationship.Name, "Details");
        ScoobRelation actualRelation = relationshipPage.GetProductDetails();
        actualRelation.Should().BeEquivalentTo(relationship,
            options => options.Excluding(x => x.Id));
        relationshipPage.ReturnToHomePage();

        //Clean up
        homePage.PerformClickOnSpecialValue(relationship.Name, "Delete");
    }
}