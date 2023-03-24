using Bogus;
using CsvHelper.Configuration.Attributes;
using Microsoft.IdentityModel.Tokens;

namespace ScoobTestBDD.Pages;

public interface ICreatePage
{
    void ClickBackToList();
    void EnterRelationshipDetails(ScoobRelation relation);
    void EnterSpecificRelationshipDetail(string fieldName, [Optional] string newText = null, [Optional] int characterLength = -1);
    IList<IWebElement> GetGangMemberOptions();
    void VerifyEnteredFieldLength(string fieldName, int characterLength);
}

public class CreatePage : ICreatePage
{
    private readonly IWebDriver driver;

    public CreatePage(IDriverFixture driver) => this.driver = driver.Driver;

    //Web Elements on Edit page
    IWebElement txtName => driver.FindElement(By.Id("Name"));
    IWebElement ddlGang => driver.FindElement(By.Id("Gang"));
    IWebElement txtRelationship => driver.FindElement(By.Id("Relationship"));
    IWebElement txtAppearance => driver.FindElement(By.Id("Appearance"));
    IWebElement lnkBackToList => driver.FindElement(By.Id("Return_List"));
    IWebElement btnCreate => driver.FindElement(By.Id("Create"));

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
    /// This method clicks the link to return home page and keeps
    /// the seperation of duties from the test files.
    /// </summary>
    public void ClickBackToList() => lnkBackToList.Click();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IList<IWebElement> GetGangMemberOptions()
    {
        SelectElement select = new SelectElement(ddlGang);
        return select.Options;
    }/// <summary>
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
}
