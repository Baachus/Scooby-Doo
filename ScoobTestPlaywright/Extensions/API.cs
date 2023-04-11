using Azure.Core;
using Bogus;
using ScoobTestPlaywright.Model;
using System.Text.Json;

namespace ScoobTestPlaywright.Extensions;

public class API : PlaywrightTest
{
    private const string baseUrl = "http://localhost:5003";
    private readonly Faker faker;

    public API()
    {
        faker = new Faker("en");
    }

    public async Task<ScoobModel> CreateRandomRelationship(IAPIRequestContext Request)
    {
        var relationship = new ScoobModel
        {
            Name = faker.Name.FullName(),
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
        return scoobModel;
    }

    public async Task DeletRelationship(IAPIRequestContext Request, int id)
    {
        IAPIResponse newRequest = await Request.DeleteAsync($"{baseUrl}/Relationship/DeleteScoobyRelationById/{id}");
        Assert.True(newRequest.Ok);
    }

    public async Task DeletRelationship(IAPIRequestContext Request, string name)
    {
        IAPIResponse newRequest = await Request.DeleteAsync($"{baseUrl}/Relationship/DeleteScoobyRelationByName/{name}");
        Assert.True(newRequest.Ok);
    }
}
