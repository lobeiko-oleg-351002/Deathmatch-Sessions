using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;
public static class ConfigInfrastructureDependency
{
    public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=sqldb;Database=Deathmatch-Sessions;Persist Security Info=True; User Id=sa; Password=RaynorRaiders44;TrustServerCertificate=True;MultipleActiveResultSets=true; Trusted_Connection=false;"));

        return services;
    }
}