using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetSessionBackend.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }
}