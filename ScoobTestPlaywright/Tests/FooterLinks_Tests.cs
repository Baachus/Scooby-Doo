using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Pages;

namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class FooterLinks_Tests : TestSetup
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

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await relationshipLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));

        //Verify privacy footer link on the Home Page
        var homeLnk = Page.GetByTestId("lnk_Home");


        if (testSettings.Mobile)
            await sharedPage.ClickToggle();
        await homeLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));

        //Verify privacy footer link on the Privacy Page
        var privacyHeaderLnk = Page.GetByTestId("lnk_Privacy");

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();
        await privacyHeaderLnk.ClickAsync();

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();
        await privacyLnk.ClickAsync();

        //Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*Privacy"));
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