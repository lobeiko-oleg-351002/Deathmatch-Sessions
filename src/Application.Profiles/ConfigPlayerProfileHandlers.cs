using Microsoft.Extensions.DependencyInjection;

namespace Application.Profiles;
public static class ConfigPlayerProfileHandlers
{
    public static IServiceCollection RegisterPlayerProfileHandlers(
        this IServiceCollection services)
    {
        return services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ConfigPlayerProfileHandlers).Assembly);
            });
    }
}
