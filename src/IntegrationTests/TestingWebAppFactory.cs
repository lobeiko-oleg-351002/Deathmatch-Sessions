using Infrastructure.Common;
using IntegrationTests.Data;
using IntegrationTests.Data.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;
public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<ApplicationDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);
            services.AddScoped<ILocationSeeder, LocationSeeder>();
            services.AddScoped<ISessionSeeder, SessionSeeder>();
            services.AddScoped<IPlayerProfileSeeder, PlayerProfileSeeder>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryUserTest");
            });
            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                appContext.Database.EnsureCreated();
                var locationSeeder = scope.ServiceProvider.GetRequiredService<ILocationSeeder>();
                var sessionSeeder = scope.ServiceProvider.GetRequiredService<ISessionSeeder>();
                var playerProfileSeeder = scope.ServiceProvider.GetRequiredService<IPlayerProfileSeeder>();
                try
                {
                    locationSeeder.Execute();
                    sessionSeeder.Execute();
                    playerProfileSeeder.Execute();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        });
    }
}
