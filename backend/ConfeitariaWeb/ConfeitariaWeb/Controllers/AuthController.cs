using ConfeitariaWeb.Data;
using ConfeitariaWeb.DTOs.Auth;
using ConfeitariaWeb.DTOs.Configuracao;
using ConfeitariaWeb.Services.Interface;
using ConfeitariaWeb.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ConfeitariaWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto dto)
        {
            var resultado = await _authService.LoginAsync(dto);

            return Ok(resultado);
        }

        [HttpPost("criar-admin")]
        public async Task<ActionResult> CriarAdministradorAsync()
        {
            await _authService.CriarAdministradorAsync();

            return Ok("Administrador criado com sucesso.");
        }
    }
}
