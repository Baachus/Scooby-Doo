using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScoobyRelationship.Data;

namespace ScoobIntegrationTest.Library;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        var projectDir = Directory.GetCurrentDirectory();
        var configPath = Path.Combine(projectDir, "appsettings.json");
        IConfiguration configuration = null;

        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                typeof(DbContextOptions<ScoobRelationDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);
            services.AddDbContext<ScoobRelationDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryScoobyRelationshipAPI");
            });

            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<ScoobRelationDbContext>())
            {
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    //TODO: Log errors or do anything you think is needed
                    throw;
                }
            }
        });
    }
}
