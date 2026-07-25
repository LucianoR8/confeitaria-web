using ConfeitariaWeb.Data;
using ConfeitariaWeb.Repositories.Interfaces;
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfeitariaWeb.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u =>u.Email == email);
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
           await _context.Usuarios.AddAsync(usuario);
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _context.Usuarios.SaveChangesAsync();
        }
    }
}
