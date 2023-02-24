using Microsoft.Extensions.DependencyInjection;
using ScoobTestFramework.Driver;
using ScoobTestFramework.Extensions;

namespace ScoobTestFramework
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.UseWebDriverInitalizer();
            services.AddScoped<IDriverFixture, DriverFixture>();
            services.AddScoped<IBrowserDriver, BrowserDriver>();
        }

    }
}
