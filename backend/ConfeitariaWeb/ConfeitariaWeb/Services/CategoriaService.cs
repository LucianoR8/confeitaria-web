using ConfeitariaWeb.Services.Interface;
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using ConfeitariaWeb.Repositories.Interface;
using ConfeitariaWeb.DTOs;
using ConfeitariaWeb.DTOs.Categoria;

namespace ConfeitariaWeb.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<CategoriaResponseDto>> ObterTodasAsync()
        {
            var categorias = await _categoriaRepository.ObterTodasAsync();

            return categorias
                .Select(categoria => new CategoriaResponseDto
                {
                    IdCategoria = categoria.IdCategoria,
                    NomeCategoria = categoria.NomeCategoria
                })
                .ToList();
        }

        public async Task<CategoriaResponseDto> AdicionarAsync(CategoriaCreateDto dto)
        {
          
            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var nomeCategoria = ValidarNomeCategoriaAsync(dto.NomeCategoria);

            var categoria = new Categoria
            {
                NomeCategoria = dto.NomeCategoria
            };

            await _categoriaRepository.AdicionarAsync(categoria);
            await _categoriaRepository.SalvarAlteracoesAsync();

            return new CategoriaResponseDto
            {
                IdCategoria = categoria.IdCategoria,
                NomeCategoria = categoria.NomeCategoria
            };
        }

        
        public async Task<CategoriaResponseDto?> ObterPorIdAsync(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if(categoria == null)
            {
                return null;
            }

            return new CategoriaResponseDto
            {
                IdCategoria = categoria.IdCategoria,
                NomeCategoria = categoria.NomeCategoria
            };
        }

        
        public async Task<CategoriaResponseDto> AtualizarAsync(int id, CategoriaUpdateDto dto)
        {
            if(dto == null) 
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if(categoria == null)
            {
                throw new KeyNotFoundException("categoria não encontrada.");
            }

            var nomeCategoria = await ValidarNomeCategoriaAsync(dto.NomeCategoria, id);

            categoria.NomeCategoria = nomeCategoria;
            categoria.AtualizadoEm = DateTime.UtcNow;

            
            _categoriaRepository.Atualizar(categoria);
            await _categoriaRepository.SalvarAlteracoesAsync();

            return new CategoriaResponseDto
            {
                IdCategoria = categoria.IdCategoria,
                NomeCategoria = categoria.NomeCategoria
            };
        }

        private async Task<string> ValidarNomeCategoriaAsync(string nomeCategoria, int? ignorarId = null)
        {
            if (string.IsNullOrWhiteSpace(nomeCategoria))
            {
                throw new ArgumentException("O nome da categoria é obrigatório.");
            }

            nomeCategoria = nomeCategoria.Trim();

            if (nomeCategoria.Length > 100)
            {
                throw new ArgumentException("O nome da categoria deve possuir menos de 100 caracteres.");
            }

            if (await _categoriaRepository.ExistePorNomeAsync(nomeCategoria, ignorarId))
            {
                throw new ArgumentException("O nome dessa categoria já existe.", nameof(nomeCategoria));
            }

            return nomeCategoria;
        }

        /*
        public Task RemoverAsync(int id)
        {

        }
        */


    }
}