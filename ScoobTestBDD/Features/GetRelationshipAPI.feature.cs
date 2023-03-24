﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ScoobTestBDD.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GetRelationshipAPIFeature : object, Xunit.IClassFixture<GetRelationshipAPIFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "GetRelationshipAPI.feature"
#line hidden
        
        public GetRelationshipAPIFeature(GetRelationshipAPIFeature.FixtureData fixtureData, ScoobTestBDD_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "GetRelationshipAPI", "This feature tests the API requests for getting a relationship.  This is tested\r\n" +
                    "with the seed data for get all relationships and non-seed data for get a specifi" +
                    "c\r\nrelationship.", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets all relationships utilizing the API and verify seed data is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets all relationships utilizing the API and verify seed data is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsAllRelationshipsUtilizingTheAPIAndVerifySeedDataIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets all relationships utilizing the API and verify seed data is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 9
 testRunner.Given("I get all relationships through the API", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Apperance",
                            "Gang"});
                table25.AddRow(new string[] {
                            "Dave Walton",
                            "Uncle",
                            "{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":3,\"EPISODE\":1,\"RELEASE_YEAR\"" +
                                ":1978}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Velma"});
                table25.AddRow(new string[] {
                            "Scrappy-Doo",
                            "Nephew",
                            "\"{\"TV\":[{}],\"Movie\":[{\"NAME\":\"Scooby-Doo\", \"RELEASE_YEAR\":2002}],\"APPEARED\":true}" +
                                "\"",
                            "Scooby"});
                table25.AddRow(new string[] {
                            "John Maxwell",
                            "Uncle",
                            "\"{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":1,\"EPISODE\":7,\"RELEASE_YEAR" +
                                "\":1969}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Daphne"});
                table25.AddRow(new string[] {
                            "Olivia Dervy",
                            "Aunt",
                            "\"{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":3,\"EPISODE\":9,\"RELEASE_YEAR" +
                                "\":1978}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Daphne"});
                table25.AddRow(new string[] {
                            "Skip Jones",
                            "Uncle",
                            "\"{\"TV\":[{}],\"Movie\":[{\"NAME\":\"Scoob-Doo! Pirates Ahoy!\", \"RELEASE_YEAR\":2006}],\"A" +
                                "PPEARED\":true}\"",
                            "Fred"});
                table25.AddRow(new string[] {
                            "Margaret \'Maggie\' Rogers",
                            "Younger Sister",
                            "\"{\"TV\":[{\"SHOW\":\"The New Scooby and Scrappy Doo Show\",\"SEASON\":1,\"EPISODE\":13,\"RE" +
                                "LEASE_YEAR\":1983}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Shaggy"});
#line 10
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table25, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by Name through the API and verify the seed data for" +
            " Dave Walton is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by Name through the API and verify the seed data for" +
            " Dave Walton is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByNameThroughTheAPIAndVerifyTheSeedDataForDaveWaltonIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by Name through the API and verify the seed data for" +
                    " Dave Walton is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 20
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 21
 testRunner.Given("I get a relationship through the API with the name Dave Walton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Apperance",
                            "Gang"});
                table26.AddRow(new string[] {
                            "Dave Walton",
                            "Uncle",
                            "{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":3,\"EPISODE\":1,\"RELEASE_YEAR\"" +
                                ":1978}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Velma"});
#line 22
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table26, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by Name through the API and verify the seed data for" +
            " Scrappy-Doo is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by Name through the API and verify the seed data for" +
            " Scrappy-Doo is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByNameThroughTheAPIAndVerifyTheSeedDataForScrappy_DooIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by Name through the API and verify the seed data for" +
                    " Scrappy-Doo is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 27
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 28
 testRunner.Given("I get a relationship through the API with the name Scrappy-Doo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Apperance",
                            "Gang"});
                table27.AddRow(new string[] {
                            "Scrappy-Doo",
                            "Nephew",
                            "\"{\"TV\":[{}],\"Movie\":[{\"NAME\":\"Scooby-Doo\", \"RELEASE_YEAR\":2002}],\"APPEARED\":true}" +
                                "\"",
                            "Scooby"});
#line 29
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table27, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by Name through the API and verify the seed data for" +
            " John Maxwell is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by Name through the API and verify the seed data for" +
            " John Maxwell is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByNameThroughTheAPIAndVerifyTheSeedDataForJohnMaxwellIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by Name through the API and verify the seed data for" +
                    " John Maxwell is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 34
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 35
 testRunner.Given("I get a relationship through the API with the name John Maxwell", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "John Maxwell",
                            "Uncle",
                            "\"{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":1,\"EPISODE\":7,\"RELEASE_YEAR" +
                                "\":1969}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Daphne"});
#line 36
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table28, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by Name through the API and verify the seed data for" +
            " Olivia Dervy is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by Name through the API and verify the seed data for" +
            " Olivia Dervy is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByNameThroughTheAPIAndVerifyTheSeedDataForOliviaDervyIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by Name through the API and verify the seed data for" +
                    " Olivia Dervy is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 40
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 41
 testRunner.Given("I get a relationship through the API with the name Olivia Dervy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Olivia Dervy",
                            "Aunt",
                            "\"{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":3,\"EPISODE\":9,\"RELEASE_YEAR" +
                                "\":1978}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Daphne"});
#line 42
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table29, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by Name through the API and verify the seed data for" +
            " Skip Jones is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by Name through the API and verify the seed data for" +
            " Skip Jones is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByNameThroughTheAPIAndVerifyTheSeedDataForSkipJonesIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by Name through the API and verify the seed data for" +
                    " Skip Jones is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 46
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 47
 testRunner.Given("I get a relationship through the API with the name Skip Jones", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "Skip Jones",
                            "Uncle",
                            "\"{\"TV\":[{}],\"Movie\":[{\"NAME\":\"Scoob-Doo! Pirates Ahoy!\", \"RELEASE_YEAR\":2006}],\"A" +
                                "PPEARED\":true}\"",
                            "Fred"});
#line 48
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table30, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by Name through the API and verify the seed data for" +
            " Margaret \'Maggie\' Rogers is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by Name through the API and verify the seed data for" +
            " Margaret \'Maggie\' Rogers is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByNameThroughTheAPIAndVerifyTheSeedDataForMargaretMaggieRogersIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by Name through the API and verify the seed data for" +
                    " Margaret \'Maggie\' Rogers is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 52
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 53
 testRunner.Given("I get a relationship through the API with the name Margaret \'Maggie\' Rogers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                            "Margaret \'Maggie\' Rogers",
                            "Younger Sister",
                            "\"{\"TV\":[{\"SHOW\":\"The New Scooby and Scrappy Doo Show\",\"SEASON\":1,\"EPISODE\":13,\"RE" +
                                "LEASE_YEAR\":1983}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Shaggy"});
#line 54
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table31, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by ID through the API and verify the seed data for D" +
            "ave Walton is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by ID through the API and verify the seed data for D" +
            "ave Walton is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByIDThroughTheAPIAndVerifyTheSeedDataForDaveWaltonIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by ID through the API and verify the seed data for D" +
                    "ave Walton is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 58
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 59
 testRunner.Given("I get a relationship through the API with the id 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Apperance",
                            "Gang"});
                table32.AddRow(new string[] {
                            "Dave Walton",
                            "Uncle",
                            "{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":3,\"EPISODE\":1,\"RELEASE_YEAR\"" +
                                ":1978}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Velma"});
#line 60
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table32, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by ID through the API and verify the seed data for S" +
            "crappy-Doo is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by ID through the API and verify the seed data for S" +
            "crappy-Doo is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByIDThroughTheAPIAndVerifyTheSeedDataForScrappy_DooIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by ID through the API and verify the seed data for S" +
                    "crappy-Doo is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 65
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 66
 testRunner.Given("I get a relationship through the API with the id 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Apperance",
                            "Gang"});
                table33.AddRow(new string[] {
                            "Scrappy-Doo",
                            "Nephew",
                            "\"{\"TV\":[{}],\"Movie\":[{\"NAME\":\"Scooby-Doo\", \"RELEASE_YEAR\":2002}],\"APPEARED\":true}" +
                                "\"",
                            "Scooby"});
#line 67
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table33, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by ID through the API and verify the seed data for J" +
            "ohn Maxwell is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by ID through the API and verify the seed data for J" +
            "ohn Maxwell is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByIDThroughTheAPIAndVerifyTheSeedDataForJohnMaxwellIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by ID through the API and verify the seed data for J" +
                    "ohn Maxwell is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 72
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 73
 testRunner.Given("I get a relationship through the API with the id 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                            "John Maxwell",
                            "Uncle",
                            "\"{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":1,\"EPISODE\":7,\"RELEASE_YEAR" +
                                "\":1969}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Daphne"});
#line 74
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table34, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by ID through the API and verify the seed data for O" +
            "livia Dervy is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by ID through the API and verify the seed data for O" +
            "livia Dervy is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByIDThroughTheAPIAndVerifyTheSeedDataForOliviaDervyIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by ID through the API and verify the seed data for O" +
                    "livia Dervy is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 78
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 79
 testRunner.Given("I get a relationship through the API with the id 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                            "Olivia Dervy",
                            "Aunt",
                            "\"{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":3,\"EPISODE\":9,\"RELEASE_YEAR" +
                                "\":1978}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Daphne"});
#line 80
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table35, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by ID through the API and verify the seed data for S" +
            "kip Jones is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by ID through the API and verify the seed data for S" +
            "kip Jones is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByIDThroughTheAPIAndVerifyTheSeedDataForSkipJonesIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by ID through the API and verify the seed data for S" +
                    "kip Jones is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 84
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 85
 testRunner.Given("I get a relationship through the API with the id 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                            "Skip Jones",
                            "Uncle",
                            "\"{\"TV\":[{}],\"Movie\":[{\"NAME\":\"Scoob-Doo! Pirates Ahoy!\", \"RELEASE_YEAR\":2006}],\"A" +
                                "PPEARED\":true}\"",
                            "Fred"});
#line 86
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table36, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Gets a specific relationship by ID through the API and verify the seed data for M" +
            "argaret \'Maggie\' Rogers is accurate")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRelationshipAPI")]
        [Xunit.TraitAttribute("Description", "Gets a specific relationship by ID through the API and verify the seed data for M" +
            "argaret \'Maggie\' Rogers is accurate")]
        [Xunit.TraitAttribute("Category", "API")]
        public void GetsASpecificRelationshipByIDThroughTheAPIAndVerifyTheSeedDataForMargaretMaggieRogersIsAccurate()
        {
            string[] tagsOfScenario = new string[] {
                    "API"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Gets a specific relationship by ID through the API and verify the seed data for M" +
                    "argaret \'Maggie\' Rogers is accurate", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 90
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 91
 testRunner.Given("I get a relationship through the API with the id 6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                            "Margaret \'Maggie\' Rogers",
                            "Younger Sister",
                            "\"{\"TV\":[{\"SHOW\":\"The New Scooby and Scrappy Doo Show\",\"SEASON\":1,\"EPISODE\":13,\"RE" +
                                "LEASE_YEAR\":1983}],\"Movie\":[{}],\"APPEARED\":true}\"",
                            "Shaggy"});
#line 92
 testRunner.Then("I can verify the data exists for the following data", ((string)(null)), table37, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GetRelationshipAPIFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GetRelationshipAPIFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
