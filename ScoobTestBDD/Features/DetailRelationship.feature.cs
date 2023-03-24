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
    public partial class DetailRelationshipFeature : object, Xunit.IClassFixture<DetailRelationshipFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "DetailRelationship.feature"
#line hidden
        
        public DetailRelationshipFeature(DetailRelationshipFeature.FixtureData fixtureData, ScoobTestBDD_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "DetailRelationship", "This feature tests the Detail page for viewing a Relationship \r\nand subsequent op" +
                    "tions around that page.", ProgrammingLanguage.CSharp, featureTags);
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Relationship",
                        "Appearance",
                        "Gang"});
            table12.AddRow(new string[] {
                        "Detail",
                        "Child",
                        "{\"Test\":\"Detail\"}",
                        "Shaggy"});
            table12.AddRow(new string[] {
                        "Detail_Edit",
                        "Child",
                        "{\"Test\":\"Detail_Edit\"}",
                        "Shaggy"});
            table12.AddRow(new string[] {
                        "Detail_Edited",
                        "Grandmother",
                        "{\"Test\":\"Detail_Edited\"}",
                        "Velma"});
#line 7
 testRunner.Given("I cleanup the following data", ((string)(null)), table12, "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create a relationship, verify the details on the details page, and remove the new" +
            " relationship")]
        [Xunit.TraitAttribute("FeatureTitle", "DetailRelationship")]
        [Xunit.TraitAttribute("Description", "Create a relationship, verify the details on the details page, and remove the new" +
            " relationship")]
        [Xunit.TraitAttribute("Category", "Smoke_Test")]
        public void CreateARelationshipVerifyTheDetailsOnTheDetailsPageAndRemoveTheNewRelationship()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke_Test"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a relationship, verify the details on the details page, and remove the new" +
                    " relationship", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
#line 15
 testRunner.Given("I click the Relationship menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
 testRunner.When("I click the \"Create New\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Appearance",
                            "Gang"});
                table13.AddRow(new string[] {
                            "Detail",
                            "Child",
                            "{\"Test\":\"Detail\"}",
                            "Shaggy"});
#line 17
 testRunner.And("I create a relationship with the following details", ((string)(null)), table13, "And ");
#line hidden
#line 20
 testRunner.And("I click the Details link of the newly created relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
 testRunner.Then("I see all the relationship details are created as expected on the details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
 testRunner.And("I delete the Detail relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create a relationship, verify the details on the details page, edit from the deta" +
            "ils page and remove the new relationship")]
        [Xunit.TraitAttribute("FeatureTitle", "DetailRelationship")]
        [Xunit.TraitAttribute("Description", "Create a relationship, verify the details on the details page, edit from the deta" +
            "ils page and remove the new relationship")]
        public void CreateARelationshipVerifyTheDetailsOnTheDetailsPageEditFromTheDetailsPageAndRemoveTheNewRelationship()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a relationship, verify the details on the details page, edit from the deta" +
                    "ils page and remove the new relationship", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
this.FeatureBackground();
#line hidden
#line 25
 testRunner.Given("I click the Relationship menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 26
 testRunner.When("I click the \"Create New\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Appearance",
                            "Gang"});
                table14.AddRow(new string[] {
                            "Detail_Edit",
                            "Child",
                            "{\"Test\":\"Detail_Edit\"}",
                            "Shaggy"});
#line 27
 testRunner.And("I create a relationship with the following details", ((string)(null)), table14, "And ");
#line hidden
#line 30
 testRunner.And("I click the Details link of the newly created relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 31
 testRunner.And("I click the Edit link on the detail page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Appearance",
                            "Gang"});
                table15.AddRow(new string[] {
                            "Detail_Edited",
                            "Grandmother",
                            "{\"Test\":\"Detail_Edited\"}",
                            "Velma"});
#line 32
 testRunner.And("I edit the relationship with the following details", ((string)(null)), table15, "And ");
#line hidden
#line 35
 testRunner.And("I click the Details link of the newly created relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.Then("I see all the relationship details are created as expected on the details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.And("I delete the Detail_Edit relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.And("I delete the Detail_Edited relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                DetailRelationshipFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                DetailRelationshipFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
