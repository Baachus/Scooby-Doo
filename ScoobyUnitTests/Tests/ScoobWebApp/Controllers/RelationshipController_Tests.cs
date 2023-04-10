using ScoobWebApp.Producer;
using System.ComponentModel;

namespace ScoobWebApp.Controllers;

public class RelationshipController_Tests
{
    [Fact]
    [Category("Unit_Positive")]
    public async Task List_ReturnsAViewResult_WithAListOfRelationships()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipUtil>();
        mockRepo.Setup(repo => repo.GetRelationship())
            .ReturnsAsync(GetTestRelationships());
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = await controller.List(1, "");

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        result.Should().BeOfType<ViewResult>();
        var model = Assert.IsAssignableFrom<IEnumerable<ScoobRelation>>(
            viewResult.ViewData.Model);
        model.Count().Should().Be(2);
    }

    [Fact]
    [Category("Unit_Positive")]
    public async Task List_ShouldReturnViewWithSortedRelationsByName()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipUtil>();
        var sortOrder = "Name";
        mockRepo.Setup(repo => repo.GetRelationship())
            .ReturnsAsync(GetTestRelationships());
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = await controller.List(1, "", sortOrder);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        viewResult.ViewData["IdSortParam"].Should().Be("Id");
        viewResult.ViewData["NameSortParam"].Should().Be("Name_desc");
        viewResult.ViewData["GangSortParam"].Should().Be("Gang");
        viewResult.ViewData["RelationshipSortParam"].Should().Be("Relationship");
    }

    [Fact]
    [Category("Unit_Positive")]
    public async Task List_ShouldReturnViewWithSortedRelationsById()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipUtil>();
        var sortOrder = "Id";
        mockRepo.Setup(repo => repo.GetRelationship())
            .ReturnsAsync(GetTestRelationships());
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = await controller.List(1, "", sortOrder);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        viewResult.ViewData["IdSortParam"].Should().Be("Id_desc");
        viewResult.ViewData["NameSortParam"].Should().Be("Name");
        viewResult.ViewData["GangSortParam"].Should().Be("Gang");
        viewResult.ViewData["RelationshipSortParam"].Should().Be("Relationship");
    }

    [Fact]
    [Category("Unit_Positive")]
    public async Task List_ShouldReturnViewWithSortedRelationsByGang()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipUtil>();
        var sortOrder = "Gang";
        mockRepo.Setup(repo => repo.GetRelationship())
            .ReturnsAsync(GetTestRelationships());
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = await controller.List(1, "", sortOrder);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        viewResult.ViewData["IdSortParam"].Should().Be("Id");
        viewResult.ViewData["NameSortParam"].Should().Be("Name");
        viewResult.ViewData["GangSortParam"].Should().Be("Gang_desc");
        viewResult.ViewData["RelationshipSortParam"].Should().Be("Relationship");
    }

    [Fact]
    [Category("Unit_Positive")]
    public async Task List_ShouldReturnViewWithSortedRelationsByRelationship()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipUtil>();
        var sortOrder = "Relationship";
        mockRepo.Setup(repo => repo.GetRelationship())
            .ReturnsAsync(GetTestRelationships());
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = await controller.List(1, "", sortOrder);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        viewResult.ViewData["IdSortParam"].Should().Be("Id");
        viewResult.ViewData["NameSortParam"].Should().Be("Name");
        viewResult.ViewData["GangSortParam"].Should().Be("Gang");
        viewResult.ViewData["RelationshipSortParam"].Should().Be("Relationship_desc");
    }

    [Fact]
    [Category("Unit_Positive")]
    public async Task Delete_ReturnsAViewResult_WithARelationship()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipUtil>();
        mockRepo.Setup(repo => repo.GetRelationshipById(1))
            .ReturnsAsync(GetTestRelationships()[0]);
        var controller = new RelationshipController(mockRepo.Object);

        // Act
        var result = await controller.Delete(1);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        result.Should().BeOfType<ViewResult>();
        var model = Assert.IsAssignableFrom<ScoobRelation>(
            viewResult.ViewData.Model);
        Assert.Equal("Alice", model.Name);
        model.Name.Should().Be("Alice");
    }

    [Fact]
    [Category("Unit_Positive")]
    public async Task Create_Post_ReturnsARedirectToActionResult_WhenModelStateIsValid()
    {
        // Arrange
        var mockRepo = new Mock<IRelationshipUtil>();
        var controller = new RelationshipController(mockRepo.Object);
        var newRelationship = new ScoobRelation()
        {
            Id = 3,
            Name = "Bob",
            Relationship = "Friend"
        };

        // Act
        var result = await controller.Create(newRelationship);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        redirectToActionResult.ControllerName.Should().BeNull();
        redirectToActionResult.ActionName.Should().Be("List");
    }

    private List<ScoobRelation> GetTestRelationships()
    {
        var relationships = new List<ScoobRelation>();
        relationships.Add(new ScoobRelation()
        {
            Id = 1,
            Name = "Alice",
            Relationship = "Mother"
        });
        relationships.Add(new ScoobRelation()
        {
            Id = 2,
            Name = "Bob",
            Relationship = "Father"
        });
        return relationships;
    }
}
