using ScoobTestFramework.Driver;
using ScoobTestFramework.Extensions;
using ScoobTestProject.Model;

namespace ScoobTestProject.Pages;

public interface IRelationshipPage
{
    void EnterRelationshipDetails(ScoobRelation relation);
    void ReturnToHomePage();
    ScoobRelation GetProductDetails();
}

public class RelationshipPage : IRelationshipPage
{
    private readonly IWebDriver driver;

    public RelationshipPage(IDriverFixture driver) => this.driver = driver.Driver;

    //Web Elements on Relationship pages (Create, Edit, Delete, and Details)
    IWebElement txtName => driver.FindElement(By.LinkText("Create New"));
    IWebElement ddlGang => driver.FindElement(By.Id("Gang"));
    IWebElement txtRelationship => driver.FindElement(By.Id("Relationship"));
    IWebElement txtApperance => driver.FindElement(By.Id("Appearance"));
    IWebElement btnCreate => driver.FindElement(By.Id("Create"));
    IWebElement lnkReturnToHome => driver.FindElement(By.Id("return"));

    /// <summary>
    /// This method enters details for a newly created relationship based upon
    /// the ScoobRelation sent in.  It enters all values in their respective 
    /// fields then clicks the create button to successfully create a new
    /// relationship.
    /// </summary>
    /// <param name="relation">ScoobRelation to be entered</param>
    public void EnterRelationshipDetails(ScoobRelation relation)
    {
        txtName.SendKeys(relation.Name);
        ddlGang.SelectDropDownByText(relation.Gang.ToString());
        txtRelationship.SendKeys(relation.Relationship);
        txtApperance.SendKeys(relation.Appearance);
        btnCreate.Click();
    }

    /// <summary>
    /// This method clicks the link to return home page and keeps
    /// the seperation of duties from the test files.
    /// </summary>
    public void ReturnToHomePage()
    {
        lnkReturnToHome.Click();
    }

    /// <summary>
    /// This method retrieves all the product details on the page, 
    /// it then returns this information in a ScoobRelation object.
    /// </summary>
    /// <returns>ScoobRelation is returned with all details for
    /// Name, Appearance, Relationship, and Gang</returns>
    public ScoobRelation GetProductDetails()
    {
        return new ScoobRelation()
        {
            Name = txtName.Text,
            Appearance = txtApperance.Text,
            Relationship = txtRelationship.Text,
            Gang = (GangMember)Enum.Parse(
                typeof(GangMember),
                ddlGang.GetAttribute("innerText").ToString())
        };
    }
}
