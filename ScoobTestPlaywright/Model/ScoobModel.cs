using ScoobTestPlaywright.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ScoobTestPlaywright.Model;

public class GangMemberConverter : JsonConverter<GangMember>
{
    public override GangMember Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && Enum.TryParse(reader.GetString(), out GangMember gangMember))
        {
            return gangMember;
        }

        throw new JsonException($"Unable to convert '{reader.GetString()}' to GangMember enum.");
    }

    public override void Write(Utf8JsonWriter writer, GangMember value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

public class ScoobModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("relationship")]
    public string Relationship { get; set; }

    [JsonPropertyName("gang")]
    public string Gang { get; set; }

    [JsonPropertyName("appearance")]
    public string Appearance { get; set; }

}
