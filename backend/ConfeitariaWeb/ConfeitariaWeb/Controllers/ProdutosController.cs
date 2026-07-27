using ConfeitariaWeb.Data;
using ConfeitariaWeb.DTOs;
using ConfeitariaWeb.DTOs.Categoria;
using ConfeitariaWeb.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConfeitariaWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoResponseDto>>> ObterTodos()
        {
            var produtos = await _produtoService.ObterTodosAsync();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoResponseDto>> ObterPorId(int id) 
        {
            var produto = await _produtoService.ObterPorIdAsync(id);

            if(produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpGet("categoria/{categoriaId}")]
        public async Task<ActionResult<List<ProdutoResponseDto>>> ObterPorCategoria(int categoriaId)
        {
            var produtos = await _produtoService.ObterPorCategoriaAsync(categoriaId);

            return Ok(produtos);
        }

        [HttpGet("destaques")]
        public async Task<ActionResult<List<ProdutoResponseDto>>> ObterDestaques()
        {
            var produtos = await _produtoService.ObterDestaquesAsync();

            return Ok(produtos);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProdutoResponseDto>> Adicionar(ProdutoCreateDto dto)
        {
            var produto = await _produtoService.AdicionarAsync(dto);

            return CreatedAtAction(nameof(ObterPorId), new { id = produto.IdProduto }, produto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProdutoResponseDto>> Atualizar(int id, ProdutoUpdateDto dto)
        {
            var produto = await _produtoService.AtualizarAsync(id, dto);

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Remover(int id)
        {
            await _produtoService.RemoverAsync(id);

            return NoContent();
        }
    }
}
