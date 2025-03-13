using MedCare.BLL.Interfaces;
using MedCare.BLL.Mappers;
using MedCare.BLL.Mappers.Users;
using MedCare.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MedCare.BLL.ConfigurationDI;

public static class ConfigurationExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IWorkerService, WorkerService>();
        return services;
    }

    public static IServiceCollection RegisterProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(options =>
        {
            options.AddMaps(typeof(WorkerProfile).Assembly);
        });
        return services;
    }
}