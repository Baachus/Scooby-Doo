using ScoobyRelationship.Data;

namespace ScoobyRelationship.Repository;

public interface IRelationshipRepository
{
    List<ScoobRelation> GetAllRelationships();
    ScoobRelation GetRelationshipById(int id);
    ScoobRelation GetRelationshipByName(string name);
    ScoobRelation AddRelationship(ScoobRelation relationship);
    void DeleteRelationship(int id);
    void DeleteRelationship(string name);
    ScoobRelation UpdateRelationship(ScoobRelation relationship);
}

public class RelationshipRepository : IRelationshipRepository
{
    private readonly ScoobRelationDbContext _context;

    public RelationshipRepository(ScoobRelationDbContext context)
    {
        _context = context;
    }

    public List<ScoobRelation> GetAllRelationships()
    {
        return _context.ScoobRelations.ToList();
    }

    public ScoobRelation GetRelationshipById(int id)
    {
        return _context.ScoobRelations.FirstOrDefault(x => x.Id == id);
    }

    public ScoobRelation GetRelationshipByName(string name)
    {
        return _context.ScoobRelations.FirstOrDefault(x => x.Name == name);
    }

    public ScoobRelation AddRelationship(ScoobRelation relationship)
    {
        _context.ScoobRelations.Add(relationship);
        _context.SaveChanges();
        return relationship;
    }

    public ScoobRelation UpdateRelationship(ScoobRelation relationship)
    {
        _context.ScoobRelations.Update(relationship);
        _context.SaveChanges();
        return relationship;
    }

    public void DeleteRelationship(int id)
    {
        var relationship = GetRelationshipById(id);
        _context.ScoobRelations.Remove(relationship);
        _context.SaveChanges();
    }

    public void DeleteRelationship(string name)
    {
        var relationship = GetRelationshipByName(name);
        _context.ScoobRelations.Remove(relationship);
        _context.SaveChanges();
    }
}
