using ConfeitariaWeb.Models;

namespace ConfeitariaWeb.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObterPorEmailAsync(string email);
        Task<bool> ExisteUsuarioAsync();
        Task AdicionarAsync(Usuario usuario);
        Task SalvarAlteracoesAsync();
    }
}
