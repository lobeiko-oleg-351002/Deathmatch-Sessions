using Application.PlayerProfiles.Consumer;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Application.PlayerProfiles;
public static class ConfigPlayerProfileHandlers
{
    public static IServiceCollection RegisterPlayerProfileHandlers(
        this IServiceCollection services)
    {
        services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ConfigPlayerProfileHandlers).Assembly);
            });

        services.AddMassTransit(x =>
        {
            x.AddConsumer<UserCreatedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
