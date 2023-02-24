namespace ScoobTestBDD.Pages;

public interface IRelationshipPage
{
    void EnterRelationshipDetails(ScoobRelation relation);
    void EditRelationshipDetails(ScoobRelation relation);
    void ClickBackToList();
    ScoobRelation GetRelationshipDetails();
    void ClickDelete();
}

public class RelationshipPage : IRelationshipPage
{
    private readonly IWebDriver driver;

    public RelationshipPage(IDriverFixture driver) => this.driver = driver.Driver;

    //Web Elements on Relationship pages (Create, Edit, Delete, and Details)
    IWebElement txtName => driver.FindElement(By.Id("Name"));
    IWebElement ddlGang => driver.FindElement(By.Id("Gang"));
    IWebElement txtRelationship => driver.FindElement(By.Id("Relationship"));
    IWebElement txtApperance => driver.FindElement(By.Id("Appearance"));
    IWebElement btnCreate => driver.FindElement(By.Id("Create"));
    IWebElement btnSave => driver.FindElement(By.Id("Save"));
    IWebElement btnDelete => driver.FindElement(By.Id("Delete"));
    IWebElement lnkBackToList => driver.FindElement(By.Id("Return_List"));


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
    /// This method edits the details for a relationship based upon
    /// the ScoobRelation sent in.  It enters all values in their respective 
    /// fields then clicks the save button to successfully edit the
    /// relationship.
    /// </summary>
    /// <param name="relation">ScoobRelation to be entered</param>
    public void EditRelationshipDetails(ScoobRelation relation)
    {
        txtName.ClearAndEnterText(relation.Name);
        ddlGang.SelectDropDownByText(relation.Gang.ToString());
        txtRelationship.ClearAndEnterText(relation.Relationship);
        txtApperance.ClearAndEnterText(relation.Appearance);
        btnSave.Click();
    }

    /// <summary>
    /// This method clicks the link to return home page and keeps
    /// the seperation of duties from the test files.
    /// </summary>
    public void ClickBackToList() => lnkBackToList.Click();

    /// <summary>
    /// This method retrieves all the relationship details on the page, 
    /// it then returns this information in a ScoobRelation object.
    /// </summary>
    /// <returns>ScoobRelation is returned with all details for
    /// Name, Appearance, Relationship, and Gang</returns>
    public ScoobRelation GetRelationshipDetails()
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

    public void ClickDelete() => btnDelete.Click();
}
