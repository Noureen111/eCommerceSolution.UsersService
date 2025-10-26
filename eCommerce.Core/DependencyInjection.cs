using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add Core services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // ToDo: Add services to the IoC container
        //Core services often include data access, caching and other low level-level components 

        services.AddTransient<IUserService, UserService>();

        //All the Validators from the assembly containing SampleValidator will automatically registered here
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}
