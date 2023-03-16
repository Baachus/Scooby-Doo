using ScoobyRelationship.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ScoobyRelationshipAPI.Data;

public class ScoobRelationTests_Tests
{
    [Fact]
    [Category("Unit_Positive")]
    public void Name_ShouldHaveStringLengthAttribute()
    {
        //Arrange
        var propertyInfo = typeof(ScoobRelation).GetProperty(nameof(ScoobRelation.Name));

        //Act
        var attribute = propertyInfo.GetCustomAttribute<StringLengthAttribute>();

        //Assert
        attribute.Should().NotBeNull();
        attribute.MaximumLength.Should().Be(60);
    }

    [Fact]
    [Category("Unit_Positive")]
    public void Relationship_ShouldHaveStringLengthAttribute()
    {
        // Arrange
        var propertyInfo = typeof(ScoobRelation).GetProperty(nameof(ScoobRelation.Relationship));

        // Act
        var attribute = propertyInfo.GetCustomAttribute<StringLengthAttribute>();

        // Assert
        attribute.Should().NotBeNull();
        attribute.MaximumLength.Should().Be(100);
    }

    [Theory]
    [InlineData(GangMember.Scooby)]
    [InlineData(GangMember.Shaggy)]
    [InlineData(GangMember.Fred)]
    [InlineData(GangMember.Daphne)]
    [InlineData(GangMember.Velma)]
    [Category("Unit_Positive")]
    public void Gang_ShouldBeEnumType(GangMember gang)
    {
        // Arrange
        var scoobRelation = new ScoobRelation();

        // Act
        scoobRelation.Gang = gang;

        // Assert
        scoobRelation.Gang.Should().Be(gang);
    }
}