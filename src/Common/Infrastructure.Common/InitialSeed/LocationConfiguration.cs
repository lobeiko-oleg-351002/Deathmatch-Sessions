using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Common.InitialSeed;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasData
        (
            new Location
            {
                Id = Guid.NewGuid(),
                Name = "Warsong",
                LevelFilepath = "levels/warsong.utm",
                PosterFilepath = "posters/ws.png"
            },
            new Location
            {
                Id = Guid.NewGuid(),
                Name = "Storm 4885",
                LevelFilepath = "levels/storm.utm",
                PosterFilepath = "posters/storm.png"
            }
        );
    }
}
