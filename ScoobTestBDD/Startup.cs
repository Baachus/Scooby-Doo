using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScoobyRelationship.Repository;
using SolidToken.SpecFlow.DependencyInjection;

namespace ScoobTestBDD;

public class Startup
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        string projectPath = AppDomain.CurrentDomain.BaseDirectory
                               .Split(new string[] { @"bin\" }, StringSplitOptions.None)[0];

        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(projectPath)
            .AddJsonFile($"appsettings.{environmentName}.json")
            .Build();

        string connectionString = configuration.GetConnectionString("SandboxConnection");
        services.AddDbContext<ScoobRelationDbContext>(options => options.UseSqlServer(connectionString));
        services.AddTransient<IRelationshipRepository, RelationshipRepository>();

        services.UseWebDriverInitalizer();

        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();

        //Pages
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<IRelationshipPage, RelationshipPage>();
        services.AddScoped<IDetailPage, DetailPage>();
        services.AddScoped<IDeletePage, DeletePage>();
        services.AddScoped<IEditPage, EditPage>();
        services.AddScoped<ICreatePage, CreatePage>();
        return services;
    }
}
