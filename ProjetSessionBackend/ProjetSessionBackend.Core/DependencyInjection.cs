using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetSessionBackend.Core.Interfaces.Services;
using ProjetSessionBackend.Core.Models.Entities;
using ProjetSessionBackend.Core.Services;

namespace ProjetSessionBackend.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IHashService, HashService>();

        return services;
    }
    
    public static IServiceCollection AddApplicationDatabaseContext(this IServiceCollection services, string? connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentNullException(nameof(connectionString));
        
        ApplicationDbContext.ConnectionString = connectionString;
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}