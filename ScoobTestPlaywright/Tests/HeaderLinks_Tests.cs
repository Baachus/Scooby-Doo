using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Pages;

namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HeaderLinks_Tests : TestSetup
{
    private Task<string>? testName;
    private SharedPage sharedPage;
    private TestSettings testSettings;

    [SetUp]
    public async Task Setup()
    {
        testName = SetupTestsNoNavigationAsync();
        testSettings = TestSettings.ReadConfig();
        sharedPage = new SharedPage(Page);
    }

    [Test]
    public async Task RelationshipLink()
    {
        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

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
        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

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
        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

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
        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //create a locator
        var relationshipLnk = Page.GetByRole(AriaRole.Link, new() { Name = "Relationship" });

        //Expect an attribute "to be stricly equal" to the value.
        await Expect(relationshipLnk).ToHaveAttributeAsync("href", "/Relationship/List");

        //Click the privacy link
        await relationshipLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Relationship/List"));

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //Verify relationship link on the Privacy Page
        var privacyLnk = Page.GetByTestId("lnk_Privacy");

        await privacyLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await relationshipLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Relationship/List"));

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //Verify relationship link on the Home Page
        var homeLnk = Page.GetByTestId("lnk_Home");

        await homeLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await relationshipLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Relationship/List"));
    }

    [Test]
    public async Task PrivacyLinkAllPages()
    {
        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //create a locator
        var privacyLnk = Page.GetByTestId("lnk_Privacy");

        //Expect an attribute "to be stricly equal" to the value.
        await Expect(privacyLnk).ToHaveAttributeAsync("href", "/Home/Privacy");

        //Click the privacy link
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //Verify privacy link on the Relationship Page
        var relationshipLnk = Page.GetByTestId("lnk_Privacy");

        await relationshipLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //Verify privacy link on the Home Page
        var homeLnk = Page.GetByTestId("lnk_Home");

        await homeLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));
    }

    [Test]
    public async Task HomeLinkAllPages()
    {
        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //create a locator
        var homeLnk = Page.GetByRole(AriaRole.Link, new() { Name = "Home" });

        //Click the privacy link
        await homeLnk.ClickAsync();

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //Verify home link on the Relationship Page
        var relationshipLnk = Page.GetByTestId("lnk_Privacy");

        await relationshipLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await homeLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //Verify home link on the Home Page
        var privacyLnk = Page.GetByTestId("lnk_Privacy");

        await privacyLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await homeLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));
    }

    [Test]
    public async Task HomeIconAllPages()
    {
        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //create a locator
        var homeLnk = Page.GetByRole(AriaRole.Link, new() { Name = "ScoobWebApp" });

        //Click the privacy link
        await homeLnk.ClickAsync();

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //Verify home link on the Relationship Page
        var relationshipLnk = Page.GetByTestId("lnk_Privacy");

        await relationshipLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await homeLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        //Verify home link on the Home Page
        var privacyLnk = Page.GetByTestId("lnk_Privacy");

        await privacyLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await homeLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));
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