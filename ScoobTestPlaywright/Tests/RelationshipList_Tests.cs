using FluentAssertions;
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
        listPage.SearchRelationship("Skip Jones");

        var table = listPage.GetTable();
        await Expect(table).ToContainTextAsync("Skip Jones");
        await Expect(table).Not.ToContainTextAsync("Dave Walton");
    }

    [Test]
    public async Task SortById()
    {
        var table = listPage.GetTable();

        await listPage.Sort("id");

        var namesColumn = table.Locator("tbody>tr>td:nth-child(1)");
        var names = await namesColumn.AllInnerTextsAsync();
        names.Should().BeInDescendingOrder();

        await listPage.Sort("id");

        namesColumn = table.Locator("tbody>tr>td:nth-child(1)");
        names = await namesColumn.AllInnerTextsAsync();
        names.Should().BeInAscendingOrder();
    }

    [Test]
    public async Task SortByName()
    {
        var table = listPage.GetTable();

        await listPage.Sort("name");

        var namesColumn = table.Locator("tbody>tr>td:nth-child(2)");
        var names = await namesColumn.AllInnerTextsAsync();
        names.Should().BeInAscendingOrder();

        await listPage.Sort("name");

        namesColumn = table.Locator("tbody>tr>td:nth-child(2)");
        names = await namesColumn.AllInnerTextsAsync();
        names.Should().BeInDescendingOrder();
    }

    [Test]
    public async Task SortByGang()
    {
        var table = listPage.GetTable();

        await listPage.Sort("gang");

        var namesColumn = table.Locator("tbody>tr>td:nth-child(3)");
        var names = await namesColumn.AllInnerTextsAsync();
        names.Should().BeInAscendingOrder();

        await listPage.Sort("gang");

        namesColumn = table.Locator("tbody>tr>td:nth-child(3)");
        names = await namesColumn.AllInnerTextsAsync();
        names.Should().BeInDescendingOrder();
    }

    [Test]
    public async Task SortByRelationship()
    {
        var table = listPage.GetTable();

        await listPage.Sort("relationship");

        var namesColumn = table.Locator("tbody>tr>td:nth-child(4)");
        var names = await namesColumn.AllInnerTextsAsync();
        names.Should().BeInAscendingOrder();

        await listPage.Sort("relationship");

        namesColumn = table.Locator("tbody>tr>td:nth-child(4)");
        names = await namesColumn.AllInnerTextsAsync();
        names.Should().BeInDescendingOrder();
    }
}
