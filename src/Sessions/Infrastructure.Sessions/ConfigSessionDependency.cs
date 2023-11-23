using Application.Sessions.Interfaces;
using Infrastructure.Common.Logging;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Sessions.Services;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Repository;
using Infrastructure.Sessions.Mapping;
using Infrastructure.Common.MongoRepository;

namespace Infrastructure.Sessions;

public static class ConfigSessionDependency
{
    public static IServiceCollection RegisterSessionDependencies(
    this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(SessionMapperProfile).Assembly);
        services.AddAutoMapper(typeof(ProfileInSessionMapperProfile).Assembly);

        services.AddScoped<ILogMessageManager<Session>, LogMessageManager<Session>>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<ILoggerRepository, SessionLogRepository>();

        services.AddScoped<ILogMessageManager<PlayerProfile>, LogMessageManager<PlayerProfile>>();
        services.AddScoped<IPlayerProfileRepository, PlayerProfileRepository>();

        services.AddScoped<ILogMessageManager<PlayerProfileInSession>, LogMessageManager<PlayerProfileInSession>>();
        services.AddScoped<IPlayerProfileInSessionRepository, PlayerProfileInSessionRepository>();

        services.AddScoped<IUserExternalService, UserExternalService>();

        services.AddHttpClient();

        return services;
    }
}
