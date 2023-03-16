using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ScoobyRelationship.Data;
using ScoobyRelationshipAPI.Data;

namespace ScoobyRelationshipAPI.Extensions;

public class DbInitalizerExtension_Tests
{
    [Fact]
    public void UseItToSeedSqlServer_NullApp_ThrowsException()
    {
        // Arrange
        IApplicationBuilder app = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => app.UseItToSeedSqlServer());
    }

    //TODO: Expand on the testing
    //[Fact]
    //public void UseItToSeedSqlServer_CallsSeedData()
    //{
    //    // Arrange
    //    var app = new Mock<IApplicationBuilder>();
    //    var scope = new Mock<IServiceScope>();
    //    var serviceScopeFactory = new Mock<IServiceScopeFactory>();
    //    var services = new Mock<IServiceProvider>();
    //    var context = new Mock<ScoobRelationDbContext>();

    //    app.Setup(x => x.ApplicationServices).Returns(serviceScopeFactory.Object);
    //    serviceScopeFactory.Setup(x => x.CreateScope()).Returns(scope.Object);
    //    scope.Setup(x => x.ServiceProvider).Returns(services.Object);
    //    services.Setup(x => x.GetRequiredService<ScoobRelationDbContext>()).Returns(context.Object);

    //    // Act
    //    app.Object.UseItToSeedSqlServer();

    //    // Assert
    //    context.Verify(x => x.Database.EnsureCreated(), Times.Once);
    //    SeedData.Verify(x => x.Seed(context.Object), Times.Once);
    //}

    //[Fact]
    //public void UseItToSeedSqlServer_ThrowsException_CallsExceptionHandler()
    //{
    //    // Arrange
    //    var app = new Mock<IApplicationBuilder>();
    //    var scope = new Mock<IServiceScope>();
    //    var serviceScopeFactory = new Mock<IServiceScopeFactory>();
    //    var services = new Mock<IServiceProvider>();
    //    var context = new Mock<ScoobRelationDbContext>();
    //    var exceptionHandler = new Mock<IExceptionHandler>();

    //    app.Setup(x => x.ApplicationServices).Returns(serviceScopeFactory.Object);
    //    serviceScopeFactory.Setup(x => x.CreateScope()).Returns(scope.Object);
    //    scope.Setup(x => x.ServiceProvider).Returns(services.Object);
    //    services.Setup(x => x.GetRequiredService<ScoobRelationDbContext>()).Throws<Exception>();
    //    exceptionHandler.Setup(x => x.HandleException(It.IsAny<Exception>()));

    //    // Act
    //    app.Object.UseItToSeedSqlServer(exceptionHandler.Object);

    //    // Assert
    //    exceptionHandler.Verify(x => x.HandleException(It.IsAny<Exception>()), Times.Once);
    //}
}
