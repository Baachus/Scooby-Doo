namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HeaderLinks_Tests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://localhost:5002/");

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));
    }

    [Test]
    public async Task RelationshipLink()
    {
        //create a locator
        var relationshipLnk = Page.GetByRole(AriaRole.Link, new() { Name = "Relationship" });

        //Expect an attribute "to be stricly equal" to the value.
        await Expect(relationshipLnk).ToHaveAttributeAsync("href", "/Relationship/List");

        //Click the privacy link
        await relationshipLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Relationship/List"));
    }

    [Test]
    public async Task PrivacyLink()
    {
        //create a locator
        var privacyLnk = Page.GetByTestId("lnk_Privacy");

        //Expect an attribute "to be stricly equal" to the value.
        await Expect(privacyLnk).ToHaveAttributeAsync("href", "/Home/Privacy");

        //Click the privacy link
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));
    }

    [Test]
    public async Task HomeLink()
    {
        //create a locator
        var homeLnk = Page.GetByRole(AriaRole.Link, new() { Name = "Home" });

        //Click the privacy link
        await homeLnk.ClickAsync();

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));
    }

    [Test]
    public async Task HomeIcon()
    {
        //create a locator
        var homeIcon = Page.GetByRole(AriaRole.Link, new() { Name = "ScoobWebApp" });

        //Click the privacy link
        await homeIcon.ClickAsync();

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));
    }

    [Test]
    public async Task RelationshipLinkAllPages()
    {
        //create a locator
        var relationshipLnk = Page.GetByRole(AriaRole.Link, new() { Name = "Relationship" });

        //Expect an attribute "to be stricly equal" to the value.
        await Expect(relationshipLnk).ToHaveAttributeAsync("href", "/Relationship/List");

        //Click the privacy link
        await relationshipLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Relationship/List"));

        //Verify relationship link on the Privacy Page
        var privacyLnk = Page.GetByTestId("lnk_Privacy");

        await privacyLnk.ClickAsync();

        await relationshipLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Relationship/List"));

        //Verify relationship link on the Home Page
        var homeLnk = Page.GetByTestId("lnk_Home");

        await homeLnk.ClickAsync();
        await relationshipLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Relationship/List"));
    }

    [Test]
    public async Task PrivacyLinkAllPages()
    {
        //create a locator
        var privacyLnk = Page.GetByTestId("lnk_Privacy");

        //Expect an attribute "to be stricly equal" to the value.
        await Expect(privacyLnk).ToHaveAttributeAsync("href", "/Home/Privacy");

        //Click the privacy link
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));

        //Verify privacy link on the Relationship Page
        var relationshipLnk = Page.GetByTestId("lnk_Privacy");

        await relationshipLnk.ClickAsync();

        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));

        //Verify privacy link on the Home Page
        var homeLnk = Page.GetByTestId("lnk_Home");

        await homeLnk.ClickAsync();
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));
    }

    [Test]
    public async Task HomeLinkAllPages()
    {
        //create a locator
        var homeLnk = Page.GetByRole(AriaRole.Link, new() { Name = "Home" });

        //Click the privacy link
        await homeLnk.ClickAsync();

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        //Verify home link on the Relationship Page
        var relationshipLnk = Page.GetByTestId("lnk_Privacy");

        await relationshipLnk.ClickAsync();
        await homeLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        //Verify home link on the Home Page
        var privacyLnk = Page.GetByTestId("lnk_Privacy");

        await privacyLnk.ClickAsync();
        await homeLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));
    }

    [Test]
    public async Task HomeIconAllPages()
    {
        //create a locator
        var homeLnk = Page.GetByRole(AriaRole.Link, new() { Name = "ScoobWebApp" });

        //Click the privacy link
        await homeLnk.ClickAsync();

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        //Verify home link on the Relationship Page
        var relationshipLnk = Page.GetByTestId("lnk_Privacy");

        await relationshipLnk.ClickAsync();
        await homeLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        //Verify home link on the Home Page
        var privacyLnk = Page.GetByTestId("lnk_Privacy");

        await privacyLnk.ClickAsync();
        await homeLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));
    }
}