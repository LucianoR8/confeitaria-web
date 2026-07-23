using AutoMapper;
using ConfeitariaWeb.DTOs;
using ConfeitariaWeb.DTOs.Categoria;
using ConfeitariaWeb.Models;
using ConfeitariaWeb.Repositories;
using ConfeitariaWeb.Repositories.Interface;
using ConfeitariaWeb.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConfeitariaWeb.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        private async Task<string> ValidarNomeProdutoAsync(string nomeProduto, int? ignorarId = null)
        {
            if (string.IsNullOrWhiteSpace(nomeProduto))
            {
                throw new ArgumentException("O nome do produto é obrigatório.");
            }

            nomeProduto = nomeProduto.Trim();

            if (nomeProduto.Length > 100)
            {
                throw new ArgumentException("O nome do produto deve possuir menos de 100 caracteres.");
            }

            if (await _produtoRepository.ExistePorNomeAsync(nomeProduto, ignorarId))
            {
                throw new ArgumentException("O nome desse produto já existe.", nameof(nomeProduto));
            }

            return nomeProduto;
        }

        public async Task<ProdutoResponseDto> AdicionarAsync(ProdutoCreateDto dto)
        {

            ArgumentNullException.ThrowIfNull(dto);

            var nomeProduto = await ValidarNomeProdutoAsync(dto.NomeProduto);
            var descricao = ValidarDescricaoProduto(dto.DescricaoProduto);
            var imagem = ValidarImagem(dto.ImagemUrl);
            var preco = ValidarPreco(dto.Preco);
            var prazoEntrega = ValidarPrazoEntrega(dto.PrazoEntrega);

            await ValidarCategoriaAsync(dto.CategoriaId);
            await ValidarQuantidadeDestaquesAsync(dto.Destaque);

            var slug = GerarSlug(nomeProduto);

            var produto = _mapper.Map<Produto>(dto);

            produto.NomeProduto = nomeProduto;
            produto.DescricaoProduto = descricao;
            produto.ImagemUrl = imagem;
            produto.Preco = preco;
            produto.PrazoEntrega = prazoEntrega;
            produto.Slug = slug;
            produto.CriadoEm = DateTime.UtcNow;
            

            await _produtoRepository.AdicionarAsync(produto);
            await _produtoRepository.SalvarAlteracoesAsync();

            return _mapper.Map<ProdutoResponseDto>(produto);
        }

        public async Task<List<ProdutoResponseDto>> ObterTodosAsync()
        {
            var produtos = await _produtoRepository.ObterTodosAsync();

            return _mapper.Map<List<ProdutoResponseDto>>(produtos);
        }

        public async Task<ProdutoResponseDto?> ObterPorIdAsync(int id)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(id);

            if(produto == null)
            {
                return null;
            }

            return _mapper.Map<ProdutoResponseDto>(produto);
        }

        public async Task<List<ProdutoResponseDto>> ObterPorCategoriaAsync(int categoriaId)
        {
            var produto = await _produtoRepository.ObterPorCategoriaAsync(categoriaId);

            return _mapper.Map<List<ProdutoResponseDto>>(produto);
        }

        public async Task<List<ProdutoResponseDto>> ObterDestaquesAsync()
        {
            var produto = await _produtoRepository.ObterDestaquesAsync();

            return _mapper.Map<List<ProdutoResponseDto>>(produto);
        }

        public async Task<ProdutoResponseDto> AtualizarAsync(int id, ProdutoUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var produto = await _produtoRepository.ObterPorIdAsync(id);

            if (produto == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }

            var nomeProduto = await ValidarNomeProdutoAsync(dto.NomeProduto, id);
            var descricao = ValidarDescricaoProduto(dto.DescricaoProduto);
            var imagem = ValidarImagem(dto.ImagemUrl);
            var preco = ValidarPreco(dto.Preco);
            var prazoEntrega = ValidarPrazoEntrega(dto.PrazoEntrega);

            await ValidarCategoriaAsync(dto.CategoriaId);
            await ValidarQuantidadeDestaquesAsync(dto.Destaque, id);

            var slug = GerarSlug(nomeProduto);

            _mapper.Map(dto, produto);

            produto.NomeProduto = nomeProduto;
            produto.DescricaoProduto = descricao;
            produto.ImagemUrl = imagem;
            produto.Preco = preco;
            produto.PrazoEntrega = prazoEntrega;
            produto.Slug = slug;
            produto.AtualizadoEm = DateTime.UtcNow;


            _produtoRepository.Atualizar(produto);
            await _produtoRepository.SalvarAlteracoesAsync();

            return _mapper.Map<ProdutoResponseDto>(produto);
        }

        public async Task RemoverAsync(int id)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(id);

            if (produto == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }

            _produtoRepository.Remover(produto);

            await _produtoRepository.SalvarAlteracoesAsync();
        }

        private string ValidarDescricaoProduto(string descricaoProduto)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(descricaoProduto);

            descricaoProduto = descricaoProduto.Trim();

            if(descricaoProduto.Length > 1000)
            {
                throw new ArgumentException("A descrição deve possuir menos que 1000 caracteres");
            }

            return descricaoProduto;
        }

        private decimal ValidarPreco(decimal preco)
        {
            if(preco <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que zero.");
            }

            return preco;
        }

        private string ValidarImagem(string imagemUrl)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(imagemUrl);

            imagemUrl = imagemUrl.Trim();

            if(imagemUrl.Length > 500)
            {
                throw new ArgumentException("A url da imagem deve possuir menos que 500 caracteres.");
            }

            bool urlValida = Uri.TryCreate(imagemUrl, UriKind.Absolute, out Uri? uriResult);

            if(!urlValida || (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("A URL da imagem é inválida.");
            }

            return imagemUrl;

        }

        private string ValidarPrazoEntrega(string prazoEntrega)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(prazoEntrega);

            prazoEntrega = prazoEntrega.Trim();

            if(prazoEntrega.Length > 30)
            {
                throw new ArgumentException("O prazo para entrega deve possuir menos 30 caracteres.");
            }

            return prazoEntrega;
        }

        private async Task ValidarCategoriaAsync(int categoriaId)
        {
            if(!await _produtoRepository.CategoriaExisteAsync(categoriaId))
            {
                throw new ArgumentException("Essa categoria não existe.");
            }
        }

        private async Task ValidarQuantidadeDestaquesAsync(bool destaque, int? ignorarProdutoId = null)
        {
            if (!destaque)
            {
                return;
            }

            var quantidade = await _produtoRepository.ObterQuantidadeDestaquesAsync();

            if (quantidade >= 9)
            {
                throw new ArgumentException("Você deve possuir no máximo 9 produtos em destaque.");
            }

        }

        private string GerarSlug(string nomeProduto)
        {
            return string.Join("-", nomeProduto.Trim().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}