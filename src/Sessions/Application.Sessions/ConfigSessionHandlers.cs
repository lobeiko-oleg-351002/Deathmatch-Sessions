using Microsoft.Extensions.DependencyInjection;

namespace Application.Sessions;
public static class ConfigSessionHandlers
{
    public static IServiceCollection RegisterSessionHandlers(
        this IServiceCollection services)
    {
        return services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ConfigSessionHandlers).Assembly);
            });
    }
}
