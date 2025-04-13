using MedCare.DAL.Interfaces;
using MedCare.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedCare.DAL.ConfigurationDI;

public static class ConfigurationExtensions
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWorkerRepository, WorkerRepository>();
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<ISpecializationRepository, SpecializationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        return services;
    }
}