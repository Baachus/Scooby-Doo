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
        var product = new ScoobyRelationshipAPI(url, webClient);

        var results = await product.GetScoobyRelationsAsync();

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
    public async Task VerifyNamesInSeedDataFromGetAllRelationships(string name)
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var product = new ScoobyRelationshipAPI(url, webClient);

        var results = await product.GetScoobyRelationsAsync();

        results.Select(x => x.Name == name).Should().NotBeEmpty();
    }

    [Fact]
    public async Task VerifyGangInSeedDataFromGetAllRelationships()
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var product = new ScoobyRelationshipAPI(url, webClient);

        var results = await product.GetScoobyRelationsAsync();

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
        var product = new ScoobyRelationshipAPI(url, webClient);

        var results = await product.GetScoobyRelationsAsync();

        foreach (var result in results)
        {
            result.Relationship.Should().BeOneOf(
                "Uncle",
                "Aunt",
                null);
        }
    }

    [Fact]
    public async Task VerifyApperanceInSeedDataFromGetAllRelationships()
    {
        var webClient = customWebApplicationFactory.CreateDefaultClient();
        var product = new ScoobyRelationshipAPI(url, webClient);

        var results = await product.GetScoobyRelationsAsync();

        foreach (var result in results)
        {
            result.Appearance.Should().NotBeEmpty();
        }
    }
}