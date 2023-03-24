namespace ScoobTestBDD.StepDefinitions;

[Binding]
public sealed class EditSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IEditPage editPage;

    public EditSteps(
        ScenarioContext scenarioContext,
        IEditPage editPage)
    {
        this.scenarioContext = scenarioContext;
        this.editPage = editPage;
    }

    [When(@"I enter random characters into the (.*) field that is (.*) characters long on the edit page")]
    public void WhenIEnterRandomCharactersIntoTheRelationshipFieldThatIsCharactersLongOnTheEditPage(string fieldName, int characterLength)
    {
        editPage.EnterSpecificRelationshipDetail(fieldName, "", characterLength);
    }

    [When(@"I edit the relationship with the following details but do not save")]
    public void WhenIEditTheRelationshipWithTheFollowingDetailsButDoNotSave(Table table)
    {
        var relationship = table.CreateInstance<ScoobRelation>();
        editPage.EditRelationshipDetailsButDontSave(relationship);
    }

    [Then(@"I can verify the Gang dropdown has the following option for (.*) on the edit page")]
    public void ThenICanVerifyTheGangDropdownHasTheFollowingOptionFor(string gangName)
    {
        IList<IWebElement> availableNames = editPage.GetGangMemberOptions();

        availableNames.Should().ContainSingle(x => x.Text == gangName.ToString())
            .And.OnlyHaveUniqueItems();
    }

    [When(@"I click the Back to List link on the edit page")]
    [Then(@"I click the Back to List link on the edit page")]
    public void WhenIClickTheBackToListLink()
    {
        editPage.ClickBackToList();
    }

    [Then(@"I can verify only (.*) characters are allowed in the (.*) field on the edit page")]
    public void ThenICanVerifyOnlyCharactersAreAllowedInTheRelationshipFieldOnTheEditPage(int characterLength, string fieldName)
    {
        editPage.VerifyEnteredFieldLength(fieldName, characterLength);
    }

    [When(@"I edit the relationship with the following details")]
    public void WhenIEditTheRelationshipWithTheFollowingDetails(Table table)
    {
        var relationship = table.CreateInstance<ScoobRelation>();
        editPage.EditRelationshipDetails(relationship);

        //Store the relationship details in the scenario context
        scenarioContext.Set<ScoobRelation>(relationship);
    }

    [Then(@"I see all the relationship details are created as expected on the edit page")]
    public void ThenISeeAllTheRelationshipDetailsAreCreatedAsExpectedOnTheEditPage()
    {
        var relation = scenarioContext.Get<ScoobRelation>();

        ScoobRelation actualProduct = editPage.GetRelationshipDetails();
        actualProduct.Should().BeEquivalentTo(relation,
            options => options.Excluding(x => x.Id));
    }
}
