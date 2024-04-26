using Microsoft.Extensions.DependencyInjection;

namespace ProjetSessionBackend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        return services;
    }
}