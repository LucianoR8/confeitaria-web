using AutoMapper;
using ConfeitariaWeb.DTOs.Auth;
using ConfeitariaWeb.Repositories.Interfaces;
using ConfeitariaWeb.Services.Interfaces;
using ConfeitariaWeb.Models;
using System.Net.Mail;
using System.Diagnostics;

namespace ConfeitariaWeb.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
        {
            throw new NotImplementedException();
        }

        private async Task<Usuario> ValidarUsuarioAsync(LoginRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

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

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);

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
    }
}
