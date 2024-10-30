using System.Reflection.Metadata;
using BuberDinner.Application.Common.Interfarces.Authentication;
using BuberDinner.Application.Common.Interfarces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationServices(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;

            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists.");
            }

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            Guid userId = Guid.NewGuid();

            var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

            return new AuthenticationResult(
                user.Id,
                firstName,
                lastName,
                email,
                token
            );
        }

        public AuthenticationResult Login(string email, string password)
        {

            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exists.");
            }

            if (user.Password != password)
            {
                throw new Exception("Invalid password.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResult(
               user.Id,
               user.FirstName,
               user.LastName,
               user.Email,
               token
           );
        }
    }
}