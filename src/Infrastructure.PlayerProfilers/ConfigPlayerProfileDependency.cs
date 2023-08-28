using Application.Profiles.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common.Logging;
using Infrastructure.Common.Repository;
using Infrastructure.PlayerProfiles.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.PlayerProfiles;

public static class ConfigPlayerProfileDependency
{
    public static IServiceCollection RegisterPlayerProfileDependencies(
    this IServiceCollection services)
    {
        services.AddScoped<ILogMessageManager<PlayerProfile>, LogMessageManager<PlayerProfile>>();
        services.AddScoped<IPlayerProfileRepository, PlayerProfileRepository>();
        services.AddScoped<IPlayerProfileService, PlayerProfileService>();

        return services;
    }
}
