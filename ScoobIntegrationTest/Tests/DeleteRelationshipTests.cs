using FluentAssertions;
using ScoobIntegrationTest.Library;

namespace ScoobIntegrationTest.Tests;

public class DeleteRelationshipTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> customWebApplicationFactory;
    private string url = "https://localhost:44334";

    public DeleteRelationshipTests(CustomWebApplicationFactory<Program> customWebApplicationFactory)
    {
        this.customWebApplicationFactory = customWebApplicationFactory;
    }

    [Fact]
    public async Task VerifyDeleteAddedRelationship()
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var relationship = new ScoobyRelationshipAPI(url, webClient);

        await relationship.AddScoobyRelationAsync(new ScoobRelation
        {
            Appearance = "{Test:Test}",
            Gang = GangMember.Scooby,
            Name = "Automation Test",
            Relationship = "Uncle"
        });

        var result = await relationship.GetScoobyRelationByNameAsync("Automation Test");

        result.Should().NotBeNull();

        await relationship.DeleteScoobyRelationAsync(result.Id);
    }
}