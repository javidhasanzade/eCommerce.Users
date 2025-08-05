using eCommerce.Users.Core.RepositoryContracts;
using eCommerce.Users.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Users.Infrastructure;

/// <summary>
/// Extension method to add infrastructure services to the dependency injection container
/// </summary>
/// <param name="services"></param>
/// <returns></returns>
public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        
        return services;
    }
}