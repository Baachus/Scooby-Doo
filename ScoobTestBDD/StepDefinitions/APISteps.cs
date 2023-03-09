using RestSharp;
using ScoobTestBDD.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

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
            //Automatically map all the Specflow table row data to the actual Relationship Type
            //based upon the property name to table row name.
            ScoobRelation relation = table.CreateInstance<ScoobRelation>();

            RestResponse response = apiExtension.SendRequest("/Relationship/GetScoobyRelations", Method.Put);

            //Store the response details in the scenario context
            scenarioContext.Set<RestResponse>(response);
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


    }
}
