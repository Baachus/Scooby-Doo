using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using ScoobTestFramework.Settings;

namespace ScoobTestFramework.Driver;

public class DriverFixture : IDriverFixture, IDisposable
{

    IWebDriver driver;
    private readonly IBrowserDriver browserDriver;
    private readonly TestSettings testSettings;

    public IWebDriver Driver => driver;
    public void Dispose() => driver.Quit();


    //Dependecy Injection is happening within this method.
    public DriverFixture(TestSettings testSettings, IBrowserDriver browserDriver)
    {
        this.testSettings = testSettings;
        this.browserDriver = browserDriver;
        
        //Changes between local and remote based upon ExecutionType in test.runsettings.
        if (testSettings.ExecutionType == ExecutionType.Local)
        {
            driver = GetLocalDriver();

            //Sets the screensize to larger field of view to assist with visibility of objects
            driver.Manage().Window.Size = new System.Drawing.Size(1800, 1500);
        }
        else
        {
            driver = new RemoteWebDriver(testSettings.SeleniumGridUrl, GetBrowserOptions());
            driver.Manage().Window.Size = new System.Drawing.Size(1800, 1500);
        }
        
        driver.Navigate().GoToUrl(testSettings.ApplicationUrl);
    }

    private IWebDriver GetLocalDriver()
    {
        return testSettings.BrowserType switch
        {
            BrowserType.Chrome => browserDriver.GetChromeDriver(),
            BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
            BrowserType.Edge => browserDriver.GetEdgeDriver(),
            _ => browserDriver.GetChromeDriver()
        };
    }
    private dynamic GetBrowserOptions()
    {
        switch (testSettings.BrowserType)
        {
            case BrowserType.Firefox:
                {
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddAdditionalOption("se:recordVideo", true);
                    return firefoxOptions;
                }
            case BrowserType.Edge:
                return new EdgeOptions();
            case BrowserType.Safri:
                return new SafariOptions();
            case BrowserType.Chrome:
                {
                    var chromeOption = new ChromeOptions();
                    chromeOption.AddAdditionalOption("se:recordVideo", true);
                    return chromeOption;
                }
            default:
                return new ChromeOptions();
        }
    }
}
