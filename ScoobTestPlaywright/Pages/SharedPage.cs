namespace ScoobTestPlaywright.Pages;

public interface ISharedPage
{
    Task ClickHomeIcon();
    Task ClickHomeLink();
    Task ClickPrivacyFooterLink();
    Task ClickPrivacyLink();
    Task ClickRelationshipLink();
}

public class SharedPage : ISharedPage
{
    //Header Links
    private readonly ILocator relationshipLnk;
    private readonly ILocator homeLnk;
    private readonly ILocator privacyLnk;

    //Header Icon
    private readonly ILocator homeIcon;

    //Footer Links
    private readonly ILocator privacyFooterLnk;

    public SharedPage(IPage page)
    {
        //Header Links
        relationshipLnk = page.GetByTestId("lnk_Relationship");
        homeLnk = page.GetByTestId("lnk_Home");
        privacyLnk = page.GetByTestId("lnk_Privacy");

        //Header Icon
        homeIcon = page.GetByRole(AriaRole.Link, new() { Name = "ScoobWebApp" });

        //Footer Links
        privacyFooterLnk = page.Locator("#Privacy_Footer");
    }

    public async Task ClickRelationshipLink() => await relationshipLnk.ClickAsync();
    public async Task ClickHomeLink() => await homeLnk.ClickAsync();
    public async Task ClickPrivacyLink() => await privacyLnk.ClickAsync();
    public async Task ClickHomeIcon() => await homeIcon.ClickAsync();
    public async Task ClickPrivacyFooterLink() => await privacyFooterLnk.ClickAsync();
}
