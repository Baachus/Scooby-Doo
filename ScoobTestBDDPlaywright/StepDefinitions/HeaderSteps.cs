namespace ScoobTestBDDPlaywright.StepDefinitions;

[Binding]
public class HeaderSteps
{
    private readonly ScenarioContext scenarioContext;

    public HeaderSteps(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }

    [Given(@"I am on the Welcome Page")]
    public void GivenIAmOnTheWelcomePage()
    {

    }
}
