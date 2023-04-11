using ScoobTestPlaywright.Extensions;

namespace ScoobTestPlaywright.Pages;

public interface IRelationshipListPage
{
    Task ClickCreateNewRelationship();
    Task ClickPage(int pageNumber);
    Task SearchRelationship(string relationshipName);
    ILocator GetTable();
    Task ClickLinkForNameAsync(string relationshipName, string action);
}

public class RelationshipListPage : IRelationshipListPage
{
    private readonly IPage page;
    private readonly ILocator createNewLnk;
    private readonly ILocator searchTxt;
    private readonly ILocator searchBtn;
    private readonly ILocator relationshipTbl;
    private ILocator idLnk;
    private ILocator nameLnk;
    private ILocator gangLnk;
    private ILocator relationshipLnk;

    public RelationshipListPage(IPage page)
    {
        this.page = page;
        createNewLnk = page.GetByRole(AriaRole.Link, new() { Name = "Create New" });
        searchTxt = page.Locator("#SearchString");
        searchBtn = page.GetByTestId("Name_Search");
        relationshipTbl = page.GetByRole(AriaRole.Table);
    }

    public async Task ClickCreateNewRelationship() => await createNewLnk.ClickAsync();

    public async Task ClickPage(int pageNumber)
    {
        page.GetByRole(AriaRole.Link, new() { Name = pageNumber.ToString() }).ClickAsync();
    }

    public async Task SearchRelationship(string relationshipName)
    {
        searchTxt.FillAsync(relationshipName);
        searchBtn.ClickAsync();
    }

    public ILocator GetTable() => relationshipTbl;

    public async Task ClickLinkForNameAsync(string relationshipName, string action)
    {
        var pageLnks = page.Locator("ul[class='pagination']>li>a");
        int pageCount = await pageLnks.CountAsync();

        var visible = page.Locator($"td:has-text('{relationshipName}')");

        var baseUrl = page.Url;
        if (await visible.CountAsync() == 0)
        {
            await page.GotoAsync(baseUrl + $"?page={pageCount}&sortOrder=Id");
            visible = page.Locator($"tr:has-text('{relationshipName}')");
            await Screenshots.TakeScreenshot(page);
        }
    }

    public async Task Sort(string column)
    {
        switch(column.ToLower())
        {
            case "id":
            default:
                idLnk = page.GetByRole(AriaRole.Link, new() { Name = "Id" });
                await idLnk.ClickAsync();
                break;
            case "name":
                nameLnk = page.GetByRole(AriaRole.Link, new() { Name = "Name" });
                await nameLnk.ClickAsync();
                break;
            case "gang":
                gangLnk = page.GetByRole(AriaRole.Link, new() { Name = "Gang" });
                await gangLnk.ClickAsync();
                break;
            case "relationship":
                var table = page.GetByRole(AriaRole.Table);
                relationshipLnk = table.GetByRole(AriaRole.Link, new() { Name = "Relationship" });
                await relationshipLnk.ClickAsync();
                break;
        }
    }
}
