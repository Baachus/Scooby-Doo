namespace ScoobTestPlaywright.Pages;

public interface ICreateAndEditPage
{
    Task ClickBackToList();
    Task ClickCreate();
    ILocator GetGang();
    Task SetApperance(string appearance);
    Task SetGang(string gang);
    Task SetName(string name);
    Task SetRelationship(string relationship);
}

public class CreateAndEditPage : PageTest, ICreateAndEditPage
{
    private readonly ILocator nameTxt;
    private ILocator gangDD;
    private readonly ILocator relationshipTxt;
    private readonly ILocator appearanceTxt;
    private readonly ILocator createBtn;
    private readonly ILocator saveBtn;
    private readonly ILocator backLnk;

    public CreateAndEditPage(IPage page)
    {
        nameTxt = page.Locator("#Name");
        gangDD = page.Locator("#Gang");
        relationshipTxt = page.Locator("#Relationship");
        appearanceTxt = page.Locator("#Appearance");
        createBtn = page.GetByRole(AriaRole.Button, new() { Name = "Create" });
        saveBtn = page.GetByRole(AriaRole.Button, new() { Name = "Save" });
        backLnk = page.GetByRole(AriaRole.Link, new() { Name = "Back to List" });

    }

    public async Task ClickBackToList() => await backLnk.ClickAsync();
    public async Task SetName(string name) => await nameTxt.FillAsync(name);

    public ILocator GetName() => nameTxt;


    public async Task SetRelationship(string relationship) => await relationshipTxt.FillAsync(relationship);
    public ILocator GetRelationship() => relationshipTxt;
    public async Task SetApperance(string appearance) => await appearanceTxt.FillAsync(appearance);
    public ILocator GetApperance() => appearanceTxt;
    public async Task SetGang(string gang)
    {
        gangDD.SelectOptionAsync(gang);
    }
    public ILocator GetGang() => gangDD;
    public async Task ClickCreate() => await createBtn.ClickAsync();
    public async Task ClickSave() => await saveBtn.ClickAsync();
}
