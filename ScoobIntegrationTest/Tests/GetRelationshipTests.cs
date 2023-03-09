using FluentAssertions;
using ScoobIntegrationTest.Library;

namespace ScoobIntegrationTest.Tests;

public class GetRelationshipTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> customWebApplicationFactory;
    private string url = "https://localhost:44334";

    public GetRelationshipTests(CustomWebApplicationFactory<Program> customWebApplicationFactory)
    {
        this.customWebApplicationFactory = customWebApplicationFactory;
    }

    [Theory]
    [InlineData("Dave Walton")]
    [InlineData("Scrappy-Doo")]
    [InlineData("John Maxwell")]
    [InlineData("Olivia Dervy")]
    [InlineData("Skip Jones")]
    [InlineData("Margaret 'Maggie' Rogers")]
    public async Task VerifyGetRelationByNameForSeedData(string name)
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var relationship = new ScoobyRelationshipAPI(url, webClient);

        var result = await relationship.GetScoobyRelationByNameAsync(name);

        result.Should().NotBeNull();

        result.Id.Should().BeGreaterThan(0);
        result.Name.Should().Be(name);
        result.Relationship.Should().NotBeEmpty()
            .And.NotBeNull();
        result.Appearance.Should().NotBeEmpty()
            .And.NotBeNull();
        result.Appearance.Should().Contain("Movie").
            And.Contain("TV");
        result.Gang.Should().BeOneOf(GangMember.Shaggy,
                                     GangMember.Scooby,
                                     GangMember.Daphne,
                                     GangMember.Velma,
                                     GangMember.Fred);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public async Task VerifyGetRelationByIdForSeedData(int id)
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var relationship = new ScoobyRelationshipAPI(url, webClient);

        var result = await relationship.GetScoobyRelationByIdAsync(id);

        result.Should().NotBeNull();

        result.Id.Should().Be(id);
        result.Name.Should().NotBeEmpty()
            .And.NotBeNull();
        result.Relationship.Should().NotBeEmpty()
            .And.NotBeNull();
        result.Appearance.Should().NotBeEmpty()
            .And.NotBeNull();
        result.Appearance.Should().Contain("Movie").
            And.Contain("TV");
        result.Gang.Should().BeOneOf(GangMember.Shaggy,
                                     GangMember.Scooby,
                                     GangMember.Daphne,
                                     GangMember.Velma,
                                     GangMember.Fred);
    }
}