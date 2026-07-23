using AutoMapper;
using ConfeitariaWeb.Models;
using ConfeitariaWeb.DTOs.Categoria;
using ConfeitariaWeb.DTOs;

namespace ConfeitariaWeb.Mappings
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoResponseDto>().ForMember(dest => dest.NomeCategoria,
        opt => opt.MapFrom(src => src.Categoria.NomeCategoria));
            CreateMap<ProdutoCreateDto, Produto>();
            CreateMap<ProdutoUpdateDto, Produto>();
        }
    }
}
