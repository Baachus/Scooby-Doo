using Newtonsoft.Json;
using RestSharp;
using ScoobTestFramework.Extensions;

namespace ScoobTestBDD.Extensions;

public class ScoobAPIExtension
{

    internal static ScoobRelation GetRelationFromResponseContent(string? content)
    {
        var relationship = JsonConvert.DeserializeObject<ScoobRelation>(content);

        var scoobRelation = new ScoobRelation()
        {
            Appearance = relationship.Appearance,
            Gang = relationship.Gang,
            Relationship = relationship.Relationship,
            Name = relationship.Name,
            Id = relationship.Id
        };

        return scoobRelation;
    }

    internal static int GetIdFromName(string name)
    {
        var apiExtension = new APIExtension();
        RestResponse idResponse = apiExtension.SendRequest($"/Relationship/GetScoobyRelationByName/{name}", Method.Get);
        return ScoobAPIExtension.GetRelationFromResponseContent(idResponse.Content).Id;
    }
}
