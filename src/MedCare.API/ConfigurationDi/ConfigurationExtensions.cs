using FluentValidation;
using FluentValidation.AspNetCore;
using MedCare.API.Contracts.Responses;
using MedCare.API.Controllers;
using MedCare.API.Validators;

namespace MedCare.API.ConfigurationDi;

public static class ConfigurationExtensions
{
    public static IServiceCollection RegisterContractProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(options =>
        {
            options.AddMaps(typeof(GetWorkerResponseProfile).Assembly);
        });

        services.AddValidatorsFromAssemblyContaining<SignInRequestValidator>();
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        return services;
    }
}