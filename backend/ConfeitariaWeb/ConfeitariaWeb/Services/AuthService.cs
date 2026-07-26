using ConfeitariaWeb.DTOs.Auth;
using ConfeitariaWeb.Models;
using ConfeitariaWeb.Models.Settings;
using ConfeitariaWeb.Repositories.Interfaces;
using ConfeitariaWeb.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;



namespace ConfeitariaWeb.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordService _passwordService;
        private readonly JwtSettings _jwtSettings;
        private readonly AdminSettings _adminSettings;

        public AuthService(IUsuarioRepository usuarioRepository, IPasswordService passwordService, IOptions<JwtSettings> jwtOptions, IOptions<AdminSettings> adminOptions)
        {
            _usuarioRepository = usuarioRepository;
            _passwordService = passwordService;
            _jwtSettings = jwtOptions.Value;
            _adminSettings = adminOptions.Value;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            var usuario = await ValidarUsuarioAsync(dto);

            var token = GerarToken(usuario);

            return new LoginResponseDto
            {
                Token = token,
                Nome = usuario.Nome,
                Role = usuario.Role,
                Expiracao = DateTime.UtcNow.AddHours(_jwtSettings.ExpireHours)

            };
        }

        public async Task CriarAdministradorAsync()
        {
            if(await _usuarioRepository.ExisteUsuarioAsync())
            {
                throw new InvalidOperationException("Já existe um usuário cadastrado.");
            }

            var usuario = new Usuario
            {
                Nome = _adminSettings.Nome,
                Email = _adminSettings.Email,
                SenhaHash = _passwordService.HashPassword(_adminSettings.Senha),
                Role = "Admin",
                Ativo = true,
                CriadoEm = DateTime.UtcNow
            };

            await _usuarioRepository.AdicionarAsync(usuario);
            await _usuarioRepository.SalvarAlteracoesAsync();
        }

        private async Task<Usuario> ValidarUsuarioAsync(LoginRequestDto dto)
        {
            var email = ValidarEmail(dto.Email);
            var senha = ValidarSenha(dto.Senha);

            var usuario = await _usuarioRepository.ObterPorEmailAsync(email);

            if(usuario == null)
            {
                throw new ArgumentException("Email ou senha inválidos.");
            }

            if (!usuario.Ativo) 
            {
                throw new ArgumentException("Usuário desativado.");
            }

            bool senhaCorreta = _passwordService.VerifyPassword(senha, usuario.SenhaHash);

            if (!senhaCorreta)
            {
               throw new ArgumentException("Email ou senha inválidos.");
            }

            return usuario;
        }

        private string ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O email é obrigatório.");
            }

            email = email.Trim();

            if (email.Length > 100)
            {
                throw new ArgumentException("O endereço de email não deve possuir mais que 100 caracteres.");
            }

            if (!MailAddress.TryCreate(email, out MailAddress resultado))
            {
                throw new ArgumentException("O endereço de email digitado é inválido.");
            }

            return resultado.Address;
        }

        private string ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new ArgumentException("A senha é obrigatória.");
            }

            return senha.Trim();
        }

        private string GerarToken(Usuario usuario)
        {
            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_jwtSettings.ExpireHours),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    
    }
}
