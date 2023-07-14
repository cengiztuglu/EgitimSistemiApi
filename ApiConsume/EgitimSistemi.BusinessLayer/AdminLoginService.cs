using EgitimSistemi.DataAccessLayer.Repositories;
using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<string> LoginAsync(string email, string password)
        {
            // Süper admini kontrol et
            var superAdmin = await _adminLoginRepository.GetSuperAdminByEmailAndPassword(email, password);
            if (superAdmin != null)
            {
                var token = GenerateJwtToken(superAdmin, "SuperAdmin");
                return token;
            }

            // Düzenli admini kontrol et
            var regularAdmin = await _adminLoginRepository.GetRegularAdminByEmailAndPassword(email, password);
            if (regularAdmin != null)
            {
                var token = GenerateJwtToken(regularAdmin, "RegularAdmin");
                return token;
            }

            return null; // Giriş başarısız
        }
       

        private string GenerateJwtToken(Admin admin, string userType)
        {
            var jwtSettings = _configuration.GetSection($"JwtSettings:{userType}");

            if (string.IsNullOrEmpty(jwtSettings["Key"]))
            {
                throw new Exception("JWT key is null or empty.");
            }

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
