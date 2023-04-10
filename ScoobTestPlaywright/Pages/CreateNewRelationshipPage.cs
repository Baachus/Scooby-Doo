namespace ScoobTestPlaywright.Pages;

public interface ICreateNewRelationshipPage
{
    Task ClickBackToList();
    Task ClickCreate();
    ILocator GetGang();
    Task SetApperance(string appearance);
    Task SetGang(string gang);
    Task SetName(string name);
    Task SetRelationship(string relationship);
}

public class CreateNewRelationshipPage : PageTest, ICreateNewRelationshipPage
{
    private readonly ILocator nameTxt;
    private ILocator gangDD;
    private readonly ILocator relationshipTxt;
    private readonly ILocator appearanceTxt;
    private readonly ILocator createBtn;
    private readonly ILocator backLnk;

    public CreateNewRelationshipPage(IPage page)
    {
        nameTxt = page.GetByRole(AriaRole.Textbox, new() { Name = "Name" });
        gangDD = page.Locator("#Gang");
        relationshipTxt = page.GetByRole(AriaRole.Textbox, new() { Name = "Relationship" });
        appearanceTxt = page.GetByRole(AriaRole.Textbox, new() { Name = "Appearance" });
        createBtn = page.GetByRole(AriaRole.Button, new() { Name = "Create" });
        backLnk = page.GetByRole(AriaRole.Link, new() { Name = "Back to List" });

    }

    public async Task ClickBackToList() => await backLnk.ClickAsync();
    public async Task SetName(string name) => await nameTxt.FillAsync(name);
    public async Task SetRelationship(string relationship) => await relationshipTxt.FillAsync(relationship);
    public async Task SetApperance(string appearance) => await appearanceTxt.FillAsync(appearance);
    public async Task SetGang(string gang)
    {
        gangDD.SelectOptionAsync(gang);
    }
    public ILocator GetGang() => gangDD;
    public async Task ClickCreate() => await createBtn.ClickAsync();
}
