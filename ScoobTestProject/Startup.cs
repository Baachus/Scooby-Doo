using Microsoft.Extensions.DependencyInjection;
using ScoobTestFramework.Driver;
using ScoobTestFramework.Extensions;
using ScoobTestProject.Pages;

namespace ScoobTestProjectl;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {

        services.UseWebDriverInitalizer();

        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();

        //Pages
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<IRelationshipPage, RelationshipPage>();
    }

}
