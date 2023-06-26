using Business.IService;
using Business.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class BusinessDI
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddScoped<ICharacterCount, CharacterCount>();

        return services;
    }
}
