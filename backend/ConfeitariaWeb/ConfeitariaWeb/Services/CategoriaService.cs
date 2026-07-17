using ConfeitariaWeb.Services.Interface;
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using ConfeitariaWeb.Repositories.Interface;

namespace ConfeitariaWeb.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<Categoria>> ObterTodasAsync()
        {
            return await _categoriaRepository.ObterTodasAsync();
        }

        public async Task AdicionarAsync(Categoria categoria)
        {
            if(categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            if (string.IsNullOrWhiteSpace(categoria.NomeCategoria))
            {
                throw new ArgumentException("O nome da categoria é obrigatório.");
            }
            
            categoria.NomeCategoria = categoria.NomeCategoria.Trim();

            if (categoria.NomeCategoria.Length > 20)
            {
                throw new ArgumentException("O nome da categoria deve possuir menos de 100 caracteres.");
            }

            if (await _categoriaRepository.ExistePorNomeAsync(categoria.NomeCategoria))
            { 
                throw new ArgumentException("O nome dessa categoria já existe.", nameof(categoria.NomeCategoria)); 
            }

            await _categoriaRepository.AdicionarAsync(categoria);
            await _categoriaRepository.SalvarAlteracoesAsync();
        }

        /* 
        public Task<Categoria?> ObterPorIdAsync(int id)
        {
            
        }

        public Task AtualizarAsync(int id, Categoria categoria)
        {

        }
        public Task RemoverAsync(int id)
        {

        }
        */
    }
}