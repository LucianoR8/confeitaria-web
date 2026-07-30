using ConfeitariaWeb.Data;
using ConfeitariaWeb.DTOs.Categoria;
using ConfeitariaWeb.DTOs.Configuracao;
using ConfeitariaWeb.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace ConfeitariaWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiguracoesController : ControllerBase
    {
        private readonly IConfiguracaoService _configuracaoService;

        public ConfiguracoesController(IConfiguracaoService configuracaoService)
        {
            _configuracaoService = configuracaoService;
        }

        [HttpGet]
        public async Task<ActionResult> Obter()
        {
            var configuracao = await _configuracaoService.ObterAsync();

            if(configuracao == null)
            {
                return NotFound("Configuração não encontrada.");
            }

            return Ok(configuracao);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Atualizar([FromForm] ConfiguracaoUpdateDto dto)
        {
            var configuracaoAtualizada = await _configuracaoService.AtualizarAsync(dto);

            return Ok(configuracaoAtualizada);
        }
    }
}
