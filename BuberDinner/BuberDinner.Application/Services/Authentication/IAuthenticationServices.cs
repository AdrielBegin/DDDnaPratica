
namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationServices
    {
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
        AuthenticationResult Login(string email, string password);
    }
}