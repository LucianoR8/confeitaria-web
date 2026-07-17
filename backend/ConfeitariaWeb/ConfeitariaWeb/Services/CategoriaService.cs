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
            // Validar nome - categoria = null

            // Remover espaços - trim()

            // Validar novamente

            // Verificar tamanho

            // Verificar duplicidade

            // Adicionar - _repository

            // Salvar - _repository
        }

        public Task<Categoria?> ObterPorIdAsync(int id)
        {
            
        }

        public Task AtualizarAsync(int id, Categoria categoria)
        {

        }
        public Task RemoverAsync(int id)
        {

        }
    }
}