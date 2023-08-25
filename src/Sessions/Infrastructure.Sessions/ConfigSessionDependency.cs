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

        services.AddScoped<ILogMessageManager<UserInSession>, LogMessageManager<UserInSession>>();
        services.AddScoped<IUserInSessionRepository, UserInSessionRepository>();
        services.AddScoped<IUserExternalService, UserExternalService>();

        services.AddScoped<IMessageProducer, RabbitMQProducer>();

        services.AddHttpClient();

        return services;
    }
}
