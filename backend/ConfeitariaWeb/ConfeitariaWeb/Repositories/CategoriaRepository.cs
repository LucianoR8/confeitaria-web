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

        public async Task<Categoria?> ObterPorIdAsync(int id)
        {
            return await _context.Categorias
                .FirstOrDefaultAsync(c => c.IdCategoria == id);
        }

        public async Task<bool> ExistePorNomeAsync(string nome)
        {
            return await _context.Categorias
                .AnyAsync(c => c.NomeCategoria == nome);
        }

        public async Task<bool> PossuiProdutosAsync(int categoriaId)
        {
            return await _context.Produtos
                .AnyAsync(p => p.CategoriaId == categoriaId);
        }

        public async Task AdicionarAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
             _context.Categorias.Update(categoria);
        }

        public void Remover(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}