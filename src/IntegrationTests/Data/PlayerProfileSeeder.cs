using Domain.Entities;
using Infrastructure.Common;
using IntegrationTests.Data.Interface;

namespace IntegrationTests.Data;
public class PlayerProfileSeeder : SeederBase<ApplicationDbContext>, IPlayerProfileSeeder
{
    public PlayerProfileSeeder(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute()
    {
        var Data = new List<PlayerProfile>();

        var testPlayerProfile = new PlayerProfile
        {
            Id = new Guid("13d54b8e-2c1f-4e35-49fb-08db94cbee6d"),
            Name = "testPlayerProfile",
            UserId = new Guid()
        };

        Data.Add(testPlayerProfile);

        _dbContext.PlayerProfiles.AddRange(Data);
        _dbContext.SaveChanges();
    }
}