using ScoobTestPlaywright.Extensions;

namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class DeleteAPI_Tests : PlaywrightTest
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
    public async Task DeleteRelationship()
    {
        TestSettings testSettings = TestSettings.ReadConfig();

        var api = new API();
        int id = (await api.CreateRandomRelationship(Request)).Id;
        IAPIResponse newRequest = await Request.DeleteAsync($"{testSettings.APIUrl}Relationship/DeleteScoobyRelationById/{id}");
        Assert.True(newRequest.Ok);
    }
}
