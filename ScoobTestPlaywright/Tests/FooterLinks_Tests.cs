namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class FooterLinks_Tests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://localhost:5002/");

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));
    }

    [Test]
    public async Task PrivacyLink()
    {
        //create a locator
        var privacyLnk = Page.Locator("#Privacy_Footer");

        //Expect an attribute "to be stricly equal" to the value.
        await Expect(privacyLnk).ToHaveAttributeAsync("href", "/Home/Privacy");

        //Click the privacy link
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));
    }

    [Test]
    public async Task PrivacyLinkAllPages()
    {
        //create a locator
        var privacyLnk = Page.Locator("#Privacy_Footer");

        //Expect an attribute "to be stricly equal" to the value.
        await Expect(privacyLnk).ToHaveAttributeAsync("href", "/Home/Privacy");

        //Click the privacy link
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));

        //Verify privacy footer link on the Relationship Page
        var relationshipLnk = Page.GetByTestId("lnk_Privacy");

        await relationshipLnk.ClickAsync();

        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));

        //Verify privacy footer link on the Home Page
        var homeLnk = Page.GetByTestId("lnk_Home");

        await homeLnk.ClickAsync();
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));

        //Verify privacy footer link on the Privacy Page
        var privacyHeaderLnk = Page.GetByTestId("lnk_Privacy");

        await privacyHeaderLnk.ClickAsync();
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));
    }
}