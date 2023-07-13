using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EgitimSistemi.BusinessLayer;
using EgitimSistemi.EntityLayer.Concreate;

namespace EgitimSistemi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(Ogrenci ogrenci)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid login request");

            var token = await _loginService.LoginAsync(ogrenci.Email, ogrenci.Sifre);
            if (token == null)
                return Unauthorized("Invalid login credentials");

            return Ok(new { Token = token });
        }
    }
  
}
