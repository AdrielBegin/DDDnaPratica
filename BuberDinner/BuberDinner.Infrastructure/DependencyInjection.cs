using BuberDinner.Application.Common.Interfarces.Authentication;
using BuberDinner.Application.Common.Interfarces.Persistence;
using BuberDinner.Application.Common.Interfarces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
namespace BuberDinner.Infrastructure;


public static class  DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, 
    Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        serviceCollection.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        serviceCollection.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        serviceCollection.AddSingleton<IDateTimeProvider,DateTimeProvider>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        
        return serviceCollection;
    }
}