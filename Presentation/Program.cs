using Caserita_Business.Services;
using Caserita_Data;
using Caserita_Data.Repos;
using Caserita_Domain.Interfaces;
using Caserita_Presentation.MappingProfiles;
using Caserita_Presentation.Middlewares;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(workerApplication =>
    {
        workerApplication.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddDbContext<CaseritaDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("CaseritaDb")));

        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IUserRepo, UserRepo>();
        services.AddSingleton<ISettingService, SettingService>();
        services.AddSingleton<ISettingRepo, SettingRepo>();

        services.AddAutoMapper(typeof(CaseritaMappingProfile));
    })
.Build();

using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<CaseritaDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

host.Run();
