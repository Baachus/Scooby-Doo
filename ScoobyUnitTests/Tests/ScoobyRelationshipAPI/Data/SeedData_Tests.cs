using Microsoft.EntityFrameworkCore;
using ScoobyRelationship.Data;
using System.ComponentModel;

namespace ScoobyRelationshipAPI.Data;

public class SeedDataTests_Tests
{
    [Fact]
    [Category("Unit_Positive")]
    public void Seed_AddsDataToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
            .UseInMemoryDatabase(databaseName: "ScoobRelationTest")
            .Options;

        using (var context = new ScoobRelationDbContext(options))
        {
            // Act
            SeedData.Seed(context);

            // Assert
            context.ScoobRelations.Should().NotBeEmpty();
        }
    }

    [Fact]
    [Category("Unit_Positive")]
    public void Seed_AddsCorrectDataToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
            .UseInMemoryDatabase(databaseName: "ScoobRelationTest")
            .Options;

        List<string> names = new List<string>{"Dave Walton",
                                    "Scrappy-Doo",
                                    "John Maxwell",
                                    "Olivia Dervy",
                                    "Skip Jones",
                                    "Margaret 'Maggie' Rogers" };

        List<string> relationships = new List<string>{"Uncle",
                                            "Nephew",
                                            "Aunt",
                                            "Father",
                                            "Younger Sister"};

        List<GangMember> gangMembers = new List<GangMember> {GangMember.Scooby,
                                                            GangMember.Shaggy,
                                                            GangMember.Fred,
                                                            GangMember.Daphne,
                                                            GangMember.Velma};

        using (var context = new ScoobRelationDbContext(options))
        {
            // Act
            SeedData.Seed(context);

            // Assert
            context.ScoobRelations.Should().HaveCount(6);
            foreach (ScoobRelation relation in context.ScoobRelations.ToList())
            {
                relation.Name.Should().BeOneOf(names);
                relation.Relationship.Should().BeOneOf(relationships);
                relation.Gang.Should().BeOneOf(gangMembers);
                relation.Appearance.Should().NotBeNullOrEmpty();
            }
        }
    }
}