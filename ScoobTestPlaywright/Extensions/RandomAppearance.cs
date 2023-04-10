using Bogus;
using Newtonsoft.Json;

namespace ScoobTestPlaywright.Extensions;

public class RandomAppearance
{
    public string GetRandomAppearance()
    {
        Faker fake = new Faker("en");

        var TV = new Faker<TV>()
            .RuleFor(p => p.Show, fake.Name.FullName())
            .RuleFor(p => p.Season, fake.Random.Number().ToString())
            .RuleFor(p => p.Episode, fake.Random.Number().ToString());

        var Movie = new Faker<Movie>()
            .RuleFor(p => p.Name, fake.Name.FullName())
            .RuleFor(p => p.Release_Year, fake.Date.Past().ToString());

        var user = new Faker<Appearance>()
            .RuleFor(p => p.TV, TV)
            .RuleFor(p => p.Movie, Movie)
            .RuleFor(p => p.Appeared, fake.Random.Bool());

        var temp = JsonConvert.SerializeObject(user.Generate(), Formatting.Indented);
        return temp;
    }
}

public class Appearance
{
    public TV TV { get; set; }
    public Movie Movie { get; set; }
    public bool Appeared { get; set; }
}

public class TV
{
    public string Show { get; set; }
    public string Season { get; set; }
    public string Episode { get; set; }
}

public class Movie
{
    public string Name { get; set; }
    public string Release_Year { get; set; }
}