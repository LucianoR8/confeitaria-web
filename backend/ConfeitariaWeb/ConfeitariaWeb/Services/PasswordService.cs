using AutoMapper;
using ConfeitariaWeb.DTOs.Auth;
using ConfeitariaWeb.Repositories.Interfaces;
using ConfeitariaWeb.Services.Interfaces;
using ConfeitariaWeb.Models;
using System.Net.Mail;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace ConfeitariaWeb.Services 
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string senha)
            => BCrypt.Net.BCrypt.HashPassword(senha);

        public bool VerifyPassword(string senha, string senhaHash)
            => BCrypt.Net.BCrypt.Verify(senha, senhaHash);

    }
}
