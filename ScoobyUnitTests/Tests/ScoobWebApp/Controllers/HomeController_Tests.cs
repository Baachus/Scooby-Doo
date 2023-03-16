using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace ScoobWebApp.Controllers;

public class HomeController_Tests
{
    private readonly Mock<ILogger<HomeController>> _loggerMock;

    public HomeController_Tests()
    {
        _loggerMock = new Mock<ILogger<HomeController>>();
    }

    [Fact]
    [Category("Unit_Positive")]
    public void Index_ReturnsViewResult()
    {
        // Arrange
        var controller = new HomeController(_loggerMock.Object);

        // Act
        var result = controller.Index();

        // Assert
        result.Should().BeOfType(typeof(ViewResult));
    }

    [Fact]
    [Category("Unit_Positive")]
    public void Privacy_ReturnsViewResult()
    {
        // Arrange
        var controller = new HomeController(_loggerMock.Object);

        // Act
        var result = controller.Privacy();

        // Assert
        result.Should().BeOfType(typeof(ViewResult));
    }

    //TODO: tests for relationship and error
}
