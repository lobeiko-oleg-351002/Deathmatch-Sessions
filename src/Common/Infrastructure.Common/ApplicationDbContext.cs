using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Location> Locations { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<PlayerProfileInSession> ProfilesInSession { get; set; }
    public DbSet<PlayerProfile> PlayerProfiles { get; set; }
}
