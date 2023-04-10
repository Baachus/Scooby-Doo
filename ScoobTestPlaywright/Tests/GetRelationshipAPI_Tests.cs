using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Model;
using System.Text.Json;

namespace ScoobTestPlaywright.Tests;

[TestFixture]
public class GetRelationshipAPI_Tests : PlaywrightTest
{
    private IAPIRequestContext? Request = null;
    private const string baseUrl = "http://localhost:5003";

    [SetUp]
    public async Task SetupRequests()
    {
        Request = await this.Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = baseUrl
        });
    }

    [Test]
    public async Task GetSpecificRelationshipById()
    {
        IAPIResponse newRequest = await Request.GetAsync($"{baseUrl}/Relationship/GetScoobyRelationById/3");
        Assert.True(newRequest.Ok);

        string body = await newRequest.TextAsync();
        ScoobModel scoobModel = JsonSerializer.Deserialize<ScoobModel>(body);

        Assert.NotNull(scoobModel);
        Assert.That(scoobModel.Id, Is.EqualTo(3));
        Assert.That(scoobModel.Name, Is.EqualTo("John Maxwell"));
        Assert.That(scoobModel.Relationship, Is.EqualTo("Uncle"));
        Assert.That(scoobModel.Gang, Is.EqualTo(GangMember.Daphne));
        Assert.That(scoobModel.Appearance, Is.EqualTo("{\"TV\":[{\"SHOW\":\"Scooby-Doo, " +
            "Where Are You!\",\"SEASON\":1,\"EPISODE\":7,\"RELEASE_YEAR\":1969}],\"Movie" +
            "\":[{}],\"APPEARED\":true}"));
    }

    [Test]
    public async Task GetAllRelationships()
    {
        IAPIResponse newRequest = await Request.GetAsync($"{baseUrl}/Relationship/GetScoobyRelations");
        Assert.True(newRequest.Ok);

        string body = await newRequest.TextAsync();
        List<ScoobModel> relationships = JsonSerializer.Deserialize<List<ScoobModel>>(body);

        Assert.NotNull(relationships);
        foreach (ScoobModel relationship in relationships)
        {
            Assert.That(relationship.Id, Is.GreaterThan(0));
            Assert.That(relationship.Name, Is.Not.Null);
            Assert.That(relationship.Relationship, Is.Not.Null);
            Assert.That(new List<string> {
                "Daphne",
                "Scooby",
                "Shaggy",
                "Fred",
                "Velma"
            }.Contains(relationship.Gang.ToString()));
            Assert.That(relationship.Appearance, Is.Not.Null);
        }
    }

    [Test]
    public async Task GetSpecificRelationshipByName()
    {
        string name = "John Maxwell";
        IAPIResponse newRequest = await Request.GetAsync($"{baseUrl}/Relationship/GetScoobyRelationByName/{name}");
        Assert.True(newRequest.Ok);

        string body = await newRequest.TextAsync();
        ScoobModel scoobModel = JsonSerializer.Deserialize<ScoobModel>(body);

        Assert.NotNull(scoobModel);
        Assert.That(scoobModel.Id, Is.EqualTo(3));
        Assert.That(scoobModel.Name, Is.EqualTo(name));
        Assert.That(scoobModel.Relationship, Is.EqualTo("Uncle"));
        Assert.That(scoobModel.Gang, Is.EqualTo(GangMember.Daphne));
        Assert.That(scoobModel.Appearance, Is.EqualTo("{\"TV\":[{\"SHOW\":\"Scooby-Doo, " +
            "Where Are You!\",\"SEASON\":1,\"EPISODE\":7,\"RELEASE_YEAR\":1969}],\"Movie" +
            "\":[{}],\"APPEARED\":true}"));
    }
}
