using Microsoft.Extensions.DependencyInjection;

namespace ProjetSessionBackend.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        // Add services to the container.
        // services.AddScoped<IMyService, MyService>();
        
        return services;
    }
}