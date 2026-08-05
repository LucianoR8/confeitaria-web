using ConfeitariaWeb.Models;


namespace ConfeitariaWeb.Repositories.Interface
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ObterTodosAsync();

        Task<Produto?> ObterPorIdAsync(int id);

        Task<List<Produto>> ObterPorCategoriaAsync(int categoriaId);

        Task<List<Produto>> ObterDestaquesAsync();

        Task<Produto?> ObterPorSlugAsync(string slug);

        Task<bool> ExistePorNomeAsync(string nome, int? ignorarId = null);

        Task<bool> CategoriaExisteAsync(int categoriaId);

        Task<int> ObterQuantidadeDestaquesAsync(int? ignorarId = null);

        Task AdicionarAsync(Produto produto);

        void Atualizar(Produto produto);

        void Remover(Produto produto);

        Task SalvarAlteracoesAsync();
    }
}