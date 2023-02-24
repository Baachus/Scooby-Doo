namespace ScoobWebApp.Producer
{
    public interface IRelationshipUtil
    {
        Task<ScoobRelation> CreateRelationship(ScoobRelation relation);
        Task DeleteRelationship(int id);
        Task<ScoobRelation> EditRelationship(ScoobRelation relation);
        Task<ICollection<ScoobRelation>> GetRelationship();
        Task<ScoobRelation> GetRelationshipById(int id);
    }
}