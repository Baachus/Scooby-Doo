namespace ScoobWebApp.Producer;

public class RelationshipUtil : IRelationshipUtil
{
    private readonly ScoobyRelationshipAPI relationshipClient;

    public RelationshipUtil() => relationshipClient = new ScoobyRelationshipAPI("http://scoobyapi:8003", new HttpClient());

    public async Task<ScoobRelation> CreateRelationship(ScoobRelation relation)
    {
        return await relationshipClient.AddScoobyRelationAsync(relation);
    }

    public async Task<ICollection<ScoobRelation>> GetRelationship()
    {
        return await relationshipClient.GetScoobyRelationsAsync();
    }

    public async Task<ScoobRelation> GetRelationshipById(int id)
    {
        return await relationshipClient.GetScoobyRelationByIdAsync(id);
    }

    public async Task DeleteRelationship(int id)
    {
        await relationshipClient.DeleteScoobyRelationByIdAsync(id);
    }

    public async Task<ScoobRelation> EditRelationship(ScoobRelation relation)
    {
        return await relationshipClient.UpdateScoobyRelationAsync(relation);
    }
}
