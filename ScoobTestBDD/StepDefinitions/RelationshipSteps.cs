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

    [Then(@"I see all the relationship details are not present as expected")]
    public void ThenISeeAllTheRelationshipDetailsAreNotPresentAsExpected()
    {
        var relation = scenarioContext.Get<ScoobRelation>();

        homePage.VerifyDataIsNotOnTable(relation);
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

    [When(@"I click the (.*) sort")]
    public void WhenIClickTheSort(string columnToSort)
    {
        relationshipPage.SortByHeader(columnToSort);
    }

    [Then(@"all records are sorted by (.*) in (.*) order")]
    public void ThenAllRecordsAreSortedByIDInAscendingOrder(string columnSort, string order)
    {
        relationshipPage.VerifySort(columnSort, order);
    }

    [Then(@"I can verify a record with the name (.*) exists on the table")]
    public void ThenICanVerifyARecordWithTheNameOnTheTable(string name)
    {
        relationshipPage.VerifyNameOnTable(name);
    }

    [When(@"I search for (.*) on the relationship page")]
    public void WhenISearchForOnTheRelationshipPage(string name)
    {
        relationshipPage.SearchForRelationship(name);
    }

}