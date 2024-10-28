using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfarces.Authentication;
using BuberDinner.Application.Common.Interfarces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
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
            issuer: _jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(60),
            claims: claim,
            signingCredentials: signingCredentials
         );
         
         return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}