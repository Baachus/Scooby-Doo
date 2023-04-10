using Bogus;
using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Model;
using System.Text.Json;

namespace ScoobTestPlaywright.Tests;

public class CreateNewAPI_Tests : PlaywrightTest
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
    public async Task CreateRelationship()
    {
        Faker fake = new Faker("en");
        var relationship = new ScoobModel
        {
            Name = fake.Name.FullName(),
            Relationship = "Grandparent",
            Gang = "Daphne",//fake.Random.Enum<GangMember>(),
            Appearance = new RandomAppearance().GetRandomAppearance()
        };
        var serializedRelation = JsonSerializer.Serialize(relationship);

        IAPIResponse newRequest = await Request.PostAsync($"{baseUrl}/Relationship/AddScoobyRelation",
            new() { DataObject = serializedRelation });

        Assert.True(newRequest.Ok);

        string body = await newRequest.TextAsync();
        ScoobModel scoobModel = JsonSerializer.Deserialize<ScoobModel>(body);

        new API().DeletRelationship(Request, scoobModel.Id);
    }
}
