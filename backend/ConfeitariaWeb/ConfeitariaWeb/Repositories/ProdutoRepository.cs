using ConfeitariaWeb.Repositories.Interface;
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using ConfeitariaWeb.Data;

namespace ConfeitariaWeb.Repositories
{
    public class ProdutoRepository  : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos.Include(p => p.Categoria).OrderBy(p => p.NomeProduto).ToListAsync();
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            return await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.IdProduto == id);
        }

        public async Task<List<Produto>> ObterPorCategoriaAsync(int categoriaId)
        {
            return await _context.Produtos.Include(p => p.Categoria).Where(p => p.CategoriaId == categoriaId).OrderBy(p => p.NomeProduto).ToListAsync();
        }

        public async Task<List<Produto>> ObterDestaquesAsync()
        {
            return await _context.Produtos.Include(p => p.Categoria).Where(p => p.Destaque).OrderBy(p => p.NomeProduto).ToListAsync();
        }

        public async Task<bool> ExistePorNomeAsync(string nome, int? ignorarId = null)
        {
            return await _context.Produtos
                .AnyAsync(p => p.NomeProduto == nome.ToUpper() && (!ignorarId.HasValue || p.IdProduto != ignorarId.Value));
        }

        public async Task<bool> CategoriaExisteAsync(int categoriaId)
        {
            return await _context.Categorias
                .AnyAsync(c => c.IdCategoria == categoriaId);
        }

        public async Task<int> ObterQuantidadeDestaquesAsync()
        {
            return await _context.Produtos.CountAsync(p => p.Destaque);
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Remover(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}