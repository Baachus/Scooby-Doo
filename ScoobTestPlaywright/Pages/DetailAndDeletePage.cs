using ScoobTestPlaywright.Model;

namespace ScoobTestPlaywright.Pages;

public interface IDetailAndDeletePage
{
    Task ClickBackToList();
    Task ClickEdit();
    ScoobModel GetDetails();
}

public class DetailAndDeletePage : PageTest, IDetailAndDeletePage
{
    private readonly ILocator nameTxt;
    private readonly ILocator gangDD;
    private readonly ILocator relationshipTxt;
    private readonly ILocator appearanceTxt;
    private readonly ILocator editBtn;
    private readonly ILocator deleteBtn;
    private readonly ILocator backLnk;

    public DetailAndDeletePage(IPage page)
    {
        nameTxt = page.Locator("#Name");
        gangDD = page.Locator("#Gang");
        relationshipTxt = page.Locator("#Relationship");
        appearanceTxt = page.Locator("#Appearance");
        editBtn = page.GetByRole(AriaRole.Link, new() { Name = "Edit" });
        deleteBtn = page.GetByRole(AriaRole.Button, new() { Name = "Delete" });
        backLnk = page.GetByRole(AriaRole.Link, new() { Name = "Back to List" });

    }

    public ScoobModel GetDetails()
    {
        var scoobModel = new ScoobModel()
        {
            Name = nameTxt.InnerTextAsync().Result,
            Appearance = appearanceTxt.InnerTextAsync().Result,
            Gang = gangDD.InnerTextAsync().Result,
            Relationship = relationshipTxt.InnerTextAsync().Result
        };
        return scoobModel;
    }

    public async Task ClickEdit() => await editBtn.ClickAsync();
    public async Task ClickDelete() => await deleteBtn.ClickAsync();
    public async Task ClickBackToList() => await backLnk.ClickAsync();
}
