using EgitimSistemi.DataAccessLayer.Concrete;
using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EgitimSistemi.DataAccessLayer.Repositories
{
    public class AdminLoginRepository
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminLoginRepository(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Admin> GetSuperAdminByEmailAndPassword(string email, string password)
        {
            return await _context.Admins.FirstOrDefaultAsync(o => o.Mail == email && o.Sifre == password && o.Yetki);
        }

        public async Task<Admin> GetRegularAdminByEmailAndPassword(string email, string password)
        {
            return await _context.Admins.FirstOrDefaultAsync(o => o.Mail == email && o.Sifre == password && !o.Yetki);
        }

        public async Task<IEnumerable<Ogrenci>> ListeleOgrenciler()
        {
            var admin = GetLoggedInAdmin();
            if (admin == null)
                return null;

            var ogrenciler = await _context.Ogrencis.ToListAsync();
            return ogrenciler;
        }

        private Admin GetLoggedInAdmin()
        {
            var loggedInUserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(loggedInUserId))
            {
                var admin = _context.Admins.FirstOrDefault(a => a.AdminID == int.Parse(loggedInUserId));
                return admin;
            }

            return null;
        }
    }
}
