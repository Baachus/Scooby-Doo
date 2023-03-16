using Microsoft.EntityFrameworkCore;
using ScoobyRelationship.Data;
using ScoobyRelationship.Repository;
using System.ComponentModel;

namespace ScoobyRelationshipAPI.Repository;

public class RelationshipRepository_Tests
{
    [Fact]
    [Category("Unit_Positive")]
    public void GetAllRelationships_ShouldReturnAllRelationships()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllRelationships_Test")
            .Options;

        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);
            repository.AddRelationship(new ScoobRelation { Name = "Test Relationship 1" });
            repository.AddRelationship(new ScoobRelation { Name = "Test Relationship 2" });
        }

        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);

            // Act
            var relationships = repository.GetAllRelationships();

            // Assert
            relationships.Count.Should().Be(2);
            relationships[0].Name.Should().Be("Test Relationship 1");
            relationships[1].Name.Should().Be("Test Relationship 2");
        }
    }

    [Fact]
    [Category("Unit_Positive")]
    public void GetRelationshipById_ShouldReturnRelationshipWithMatchingId()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetRelationshipById_Test")
            .Options;

        int id = 1;
        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);
            repository.AddRelationship(new ScoobRelation { Id = id, Name = "Test Relationship" });
        }

        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);

            // Act
            var relationship = repository.GetRelationshipById(id);

            // Assert
            relationship.Should().NotBeNull();
            relationship.Name.Should().Be("Test Relationship");
        }
    }

    [Fact]
    [Category("Unit_Negative")]
    public void GetRelationshipById_InvalidIdShouldReturnNull()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetRelationshipById_Test")
            .Options;

        int id = 2;
        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);
            repository.AddRelationship(new ScoobRelation { Id = id, Name = "Test Relationship - Negative" });
        }

        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);

            // Act
            var relationship = repository.GetRelationshipById(-1);

            // Assert
            relationship.Should().BeNull();
        }
    }

    [Fact]
    [Category("Unit_Positive")]
    public void GetRelationshipByName_ShouldReturnRelationshipWithMatchingName()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetRelationshipByName_Test")
            .Options;

        string name = "Test Relationship Name";
        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);
            repository.AddRelationship(new ScoobRelation { Name = name });
        }

        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);

            // Act
            var relationship = repository.GetRelationshipByName(name);

            // Assert
            relationship.Should().NotBeNull();
            relationship.Name.Should().Be(name);
        }
    }

    [Fact]
    [Category("Unit_Negative")]
    public void GetRelationshipByName_InvalidNameShouldReturnNull()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ScoobRelationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetRelationshipByName_Test")
            .Options;

        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);
            repository.AddRelationship(new ScoobRelation { Name = "Test Relationship Name - Negative" });
        }

        using (var context = new ScoobRelationDbContext(options))
        {
            var repository = new RelationshipRepository(context);

            // Act
            var relationship = repository.GetRelationshipByName("");

            // Assert
            relationship.Should().BeNull();
        }
    }
}
