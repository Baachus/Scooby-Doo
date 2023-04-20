using Bogus;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Model;
using ScoobTestPlaywright.Pages;

namespace ScoobTestPlaywright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Edit_Tests : TestSetup
{
    private SharedPage sharedPage;
    private RelationshipListPage listPage;
    private CreateAndEditPage editPage;
    private DetailAndDeletePage detailPage;
    private IAPIRequestContext? Request = null;
    private const string baseUrl = "http://localhost:5003";
    private Task<string>? testName;

    [SetUp]
    public async Task Setup()
    {
        testName = SetupTestsAsync("Details Tests");

        listPage = new RelationshipListPage(Page);

        Request = await this.Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = baseUrl
        });
    }

    [Test]
    public async Task VerifyEditPageContainsCorrectData()
    {

        Faker fake = new Faker("en");
        var newName = fake.Name.FullName();
        var newGang = fake.Random.Enum<GangMember>().ToString();
        var newRelationship = "Cousin";
        var newAppearance = new RandomAppearance().GetRandomAppearance();
        await listPage.ClickCreateNewRelationship();

        editPage = new CreateAndEditPage(Page);

        await editPage.SetName(newName);
        await editPage.SetGang(newGang);
        await editPage.SetRelationship(newRelationship);
        await editPage.SetApperance(newAppearance);

        await editPage.ClickCreate();

        try
        {
            await listPage.ClickLinkForNameAsync(newName, "Edit");

            editPage = new CreateAndEditPage(Page);

            editPage.GetName().InputValueAsync().Result.Should().Be(newName);
            editPage.GetRelationship().InputValueAsync().Result.Should().Be(newRelationship);

            GangMember gangG = (GangMember)Enum.Parse(typeof(GangMember), editPage.GetGang().InputValueAsync().Result, true);
            gangG.ToString().Should().Be(newGang);

            editPage.GetApperance().InputValueAsync().Result.Should().NotBeNullOrEmpty();
        }
        finally
        {
            await new API().DeletRelationship(Request, newName);
        }
    }

    [Test]
    public async Task EditWithoutSavingDoesntChangeDetails()
    {

        Faker fake = new Faker("en");
        string newName = fake.Name.FullName();
        string newGang = fake.Random.Enum<GangMember>().ToString();
        string newRelationship = "Cousin";
        string newAppearance = new RandomAppearance().GetRandomAppearance();

        string updatedName = fake.Name.FullName();
        string updatedGang = fake.Random.Enum<GangMember>().ToString();
        string updatedRelationship = "Second Cousin";
        string updatedAppearance = new RandomAppearance().GetRandomAppearance();

        await listPage.ClickCreateNewRelationship();

        editPage = new CreateAndEditPage(Page);

        await editPage.SetName(newName);
        await editPage.SetGang(newGang);
        await editPage.SetRelationship(newRelationship);
        await editPage.SetApperance(newAppearance);

        await editPage.ClickCreate();

        try
        {
            await listPage.ClickLinkForNameAsync(newName, "Edit");

            editPage = new CreateAndEditPage(Page);

            await editPage.SetName(updatedName);
            await editPage.SetGang(updatedGang);
            await editPage.SetRelationship(updatedRelationship);
            await editPage.SetApperance(updatedAppearance);

            await editPage.ClickBackToList();

            await listPage.ClickLinkForNameAsync(newName, "Details");
            detailPage = new DetailAndDeletePage(Page);
            ScoobModel details = detailPage.GetDetails();

            details.Name.Should().Be(newName);
            details.Gang.Should().Be(newGang);
            details.Relationship.Should().Be(newRelationship);
            var jsonDetails = JsonConvert.SerializeObject(details.Appearance, Formatting.Indented);
            jsonDetails.Should().NotBeNullOrEmpty();
        }
        finally
        {
            await new API().DeletRelationship(Request, newName);
        }
    }
    [Test]
    public async Task EditWitSavingUpdatesDetails()
    {

        Faker fake = new Faker("en");
        string newName = fake.Name.FullName();
        string newGang = fake.Random.Enum<GangMember>().ToString();
        string newRelationship = "Cousin";
        string newAppearance = new RandomAppearance().GetRandomAppearance();

        string updatedName = fake.Name.FullName();
        string updatedGang = fake.Random.Enum<GangMember>().ToString();
        string updatedRelationship = "Second Cousin";
        string updatedAppearance = new RandomAppearance().GetRandomAppearance();

        await listPage.ClickCreateNewRelationship();

        editPage = new CreateAndEditPage(Page);

        await editPage.SetName(newName);
        await editPage.SetGang(newGang);
        await editPage.SetRelationship(newRelationship);
        await editPage.SetApperance(newAppearance);

        await editPage.ClickCreate();

        try
        {
            await listPage.ClickLinkForNameAsync(newName, "Edit");

            editPage = new CreateAndEditPage(Page);

            await editPage.SetName(updatedName);
            await editPage.SetGang(updatedGang);
            await editPage.SetRelationship(updatedRelationship);
            await editPage.SetApperance(updatedAppearance);

            await editPage.ClickSave();

            await listPage.ClickLinkForNameAsync(updatedName, "Details");
            detailPage = new DetailAndDeletePage(Page);
            ScoobModel details = detailPage.GetDetails();

            details.Name.Should().Be(updatedName);
            details.Gang.Should().Be(updatedGang);
            details.Relationship.Should().Be(updatedRelationship);
            var jsonDetails = JsonConvert.SerializeObject(details.Appearance, Formatting.Indented);
            jsonDetails.Should().NotBeNullOrEmpty();
        }
        finally
        {
            await new API().DeletRelationship(Request, updatedName);
        }
    }

    [TearDown]
    public async Task CloseTest()
    {
        string name = await testName;
        await Context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = $"../../../Traces/{name}.zip"
        });
    }
}
