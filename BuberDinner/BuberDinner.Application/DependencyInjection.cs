using BuberDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;


public static class  DependencyInjection
{
    public static IServiceCollection AddApplication (this IServiceCollection serviceCollection)
    {
         serviceCollection.AddScoped<IAuthenticationServices, AuthenticationServices>();

        return serviceCollection;
    }
}