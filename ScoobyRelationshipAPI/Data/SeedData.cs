using ScoobyRelationship.Data;

namespace ScoobyRelationshipAPI.Data
{
    public static class SeedData
    {
        public static void Seed(this ScoobRelationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();

            if (!context.ScoobRelations.Any())
            {
                var relationships = new List<ScoobRelation>()
                {
                    new ScoobRelation()
                    {
                        Name = "Dave Walton",
                        Appearance = "{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":3,\"EPISODE\":1,\"RELEASE_YEAR\":1978}],\"Movie\":[{}],\"APPEARED\":true}",
                        Gang = GangMember.Velma,
                        Relationship = "Uncle"
                    },
                    new ScoobRelation()
                    {
                        Name = "Scrappy-Doo",
                        Appearance = "{\"TV\":[{}],\"Movie\":[{\"NAME\":\"Scooby-Doo\", \"RELEASE_YEAR\":2002}],\"APPEARED\":true}",
                        Gang = GangMember.Scooby,
                        Relationship = "Uncle"
                    },
                    new ScoobRelation()
                    {
                        Name = "John Maxwell",
                        Appearance = "{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":1,\"EPISODE\":7,\"RELEASE_YEAR\":1969}],\"Movie\":[{}],\"APPEARED\":true}",
                        Gang = GangMember.Daphne,
                        Relationship = "Uncle"
                    },
                    new ScoobRelation()
                    {
                        Name = "Olivia Dervy",
                        Appearance = "{\"TV\":[{\"SHOW\":\"Scooby-Doo, Where Are You!\",\"SEASON\":3,\"EPISODE\":9,\"RELEASE_YEAR\":1978}],\"Movie\":[{}],\"APPEARED\":true}",
                        Gang = GangMember.Daphne,
                        Relationship = "Aunt"
                    },
                };

                context.ScoobRelations.AddRange(relationships);
                context.SaveChanges();
            }
        }
    }
}
