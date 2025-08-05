using eCommerce.Users.Core.ServiceContracts;
using eCommerce.Users.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Users.Core;

/// <summary>
/// Extension method to add core services to the dependency injection container
/// </summary>
/// <param name="services"></param>
/// <returns></returns>
public static class CoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        
        return services;
    }
}