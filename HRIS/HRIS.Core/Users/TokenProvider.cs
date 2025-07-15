using System.Security.Claims;
using System.Text;
using HRIS.Core.Users.Contracts;
using HRIS.Infrastructure.Databases.Entities;
using HRIS.Shared.Models.Users;
using HRIS.Shared.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace HRIS.Core.Users;

public sealed class TokenProvider(JwtSetting jwtSetting, ILogger<TokenProvider> logger) : ITokenProvider
{
    public UserTokenDto Create(User user)
    {
        try
        {
            // Get token expiration
            var expires = DateTime.UtcNow.AddMinutes(jwtSetting.ExpirationInMinutes);
        
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Secret));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Type.ToString()),
                ]),
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = jwtSetting.Issuer,
                Audience = jwtSetting.Audience,
            };

            var handler = new JsonWebTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);

            return new UserTokenDto(token, expires);
        }
        catch (Exception ex)
        {
            logger.LogError($"Error occurred while creating authentication token for user. {ex.Message}");
            throw;
        }
    }
}