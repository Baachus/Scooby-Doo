using ScoobyRelationship.Repository;

namespace ScoobTestBDD.StepDefinitions;

[Binding]
public class ReuseableSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IRelationshipRepository relationshipRepository;
    private readonly IHomePage homePage;

    public ReuseableSteps(ScenarioContext scenarioContext,
        IRelationshipRepository relationshipRepository,
        IHomePage homePage)
    {
        this.scenarioContext = scenarioContext;
        this.relationshipRepository = relationshipRepository;
        this.homePage = homePage;
    }

    [Then(@"I delete the (.*) relationship")]
    [When(@"I delete the (.*) relationship")]
    public void WhenIDeleteTheAutomationGuyRelationship(string relationshipName)
    {
        try
        {
            relationshipRepository.DeleteRelationship(relationshipName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(relationshipName + ": Does not exist - " + ex.Message);
        }
    }

    [Given(@"I ensure the following relationship is created")]
    public void GivenIEnsureTheFollowingRelationshipIsCreated(Table table)
    {
        //Automatically map all the Specflow table row data to the actual Product Type
        //based upon the property name to table row name.
        ScoobRelation relation = table.CreateInstance<ScoobRelation>();

        relationshipRepository.AddRelationship(relation);

        //Store the relationship details in the scenario context
        scenarioContext.Set<ScoobRelation>(relation);
    }

    [Given(@"I cleanup the following data")]
    public void GivenICleanupTheFollowingData(Table table)
    {
        var relationships = table.CreateSet<ScoobRelation>();
        foreach (var relationship in relationships)
        {
            var relat = relationshipRepository.GetRelationshipByName(relationship.Name);

            //TODO: Repeat until all clear incase multiple 
            if (relat != null)
                relationshipRepository.DeleteRelationship(relationship.Name);
        }
    }

    [Given(@"I click the (.*) menu")]
    [When(@"I click the (.*) menu")]
    public void WhenIClickTheRelationshipLink(string linkName)
    {
        switch (linkName.ToLower())
        {
            case "relationship":
            case "relationship page":
                homePage.ClickRelationship();
                break;
            case "privacy":
            case "privacy page":
                homePage.ClickPrivacy();
                break;
            case "home":
            case "home page":
                homePage.ClickHome();
                break;
            case "scoobwebapp":
                homePage.ClickScoobWebApp();
                break;
        }
    }

    [When(@"I click the Privacy menu in the footer")]
    public void WhenIClickThePrivacyMenuInTheFooter()
    {
        homePage.ClickFooterPrivacy();
    }


    [Then(@"I verify I am on the (.*) page")]
    public void ThenIVerifyIAmOnTheRelationshipPage(string pageName)
    {
        switch (pageName.ToLower())
        {
            case "relationship":
            case "relationship page":
                homePage.VerifyRelationshipPage();
                break;
            case "privacy":
            case "privacy page":
                homePage.VerifyPrivacyPage();
                break;
            case "home":
            case "home page":
                homePage.GetWelcomeBanner().Text.Should().Be("Welcome");
                break;
        }
    }

}
