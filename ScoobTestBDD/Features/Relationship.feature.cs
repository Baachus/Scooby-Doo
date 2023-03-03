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
    public partial class RelationshipFeature : object, Xunit.IClassFixture<RelationshipFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Relationship.feature"
#line hidden
        
        public RelationshipFeature(RelationshipFeature.FixtureData fixtureData, ScoobTestBDD_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Relationship", "This feature verifies the Relationship pages", ProgrammingLanguage.CSharp, featureTags);
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
#line 5
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Relationship",
                        "Appearance",
                        "Gang"});
            table4.AddRow(new string[] {
                        "AutomationGuy",
                        "Child",
                        "{\"Test\":\"test_data\"}",
                        "Shaggy"});
            table4.AddRow(new string[] {
                        "AutomationTest",
                        "Uncle",
                        "{\"Test\":\"test_data\"}",
                        "Fred"});
            table4.AddRow(new string[] {
                        "AutomationGuyBackToList",
                        "Child",
                        "{\"Test\":\"test_data\"}",
                        "Shaggy"});
#line 6
 testRunner.Given("I cleanup the following data", ((string)(null)), table4, "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Relationship")]
        [Xunit.TraitAttribute("Description", "Create a relationship, verify the details, and remove the new relationship")]
        [Xunit.TraitAttribute("Category", "Smoke_Test")]
        [Xunit.TraitAttribute("Category", "retry(1)")]
        [xRetry.RetryFact(1, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Create a relationship, verify the details, and remove the new relationship")]
        public void CreateARelationshipVerifyTheDetailsAndRemoveTheNewRelationship()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke_Test",
                    "retry(1)"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a relationship, verify the details, and remove the new relationship", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 14
 testRunner.Given("I click the Relationship menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
 testRunner.When("I click the \"Create New\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Appearance",
                            "Gang"});
                table5.AddRow(new string[] {
                            "AutomationGuy",
                            "Child",
                            "{\"Test\":\"test_data\"}",
                            "Shaggy"});
#line 16
 testRunner.And("I create a relationship with the following details", ((string)(null)), table5, "And ");
#line hidden
#line 19
 testRunner.And("I click the Details link of the newly created relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
 testRunner.Then("I see all the relationship details are created as expected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 21
 testRunner.And("I delete the AutomationGuy relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Relationship")]
        [Xunit.TraitAttribute("Description", "Edit the relationship, verify the details, and remove the new relationship")]
        [Xunit.TraitAttribute("Category", "Smoke_Test")]
        [Xunit.TraitAttribute("Category", "retry(1)")]
        [xRetry.RetryFact(1, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Edit the relationship, verify the details, and remove the new relationship")]
        public void EditTheRelationshipVerifyTheDetailsAndRemoveTheNewRelationship()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke_Test",
                    "retry(1)"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit the relationship, verify the details, and remove the new relationship", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Appearance",
                            "Gang"});
                table6.AddRow(new string[] {
                            "AutomationTest",
                            "Uncle",
                            "{\"Test\":\"test_data\"}",
                            "Fred"});
#line 25
 testRunner.Given("I ensure the following relationship is created", ((string)(null)), table6, "Given ");
#line hidden
#line 28
 testRunner.When("I click the Relationship menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 29
 testRunner.And("I click the Edit link of the newly created relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Appearance",
                            "Gang"});
                table7.AddRow(new string[] {
                            "AutomationTest",
                            "Child",
                            "{\"Test\":\"test_data\"}",
                            "Velma"});
#line 30
 testRunner.And("I edit the relationship with the following details", ((string)(null)), table7, "And ");
#line hidden
#line 33
 testRunner.And("I click the Details link of the newly created relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.Then("I see all the relationship details are created as expected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 35
 testRunner.And("I delete the AutomationTest relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Relationship")]
        [Xunit.TraitAttribute("Description", "Verify Back to List works on every modify page, i.e. Edit, Details, and Delete")]
        [Xunit.TraitAttribute("Category", "retry(1)")]
        [xRetry.RetryFact(1, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Verify Back to List works on every modify page, i.e. Edit, Details, and Delete")]
        public void VerifyBackToListWorksOnEveryModifyPageI_E_EditDetailsAndDelete()
        {
            string[] tagsOfScenario = new string[] {
                    "retry(1)"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Back to List works on every modify page, i.e. Edit, Details, and Delete", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 38
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 39
 testRunner.Given("I click the Relationship menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 40
 testRunner.When("I click the \"Create New\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Relationship",
                            "Appearance",
                            "Gang"});
                table8.AddRow(new string[] {
                            "AutomationGuyBackToList",
                            "Child",
                            "{\"Test\":\"test_data\"}",
                            "Shaggy"});
#line 41
 testRunner.And("I create a relationship with the following details", ((string)(null)), table8, "And ");
#line hidden
#line 44
 testRunner.And("I click the Details link of the newly created relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
 testRunner.And("I click the Back to List link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 46
 testRunner.Then("I verify I am on the Relationship page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 47
 testRunner.When("I click the Edit link of the newly created relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
 testRunner.And("I click the Back to List link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
 testRunner.Then("I verify I am on the Relationship page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.When("I click the Delete link of the newly created relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 51
 testRunner.And("I click the Back to List link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.Then("I verify I am on the Relationship page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 53
 testRunner.And("I delete the AutomationGuyBackToList relationship", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.When("I click the \"Create New\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 55
 testRunner.And("I click the Back to List link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.Then("I verify I am on the Relationship page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                RelationshipFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                RelationshipFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
