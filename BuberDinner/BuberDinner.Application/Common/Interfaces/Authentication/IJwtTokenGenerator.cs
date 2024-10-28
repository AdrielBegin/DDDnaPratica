namespace BuberDinner.Application.Common.Interfarces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName);
}