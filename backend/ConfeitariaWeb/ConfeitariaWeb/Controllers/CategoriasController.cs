using ConfeitariaWeb.Data;
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
}