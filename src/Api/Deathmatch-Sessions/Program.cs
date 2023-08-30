using Application.Locations;
using Infrastructure.Locations;
using Infrastructure.Common;
using Application.Sessions;
using Infrastructure.Sessions;
using Application.PlayerProfiles;
using Infrastructure.PlayerProfiles;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddControllers();

services.RegisterInfrastructureDependencies();
services.RegisterLocationDependencies();
services.RegisterLocationHandlers();
services.RegisterSessionDependencies();
services.RegisterSessionHandlers();
services.RegisterPlayerProfileDependencies();
services.RegisterPlayerProfileHandlers();

services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }
