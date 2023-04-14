﻿using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Model;
using ScoobTestPlaywright.Pages;

namespace ScoobTestPlaywright.Tests;

public class Edit_Tests : PageTest
{
    private SharedPage sharedPage;
    private RelationshipListPage listPage;
    private CreateAndEditPage editPage;
    private DetailAndDeletePage detailPage;
    private IAPIRequestContext? Request = null;
    private const string baseUrl = "http://localhost:5003";

    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://localhost:5002/");

        //Expect a title to contain a substring of Home Page
        await Expect(Page).ToHaveTitleAsync(new Regex("Home Page"));

        sharedPage = new SharedPage(Page);
        await sharedPage.ClickRelationshipLink();

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

            await Expect(editPage.GetName()).ToHaveTextAsync(newName);
            await Expect(editPage.GetRelationship()).ToHaveTextAsync(newRelationship);
            await Expect(editPage.GetGang()).ToHaveTextAsync(newGang);
            await Expect(editPage.GetApperance()).ToHaveTextAsync(newAppearance);
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

            await Screenshots.TakeScreenshot(Page);

            await editPage.ClickBackToList();

            await listPage.ClickLinkForNameAsync(newName, "Details");
            detailPage = new DetailAndDeletePage(Page);
            ScoobModel details = detailPage.GetDetails();
            await Screenshots.TakeScreenshot(Page);

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

            await Screenshots.TakeScreenshot(Page);

            await editPage.ClickSave();

            await listPage.ClickLinkForNameAsync(updatedName, "Details");
            detailPage = new DetailAndDeletePage(Page);
            ScoobModel details = detailPage.GetDetails();
            await Screenshots.TakeScreenshot(Page);

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
}
