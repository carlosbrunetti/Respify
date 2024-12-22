using Bogus;
using Tests.helpers.@class;

namespace Tests.helpers.generator;

public class CarGenerator
{
    public List<Car> GenerateCarList(int count)
    {
        var carFaker = new Faker<Car>()
            .RuleFor(c => c.Id, f => f.IndexFaker + 1)
            .RuleFor(c => c.Make, f => f.Vehicle.Manufacturer())
            .RuleFor(c => c.Model, f => f.Vehicle.Model())
            .RuleFor(c => c.Year, f => f.Date.Past(15).Year)
            .RuleFor(c => c.Color, f => f.Commerce.Color());

        return carFaker.Generate(count);
    }
}