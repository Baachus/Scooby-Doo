using ScoobWebApp.Models;
using System.ComponentModel;

namespace ScoobWebApp.Models;

public class ErrorViewModel_Tests
{
    [Fact]
    [Category("Unit_Positive")]
    public void ShowRequestId_ReturnsTrue_WhenRequestIdIsNotNullOrEmpty()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel { RequestId = "123" };

        // Act
        var result = errorViewModel.ShowRequestId;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    [Category("Unit_Negative")]
    public void ShowRequestId_ReturnsFalse_WhenRequestIdIsEmpty()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel { RequestId = "" };

        // Act
        var result = errorViewModel.ShowRequestId;

        // Assert
        result.Should().BeFalse();
    }
}
