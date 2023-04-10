using RestSharp;
using ScoobTestBDD.Extensions;

namespace ScoobTestBDD.StepDefinitions
{
    [Binding]
    public sealed class APISteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly APIExtension apiExtension;

        public APISteps(ScenarioContext scenarioContext)
        {
            apiExtension = new APIExtension();
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I create a relationship with the following details through the API")]
        public void GivenICreateARelationshipWithTheFollowingDetailsThroughTheAPI(Table table)
        {
            ScoobRelation relation = table.CreateInstance<ScoobRelation>();

            RestResponse response = apiExtension.SendRequest("/Relationship/AddScoobyRelation", Method.Post, relation);

            //Store the response details in the scenario context
            scenarioContext.Set<RestResponse>(response);

            ScoobRelation scoobRelation = ScoobAPIExtension.GetRelationFromResponseContent(response.Content);

            //Store the relationshpi details in the scenario context
            scenarioContext.Set<ScoobRelation>(scoobRelation);
        }

        [Given(@"I create multiple relationships with the following details through the API")]
        public void GivenICreateMultipleRelationshipsWithTheFollowingDetailsThroughTheAPI(Table table)
        {
            IEnumerable<ScoobRelation> relations = table.CreateSet<ScoobRelation>();

            RestResponse response = null;

            foreach (var relation in relations)
                response = apiExtension.SendRequest("/Relationship/AddScoobyRelation", Method.Post, relation);

            //Store the response details in the scenario context
            scenarioContext.Set<RestResponse>(response);

            ScoobRelation scoobRelation = ScoobAPIExtension.GetRelationFromResponseContent(response.Content);

            //Store the relationshpi details in the scenario context
            scenarioContext.Set<ScoobRelation>(scoobRelation);
        }


        [Given(@"I get all relationships through the API")]
        public void GivenIGetAllRelationshipsThroughTheAPI()
        {
            RestResponse response = apiExtension.SendRequest("/Relationship/GetScoobyRelations", Method.Get);

            //Store the response details in the scenario context
            scenarioContext.Set<RestResponse>(response);
        }

        [Given(@"I get a relationship through the API with the name (.*)")]
        public void GivenIGetARelationshipThroughTheAPIWithTheName(string name)
        {
            RestResponse response = apiExtension.SendRequest($"/Relationship/GetScoobyRelationByName/{name}", Method.Get);

            //Store the response details in the scenario context
            scenarioContext.Set<RestResponse>(response);
        }

        [Given(@"I get a relationship through the API with the id (.*)")]
        public void GivenIGetARelationshipThroughTheAPIWithTheId(int id)
        {
            RestResponse response = apiExtension.SendRequest($"/Relationship/GetScoobyRelationById/{id}", Method.Get);

            //Store the response details in the scenario context
            scenarioContext.Set<RestResponse>(response);
        }

        [Then(@"I can verify the data exists for the following data")]
        public void ThenICanVerifyTheDataExistsForTheFollowingData(Table table)
        {
            var relation = table.CreateSet<ScoobRelation>();

            RestResponse response = scenarioContext.Get<RestResponse>();
            foreach (ScoobRelation relationship in relation)
            {
                response.Content.Should().Contain(relationship.Name);
                //response.Content.Should().Contain(relationship.Appearance);  TODO: coming in as null from table - investigate why
                response.Content.Should().Contain(relationship.Gang.ToString());
                response.Content.Should().Contain(relationship.Relationship);
            }
        }

        [When(@"I delete the (.*) relationship through the API by name")]
        public void WhenIDeleteTheAutomationDeleteGuyRelationshipThroughTheAPIByName(string name)
        {
            RestResponse response = apiExtension.SendRequest($"/Relationship/DeleteScoobyRelationByName/{name}", Method.Delete);

            scenarioContext.Set<RestResponse>(response);
        }

        [When(@"I delete the (.*) relationship through the API")]
        public void WhenIDeleteTheAutomationDeleteGuyRelationshipThroughTheAPI(string name)
        {
            int idFromName = ScoobAPIExtension.GetIdFromName(name);

            RestResponse response = apiExtension.SendRequest($"/Relationship/DeleteScoobyRelationById/{idFromName}", Method.Delete);

            scenarioContext.Set<RestResponse>(response);
        }

        [When(@"I update a relationship with the following details through the API")]
        public void WhenIUpdateARelationshipWithTheFollowingDetailsThroughTheAPI(Table table)
        {
            ScoobRelation relation = table.CreateInstance<ScoobRelation>();

            RestResponse response = apiExtension.SendRequest("/Relationship/UpdateScoobyRelation", Method.Put, relation);

            //Store the response details in the scenario context
            scenarioContext.Set<RestResponse>(response);

            ScoobRelation scoobRelation = ScoobAPIExtension.GetRelationFromResponseContent(response.Content);

            //Store the relationshpi details in the scenario context
            scenarioContext.Set<ScoobRelation>(scoobRelation);
        }

    }
}
