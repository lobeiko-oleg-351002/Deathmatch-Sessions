using Domain.Entities;
using Infrastructure.Common;

namespace IntegrationTests.Data;
public class LocationSeeder : SeederBase<ApplicationDbContext, List<Location>>
{
    public LocationSeeder(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute()
    {
        var Data = new List<Location>();

        var testLocation = new Location
        {
            Id = new Guid("34d54b8e-2c1f-4e35-49fb-08db94cbee6d"),
            Name = "testLocation",
            LevelFilepath = "levels/testLocation.utm",
            PosterFilepath = "posters/testLocation.png"
        };

        Data.Add(testLocation);

        _dbContext.Locations.AddRange(Data);
        _dbContext.SaveChanges();
    }
}