namespace ScoobTestBDD.StepDefinitions;

[Binding]
public sealed class RelationshipSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IHomePage homePage;
    private readonly IRelationshipPage relationshipPage;

    public RelationshipSteps(
        ScenarioContext scenarioContext,
        IHomePage homePage,
        IRelationshipPage relationshipPage)
    {
        this.scenarioContext = scenarioContext;
        this.homePage = homePage;
        this.relationshipPage = relationshipPage;
    }

    [When(@"I click the ""([^""]*)"" link")]
    public void WhenIClickTheLink(string linkName)
    {
        switch (linkName.ToLower())
        {
            case "create":
            case "create new":
                homePage.ClickCreateNew();
                break;
            case "delete":
                var relation = scenarioContext.Get<ScoobRelation>();
                homePage.PerformClickOnSpecialValue(relation.Name, "Delete");
                break;
        }
    }

    [When(@"I create a relationship with the following details")]
    public void GivenICreateARelationshipWithTheFollowingDetails(Table table)
    {
        //Automatically map all the Specflow table row data to the actual Relationship Type
        //based upon the property name to table row name.
        ScoobRelation relation = table.CreateInstance<ScoobRelation>();
        relationshipPage.EnterRelationshipDetails(relation);

        //Store the relationship details in the scenario context
        scenarioContext.Set<ScoobRelation>(relation);
    }

    [When(@"I click the (.*) link of the newly created relationship")]
    public void WhenIClickTheOperationLinkOfTheNewlyCreatedRelationship(string operation)
    {
        var relation = scenarioContext.Get<ScoobRelation>();
        homePage.PerformClickOnSpecialValue(relation.Name, operation);
    }

    [Then(@"I see all the relationship details are created as expected")]
    public void ThenISeeAllTheRelationshipDetailsAreCreatedAsExpected()
    {
        var relation = scenarioContext.Get<ScoobRelation>();

        ScoobRelation actualProduct = relationshipPage.GetRelationshipDetails();
        actualProduct.Should().BeEquivalentTo(relation,
            options => options.Excluding(x => x.Id));
    }

    [Then(@"I see the new relationship on the relationship table")]
    public void ThenISeeTheNewRelationshipOnTheRelationshipTable()
    {
        var relation = scenarioContext.Get<ScoobRelation>();

        homePage.VerifyDataOnTable(relation);
    }


    [When(@"I click to return to the Relationship List")]
    public void WhenIClickToReturnToTheRelationshipList()
    {
        relationshipPage.ClickBackToList();
    }

    [When(@"I edit the relationship with the following details")]
    public void WhenIEditTheRelationshipWithTheFollowingDetails(Table table)
    {
        var relationship = table.CreateInstance<ScoobRelation>();
        relationshipPage.EditRelationshipDetails(relationship);

        //Store the relationship details in the scenario context
        scenarioContext.Set<ScoobRelation>(relationship);
    }

    [When(@"I click the Back to List link")]
    [Then(@"I click the Back to List link")]
    public void WhenIClickTheBackToListLink()
    {
        relationshipPage.ClickBackToList();
    }

    [Then(@"I can verify the Gang dropdown has the following option for (.*)")]
    public void ThenICanVerifyTheGangDropdownHasTheFollowingOptionFor(string gangName)
    {
        IList<IWebElement> availableNames = relationshipPage.GetGangMemberOptions();

        availableNames.Should().ContainSingle(x => x.Text == gangName.ToString())
            .And.OnlyHaveUniqueItems();
    }

    [When(@"I enter a random sentence into the (.*) field that is (.*) characters long")]
    public void WhenIEnterARandomSentenceIntoTheRelationshipFieldThatIsCharactersLong(string fieldName, int characterLength)
    {
        relationshipPage.EnterSpecificRelationshipDetail(fieldName, "",characterLength);
    }

    [Then(@"I can verify only (.*) characters are allowed in the (.*) field")]
    public void ThenICanVerifyOnlyCharactersAreAllowedInTheRelationshipField(int characterLength, string fieldName)
    {
        relationshipPage.VerifyEnteredFieldLength(fieldName, characterLength);
    }

    [When(@"I edit the relationship with the following details but do not save")]
    public void WhenIEditTheRelationshipWithTheFollowingDetailsButDoNotSave(Table table)
    {
        var relationship = table.CreateInstance<ScoobRelation>();
        relationshipPage.EditRelationshipDetailsButDontSave(relationship);
    }
}