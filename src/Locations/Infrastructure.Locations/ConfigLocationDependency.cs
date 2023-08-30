using Application.Locations.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common.Logging;
using Infrastructure.Common.Repository;
using Infrastructure.Locations.Mapping;
using Infrastructure.Locations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Locations;

public static class ConfigLocationDependency
{
    public static IServiceCollection RegisterLocationDependencies(
    this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(LocationMapperProfile).Assembly);
        services.AddScoped<ILogMessageManager<Location>, LogMessageManager<Location>>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<ILocationService, LocationService>();

        return services;
    }
}
