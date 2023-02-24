using Microsoft.Extensions.DependencyInjection;
using ScoobTestFramework.Settings;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ScoobTestFramework.Extensions;

public static class WebDriverInitalizerExtension
{
    public static IServiceCollection UseWebDriverInitalizer(
        this IServiceCollection services)
    {
        services.AddSingleton(ReadConfig());
        return services;
    }

    private static TestSettings ReadConfig()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var configFile = File
            .ReadAllText(Path
            .GetDirectoryName(Assembly
            .GetExecutingAssembly()
            .Location) + $"/appsettings.{environmentName}.json");

        var jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        var testSettings = JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerOptions);
        return testSettings;
    }
}
