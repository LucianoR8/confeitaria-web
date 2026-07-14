using ConfeitariaWeb.Data;
using ConfeitariaWeb.Repositories.Interface;
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfeitariaWeb.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> ObterTodasAsync()
        {
            return await _context.Categorias
                .OrderBy(c => c.NomeCategoria)
                .ToListAsync();
        }
    }
}