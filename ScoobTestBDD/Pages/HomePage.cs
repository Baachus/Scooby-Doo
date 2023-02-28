namespace ScoobTestBDD.Pages;

public interface IHomePage
{
    void ClickRelationship();
    void ClickCreateNew();
    void ClickHome();
    void ClickScoobWebApp();
    void ClickPrivacy();
    void ClickFooterPrivacy();
    void PerformClickOnSpecialValue(string name, string operation = "Details");
    void VerifyPrivacyPage();
    void VerifyRelationshipPage();
    IWebElement GetWelcomeBanner();
}

public class HomePage : IHomePage
{
    private readonly IWebDriver driver;

    public HomePage(IDriverFixture driver) => this.driver = driver.Driver;

    //Web Elements for Home Page and List Page
    IWebElement lnkRelationship => driver.FindElement(By.LinkText("Relationship"));
    IWebElement lnkCreate => driver.FindElement(By.LinkText("Create New"));
    IWebElement tblList => driver.FindElement(By.ClassName("table"));
    IWebElement lnkHome => driver.FindElement(By.LinkText("Home"));
    IWebElement lnkPrivacy => driver.FindElement(By.LinkText("Privacy"));
    IWebElement lnkFooterPrivacy => driver.FindElement(By.Id("Privacy_Footer"));
    IWebElement lblWelcome => driver.FindElement(By.CssSelector("h1[class='display-4']"));
    IWebElement lnkScoobWebApp => driver.FindElement(By.LinkText("ScoobWebApp"));

    /// <summary>
    /// This method takes the user from the home page and clicks the 
    /// Relationship link to be on the Relationship List page.
    /// </summary>
    public void ClickRelationship() => lnkRelationship.Click();

    /// <summary>
    /// This method takes the user from the Relationship List page
    /// and clicks the Create New link to navigate to the creation 
    /// page.
    /// </summary>
    public void ClickCreateNew() => lnkCreate.Click();

    /// <summary>
    /// This method takes the user from any page and clicks on the
    /// Home link on the top of the page.
    /// </summary>
    public void ClickHome() => lnkHome.Click();

    /// <summary>
    /// This method takes the user from any page and clicks on the
    /// Privacy link on the top of the page.
    /// </summary>
    public void ClickPrivacy() => lnkPrivacy.Click();

    /// <summary>
    /// This method takes the user from any page and clicks on the
    /// Privacy link on the bottom of the page.
    /// </summary>
    public void ClickFooterPrivacy() => lnkFooterPrivacy.Click();

    /// <summary>
    /// This method takes the user from any page and clicks on the
    /// ScoobWebApp link on the top of the page.
    /// </summary>
    public void ClickScoobWebApp() => lnkScoobWebApp.Click();

    /// <summary>
    /// This method clicks on the fifth column for a specific operation.  The
    /// row selected is based upon the name passed in and the link selected
    /// on the fifth row is based upon the operation sent in. 
    /// </summary>
    /// <param name="name">Name of row to be used</param>
    /// <param name="operation">Operation to be clicked on for that row,
    /// the available operations are Delete, Details, or Edit</param>
    public void PerformClickOnSpecialValue(string name, string operation = "Details")
    {
        tblList.PerformActionOnCell("5", "Name", name, operation);
    }

    public void VerifyPrivacyPage()
    {
        driver.Url.Should().EndWith("/Home/Privacy");
    }
    public void VerifyRelationshipPage()
    {
        driver.Url.Should().EndWith("/Relationship/List");
    }

    public IWebElement GetWelcomeBanner()
    {
        return lblWelcome;
    }
}
