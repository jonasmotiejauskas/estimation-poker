using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EstimationPoker.ApiService.Services
{
    public interface IJwtService
    {
        string GenerateToken(string email, int userId, string role);
    }

    public class JwtService : IJwtService
    {
        public readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string email, int userId, string role)
        {
            var key = _configuration["Jwt:Key"];
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha512Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, email),
                new Claim("userId", userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, userId.ToString()),
            };

            var jwt = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

    }
}
