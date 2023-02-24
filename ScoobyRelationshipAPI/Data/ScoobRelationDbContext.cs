using Microsoft.EntityFrameworkCore;

namespace ScoobyRelationship.Data
{
    public class ScoobRelationDbContext : DbContext
    {
        public ScoobRelationDbContext(DbContextOptions<ScoobRelationDbContext> options)
            : base(options) { }

        public DbSet<ScoobRelation> ScoobRelations { get; set; }
    }
}