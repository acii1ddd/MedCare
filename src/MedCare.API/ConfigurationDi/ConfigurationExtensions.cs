using MedCare.API.Contracts;

namespace MedCare.API.ConfigurationDi;

public static class ConfigurationExtensions
{
    public static IServiceCollection RegisterContractProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(options =>
        {
            options.AddMaps(typeof(GetWorkerResponseProfile).Assembly);
        });
        return services;
    }
}