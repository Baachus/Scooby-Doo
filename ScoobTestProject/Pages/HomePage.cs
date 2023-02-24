using ScoobTestFramework.Driver;
using ScoobTestFramework.Extensions;

namespace ScoobTestProject.Pages;

public interface IHomePage
{
    void CreateRelationship();
    void PerformClickOnSpecialValue(string name, string operation = "Details");
}

public class HomePage : IHomePage
{
    private readonly IWebDriver driver;

    public HomePage(IDriverFixture driver) => this.driver = driver.Driver;

    //Web Elements for Home Page and List Page
    IWebElement lnkRelationship => driver.FindElement(By.LinkText("Relationship"));
    IWebElement lnkCreate => driver.FindElement(By.LinkText("Create New"));
    IWebElement tblList => driver.FindElement(By.ClassName("table"));

    /// <summary>
    /// This method takes the user from the home page and clicks the 
    /// Relationship link to be on the Relationship List page, then
    /// clicks the Create link to create a new relationship.
    /// </summary>
    public void CreateRelationship()
    {
        lnkRelationship.Click();
        lnkCreate.Click();
    }

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
}
