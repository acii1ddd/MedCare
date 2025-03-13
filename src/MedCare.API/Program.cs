using MedCare.API.ConfigurationDi;
using MedCare.BLL.ConfigurationDI;
using MedCare.DAL;
using MedCare.DAL.ConfigurationDI;
using MedCare.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace MedCare.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();
        
        // Authentication
        
        // Add services to the container.
        builder.Services.AddAuthentication();
        
        
        
        // Authorization
        builder.Services.AddAuthorization();
        

        
        // custom
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"),
                optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
            });
        });

        builder.Services
            .RegisterRepositories()
            .RegisterServices()
            .RegisterProfiles()
            .RegisterContractProfiles();

        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // first
        app.UseAuthentication();
        // second
        app.UseAuthorization();

        app.MapControllers();
        
        using (var serviceScope = app.Services.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await DbInitializer.Initialize(context);
        }
        
        var logger = app.Services.GetRequiredService<ILogger<Program>>();   
        
        try
        {
            await app.RunAsync();
        }
        catch (Exception e)
        {
            logger.LogError("Произошла ошибка при работе приложения {error}", e);
            Environment.Exit(-1);
        }
    }
}