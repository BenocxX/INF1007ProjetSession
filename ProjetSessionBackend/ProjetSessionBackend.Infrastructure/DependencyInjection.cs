using Microsoft.Extensions.DependencyInjection;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Infrastructure.Repositories;

namespace ProjetSessionBackend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
        
        return services;
    }
}