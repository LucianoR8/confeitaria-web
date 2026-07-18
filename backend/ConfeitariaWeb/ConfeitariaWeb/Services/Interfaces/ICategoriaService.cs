using ConfeitariaWeb.Models;
using ConfeitariaWeb.DTOs;
using ConfeitariaWeb.DTOs.Categoria;

namespace ConfeitariaWeb.Services.Interface
{
    public interface ICategoriaService
    {
        Task<List<CategoriaResponseDto>> ObterTodasAsync();
        Task<CategoriaResponseDto?> ObterPorIdAsync(int id);
        Task<CategoriaResponseDto> AdicionarAsync(CategoriaCreateDto dto);

        Task<CategoriaResponseDto> AtualizarAsync(int id, CategoriaUpdateDto dto);
        // Task RemoverAsync(int id);

    }
}