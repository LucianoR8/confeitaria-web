using ConfeitariaWeb.Repositories;
using ConfeitariaWeb.Models;

namespace ConfeitariaWeb.Repositories.Interface
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ObterTodasAsync();

        Task<Categoria?> ObterPorIdAsync(int id);

        Task<bool> ExistePorNomeAsync(string nome);

        Task<bool> PossuiProdutosAsync(int categoriaId);

        Task AdicionarAsync(Categoria categoria);

        void Atualizar(Categoria categoria);

        void Remover(Categoria categoria);

        Task SalvarAlteracoesAsync();
    }
}