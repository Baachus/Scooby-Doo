using FluentAssertions;
using ScoobIntegrationTest.Library;

namespace ScoobIntegrationTest.Tests;

public class AddRelationshipTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> customWebApplicationFactory;
    private readonly string url = "https://localhost:44334";

    public AddRelationshipTests(CustomWebApplicationFactory<Program> customWebApplicationFactory)
    {
        this.customWebApplicationFactory = customWebApplicationFactory;
    }


    [Fact]
    public async Task VerifyAddRelationship()
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

        await relationship.DeleteScoobyRelationByIdAsync(result.Id);
    }

    [Fact]
    public async Task VerifyAddRelationshipDefaultGangMember()
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var relationship = new ScoobyRelationshipAPI(url, webClient);

        var result = await relationship.AddScoobyRelationAsync(new ScoobRelation { });

        result.Name.Should().BeNull();
        result.Relationship.Should().BeNull();
        result.Appearance.Should().BeNull();
        result.Id.Should().BeGreaterThan(0);
        result.Gang.Should().Be(GangMember.Scooby);

        await relationship.DeleteScoobyRelationByIdAsync(result.Id);
    }
}
