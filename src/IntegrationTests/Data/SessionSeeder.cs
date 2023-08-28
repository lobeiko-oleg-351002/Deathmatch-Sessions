using Domain.Entities;
using Infrastructure.Common;
using IntegrationTests.Data.Interface;

namespace IntegrationTests.Data;
public class SessionSeeder : SeederBase<ApplicationDbContext>, ISessionSeeder
{
    public SessionSeeder(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute()
    {
        var Data = new List<Session>();

        var testLocation = new Location
        {
            Id = new Guid("23d54b8e-2c1f-4e35-49fb-08db94cbee6d"),
            Name = "testLocation",
            LevelFilepath = "levels/testLocation.utm",
            PosterFilepath = "posters/testLocation.png"
        };

        Data.Add(new Session {Id = new Guid("24d54b8e-2c1f-4e35-49fb-08db94cbee6d"), Name = "testSession", MaxPlayerCount = 10, UserHostId = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"), Level = testLocation });

        _dbContext.Sessions.AddRange(Data);
        _dbContext.SaveChanges();
    }
}