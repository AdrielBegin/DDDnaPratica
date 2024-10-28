using BuberDinner.Application.Common.Interfarces.Authentication;
using BuberDinner.Application.Common.Interfarces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
namespace BuberDinner.Infrastructure;


public static class  DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        serviceCollection.AddSingleton<IDateTimeProvider,DateTimeProvider>();
        return serviceCollection;
    }
}