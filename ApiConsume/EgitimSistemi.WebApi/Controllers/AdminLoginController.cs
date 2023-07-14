using EgitimSistemi.BusinessLayer;
using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EgitimSistemi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly AdminLoginService _adminLoginService;

        public AdminLoginController(AdminLoginService adminLoginService)
        {
            _adminLoginService = adminLoginService;
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
    }
}
