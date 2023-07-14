using EgitimSistemi.BusinessLayer;
using EgitimSistemi.DataAccessLayer.Repositories;
using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EgitimSistemi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly AdminLoginService _adminLoginService;
        private readonly AdminLoginRepository _adminLoginRepository;

        public AdminLoginController(AdminLoginService adminLoginService, AdminLoginRepository adminLoginRepository)
        {
            _adminLoginService = adminLoginService;
            _adminLoginRepository = adminLoginRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid login request");

            var userType = admin.Yetki ? "SuperAdmin" : "RegularAdmin";
            var token = await _adminLoginService.LoginAsync(admin.Mail, admin.Sifre);
            if (token == null)
                return Unauthorized("Invalid login credentials");

            return Ok(new { Token = token });
        }

        [HttpGet("ogrenciler")]
        public async Task<IActionResult> ListeleOgrenciler()
        {
            var ogrenciler = await _adminLoginRepository.ListeleOgrenciler();
            if (ogrenciler == null)
                return Forbid("Bu işlemi gerçekleştirmek için yetkiniz bulunmamaktadır.");

            return Ok(ogrenciler);
        }
    }
}
