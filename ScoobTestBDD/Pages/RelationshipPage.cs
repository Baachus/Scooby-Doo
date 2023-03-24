using Bogus;
using CsvHelper.Configuration.Attributes;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace ScoobTestBDD.Pages;

public interface IRelationshipPage
{
    void EnterRelationshipDetails(ScoobRelation relation);
    void EditRelationshipDetails(ScoobRelation relation);
    void EditRelationshipDetailsButDontSave(ScoobRelation relation);
    void ClickBackToList();
    void ClickEdit();
    ScoobRelation GetRelationshipDetails();
    void ClickDelete();
    IList<IWebElement> GetGangMemberOptions();
    void EnterSpecificRelationshipDetail(string fieldName, [Optional] string? newText = null, [Optional] int characterLength = -1);
    void VerifyEnteredFieldLength(string fieldName, int characterLength);
    void SortByHeader(string columnToSort);
    void VerifySort(string columnSort, string order);
    void VerifyNameOnTable(string name);
    void SearchForRelationship(string name);
}

public class RelationshipPage : IRelationshipPage
{
    private readonly IWebDriver driver;

    public RelationshipPage(IDriverFixture driver) => this.driver = driver.Driver;

    //Web Elements on Relationship pages (Create, Edit, Delete, and Details)
    IWebElement txtName => driver.FindElement(By.Id("Name"));
    IWebElement ddlGang => driver.FindElement(By.Id("Gang"));
    IWebElement tblList => driver.FindElement(By.ClassName("table"));
    IWebElement txtRelationship => driver.FindElement(By.Id("Relationship"));
    IWebElement txtAppearance => driver.FindElement(By.Id("Appearance"));
    IWebElement btnCreate => driver.FindElement(By.Id("Create"));
    IWebElement btnSave => driver.FindElement(By.Id("Save"));
    IWebElement btnDelete => driver.FindElement(By.Id("Delete"));
    IWebElement lnkBackToList => driver.FindElement(By.Id("Return_List"));
    IWebElement lnkEdit => driver.FindElement(By.LinkText("Edit"));
    IWebElement lnkIdHeader => driver.FindElement(By.CssSelector("#Id_Header>a"));
    IWebElement lnkNameHeader => driver.FindElement(By.CssSelector("#Name_Header>a"));
    IWebElement lnkGangHeader => driver.FindElement(By.CssSelector("#Gang_Header>a"));
    IWebElement lnkRelationshipHeader => driver.FindElement(By.CssSelector("#Relationship_Header>a"));
    IWebElement lnkApperanceHeader => driver.FindElement(By.CssSelector("#Apperance_Header>a"));
    IWebElement txtSearch => driver.FindElement(By.Id("SearchString"));
    IWebElement btnSearch => driver.FindElement(By.Id("Name_Search"));

    /// <summary>
    /// This method enters details for a newly created relationship based upon
    /// the ScoobRelation sent in.  It enters all values in their respective 
    /// fields then clicks the create button to successfully create a new
    /// relationship.
    /// </summary>
    /// <param name="relation">ScoobRelation to be entered</param>
    public void EnterRelationshipDetails(ScoobRelation relation)
    {
        var fake = new Faker("en");

        relation.Name ??= fake.Name.FullName();
        relation.Relationship ??= fake.Lorem.Word();
        relation.Appearance ??= fake.Lorem.Sentences();
        if (relation.Gang == null)
            fake.PickRandom<GangMember>();

        txtName.SendKeys(relation.Name);
        ddlGang.SelectDropDownByText(relation.Gang.ToString());
        txtRelationship.SendKeys(relation.Relationship);
        txtAppearance.SendKeys(relation.Appearance);
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
        txtName.ClearAndEnterText(relation.Name ?? "");
        if (relation.Gang != null)
            ddlGang.SelectDropDownByText(relation.Gang.ToString());
        txtRelationship.ClearAndEnterText(relation.Relationship ?? "");
        txtAppearance.ClearAndEnterText(relation.Appearance ?? "");
        btnSave.Click();
    }

    /// <summary>
    /// This method edits the details for a relationship based upon
    /// the ScoobRelation sent in.  It enters all values in their respective 
    /// fields but doesn't clicks the save button to successfully edit the
    /// relationship.
    /// </summary>
    /// <param name="relation">ScoobRelation to be entered</param>
    public void EditRelationshipDetailsButDontSave(ScoobRelation relation)
    {
        txtName.ClearAndEnterText(relation.Name ?? "");
        if (relation.Gang != null)
            ddlGang.SelectDropDownByText(relation.Gang.ToString());
        txtRelationship.ClearAndEnterText(relation.Relationship ?? "");
        txtAppearance.ClearAndEnterText(relation.Appearance ?? "");
    }

    /// <summary>
    /// This method clicks the link to return home page and keeps
    /// the seperation of duties from the test files.
    /// </summary>
    public void ClickBackToList() => lnkBackToList.Click();

    /// <summary>
    /// 
    /// </summary>
    public void ClickEdit() => lnkEdit.Click();

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
            Appearance = txtAppearance.Text,
            Relationship = txtRelationship.Text,
            Gang = (GangMember)Enum.Parse(
                typeof(GangMember),
                ddlGang.GetAttribute("innerText").ToString())
        };
    }

    /// <summary>
    /// 
    /// </summary>
    public void ClickDelete() => btnDelete.Click();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IList<IWebElement> GetGangMemberOptions()
    {
        SelectElement select = new SelectElement(ddlGang);
        return select.Options;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fieldName"></param>
    /// <param name="newText"></param>
    /// <param name="characterLength"></param>
    public void EnterSpecificRelationshipDetail(string fieldName,
                                                [Optional] string newText = null,
                                                [Optional] int characterLength = -1)
    {
        if (characterLength > 0 || newText.IsNullOrEmpty())
        {
            var fake = new Faker("en");
            newText = fake.Random.AlphaNumeric(characterLength);
        }

        switch (fieldName.ToLower())
        {
            case "name":
                txtName.ClearAndEnterText(newText);
                break;
            case "relationship":
                txtRelationship.ClearAndEnterText(newText);
                break;
            case "appearance":
                txtAppearance.ClearAndEnterText(newText);
                break;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fieldName"></param>
    /// <param name="characterLength"></param>
    public void VerifyEnteredFieldLength(string fieldName, int characterLength)
    {
        string result = "";

        switch (fieldName.ToLower())
        {
            case "name":
                result = txtName.GetAttribute("value");
                break;
            case "relationship":
                result = txtRelationship.GetAttribute("value");
                break;
            case "appearance":
                result = txtAppearance.GetAttribute("value");
                break;
        }

        result.Should().HaveLength(characterLength);
    }

    /// <summary>
    /// This method clicks the specific header link at the top of the
    /// relationship page for sorting.
    /// </summary>
    /// <param name="columnToSort">The column name to be sorted by</param>
    public void SortByHeader(string columnToSort)
    {
        switch(columnToSort.ToLower())
        {
            case "id":
                lnkIdHeader.Click();
                break;
            case "name":
                lnkNameHeader.Click();
                break;
            case "gang":
                lnkGangHeader.Click();
                break;
            case "relationship":
                lnkRelationshipHeader.Click();
                break;
            case "apperance":
                lnkApperanceHeader.Click();
                break;
        }
    }

    public void VerifySort(string columnSort, string order)
    {
        List<TableDatacolleciton> table = HtmlTableExtension.ReadTable(tblList);

        table.Should().NotBeEmpty();

        var alteredTable = new List<TableDatacolleciton>();
        
        // Iterate over each table row and remove columns not needed
        foreach (var row in table)
        {
            if (row.ColumnName.ToUpper() == columnSort.ToUpper())
                alteredTable.Add(row);
        }

        switch (order[0])
        {
            case 'a':
            case 'A':
                alteredTable.Should().BeInAscendingOrder(td=>td.ColumnValue);
                break;
            default:
            case 'd':
            case 'D':
                alteredTable.Should().BeInDescendingOrder(td => td.ColumnValue);
                break;
        }
    }

    public void VerifyNameOnTable(string name)
    {
        List<TableDatacolleciton> table = HtmlTableExtension.ReadTable(tblList);

        bool found = false;
        foreach(var row in table)
        {
            if (row.ColumnValue == name) 
                found = true;
        }
        
        found.Should().BeTrue();
    }

    public void SearchForRelationship(string name)
    {
        txtSearch.ClearAndEnterText(name);
        btnSearch.Click();
    }
}
