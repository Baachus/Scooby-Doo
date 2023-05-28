using FluentAssertions;
using ScoobIntegrationTest.Library;

namespace ScoobIntegrationTest.Tests;

public class GetAllRelationshipTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> customWebApplicationFactory;
    private string url = "https://localhost:44334";

    public GetAllRelationshipTests(CustomWebApplicationFactory<Program> customWebApplicationFactory)
    {
        this.customWebApplicationFactory = customWebApplicationFactory;
    }

    [Fact]
    public async Task VerifyIDForSeedDataFromGetAllRelationships()
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var relationship = new ScoobyRelationshipAPI(url, webClient);

        var results = await relationship.GetScoobyRelationsAsync();

        results.Should().NotBeEmpty();

        foreach (var result in results)
        {
            result.Id.Should().BeGreaterThan(0);
        }
    }

    [Theory]
    [InlineData("Dave Walton")]
    [InlineData("Scrappy-Doo")]
    [InlineData("John Maxwell")]
    [InlineData("Olivia Dervy")]
    [InlineData("Skip Jones")]
    [InlineData("Margaret 'Maggie' Rogers")]
    [InlineData("Shannon Blake")]
    public async Task VerifyNamesInSeedDataFromGetAllRelationships(string name)
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var relationship = new ScoobyRelationshipAPI(url, webClient);

        var results = await relationship.GetScoobyRelationsAsync();

        results.Select(x => x.Name == name).Should().NotBeEmpty();
    }

    [Fact]
    public async Task VerifyGangInSeedDataFromGetAllRelationships()
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var relationship = new ScoobyRelationshipAPI(url, webClient);

        var results = await relationship.GetScoobyRelationsAsync();

        results.Should().NotBeEmpty();

        foreach (var result in results)
        {
            result.Gang.Should().BeOneOf(
                GangMember.Scooby,
                GangMember.Shaggy,
                GangMember.Daphne,
                GangMember.Fred,
                GangMember.Velma);
        }
    }

    [Fact]
    public async Task VerifyRelationshipInSeedDataFromGetAllRelationships()
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var relationship = new ScoobyRelationshipAPI(url, webClient);

        var results = await relationship.GetScoobyRelationsAsync();

        results.Should().NotBeEmpty();

        foreach (var result in results)
        {
            result.Relationship.Should().BeOneOf(
                "Uncle",
                "Aunt",
                "Father",
                "Younger Sister",
                "Nephew",
                "Cousin",
                null);
        }
    }

    [Fact]
    public async Task VerifyApperanceInSeedDataFromGetAllRelationships()
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var relationship = new ScoobyRelationshipAPI(url, webClient);

        var results = await relationship.GetScoobyRelationsAsync();

        results.Should().NotBeEmpty();

        foreach (var result in results)
        {
            result.Appearance.Should().NotBeEmpty();
        }
    }
}