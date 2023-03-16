using ScoobyRelationship.Data;

namespace ScoobyRelationship.Repository;

public interface IRelationshipRepository
{
    List<ScoobRelation> GetAllRelationships();
    ScoobRelation GetRelationshipById(int id);
    ScoobRelation GetRelationshipByName(string name);
    ScoobRelation AddRelationship(ScoobRelation relationship);
    ScoobRelation UpdateRelationship(ScoobRelation relationship);
    void DeleteScoobyRelationById(int id);
    void DeleteRelationshipByName(string name);
}

public class RelationshipRepository : IRelationshipRepository
{
    private readonly ScoobRelationDbContext _context;

    public RelationshipRepository(ScoobRelationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all relationships in the database
    /// </summary>
    /// <returns>List of ScoobRelations for each record in the database</returns>
    public List<ScoobRelation> GetAllRelationships()
    {
        return _context.ScoobRelations.ToList();
    }

    /// <summary>
    /// Retrieves a ScoobRelation based upon the id supplied
    /// </summary>
    /// <param name="id">The identifying number to retrieve</param>
    /// <returns>ScoobRelation that correspondes to the id sent in</returns>
    public ScoobRelation GetRelationshipById(int id)
    {
        return _context.ScoobRelations.FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Retrieves a ScoobRelation based upon the name supplied, this name
    /// is the name of the record not the gang member.
    /// </summary>
    /// <param name="name">The name of the relationship to retrieve</param>
    /// <returns>ScoobRelation that correspondes to the name sent in</returns>
    public ScoobRelation GetRelationshipByName(string name)
    {
        return _context.ScoobRelations.FirstOrDefault(x => x.Name == name);
    }

    /// <summary>
    /// Adds a relationship to the database based upon the relationship sent in
    /// </summary>
    /// <param name="relationship">ScoobRelation that is to be added to the database</param>
    /// <returns>ScoobRelation that was added</returns>
    public ScoobRelation AddRelationship(ScoobRelation relationship)
    {
        _context.ScoobRelations.Add(relationship);
        _context.SaveChanges();
        return relationship;
    }

    /// <summary>
    /// Modifies the relationship to the sent in ScoobRelation
    /// </summary>
    /// <param name="relationship">ScoobRelation that is to be updated and the updated
    /// data that should be used for this relationship</param>
    /// <returns>ScoobRelation that was updated</returns>
    public ScoobRelation UpdateRelationship(ScoobRelation relationship)
    {
        _context.ScoobRelations.Update(relationship);
        _context.SaveChanges();
        return relationship;
    }

    /// <summary>
    /// Deletes the relationship based upon the id that was provided
    /// </summary>
    /// <param name="id">The identifying number that should be removed</param>
    public void DeleteScoobyRelationById(int id)
    {
        var relationship = GetRelationshipById(id);
        _context.ScoobRelations.Remove(relationship);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deletes the relationship based upon the name that was provided
    /// </summary>
    /// <param name="name">The identifying name that should be removed</param>
    public void DeleteRelationshipByName(string name)
    {
        var relationship = GetRelationshipByName(name);
        _context.ScoobRelations.Remove(relationship);
        _context.SaveChanges();
    }
}
