using Microsoft.IdentityModel.Tokens;
using RestWithASPNETUdemy.Configurations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private TokenConfiguration _configuration;

        public TokenService(TokenConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_configuration.Minutes),
                signingCredentials: signingCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetPricipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
