using Bogus;
using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Pages;

namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CreateNew_Tests : TestSetup
{
    private RelationshipListPage listPage;
    private CreateAndEditPage createPage;
    private IAPIRequestContext? Request = null;
    private const string baseUrl = "http://localhost:5003";
    private Task<string>? testName;

    [SetUp]
    public async Task Setup()
    {
        testName = SetupTestsAsync("Create New Tests");

        listPage = new RelationshipListPage(Page);
        await listPage.ClickCreateNewRelationship();

        createPage = new CreateAndEditPage(Page);

        Request = await this.Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = baseUrl
        });
    }

    [Test]
    public async Task BackToListOnCreateNewPage()
    {
        await createPage.ClickBackToList();
        await Expect(Page).ToHaveTitleAsync(new Regex("Relationships"));
    }

    [Test]
    public async Task CreateNewVerifyGangMembersDropDown()
    {
        await Expect(createPage.GetGang()).ToHaveTextAsync(new Regex("Select type ..."));
        await Expect(createPage.GetGang()).ToHaveTextAsync(new Regex("Scooby"));
        await Expect(createPage.GetGang()).ToHaveTextAsync(new Regex("Velma"));
        await Expect(createPage.GetGang()).ToHaveTextAsync(new Regex("Shaggy"));
        await Expect(createPage.GetGang()).ToHaveTextAsync(new Regex("Fred"));
        await Expect(createPage.GetGang()).ToHaveTextAsync(new Regex("Daphne"));
    }

    [Test]
    public async Task CreateNewRelationship()
    {
        Faker fake = new Faker("en");
        var newName = fake.Name.FullName();

        await createPage.SetName(newName);
        await createPage.SetGang(fake.Random.Enum<GangMember>().ToString());
        await createPage.SetRelationship("Cousin");
        await createPage.SetApperance(new RandomAppearance().GetRandomAppearance());

        await createPage.ClickCreate();

        new API().DeletRelationship(Request, newName);
    }

    [TearDown]
    public async Task CloseTest()
    {
        string name = await testName;
        await Context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = $"../../../Traces/{name}.zip"
        });
    }

}
