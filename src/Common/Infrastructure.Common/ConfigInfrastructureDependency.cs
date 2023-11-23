using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Infrastructure.Common;
public static class ConfigInfrastructureDependency
{
    public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=sqldb;Database=Deathmatch-Sessions;Persist Security Info=True; User Id=sa; Password=RaynorRaiders44;TrustServerCertificate=True;MultipleActiveResultSets=true; Trusted_Connection=false;"));
        services.AddSingleton(new MongoClient("mongodb://root:example@mongo:27017").GetDatabase("MongoLogDb"));
        return services;
    }
}