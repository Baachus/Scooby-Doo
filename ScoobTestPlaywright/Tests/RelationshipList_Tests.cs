using ScoobTestPlaywright.Pages;

namespace ScoobTestPlaywright.Tests;


[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class RelationshipList_Tests : PageTest
{
    private SharedPage sharedPage;
    private RelationshipListPage listPage;

    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://localhost:5002/");

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        sharedPage = new SharedPage(Page);
        await sharedPage.ClickRelationshipLink();

        listPage = new RelationshipListPage(Page);
    }

    [Test]
    public async Task NavigatePages()
    {
        await listPage.ClickPage(2);
        await Expect(Page).ToHaveURLAsync(new Regex("page=2"));

        await listPage.ClickPage(1);
        await Expect(Page).ToHaveURLAsync(new Regex("page=1"));
    }

    [Test]
    public async Task SearchRelationships()
    {
        await listPage.SearchRelationship("Skip Jones");

        var table = listPage.GetTable();
        await Expect(table).ToContainTextAsync("Skip Jones");
        await Expect(table).Not.ToContainTextAsync("Dave Walton");
    }
}
