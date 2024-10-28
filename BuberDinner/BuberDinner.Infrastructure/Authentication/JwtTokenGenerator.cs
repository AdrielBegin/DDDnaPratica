using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfarces.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("your-super-secret-longer-key-32-characters-minimum")),
                SecurityAlgorithms.HmacSha256
            );        

        var claim = new [] 
        {
            new Claim (JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim (JwtRegisteredClaimNames.GivenName, firstName),
            new Claim (JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

         var securityToken = new JwtSecurityToken(
            issuer: "BuberDinner",
            expires: DateTime.Now.AddDays(1),
            claims: claim,
            signingCredentials: signingCredentials
         );
         
         return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}