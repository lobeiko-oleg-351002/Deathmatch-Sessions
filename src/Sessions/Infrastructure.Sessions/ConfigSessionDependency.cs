using Application.Sessions.Interfaces;
using Infrastructure.Common.Logging;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Sessions.Services;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Repository;
using Application.Sessions.Messages;

namespace Infrastructure.Sessions;

public static class ConfigSessionDependency
{
    public static IServiceCollection RegisterSessionDependencies(
    this IServiceCollection services)
    {
        services.AddScoped<ILogMessageManager<Session>, LogMessageManager<Session>>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<ISessionService, SessionService>();

        services.AddScoped<ILogMessageManager<PlayerProfile>, LogMessageManager<PlayerProfile>>();
        services.AddScoped<IPlayerProfileRepository, PlayerProfileRepository>();

        services.AddScoped<ILogMessageManager<PlayerProfileInSession>, LogMessageManager<PlayerProfileInSession>>();
        services.AddScoped<IPlayerProfileInSessionRepository, PlayerProfileInSessionRepository>();

        services.AddScoped<IUserExternalService, UserExternalService>();

        services.AddHttpClient();

        return services;
    }
}
