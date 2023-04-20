using FluentAssertions;
using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Pages;

namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class RelationshipList_Tests : TestSetup
{
    private RelationshipListPage listPage;
    private Task<string>? testName;

    [SetUp]
    public async Task Setup()
    {
        testName = SetupTestsAsync("Details Tests");

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

        var idColumn = table.Locator("tbody>tr>td:nth-child(1)");
        var ids = await idColumn.AllInnerTextsAsync();
        IEnumerable<int> intEnumerableDescending = ids.Select(int.Parse);
        intEnumerableDescending.Should().BeInDescendingOrder();

        await listPage.Sort("id");

        idColumn = table.Locator("tbody>tr>td:nth-child(1)");
        ids = await idColumn.AllInnerTextsAsync();
        IEnumerable<int> intEnumerableAscending = ids.Select(int.Parse);
        intEnumerableAscending.Should().BeInAscendingOrder();
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

        var gangColumn = table.Locator("tbody>tr>td:nth-child(3)");
        var gangName = await gangColumn.AllInnerTextsAsync();
        gangName.Should().BeInAscendingOrder();

        await listPage.Sort("gang");

        gangColumn = table.Locator("tbody>tr>td:nth-child(3)");
        gangName = await gangColumn.AllInnerTextsAsync();
        gangName.Should().BeInDescendingOrder();
    }

    [Test]
    public async Task SortByRelationship()
    {
        var table = listPage.GetTable();

        await listPage.Sort("relationship");

        var relationshipColumn = table.Locator("tbody>tr>td:nth-child(4)");
        var relationships = await relationshipColumn.AllInnerTextsAsync();
        relationships.Should().BeInAscendingOrder();

        await listPage.Sort("relationship");

        relationshipColumn = table.Locator("tbody>tr>td:nth-child(4)");
        relationships = await relationshipColumn.AllInnerTextsAsync();
        relationships.Should().BeInDescendingOrder();
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
