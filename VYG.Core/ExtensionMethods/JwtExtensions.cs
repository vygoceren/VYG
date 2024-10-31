using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VYG.Core.ExtensionMethods
{
    public static class JwtExtensions
    {
        public static string GetClaimValue(this JwtSecurityToken token, string claimType)
        {
            var claim = token.Claims.FirstOrDefault(c => c.Type == claimType);
            return claim?.Value;
        }

        public static string GenerateJwtToken(this JwtSecurityTokenHandler tokenHandler,
                                           string secretKey,
                                           string issuer,
                                           string audience,
                                           Claim[] claims,
                                           int expirationMinutes = 30)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(expirationMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = creds
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public static ClaimsPrincipal ValidateJwtToken(this JwtSecurityTokenHandler tokenHandler,
                                                  string token,
                                                  string secretKey,
                                                  string issuer,
                                                  string audience)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = issuer,
                ValidAudience = audience
            };

            return tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
        }
    }
}
