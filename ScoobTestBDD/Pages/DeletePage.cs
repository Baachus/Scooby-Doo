﻿namespace ScoobTestBDD.Pages;

public interface IDeletePage
{
    void ClickBackToList();
    void ClickDelete();
    ScoobRelation GetRelationshipDetails();
}

public class DeletePage : IDeletePage
{
    private readonly IWebDriver driver;

    public DeletePage(IDriverFixture driver) => this.driver = driver.Driver;

    //Web Elements on Delete page
    IWebElement txtName => driver.FindElement(By.Id("Name"));
    IWebElement ddlGang => driver.FindElement(By.Id("Gang"));
    IWebElement txtRelationship => driver.FindElement(By.Id("Relationship"));
    IWebElement txtAppearance => driver.FindElement(By.Id("Appearance"));
    IWebElement lnkBackToList => driver.FindElement(By.Id("Return_List"));
    IWebElement btnDelete => driver.FindElement(By.Id("Delete"));


    /// <summary>
    /// This method retrieves all the relationship details on the page, 
    /// it then returns this information in a ScoobRelation object.
    /// </summary>
    /// <returns>ScoobRelation is returned with all details for
    /// Name, Appearance, Relationship, and Gang</returns>
    public ScoobRelation GetRelationshipDetails()
    {
        return new ScoobRelation()
        {
            Name = txtName.Text,
            Appearance = txtAppearance.Text,
            Relationship = txtRelationship.Text,
            Gang = (GangMember)Enum.Parse(
                typeof(GangMember),
                ddlGang.GetAttribute("innerText").ToString())
        };
    }

    /// <summary>
    /// This method clicks the link to return home page and keeps
    /// the seperation of duties from the test files.
    /// </summary>
    public void ClickBackToList() => lnkBackToList.Click();


    /// <summary>
    /// 
    /// </summary>
    public void ClickDelete() => btnDelete.Click();
}