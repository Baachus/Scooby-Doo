namespace ScoobTestBDD.StepDefinitions;

[Binding]
public sealed class CreateSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly ICreatePage createPage;

    public CreateSteps(
        ScenarioContext scenarioContext,
        ICreatePage createPage)
    {
        this.scenarioContext = scenarioContext;
        this.createPage = createPage;
    }


}
