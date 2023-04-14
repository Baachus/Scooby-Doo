﻿using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using ScoobTestPlaywright.Extensions;
using ScoobTestPlaywright.Model;
using ScoobTestPlaywright.Pages;
using System.Diagnostics;

namespace ScoobTestPlaywright.Tests;

public class Details_Tests : PageTest
{
    private SharedPage sharedPage;
    private RelationshipListPage listPage;
    private CreateAndEditPage createPage;
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
    public async Task VerifyDetailsOnNewlyCreatedRelationship()
    {
        Faker fake = new Faker("en");
        var newName = fake.Name.FullName();
        var newGang = fake.Random.Enum<GangMember>().ToString();
        var newRelationship = "Cousin";
        var newAppearance = new RandomAppearance().GetRandomAppearance();
        await listPage.ClickCreateNewRelationship();

        createPage = new CreateAndEditPage(Page);

        await createPage.SetName(newName);
        await createPage.SetGang(newGang);
        await createPage.SetRelationship(newRelationship);
        await createPage.SetApperance(newAppearance);

        await createPage.ClickCreate();

        try
        {
            listPage.ClickLinkForNameAsync(newName, "Details");
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
    public async Task EditDetailsFromDetailPage()
    {
        Faker fake = new Faker("en");
        var newName = fake.Name.FullName();
        var newGang = fake.Random.Enum<GangMember>().ToString();
        var newRelationship = "Cousin";
        var newAppearance = new RandomAppearance().GetRandomAppearance();
        await listPage.ClickCreateNewRelationship();

        createPage = new CreateAndEditPage(Page);

        await createPage.SetName(newName);
        await createPage.SetGang(newGang);
        await createPage.SetRelationship(newRelationship);
        await createPage.SetApperance(newAppearance);

        await createPage.ClickCreate();

        try
        {
            await listPage.ClickLinkForNameAsync(newName, "Details");
            detailPage = new DetailAndDeletePage(Page);
            await detailPage.ClickEdit();

            createPage = new CreateAndEditPage(Page);

            createPage.GetName().InputValueAsync().Result.Should().Be(newName);
            createPage.GetRelationship().InputValueAsync().Result.Should().Be(newRelationship);

            GangMember gangG = (GangMember)Enum.Parse(typeof(GangMember), createPage.GetGang().InputValueAsync().Result, true);
            gangG.ToString().Should().Be(newGang);
            
            createPage.GetApperance().InputValueAsync().Result.Should().NotBeNullOrEmpty();
        }
        finally
        {
            await new API().DeletRelationship(Request, newName);
        }
    }

    [Test]
    public async Task BackToListFromDetailPage()
    {
        Faker fake = new Faker("en");
        var newName = fake.Name.FullName();
        var newGang = fake.Random.Enum<GangMember>().ToString();
        var newRelationship = "Cousin";
        var newAppearance = new RandomAppearance().GetRandomAppearance();
        await listPage.ClickCreateNewRelationship();

        createPage = new CreateAndEditPage(Page);

        await createPage.SetName(newName);
        await createPage.SetGang(newGang);
        await createPage.SetRelationship(newRelationship);
        await createPage.SetApperance(newAppearance);

        await createPage.ClickCreate();

        try
        {
            listPage.ClickLinkForNameAsync(newName, "Details");
            detailPage = new DetailAndDeletePage(Page);
            await detailPage.ClickBackToList();

            Expect(Page).ToHaveURLAsync("*/Relationship/List");
        }
        finally
        {
            await new API().DeletRelationship(Request, newName);
        }
    }
}
