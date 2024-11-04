using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfarces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}