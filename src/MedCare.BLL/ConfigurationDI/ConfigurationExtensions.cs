using MedCare.BLL.Interfaces;
using MedCare.BLL.Interfaces.Auth;
using MedCare.BLL.Mappers;
using MedCare.BLL.Mappers.Users;
using MedCare.BLL.Services;
using MedCare.BLL.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace MedCare.BLL.ConfigurationDI;

public static class ConfigurationExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IWorkerService, WorkerService>();
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<ISpecializationService, SpecializationService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        // services.AddScoped<IServiceService, ServiceService>();
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