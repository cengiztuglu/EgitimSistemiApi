// AuthService.cs

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EgitimSistemi.DataAccessLayer.Concrete;
using EgitimSistemi.DataAccessLayer.Repositories;
using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EgitimSistemi.BusinessLayer
{
    public class LoginService
    {
        private readonly OgrenciLoginRepository _ogrenciRepository;
        private readonly IConfiguration _configuration;

        public LoginService(OgrenciLoginRepository ogrenciRepository, IConfiguration configuration)
        {
            _ogrenciRepository = ogrenciRepository;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(string email, string sifre)
        {
            var ogrenci = await _ogrenciRepository.GetOgrenciByEmailAndPassword(email, sifre);
            if (ogrenci == null)
                return null;

            var token = GenerateJwtToken(ogrenci);
            return token;
        }

        private string GenerateJwtToken(Ogrenci ogrenci)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, ogrenci.OgrenciID.ToString()),
                new Claim(ClaimTypes.Email, ogrenci.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
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
