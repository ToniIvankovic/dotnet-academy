using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Library.ToniIvankovic.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly JWTSettings _settings;
        public TokenGenerator(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;
        }

        public TokenDTO GenerateToken(List<Claim> claims)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_settings.Key);
            var authSigningKey = new SymmetricSecurityKey(keyBytes);

            var jwtToken = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_settings.ValidHours),
                signingCredentials: new SigningCredentials(
                    authSigningKey,
                    SecurityAlgorithms.HmacSha256)
                );
            Console.WriteLine(jwtToken);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return new TokenDTO
            {
                Token = token,
                ExpiresAt = jwtToken.ValidTo,
            };
        }
    }
}
