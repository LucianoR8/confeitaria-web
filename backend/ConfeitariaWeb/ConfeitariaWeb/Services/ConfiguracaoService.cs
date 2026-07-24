using AutoMapper;
using ConfeitariaWeb.DTOs.Configuracao;
using ConfeitariaWeb.Repositories.Interfaces;
using ConfeitariaWeb.Services.Interface;
using System.Net.Mail;

namespace ConfeitariaWeb.Services
{
    public class ConfiguracaoService : IConfiguracaoService
    {
        private readonly IConfiguracaoRepository _configuracaoRepository;
        private readonly IMapper _mapper;

        public ConfiguracaoService(IConfiguracaoRepository configuracaoRepository, IMapper mapper)
        {
            _configuracaoRepository = configuracaoRepository;
            _mapper = mapper;
        }

        public async Task<ConfiguracaoResponseDto?> ObterAsync()
        {
            var configuracao = await _configuracaoRepository.ObterAsync();

            if(configuracao == null)
            {
                return null;
            }

            return _mapper.Map<ConfiguracaoResponseDto>(configuracao);
        }

        public async Task<ConfiguracaoResponseDto> AtualizarAsync(ConfiguracaoUpdateDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            var configuracao = await _configuracaoRepository.ObterAsync();

            if(configuracao == null)
            {
                throw new KeyNotFoundException("Configuração não encontrada.");
            }

            var nomeLoja = ValidarNomeLoja(dto.NomeLoja);
            var telefone = ValidarTelefone(dto.Telefone);
            var whatsapp = ValidarWhatsApp(dto.WhatsApp);
            var email = ValidarEmail(dto.Email);
            var endereco = ValidarEndereco(dto.Endereco);
            var logoUrl = ValidarUrl(dto.LogoUrl);
            var iconeUrl = ValidarUrl(dto.IconeUrl);
            var bannerUrl = ValidarUrl(dto.BannerUrl);
            var quantidade = ValidarQuantidadeDestaques(dto.QuantidadeMaximaDestaques);

            ValidarHorario(dto.AbreAs, dto.FechaAs);

            _mapper.Map(dto, configuracao);

            configuracao.NomeLoja = nomeLoja;
            configuracao.Telefone = telefone;
            configuracao.WhatsApp = whatsapp;
            configuracao.Email = email;
            configuracao.Endereco = endereco;
            configuracao.LogoUrl = logoUrl;
            configuracao.IconeUrl = iconeUrl;
            configuracao.BannerUrl = bannerUrl;
            configuracao.QuantidadeMaximaDestaques = quantidade;
            configuracao.AtualizadoEm = DateTime.UtcNow;

            _configuracaoRepository.Atualizar(configuracao);
            await _configuracaoRepository.SalvarAlteracoesAsync();

            return _mapper.Map<ConfiguracaoResponseDto>(configuracao);

        }

        private string ValidarNomeLoja(string nomeLoja)
        {
            if (string.IsNullOrWhiteSpace(nomeLoja))
            {
                throw new ArgumentException("O nome da loja é obrigatório.");
            }

            nomeLoja = nomeLoja.Trim();

            if (nomeLoja.Length > 100 || nomeLoja.Length < 5)
            {
                throw new ArgumentException("O nome da loja deve possuir entre 5 e 100 caracteres.");
            }

            return nomeLoja;
        }

        private string ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                throw new ArgumentException("O telefone da loja é obrigatório.");
            }

            telefone = telefone.Trim();

            if (telefone.Length > 20)
            {
                throw new ArgumentException("O telefone deve possuir menos de 20 caracteres.");
            }

            return telefone;
        }

        private string ValidarWhatsApp(string whatsapp)
        {
            return ValidarTelefone(whatsapp);
        }
        private string? ValidarEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            email = email.Trim();

            if (email.Length > 100)
            {
                throw new ArgumentException("O endereço de email não deve possuir mais que 100 caracteres.");
            }

            if(MailAddress.TryCreate(email, out MailAddress resultado))
            {
                return resultado.Address;
            }
            else
            {
                throw new ArgumentException("O endereço de email digitado é inválido.");
            }
        }

        private string ValidarEndereco(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
            {
                throw new ArgumentException("O endereco da loja é obrigatório.");
            }

            endereco = endereco.Trim();

            if (endereco.Length > 200 || endereco.Length < 5)
            {
                throw new ArgumentException("O endereço da loja deve possuir entre 5 e 200 caracteres.");
            }

            return endereco;
        }

        private string? ValidarUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            url = url.Trim();

            if (url.Length > 500)
            {
                throw new ArgumentException("A url da imagem deve possuir menos que 500 caracteres.");
            }

            bool urlValida = Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult);

            if (!urlValida || (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("A URL da imagem é inválida.");
            }

            return url;
        }

        private short ValidarQuantidadeDestaques(short quantidade)
        {
            if(quantidade > 9 || quantidade < 1)
            {
                throw new ArgumentException("A quantidade de destaques deve ser entre 1 e 9 produtos.");
            }

            return quantidade;
        }

        private void ValidarHorario(TimeOnly abreAs, TimeOnly fechaAs)
        {
            if(abreAs >= fechaAs)
            {
                throw new ArgumentException("O horário de abertura deve ser anterior ao de fechamento.");
            }
        }

    }
}