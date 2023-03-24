namespace ScoobTestBDD.StepDefinitions;

[Binding]
public sealed class DeleteSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IDeletePage deletePage;

    public DeleteSteps(
        ScenarioContext scenarioContext,
        IDeletePage deletePage)
    {
        this.scenarioContext = scenarioContext;
        this.deletePage = deletePage;
    }

    [Then(@"I see all the relationship details are created as expected on the delete page")]
    public void ThenISeeAllTheRelationshipDetailsAreCreatedAsExpected()
    {
        var relation = scenarioContext.Get<ScoobRelation>();

        ScoobRelation actualProduct = deletePage.GetRelationshipDetails();
        actualProduct.Should().BeEquivalentTo(relation,
            options => options.Excluding(x => x.Id));
    }

    [When(@"I click the Back to List link on the delete page")]
    public void WhenIClickTheBackToListLinkOnTheDeletePage()
    {
        deletePage.ClickBackToList();
    }

    [When(@"I click the Delete button")]
    public void WhenIClickTheDeleteButton()
    {
        deletePage.ClickDelete();
    }

}
