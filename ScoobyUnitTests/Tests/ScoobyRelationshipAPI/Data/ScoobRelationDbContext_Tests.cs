using Microsoft.EntityFrameworkCore;
using ScoobyRelationship.Data;
using System.ComponentModel;

namespace ScoobyRelationshipAPI.Data;

public class ScoobRelationDbContext_Tests
{
    [Fact]
    [Category("Unit_Positive")]
    public void TestDbContextConstructor()
    {
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
                      .UseInMemoryDatabase(databaseName: "TestDatabase")
                      .Options;
        var dbContext = new ScoobRelationDbContext(options);
        dbContext.Should().NotBeNull();
    }

    [Fact]
    [Category("Unit_Positive")]
    public void TestScoobRelationsEntity()
    {
        //TODO: Include tests to verify entity type values
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
                      .UseInMemoryDatabase(databaseName: "TestDatabase")
                      .Options;
        var dbContext = new ScoobRelationDbContext(options);
        dbContext.Model.GetEntityTypes().ToList().Should().HaveCount(1);
    }

    [Fact]
    [Category("Unit_Positive")]
    public async Task TestAddScoobRelation()
    {
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
                      .UseInMemoryDatabase(databaseName: "TestDatabase")
                      .Options;
        var dbContext = new ScoobRelationDbContext(options);
        var scoobRelation = new ScoobRelation { Name = "Shagster", Gang = GangMember.Shaggy, Relationship = "Second Uncle" };
        dbContext.ScoobRelations.Add(scoobRelation);
        await dbContext.SaveChangesAsync();
        dbContext.ScoobRelations.CountAsync().Status.Should().Be(TaskStatus.RanToCompletion);
    }
}
