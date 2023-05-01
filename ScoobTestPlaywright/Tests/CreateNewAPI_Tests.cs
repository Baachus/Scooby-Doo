using Bogus;
using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Model;
using System.Text.Json;

namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CreateNewAPI_Tests : PlaywrightTest
{
    private IAPIRequestContext? Request = null;

    [SetUp]
    public async Task SetupRequests()
    {
        TestSettings testSettings = TestSettings.ReadConfig();

        Request = await this.Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = testSettings.APIUrl.ToString()
        });
    }

    [Test]
    public async Task CreateRelationship()
    {
        TestSettings testSettings = TestSettings.ReadConfig();

        Faker fake = new Faker("en");
        var relationship = new ScoobModel
        {
            Name = fake.Name.FullName(),
            Relationship = "Grandparent",
            Gang = "Daphne",//fake.Random.Enum<GangMember>(),
            Appearance = new RandomAppearance().GetRandomAppearance()
        };
        var serializedRelation = JsonSerializer.Serialize(relationship);

        IAPIResponse newRequest = await Request.PostAsync($"{testSettings.APIUrl}Relationship/AddScoobyRelation",
            new() { DataObject = serializedRelation });

        Assert.True(newRequest.Ok);

        string body = await newRequest.TextAsync();
        ScoobModel scoobModel = JsonSerializer.Deserialize<ScoobModel>(body);

        new API().DeletRelationship(Request, scoobModel.Id);
    }
}
