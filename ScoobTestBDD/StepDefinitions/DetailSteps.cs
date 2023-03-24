namespace ScoobTestBDD.StepDefinitions;

[Binding]
public sealed class DetailSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IDetailPage detailPage;

    public DetailSteps(
        ScenarioContext scenarioContext,
        IDetailPage detailPage)
    {
        this.scenarioContext = scenarioContext;
        this.detailPage = detailPage;
    }

    [Then(@"I see all the relationship details are created as expected on the details page")]
    public void ThenISeeAllTheRelationshipDetailsAreCreatedAsExpected()
    {
        var relation = scenarioContext.Get<ScoobRelation>();

        ScoobRelation actualProduct = detailPage.GetRelationshipDetails();
        actualProduct.Should().BeEquivalentTo(relation,
            options => options.Excluding(x => x.Id));
    }

    [When(@"I click the Back to List link on the detail page")]
    public void WhenIClickTheBackToListLinkOnTheDetailPage()
    {
        detailPage.ClickBackToList();
    }

    [When(@"I click the Edit link on the detail page")]
    public void WhenIClickTheEditLinkOnTheDetailPage()
    {
        detailPage.ClickEdit();
    }
}
