using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MedCare.API.ConfigurationDi;
using MedCare.API.Extensions;
using MedCare.API.Middleware;
using MedCare.BLL.ConfigurationDI;
using MedCare.BLL.Models.Auth;
using MedCare.DAL;
using MedCare.DAL.ConfigurationDI;
using MedCare.DAL.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            .RegisterContractProfiles()
            .AddSwagger();
        
        var authSection = builder.Configuration.GetSection("AuthSettings");
        if (!authSection.Exists()) 
        {
            throw new ApplicationException($"Секция {nameof(AuthSettings)} не найдена в конфигурационном файле");
        }
        builder.Services.Configure<AuthSettings>(authSection);
        
        var authSettings = authSection.Get<AuthSettings>()
            ?? throw new ApplicationException("Не удалось сопоставить параметры аутентификации");


        builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = authSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Secret)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        
        builder.Services.AddAuthorization(authOptions =>
        {
            // authOptions.AddPolicy();
        });
        
        const string myCorsPolicy = "MedCareCorsPolicy";
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                name: myCorsPolicy,
                policy =>
            {
                policy.WithOrigins("http://localhost:5173");
            });
        });
        
        var app = builder.Build();

        app.UseMiddleware<ExceptionHandling>();
        
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

        app.UseCors(myCorsPolicy);

        // app.UseStaticFiles(new StaticFileOptions
        // {
        //     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../MedCare.UI/public")),
        //     RequestPath = ""
        // });
        
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