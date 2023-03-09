using ScoobTestFramework.Driver;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ScoobTestFramework.Settings;

public class TestSettings
{
    public BrowserType BrowserType { get; set; }
    public Uri ApplicationUrl { get; set; }
    public Uri APIUrl { get; set; }
    public int TimeoutInterval { get; set; }
    public Uri SeleniumGridUrl { get; set; }
    public ExecutionType ExecutionType { get; set; }

    public static TestSettings ReadConfig()
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
