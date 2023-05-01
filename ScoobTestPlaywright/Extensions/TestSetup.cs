using ScoobTestPlaywright.Pages;
using System.Security.Authentication.ExtendedProtection;

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

    public async Task<string> SetupTestsAsync()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        await Context.Tracing.StartAsync(new TracingStartOptions
        {
            Title = testName,
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        var testSettings = TestSettings.ReadConfig();

        await Page.GotoAsync(testSettings.ApplicationUrl.ToString());

        SharedPage sharedPage;
        sharedPage = new SharedPage(Page);

        if (testSettings.Mobile)
            await sharedPage.ClickToggle();

        await sharedPage.ClickRelationshipLink();

        return testName;
    }

    public async Task<string> SetupTestsNoNavigationAsync()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        await Context.Tracing.StartAsync(new TracingStartOptions
        {
            Title = testName,
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        await Page.GotoAsync(testSettings.ApplicationUrl.ToString());

        return testName;
    }
}
