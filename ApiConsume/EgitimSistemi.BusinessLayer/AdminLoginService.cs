using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EgitimSistemi.DataAccessLayer.Repositories;
using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EgitimSistemi.BusinessLayer
{
    public class AdminLoginService
    {
        private readonly AdminLoginRepository _adminLoginRepository;
        private readonly IConfiguration _configuration;

        public AdminLoginService(AdminLoginRepository adminLoginRepository, IConfiguration configuration)
        {
            _adminLoginRepository = adminLoginRepository;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(string email, string password, string userType)
        {
            var admin = await _adminLoginRepository.GetOgrenciByEmailAndPassword(email, password);
            if (admin == null)
                return null;

            var token = GenerateJwtToken(admin, userType);
            return token;
        }

        private string GenerateJwtToken(Admin admin, string userType)
        {
            var jwtSettings = _configuration.GetSection($"Jwt:{userType}");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, admin.AdminID.ToString()),
                new Claim(ClaimTypes.Email, admin.Mail)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwtSettings["Issuer"],
                jwtSettings["Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }
    }
}
