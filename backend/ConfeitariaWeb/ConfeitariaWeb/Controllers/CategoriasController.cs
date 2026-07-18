using ConfeitariaWeb.Data;
using ConfeitariaWeb.DTOs.Categoria;
using ConfeitariaWeb.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ConfeitariaWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<ActionResult> Listar()
    {
        var categorias = await _categoriaService.ObterTodasAsync();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> ObterPorId(int id)
    {
        var categoria = await _categoriaService.ObterPorIdAsync(id);

        if(categoria == null)
        {
            return NotFound();
        }

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(CategoriaCreateDto dto)
    {
        var categoriaCriada = await _categoriaService.AdicionarAsync(dto);

        return CreatedAtAction(nameof(ObterPorId), new {id = categoriaCriada.IdCategoria}, categoriaCriada);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, CategoriaUpdateDto dto)
    {
        var categoriaAtualizada = await _categoriaService.AtualizarAsync(id, dto);

        return Ok(categoriaAtualizada);
    }

}