using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TekhnelogosOkr.Business.Abstract;

namespace TekhnelogosOkr.Business.Concrete
{
    public class JwtHelper : ITokenService
    {
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration["JWTAuth:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWTAuth:ValidIssuerURL"],
                audience: _configuration["JWTAuth:ValidAudienceURL"],
                expires: DateTime.Now.AddDays(int.Parse(_configuration["JWTAuth:Expire"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey,
                SecurityAlgorithms.HmacSha256)
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}