using ScoobTestPlaywright.Pages;

namespace ScoobTestPlaywright.Extensions;

public class TestSetup : PageTest
{
    private TestSettings testSettings;
    public TestSetup() => testSettings = new TestSettings();

    public override BrowserNewContextOptions ContextOptions()
    {
        testSettings = TestSettings.ReadConfig();

        if (testSettings.Mobile)
        {
            var mobile = Playwright.Devices["Pixel 4a (5G)"];
            return new BrowserNewContextOptions()
            {
                IsMobile = true,
                DeviceScaleFactor = mobile.DeviceScaleFactor,
                UserAgent = mobile.UserAgent,
                ViewportSize = mobile.ViewportSize
            };
        }
        return new BrowserNewContextOptions();
    }

    public async Task<string> SetupTestsAsync(string testName)
    {
        Guid guid = Guid.NewGuid();
        testName = $"{testName} - {guid}";
        await Context.Tracing.StartAsync(new TracingStartOptions
        {
            Title = testName,
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        await Page.GotoAsync("http://localhost:5002/");

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        SharedPage sharedPage;
        sharedPage = new SharedPage(Page);

        var testSettings = TestSettings.ReadConfig();
        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await sharedPage.ClickRelationshipLink();

        return testName;
    }

    public async Task<string> SetupTestsNoNavigationAsync(string testName)
    {
        Guid guid = Guid.NewGuid();
        testName = $"{testName} - {guid}";
        await Context.Tracing.StartAsync(new TracingStartOptions
        {
            Title = testName,
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        await Page.GotoAsync("http://localhost:5002/");

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        return testName;
    }
}
