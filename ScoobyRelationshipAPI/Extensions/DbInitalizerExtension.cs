using ScoobyRelationship.Data;
using ScoobyRelationshipAPI.Data;

namespace ScoobyRelationshipAPI.Extensions;

public static class DbInitalizerExtension
{
    public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ScoobRelationDbContext>();
            SeedData.Seed(context);
        }
        catch (Exception ex)
        {

        }

        return app;
    }
}
