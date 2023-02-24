namespace ScoobTestFramework.Driver;

public interface IBrowserDriver
{
    IWebDriver GetChromeDriver();
    IWebDriver GetFirefoxDriver();
    IWebDriver GetEdgeDriver();
}
