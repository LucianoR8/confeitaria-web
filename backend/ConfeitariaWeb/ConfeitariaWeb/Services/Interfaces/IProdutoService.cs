using ConfeitariaWeb.Models;
using ConfeitariaWeb.DTOs;
using ConfeitariaWeb.DTOs.Categoria;

namespace ConfeitariaWeb.Services.Interface
{
    public interface IProdutoService
    {
        Task<List<ProdutoResponseDto>> ObterTodosAsync();

        Task<ProdutoResponseDto?> ObterPorIdAsync(int id);

        Task<List<ProdutoResponseDto>> ObterPorCategoriaAsync(int categoriaId);

        Task<List<ProdutoResponseDto>> ObterDestaquesAsync();

        Task<ProdutoResponseDto> AdicionarAsync(ProdutoCreateDto dto);

        Task<ProdutoResponseDto> AtualizarAsync(int id, ProdutoUpdateDto dto);

        Task RemoverAsync(int id);
    }
}