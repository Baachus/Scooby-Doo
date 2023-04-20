using ScoobTestPlaywright.Extensions;

namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class DeleteAPI_Tests : PlaywrightTest
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
    public async Task DeleteRelationship()
    {
        var api = new API();
        int id = (await api.CreateRandomRelationship(Request)).Id;
        IAPIResponse newRequest = await Request.DeleteAsync($"{baseUrl}/Relationship/DeleteScoobyRelationById/{id}");
        Assert.True(newRequest.Ok);
    }
}
