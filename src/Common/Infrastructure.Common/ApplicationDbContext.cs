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
    public DbSet<UserInSession> UsersInSession { get; set; }
}
