using ScoobyRelationship.Controllers;
using ScoobyRelationship.Data;
using ScoobyRelationship.Repository;
using System.ComponentModel;

namespace ScoobyRelationshipAPI.Controllers;

public class RelationshipController_Tests
{
    [Fact]
    [Category("Unit_Positive")]
    public void GetScoobyRelations_ReturnsListOfRelations()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipRepository>();
        var relations = new List<ScoobRelation>()
        {
            new ScoobRelation() { Id = 1, Name = "George", Relationship = "Stepson", Gang = GangMember.Fred, Appearance = "first appearance" },
            new ScoobRelation() { Id = 2, Name = "Billy", Relationship = "Uncle", Gang = GangMember.Daphne, Appearance = "second appearance" }
        };
        mockRepo.Setup(repo => repo.GetAllRelationships()).Returns(relations);
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = controller.GetScoobyRelations();

        // Assert
        var actionResult = Assert.IsType<ActionResult<List<ScoobRelation>>>(result);
        var returnValue = Assert.IsType<List<ScoobRelation>>(actionResult.Value);
        returnValue.Count.Should().Be(2);
        relations[0].Id.Should().Be(returnValue[0].Id);
        relations[1].Id.Should().Be(returnValue[1].Id);
        relations[0].Name.Should().Be(returnValue[0].Name);
        relations[1].Name.Should().Be(returnValue[1].Name);
        relations[0].Relationship.Should().Be(returnValue[0].Relationship);
        relations[1].Relationship.Should().Be(returnValue[1].Relationship);
        relations[0].Gang.Should().Be(returnValue[0].Gang);
        relations[1].Gang.Should().Be(returnValue[1].Gang);
        relations[0].Appearance.Should().Be(returnValue[0].Appearance);
        relations[1].Appearance.Should().Be(returnValue[1].Appearance);
    }

    [Fact]
    [Category("Unit_Positive")]
    public void GetScoobyRelationById_ReturnsRelation()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipRepository>();
        var relation = new ScoobRelation() { Id = 1, Name = "George", Relationship = "Stepson", Gang = GangMember.Fred, Appearance = "first appearance" };
        mockRepo.Setup(repo => repo.GetRelationshipById(1)).Returns(relation);
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = controller.GetScoobyRelationById(1);

        // Assert
        var returnValue = Assert.IsType<ScoobRelation>(result);
        returnValue.Id.Should().Be(relation.Id);
        returnValue.Name.Should().Be(relation.Name);
        returnValue.Relationship.Should().Be(relation.Relationship);
        returnValue.Gang.Should().Be(relation.Gang);
        returnValue.Appearance.Should().Be(relation.Appearance);
    }

    [Fact]
    [Category("Unit_Negative")]
    public void GetScoobyRelationById_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipRepository>();
        mockRepo.Setup(repo => repo.GetRelationshipById(0))
                .Returns((ScoobRelation)null);
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = controller.GetScoobyRelationById(0);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    [Category("Unit_Positive")]
    public void GetScoobyRelationByName_ReturnsRelation()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipRepository>();
        var relation = new ScoobRelation() { Id = 1, Name = "George", Relationship = "Stepson", Gang = GangMember.Fred, Appearance = "first appearance" };
        mockRepo.Setup(repo => repo.GetRelationshipByName("George")).Returns(relation);
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = controller.GetScoobyRelationByName("George");

        // Assert
        var returnValue = Assert.IsType<ScoobRelation>(result);
        returnValue.Id.Should().Be(relation.Id);
        returnValue.Name.Should().Be(relation.Name);
        returnValue.Relationship.Should().Be(relation.Relationship);
        returnValue.Gang.Should().Be(relation.Gang);
        returnValue.Appearance.Should().Be(relation.Appearance);
    }

    [Fact]
    [Category("Unit_Negative")]
    public void GetScoobyRelationByName_InvalidName_ReturnsNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipRepository>();
        mockRepo.Setup(repo => repo.GetRelationshipByName(""))
                .Returns((ScoobRelation)null);
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = controller.GetScoobyRelationByName("");

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    [Category("Unit_Positive")]
    public void AddScoobyRelation_ReturnsAddedRelation()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipRepository>();
        var relation = new ScoobRelation() { Id = 1, Name = "George", Relationship = "Stepson", Gang = GangMember.Fred, Appearance = "first appearance" };
        mockRepo.Setup(repo => repo.AddRelationship(relation)).Returns(relation);
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = controller.AddScoobyRelation(relation);

        // Assert
        var returnValue = Assert.IsType<ScoobRelation>(result);
        returnValue.Id.Should().Be(relation.Id);
        returnValue.Name.Should().Be(relation.Name);
        returnValue.Relationship.Should().Be(relation.Relationship);
        returnValue.Gang.Should().Be(relation.Gang);
        returnValue.Appearance.Should().Be(relation.Appearance);
    }

    [Fact]
    [Category("Unit_Positive")]
    public void UpdateScoobyRelation_ShouldReturnUpdatedScoobyRelation()
    {
        // Arrange
        var fakeScoobRelation = new ScoobRelation { Id = 1, Name = "George", Relationship = "Uncle", Gang = GangMember.Shaggy, Appearance = "apperance" };
        var fakeRepository = new Mock<IRelationshipRepository>();
        fakeRepository.Setup(x => x.UpdateRelationship(It.IsAny<ScoobRelation>())).Returns(fakeScoobRelation);
        var controller = new RelationshipController(fakeRepository.Object);

        // Act
        var result = controller.UpdateScoobyRelation(fakeScoobRelation);

        // Assert
        fakeScoobRelation.Should().Be(result);
    }

    [Fact]
    [Category("Unit_Positive")]
    public void DeleteScoobyRelationById_ShouldCallDeleteRelationshipInRepository()
    {
        // Arrange
        var fakeRepository = new Mock<IRelationshipRepository>();
        var controller = new RelationshipController(fakeRepository.Object);

        // Act
        controller.DeleteScoobyRelationById(1);

        // Assert
        fakeRepository.Verify(x => x.DeleteScoobyRelationById(1), Times.Once);
    }

    [Fact]
    [Category("Unit_Positive")]
    public void DeleteScoobyRelationByName_ShouldCallDeleteRelationshipInRepository()
    {
        // Arrange
        var fakeRepository = new Mock<IRelationshipRepository>();
        string name = "Billy";
        var relations = new List<ScoobRelation>()
        {
            new ScoobRelation() { Id = 1, Name = name, Relationship = "Stepson", Gang = GangMember.Fred, Appearance = "first appearance" },
        };
        fakeRepository.Setup(repo => repo.GetAllRelationships()).Returns(relations);
        var controller = new RelationshipController(fakeRepository.Object);

        // Act
        controller.DeleteScoobyRelationByName(name);

        // Assert
        fakeRepository.Verify(x => x.DeleteRelationshipByName(name), Times.Once);
    }
}