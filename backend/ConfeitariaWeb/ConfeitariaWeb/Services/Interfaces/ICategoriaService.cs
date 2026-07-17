using ConfeitariaWeb.Models;

namespace ConfeitariaWeb.Services.Interface
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> ObterTodasAsync();
        //Task<Categoria?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Categoria categoria);
        // Task AtualizarAsync(int id, Categoria categoria);
        // Task RemoverAsync(int id);

    }
}