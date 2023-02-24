namespace ScoobTestProject.Model;

/***
* Created: 1/10/2023
* Author: Robert Chapin
* This is a simple class to represent the relationships of Scooby-Doo.  It includes the Id, Name, Gang, Relationship, and Appearance.
***/
public class ScoobRelation
{
    public int Id { get; init; }
    public string? Name { get; set; }
    public GangMember Gang { get; set; }
    public string? Relationship { get; set; }
    public string? Appearance { get; set; }     //TODO: Modify to JSON Format
}

/***
* Created: 1/10/2023
* Author: Robert Chapin
* This is a simple enum to represent the gang members of Scooby-Doo.
***/
public enum GangMember
{
    Scooby,
    Shaggy,
    Fred,
    Daphne,
    Velma
}
