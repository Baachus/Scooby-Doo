using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ScoobTestPlaywright.Extensions;

public class TestSettings
{
    public Uri ApplicationUrl { get; set; }
    public Uri APIUrl { get; set; }
    public bool Mobile { get; set; }

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
