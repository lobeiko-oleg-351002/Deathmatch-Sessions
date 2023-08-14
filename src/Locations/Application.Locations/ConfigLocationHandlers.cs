using Microsoft.Extensions.DependencyInjection;

namespace Application.Locations;
public static class ConfigLocationHandlers
{
    public static IServiceCollection RegisterLocationHandlers(
        this IServiceCollection services)
    {
        return services
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ConfigLocationHandlers).Assembly);
            });
    }
}
