using Microsoft.Extensions.DependencyInjection;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Infrastructure.Repositories;

namespace ProjetSessionBackend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        return services;
    }
}