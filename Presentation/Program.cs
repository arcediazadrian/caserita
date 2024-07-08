using Business;
using Caserita_Data;
using Caserita_Domain.Interfaces;
using Data;
using Domain.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<CaseritaDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("CaseritaDb")));

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IUserData, UserData>();
        services.AddSingleton<IUserRepo, UserRepo>();
    })
    .Build();

host.Run();
