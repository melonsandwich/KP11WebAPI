using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KP11WebAPI.Auth;

public class TokenService : ITokenService
{
    private TimeSpan ExpireDuration = new(24, 0, 0);
    public string BuildToken(string key, string issuer, UserDto user)
    {
        Claim[] claims =
        {
            new(ClaimTypes.Name, user.Login),
            new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
        };

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(key));
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        JwtSecurityToken tokenDescriptor = new(issuer, issuer, claims, expires: DateTime.Now.Add(ExpireDuration), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}