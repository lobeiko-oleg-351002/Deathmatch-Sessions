using Infrastructure.Common;
using IntegrationTests.Data;
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
            services.AddScoped<ISeeder, LocationSeeder>();
            services.AddScoped<ISeeder, SessionSeeder>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryUserTest");
            });
            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
                try
                {
                    if (!appContext.Database.EnsureCreated())
                    {
                        seeder.Execute();
                    }
                    
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        });
    }
}
